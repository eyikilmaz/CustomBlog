using AutoMapper;
using CustomBlog.Api.Application.Interfaces.Repositories;
using CustomBlog.Common.Events.User;
using CustomBlog.Common;
using CustomBlog.Common.Exceptions;
using CustomBlog.Common.Infrastructure;
using CustomBlog.Common.Models.RequestModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomBlog.Api.Application.Features.Commands.User.Update;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Guid>
{
    private readonly IMapper mapper;
    private readonly IUserRepository userRepository;

    public UpdateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
    {
        this.mapper = mapper;
        this.userRepository = userRepository;
    }

    public async Task<Guid> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var dbUser = await userRepository.GetByIdAsync(request.Id);

        if (dbUser is null)
            throw new DatabaseValidationException("Kullanıcı bulunamadı.");

        var dbEmailAddress = dbUser.EmailAddress;
        var emailChanged = string.CompareOrdinal(dbEmailAddress, request.EmailAddress) != 0;

        mapper.Map(request, dbUser);

        var rows = await userRepository.UpdateAsync(dbUser);

        if (rows > 0 && emailChanged)
        {
            var @event = new UserEmailChangedEvent()
            {
                OldEmailAddress = dbEmailAddress,
                NewEmailAddress = request.EmailAddress
            };

            QueueFactory.SendMessageToExchange(exchangeName: BlogConstants.UserExchangeName,
                                               exchangeType: BlogConstants.DefaultExchangeType,
                                               queueName: BlogConstants.UserEmailChangedQueueName,
                                               obj: @event);

            dbUser.EmailConfirmed = false;
            await userRepository.UpdateAsync(dbUser);
        }

        return dbUser.Id;
    }
}
