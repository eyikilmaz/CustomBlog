using CustomBlog.Api.Application.Interfaces.Repositories;
using CustomBlog.Api.Domain.Models;
using CustomBlog.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomBlog.Infrastructure.Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(CustomBlogContext dbContext) : base(dbContext)
    {
    }
}
