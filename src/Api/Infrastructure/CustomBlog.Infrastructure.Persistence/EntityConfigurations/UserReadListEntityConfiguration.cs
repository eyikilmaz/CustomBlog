using CustomBlog.Api.Domain.Models;
using CustomBlog.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomBlog.Infrastructure.Persistence.EntityConfigurations;

public class UserReadListEntityConfiguration : BaseEntityConfiguration<UserReadSaved>
{
    public override void Configure(EntityTypeBuilder<UserReadSaved> builder)
    {
        base.Configure(builder);

        builder.ToTable("userreadsaved", CustomBlogContext.DEFAULT_SCHEMA);

        builder.HasOne(i => i.Article)
          .WithMany(i => i.UserReadLists)
          .HasForeignKey(i => i.ArticleId);

        builder.HasOne(i => i.CreatedBy)
            .WithMany(i => i.UserReadLists)
            .HasForeignKey(i => i.CreatedById)
             .OnDelete(DeleteBehavior.Restrict);
    }
}
