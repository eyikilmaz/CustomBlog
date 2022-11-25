using CustomBlog.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomBlog.Infrastructure.Persistence.EntityConfigurations.Article;

public class ArticleEntityConfiguration : BaseEntityConfiguration<Api.Domain.Models.Article>
{
    public override void Configure(EntityTypeBuilder<Api.Domain.Models.Article> builder)
    {
        base.Configure(builder);

        builder.ToTable("article", CustomBlogContext.DEFAULT_SCHEMA);

        builder.HasOne(i => i.CreatedBy)
            .WithMany(i => i.Articles)
            .HasForeignKey(i => i.CreatedById);
    }
}
