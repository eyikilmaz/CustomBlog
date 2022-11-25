using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomBlog.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "emailconfirmation",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OldEmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewEmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emailconfirmation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "article",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReadDuration = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_article", x => x.Id);
                    table.ForeignKey(
                        name: "FK_article_user_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "dbo",
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "articlecomment",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articlecomment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_articlecomment_article_ArticleId",
                        column: x => x.ArticleId,
                        principalSchema: "dbo",
                        principalTable: "article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_articlecomment_user_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "dbo",
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "articlefavorite",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articlefavorite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_articlefavorite_article_ArticleId",
                        column: x => x.ArticleId,
                        principalSchema: "dbo",
                        principalTable: "article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_articlefavorite_user_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "dbo",
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "userreadsaved",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userreadsaved", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userreadsaved_article_ArticleId",
                        column: x => x.ArticleId,
                        principalSchema: "dbo",
                        principalTable: "article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userreadsaved_user_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "dbo",
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "articlecommentfavorite",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArticleCommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articlecommentfavorite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_articlecommentfavorite_articlecomment_ArticleCommentId",
                        column: x => x.ArticleCommentId,
                        principalSchema: "dbo",
                        principalTable: "articlecomment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_articlecommentfavorite_user_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "dbo",
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_article_CreatedById",
                schema: "dbo",
                table: "article",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_articlecomment_ArticleId",
                schema: "dbo",
                table: "articlecomment",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_articlecomment_CreatedById",
                schema: "dbo",
                table: "articlecomment",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_articlecommentfavorite_ArticleCommentId",
                schema: "dbo",
                table: "articlecommentfavorite",
                column: "ArticleCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_articlecommentfavorite_CreatedById",
                schema: "dbo",
                table: "articlecommentfavorite",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_articlefavorite_ArticleId",
                schema: "dbo",
                table: "articlefavorite",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_articlefavorite_CreatedById",
                schema: "dbo",
                table: "articlefavorite",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_userreadsaved_ArticleId",
                schema: "dbo",
                table: "userreadsaved",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_userreadsaved_CreatedById",
                schema: "dbo",
                table: "userreadsaved",
                column: "CreatedById");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articlecommentfavorite",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "articlefavorite",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "emailconfirmation",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "userreadsaved",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "articlecomment",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "article",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "user",
                schema: "dbo");
        }
    }
}
