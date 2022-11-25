using CustomBlog.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomBlog.Infrastructure.Persistence.Context;

public class CustomBlogContext : DbContext
{
    public const string DEFAULT_SCHEMA = "dbo";

	public CustomBlogContext()
	{

	}

	public CustomBlogContext(DbContextOptions options) : base(options)
	{

	}

	DbSet<User> Users { get; set; }
	DbSet<Article> Articles { get; set; }
	DbSet<ArticleFavorite> ArticleFavorites { get; set; }
	DbSet<ArticleComment> ArticleComments { get; set; }
	DbSet<ArticleCommentFavorite> ArticleCommentFavorites { get; set; }
	DbSet<EmailConfirmation> EmailConfirmations { get; set; }
	DbSet<UserReadSaved> UserReadLists { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		if (!optionsBuilder.IsConfigured)
		{
			var connStr = "Data Source=EMRE;Initial Catalog=customblog;Persist Security Info=True; Encrypt=False; User ID=sa; Password=1234";
			optionsBuilder.UseSqlServer(connStr, opt =>
			{
				opt.EnableRetryOnFailure();
			});
        }
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}

    public override int SaveChanges()
    {
        OnBeforeSave();
        return base.SaveChanges();
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        OnBeforeSave();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

	public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
	{
        OnBeforeSave();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
	}

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        OnBeforeSave();
        return base.SaveChangesAsync(cancellationToken);
    }

	private void OnBeforeSave()
	{
		var addedEntites = ChangeTracker.Entries()
										 .Where(i => i.State == EntityState.Added)
										 .Select(i => (BaseEntity)i.Entity);

        PrepareAddedEntities(addedEntites);
    }

    private void PrepareAddedEntities(IEnumerable<BaseEntity> entities)
	{
		foreach (var entity in entities)
		{
			if (entity.CreateDate == DateTime.MinValue)
				entity.CreateDate = DateTime.Now;
		}
	}
}
