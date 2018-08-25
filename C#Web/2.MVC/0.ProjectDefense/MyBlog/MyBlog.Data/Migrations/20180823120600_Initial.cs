using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlog.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategories", x => x.Id);
                    table.UniqueConstraint("AK_ArticleCategories_CategoryName", x => x.CategoryName);
                });

            migrationBuilder.CreateTable(
                name: "ArtistTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArtistTypeName = table.Column<string>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistTypes", x => x.Id);
                    table.UniqueConstraint("AK_ArtistTypes_ArtistTypeName", x => x.ArtistTypeName);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthorGenres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuthorGenreName = table.Column<string>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthorGenres", x => x.Id);
                    table.UniqueConstraint("AK_BookAuthorGenres_AuthorGenreName", x => x.AuthorGenreName);
                });

            migrationBuilder.CreateTable(
                name: "BookCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookCategoryName = table.Column<string>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategories", x => x.Id);
                    table.UniqueConstraint("AK_BookCategories_BookCategoryName", x => x.BookCategoryName);
                });

            migrationBuilder.CreateTable(
                name: "BrandTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeName = table.Column<string>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandTypes", x => x.Id);
                    table.UniqueConstraint("AK_BrandTypes_TypeName", x => x.TypeName);
                });

            migrationBuilder.CreateTable(
                name: "GameTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GameTypeName = table.Column<string>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTypes", x => x.Id);
                    table.UniqueConstraint("AK_GameTypes_GameTypeName", x => x.GameTypeName);
                });

            migrationBuilder.CreateTable(
                name: "InstrumentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeName = table.Column<string>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentTypes", x => x.Id);
                    table.UniqueConstraint("AK_InstrumentTypes_TypeName", x => x.TypeName);
                });

            migrationBuilder.CreateTable(
                name: "Jokes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 80, nullable: false),
                    Content = table.Column<string>(nullable: false),
                    PhotoURL = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jokes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Memes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 80, nullable: false),
                    PhotoURL = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeName = table.Column<string>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                    table.UniqueConstraint("AK_ProductTypes_TypeName", x => x.TypeName);
                });

            migrationBuilder.CreateTable(
                name: "ReviewTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReviewTypeName = table.Column<string>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewTypes", x => x.Id);
                    table.UniqueConstraint("AK_ReviewTypes_ReviewTypeName", x => x.ReviewTypeName);
                });

            migrationBuilder.CreateTable(
                name: "SongGenres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GenreName = table.Column<string>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongGenres", x => x.Id);
                    table.UniqueConstraint("AK_SongGenres_GenreName", x => x.GenreName);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 80, nullable: false),
                    PhotoURL = table.Column<string>(nullable: false),
                    HighLightVideoURL = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    ArticleCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.UniqueConstraint("AK_Articles_Title", x => x.Title);
                    table.ForeignKey(
                        name: "FK_Articles_ArticleCategories_ArticleCategoryId",
                        column: x => x.ArticleCategoryId,
                        principalTable: "ArticleCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(maxLength: 80, nullable: false),
                    PhotoURL = table.Column<string>(nullable: false),
                    HighLightVideoURL = table.Column<string>(nullable: false),
                    AdditionalInfoURL = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    ArtistTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                    table.UniqueConstraint("AK_Artists_FullName", x => x.FullName);
                    table.ForeignKey(
                        name: "FK_Artists_ArtistTypes_ArtistTypeId",
                        column: x => x.ArtistTypeId,
                        principalTable: "ArtistTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(maxLength: 80, nullable: false),
                    PhotoURL = table.Column<string>(nullable: false),
                    HighLightVideoURL = table.Column<string>(nullable: false),
                    AdditionalInfoURL = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    BookAuthorGenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => x.Id);
                    table.UniqueConstraint("AK_BookAuthors_FullName", x => x.FullName);
                    table.ForeignKey(
                        name: "FK_BookAuthors_BookAuthorGenres_BookAuthorGenreId",
                        column: x => x.BookAuthorGenreId,
                        principalTable: "BookAuthorGenres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrandName = table.Column<string>(maxLength: 80, nullable: false),
                    BrandDescription = table.Column<string>(nullable: false),
                    BrandImageURL = table.Column<string>(nullable: false),
                    AdditionalInfoURL = table.Column<string>(nullable: false),
                    BrandTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                    table.UniqueConstraint("AK_Brands_BrandName", x => x.BrandName);
                    table.ForeignKey(
                        name: "FK_Brands_BrandTypes_BrandTypeId",
                        column: x => x.BrandTypeId,
                        principalTable: "BrandTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavouriteUserJokes",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    JokeId = table.Column<int>(nullable: false),
                    AddedToFavouritesOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteUserJokes", x => new { x.JokeId, x.UserId });
                    table.ForeignKey(
                        name: "FK_FavouriteUserJokes_Jokes_JokeId",
                        column: x => x.JokeId,
                        principalTable: "Jokes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouriteUserJokes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavouriteUserMemes",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    MemeId = table.Column<int>(nullable: false),
                    AddedToFavouritesOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteUserMemes", x => new { x.MemeId, x.UserId });
                    table.ForeignKey(
                        name: "FK_FavouriteUserMemes_Memes_MemeId",
                        column: x => x.MemeId,
                        principalTable: "Memes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouriteUserMemes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 80, nullable: false),
                    PhotoURL = table.Column<string>(nullable: false),
                    HighLightVideoURL = table.Column<string>(nullable: false),
                    AdditionalInfoURL = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    ReviewTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.UniqueConstraint("AK_Reviews_Title", x => x.Title);
                    table.ForeignKey(
                        name: "FK_Reviews_ReviewTypes_ReviewTypeId",
                        column: x => x.ReviewTypeId,
                        principalTable: "ReviewTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavouriteUserArticles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    ArticleId = table.Column<int>(nullable: false),
                    AddedToFavouritesOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteUserArticles", x => new { x.ArticleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_FavouriteUserArticles_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouriteUserArticles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavouriteUserArtists",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    ArtistId = table.Column<int>(nullable: false),
                    AddedToFavouritesOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteUserArtists", x => new { x.ArtistId, x.UserId });
                    table.ForeignKey(
                        name: "FK_FavouriteUserArtists_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouriteUserArtists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SongName = table.Column<string>(maxLength: 80, nullable: false),
                    ArtistId = table.Column<int>(nullable: false),
                    PhotoURL = table.Column<string>(nullable: false),
                    HighLightVideoURL = table.Column<string>(nullable: false),
                    AdditionalInfoURL = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    SongGenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                    table.UniqueConstraint("AK_Songs_SongName", x => x.SongName);
                    table.ForeignKey(
                        name: "FK_Songs_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Songs_SongGenres_SongGenreId",
                        column: x => x.SongGenreId,
                        principalTable: "SongGenres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 80, nullable: false),
                    BookAuthorId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    PhotoURL = table.Column<string>(nullable: false),
                    AdditionalInfoURL = table.Column<string>(nullable: false),
                    BookCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.UniqueConstraint("AK_Books_Title", x => x.Title);
                    table.ForeignKey(
                        name: "FK_Books_BookAuthors_BookAuthorId",
                        column: x => x.BookAuthorId,
                        principalTable: "BookAuthors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_BookCategories_BookCategoryId",
                        column: x => x.BookCategoryId,
                        principalTable: "BookCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavouriteUserBrands",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    BrandId = table.Column<int>(nullable: false),
                    AddedToFavouritesOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteUserBrands", x => new { x.BrandId, x.UserId });
                    table.ForeignKey(
                        name: "FK_FavouriteUserBrands_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouriteUserBrands_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GameName = table.Column<string>(maxLength: 80, nullable: false),
                    BrandId = table.Column<int>(nullable: false),
                    PhotoURL = table.Column<string>(nullable: false),
                    HighLightVideoURL = table.Column<string>(nullable: false),
                    AdditionalInfoURL = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    GameTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.UniqueConstraint("AK_Games_GameName", x => x.GameName);
                    table.ForeignKey(
                        name: "FK_Games_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Games_GameTypes_GameTypeId",
                        column: x => x.GameTypeId,
                        principalTable: "GameTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Instruments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrandId = table.Column<int>(nullable: false),
                    ModelName = table.Column<string>(maxLength: 80, nullable: false),
                    PhotoURL = table.Column<string>(nullable: false),
                    HighLightVideoURL = table.Column<string>(nullable: false),
                    AdditionalInfoURL = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    InstrumentTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instruments", x => x.Id);
                    table.UniqueConstraint("AK_Instruments_ModelName", x => x.ModelName);
                    table.ForeignKey(
                        name: "FK_Instruments_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Instruments_InstrumentTypes_InstrumentTypeId",
                        column: x => x.InstrumentTypeId,
                        principalTable: "InstrumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductName = table.Column<string>(maxLength: 80, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BrandId = table.Column<int>(nullable: false),
                    PhotoURL = table.Column<string>(nullable: false),
                    HighLightVideoURL = table.Column<string>(nullable: false),
                    AdditionalInfoURL = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    ProductTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.UniqueConstraint("AK_Products_ProductName", x => x.ProductName);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavouriteUserReviews",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    ReviewId = table.Column<int>(nullable: false),
                    AddedToFavouritesOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteUserReviews", x => new { x.ReviewId, x.UserId });
                    table.ForeignKey(
                        name: "FK_FavouriteUserReviews_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouriteUserReviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavouriteUserSongs",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    SongId = table.Column<int>(nullable: false),
                    AddedToFavouritesOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteUserSongs", x => new { x.SongId, x.UserId });
                    table.ForeignKey(
                        name: "FK_FavouriteUserSongs_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouriteUserSongs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavouriteUserBooks",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    BookId = table.Column<int>(nullable: false),
                    AddedToFavouritesOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteUserBooks", x => new { x.BookId, x.UserId });
                    table.ForeignKey(
                        name: "FK_FavouriteUserBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouriteUserBooks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavouriteUserGames",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    GameId = table.Column<int>(nullable: false),
                    AddedToFavouritesOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteUserGames", x => new { x.GameId, x.UserId });
                    table.ForeignKey(
                        name: "FK_FavouriteUserGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouriteUserGames_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavouriteUserInstruments",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    InstrumentId = table.Column<int>(nullable: false),
                    AddedToFavouritesOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteUserInstruments", x => new { x.InstrumentId, x.UserId });
                    table.ForeignKey(
                        name: "FK_FavouriteUserInstruments_Instruments_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instruments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouriteUserInstruments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBoughtProducts",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    BoughtOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBoughtProducts", x => new { x.ProductId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserBoughtProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBoughtProducts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ArticleCategoryId",
                table: "Articles",
                column: "ArticleCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Artists_ArtistTypeId",
                table: "Artists",
                column: "ArtistTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_BookAuthorGenreId",
                table: "BookAuthors",
                column: "BookAuthorGenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookAuthorId",
                table: "Books",
                column: "BookAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookCategoryId",
                table: "Books",
                column: "BookCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_BrandTypeId",
                table: "Brands",
                column: "BrandTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteUserArticles_UserId",
                table: "FavouriteUserArticles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteUserArtists_UserId",
                table: "FavouriteUserArtists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteUserBooks_UserId",
                table: "FavouriteUserBooks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteUserBrands_UserId",
                table: "FavouriteUserBrands",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteUserGames_UserId",
                table: "FavouriteUserGames",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteUserInstruments_UserId",
                table: "FavouriteUserInstruments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteUserJokes_UserId",
                table: "FavouriteUserJokes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteUserMemes_UserId",
                table: "FavouriteUserMemes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteUserReviews_UserId",
                table: "FavouriteUserReviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteUserSongs_UserId",
                table: "FavouriteUserSongs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_BrandId",
                table: "Games",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_GameTypeId",
                table: "Games",
                column: "GameTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Instruments_BrandId",
                table: "Instruments",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Instruments_InstrumentTypeId",
                table: "Instruments",
                column: "InstrumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeId",
                table: "Products",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReviewTypeId",
                table: "Reviews",
                column: "ReviewTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_ArtistId",
                table: "Songs",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_SongGenreId",
                table: "Songs",
                column: "SongGenreId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBoughtProducts_UserId",
                table: "UserBoughtProducts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "FavouriteUserArticles");

            migrationBuilder.DropTable(
                name: "FavouriteUserArtists");

            migrationBuilder.DropTable(
                name: "FavouriteUserBooks");

            migrationBuilder.DropTable(
                name: "FavouriteUserBrands");

            migrationBuilder.DropTable(
                name: "FavouriteUserGames");

            migrationBuilder.DropTable(
                name: "FavouriteUserInstruments");

            migrationBuilder.DropTable(
                name: "FavouriteUserJokes");

            migrationBuilder.DropTable(
                name: "FavouriteUserMemes");

            migrationBuilder.DropTable(
                name: "FavouriteUserReviews");

            migrationBuilder.DropTable(
                name: "FavouriteUserSongs");

            migrationBuilder.DropTable(
                name: "UserBoughtProducts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Instruments");

            migrationBuilder.DropTable(
                name: "Jokes");

            migrationBuilder.DropTable(
                name: "Memes");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ArticleCategories");

            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropTable(
                name: "BookCategories");

            migrationBuilder.DropTable(
                name: "GameTypes");

            migrationBuilder.DropTable(
                name: "InstrumentTypes");

            migrationBuilder.DropTable(
                name: "ReviewTypes");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "SongGenres");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "BookAuthorGenres");

            migrationBuilder.DropTable(
                name: "ArtistTypes");

            migrationBuilder.DropTable(
                name: "BrandTypes");
        }
    }
}
