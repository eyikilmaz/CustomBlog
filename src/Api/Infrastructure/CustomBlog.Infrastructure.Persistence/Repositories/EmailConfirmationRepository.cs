using CustomBlog.Api.Application.Interfaces.Repositories;
using CustomBlog.Api.Domain.Models;
using CustomBlog.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomBlog.Infrastructure.Persistence.Repositories;

public class EmailConfirmationRepository : GenericRepository<EmailConfirmation>, IEmailConfirmationRepository
{
    public EmailConfirmationRepository(CustomBlogContext dbContext) : base(dbContext)
    {
    }
}
