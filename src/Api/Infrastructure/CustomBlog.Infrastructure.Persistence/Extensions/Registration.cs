using CustomBlog.Api.Application.Interfaces.Repositories;
using CustomBlog.Api.Domain.Models;
using CustomBlog.Infrastructure.Persistence.Context;
using CustomBlog.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomBlog.Infrastructure.Persistence.Extensions;

public static class Registration
{
    public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CustomBlogContext>(conf =>
        {
            var connStr = configuration[""].ToString();
            conf.UseSqlServer(connStr, opt =>
            {
                opt.EnableRetryOnFailure();
            });
        });

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IArticleRepository, ArticleRepository>();
        services.AddScoped<IArticleCommentRepository, ArticleCommentRepository>();
        services.AddScoped<IUserReadSavedRepository, UserReadSavedRepository>();

        return services;
    }
}
