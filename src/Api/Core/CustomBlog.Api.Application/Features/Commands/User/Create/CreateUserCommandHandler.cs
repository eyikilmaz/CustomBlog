using AutoMapper;
using CustomBlog.Api.Application.Interfaces.Repositories;
using CustomBlog.Common;
using CustomBlog.Common.Events.User;
using CustomBlog.Common.Exceptions;
using CustomBlog.Common.Infrastructure;
using CustomBlog.Common.Models.RequestModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomBlog.Api.Application.Features.Commands.User.Create;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IMapper mapper;
    private readonly IUserRepository userRepository;

    public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
    {
        this.mapper = mapper;
        this.userRepository = userRepository;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var existsUser = await userRepository.GetSingleAsync(i => i.EmailAddress == request.EmailAddress);

        if (existsUser is not null)
            throw new DatabaseValidationException("Kullanıcı zaten kayıtlı.");

        var dbUser = mapper.Map<Domain.Models.User>(request);

        var rows = await userRepository.AddAsync(dbUser);

        if (rows > 0)
        {
            var @event = new UserEmailChangedEvent()
            {
                OldEmailAddress = null,
                NewEmailAddress = dbUser.EmailAddress
            };

            QueueFactory.SendMessageToExchange(exchangeName: BlogConstants.UserExchangeName,
                                               exchangeType: BlogConstants.DefaultExchangeType,
                                               queueName: BlogConstants.UserEmailChangedQueueName,
                                               obj: @event);
        }


        return dbUser.Id;
    }
}
