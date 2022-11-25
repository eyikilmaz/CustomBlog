using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomBlog.Api.Domain.Models;

public class Article : BaseEntity
{
    public string Subject { get; set; }
    public string Content { get; set; }
    public Guid CreatedById { get; set; }
    public int ReadDuration { get; set; }
    public virtual User CreatedBy { get; set; }
    public virtual ICollection<ArticleComment> ArticleComments { get; set; }
    public virtual ICollection<ArticleFavorite> ArticleFavorites { get; set; }
}
