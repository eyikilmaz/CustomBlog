using CustomBlog.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomBlog.Infrastructure.Persistence.EntityConfigurations.ArticleComment;

public class ArticleCommentEntityConfiguration : BaseEntityConfiguration<Api.Domain.Models.ArticleComment>
{
    public override void Configure(EntityTypeBuilder<Api.Domain.Models.ArticleComment> builder)
    {
        base.Configure(builder);

        builder.ToTable("articlecomment", CustomBlogContext.DEFAULT_SCHEMA);

        builder.HasOne(i => i.Article)
            .WithMany(i => i.ArticleComments)
            .HasForeignKey(i => i.ArticleId);

        builder.HasOne(i => i.CreatedBy)
            .WithMany(i => i.ArticleComments)
            .HasForeignKey(i => i.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
