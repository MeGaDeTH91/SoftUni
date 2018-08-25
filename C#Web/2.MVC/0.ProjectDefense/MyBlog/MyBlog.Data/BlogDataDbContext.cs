namespace MyBlog.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using MyBlog.Data.EntityConfiguration.ArticlesConfiguration;
    using MyBlog.Data.EntityConfiguration.BooksConfiguration;
    using MyBlog.Data.EntityConfiguration.BrandsConfiguration;
    using MyBlog.Data.EntityConfiguration.FunConfiguration;
    using MyBlog.Data.EntityConfiguration.GamesConfiguration;
    using MyBlog.Data.EntityConfiguration.MusicConfiguration.ArtistsConfiguration;
    using MyBlog.Data.EntityConfiguration.MusicConfiguration.InstrumentsConfiguration;
    using MyBlog.Data.EntityConfiguration.MusicConfiguration.SongsConfiguration;
    using MyBlog.Data.EntityConfiguration.ProductsConfiguration;
    using MyBlog.Data.EntityConfiguration.ReviewsConfiguration;
    using MyBlog.Models.Users;
    using MyBlog.Models.Articles;
    using MyBlog.Models.Books;
    using MyBlog.Models.Brands;
    using MyBlog.Models.Fun;
    using MyBlog.Models.Games;
    using MyBlog.Models.Music.Artists;
    using MyBlog.Models.Music.Instruments;
    using MyBlog.Models.Music.Songs;
    using MyBlog.Models.ProductsForSale;
    using MyBlog.Models.Reviews;
    using System.Reflection;
    using System;
    using System.Linq;
    using MyBlog.Data.EntityConfiguration.UsersConfiguration;
    using System.Collections.Generic;

    public class BlogDataDbContext : IdentityDbContext<User>
    {
        public BlogDataDbContext(DbContextOptions<BlogDataDbContext> options)
            : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookAuthorGenre> BookAuthorGenres { get; set; }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<BrandType> BrandTypes { get; set; }

        public DbSet<Joke> Jokes { get; set; }
        public DbSet<Meme> Memes { get; set; }

        public DbSet<Game> Games { get; set; }
        public DbSet<GameType> GameTypes { get; set; }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<ArtistType> ArtistTypes { get; set; }

        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<InstrumentType> InstrumentTypes { get; set; }

        public DbSet<Song> Songs { get; set; }
        public DbSet<SongGenre> SongGenres { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        public DbSet<Review> Reviews { get; set; }
        public DbSet<ReviewType> ReviewTypes { get; set; }


        public DbSet<UserArticles> FavouriteUserArticles { get; set; }

        public DbSet<UserArtists> FavouriteUserArtists { get; set; }

        public DbSet<UserBooks> FavouriteUserBooks { get; set; }

        public DbSet<UserBrands> FavouriteUserBrands { get; set; }

        public DbSet<UserJokes> FavouriteUserJokes { get; set; }

        public DbSet<UserMemes> FavouriteUserMemes { get; set; }

        public DbSet<UserGames> FavouriteUserGames { get; set; }

        public DbSet<UserInstruments> FavouriteUserInstruments { get; set; }

        public DbSet<UserSongs> FavouriteUserSongs { get; set; }

        public DbSet<UserProducts> UserBoughtProducts { get; set; }

        public DbSet<UserReviews> FavouriteUserReviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ServerConfig.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            ApplyAllEntityConfigurations(builder);

            // Uncomment if the Reflection strategy above is not working for some reason

            //builder.ApplyConfiguration(new ArticleCategoryConfig());
            //builder.ApplyConfiguration(new ArticleConfig());

            //builder.ApplyConfiguration(new BookAuthorConfig());
            //builder.ApplyConfiguration(new BookAuthorGenreConfig());
            //builder.ApplyConfiguration(new BookCategoryConfig());
            //builder.ApplyConfiguration(new BookConfig());

            //builder.ApplyConfiguration(new BrandConfig());
            //builder.ApplyConfiguration(new BrandTypeConfig());

            //builder.ApplyConfiguration(new JokeConfig());
            //builder.ApplyConfiguration(new MemeConfig());

            //builder.ApplyConfiguration(new GameConfig());
            //builder.ApplyConfiguration(new GameTypeConfig());

            //builder.ApplyConfiguration(new ArtistConfig());
            //builder.ApplyConfiguration(new ArtistTypeConfig());

            //builder.ApplyConfiguration(new InstrumentConfig());
            //builder.ApplyConfiguration(new InstrumentTypeConfig());

            //builder.ApplyConfiguration(new SongConfig());
            //builder.ApplyConfiguration(new SongGenreConfig());

            //builder.ApplyConfiguration(new ProductConfig());
            //builder.ApplyConfiguration(new ProductTypeConfig());

            //builder.ApplyConfiguration(new ReviewConfig());
            //builder.ApplyConfiguration(new ReviewTypeConfig());

            //builder.ApplyConfiguration(new UserArticlesConfig());
            //builder.ApplyConfiguration(new UserArtistsConfig());
            //builder.ApplyConfiguration(new UserBooksConfig());
            //builder.ApplyConfiguration(new UserBrandsConfig());
            //builder.ApplyConfiguration(new UserJokesConfig());
            //builder.ApplyConfiguration(new UserMemesConfig());
            //builder.ApplyConfiguration(new UserGamesConfig());
            //builder.ApplyConfiguration(new UserInstrumentsConfig());
            //builder.ApplyConfiguration(new UserSongsConfig());
            //builder.ApplyConfiguration(new UserProductsConfig());
            //builder.ApplyConfiguration(new UserReviewsConfig());
        }

        private static void ApplyAllEntityConfigurations(ModelBuilder builder)
        {
            var applyGenericMethod = typeof(ModelBuilder).GetMethods().Where(x => x.Name.StartsWith("ApplyConfiguration")).ToList().First();
            // replace GetExecutingAssembly with assembly where your configurations are if necessary
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes()
                .Where(c => c.IsClass && !c.IsAbstract && !c.ContainsGenericParameters))
            {
                // use type.Namespace to filter by namespace if necessary
                foreach (var iface in type.GetInterfaces())
                {
                    // if type implements interface IEntityTypeConfiguration<SomeEntity>
                    if (iface.IsConstructedGenericType && iface.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
                    {
                        // make concrete ApplyConfiguration<SomeEntity> method
                        var applyConcreteMethod = applyGenericMethod.MakeGenericMethod(iface.GenericTypeArguments[0]);
                        // and invoke that with fresh instance of your configuration type
                        applyConcreteMethod.Invoke(builder, new object[] { Activator.CreateInstance(type) });
                        break;
                    }
                }
            }
        }
    }
}
