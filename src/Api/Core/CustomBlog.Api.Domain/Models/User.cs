using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomBlog.Api.Domain.Models;

public class User : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Description { get; set; }
    public string EmailAddress { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public bool EmailConfirmed { get; set; }

    public virtual ICollection<Article> Articles { get; set; }
    public virtual ICollection<ArticleFavorite> ArticleFavorites { get; set; }
    public virtual ICollection<ArticleComment> ArticleComments { get; set; }
    public virtual ICollection<UserReadList> ArticleReadLists { get; set; }
}
