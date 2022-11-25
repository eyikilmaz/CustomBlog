using CustomBlog.Api.Domain.Models;
using CustomBlog.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomBlog.Infrastructure.Persistence.EntityConfigurations.ArticleComment;

public class ArticleCommentFavoriteEntityConfiguration : BaseEntityConfiguration<ArticleCommentFavorite>
{
    public override void Configure(EntityTypeBuilder<ArticleCommentFavorite> builder)
    {
        base.Configure(builder);

        builder.ToTable("articlecommentfavorite", CustomBlogContext.DEFAULT_SCHEMA);

        builder.HasOne(i => i.ArticleComment)
            .WithMany(i => i.ArticleCommentFavorites)
            .HasForeignKey(i => i.ArticleCommentId);

        builder.HasOne(i => i.CreatedUser)
            .WithMany(i => i.ArticleCommentFavorites)
            .HasForeignKey(i => i.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
