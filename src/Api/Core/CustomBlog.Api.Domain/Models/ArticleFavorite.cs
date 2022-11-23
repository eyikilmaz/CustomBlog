using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomBlog.Api.Domain.Models;

public class ArticleFavorite
{
    public Guid ArticleId { get; set; }
    public Guid CreatedById { get; set; }
    public virtual Article Article { get; set; }
    public virtual User CreatedUser { get; set; }
}
