using CustomBlog.Api.Domain.Models;
using CustomBlog.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomBlog.Infrastructure.Persistence.EntityConfigurations.Article;

public class ArticleFavoriteEntityConfiguration : BaseEntityConfiguration<ArticleFavorite>
{
    public override void Configure(EntityTypeBuilder<ArticleFavorite> builder)
    {
        base.Configure(builder);

        builder.ToTable("articlefavorite", CustomBlogContext.DEFAULT_SCHEMA);

        builder.HasOne(i => i.Article)
            .WithMany(i => i.ArticleFavorites)
            .HasForeignKey(i => i.ArticleId);

        builder.HasOne(i => i.CreatedUser)
            .WithMany(i => i.ArticleFavorites)
            .HasForeignKey(i => i.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
