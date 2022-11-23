﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomBlog.Api.Domain.Models;

public class ArticleComment
{
    public string Content { get; set; }
    public Guid CreatedById { get; set; }
    public Guid ArticleId { get; set; }
    public virtual Article Article { get; set; }
    public virtual User CreatedBy { get; set; }
    public virtual ICollection<ArticleCommentFavorite> ArticleCommentFavorite { get; set; }
}
