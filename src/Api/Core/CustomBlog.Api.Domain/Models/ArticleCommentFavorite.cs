using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomBlog.Api.Domain.Models;

public class ArticleCommentFavorite : BaseEntity
{
    public Guid ArticleCommentId { get; set; }
    public Guid CreatedById { get; set; }
    public virtual ArticleComment ArticleComment { get; set; }
    public virtual User CreatedUser { get; set; }
}
