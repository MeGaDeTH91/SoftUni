namespace MyBlog.App.Mappings
{
    using AutoMapper;
    using MyBlog.CommonModels.BindingModels.Articles;
    using MyBlog.CommonModels.BindingModels.Books;
    using MyBlog.CommonModels.BindingModels.Brands;
    using MyBlog.CommonModels.BindingModels.Fun;
    using MyBlog.CommonModels.BindingModels.Games;
    using MyBlog.CommonModels.BindingModels.Music.Artists;
    using MyBlog.CommonModels.BindingModels.Music.Instruments;
    using MyBlog.CommonModels.BindingModels.Music.Songs;
    using MyBlog.CommonModels.BindingModels.Products;
    using MyBlog.CommonModels.BindingModels.Reviews;
    using MyBlog.CommonModels.ViewModels.Articles;
    using MyBlog.CommonModels.ViewModels.Books;
    using MyBlog.CommonModels.ViewModels.Brands;
    using MyBlog.CommonModels.ViewModels.Fun;
    using MyBlog.CommonModels.ViewModels.Games;
    using MyBlog.CommonModels.ViewModels.Music.Artists;
    using MyBlog.CommonModels.ViewModels.Music.Instruments;
    using MyBlog.CommonModels.ViewModels.Music.Songs;
    using MyBlog.CommonModels.ViewModels.Products;
    using MyBlog.CommonModels.ViewModels.PremiumOffers;
    using MyBlog.CommonModels.ViewModels.Reviews;
    using MyBlog.CommonModels.ViewModels.Users;
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
    using MyBlog.Models.Users;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Binding Mappings
            //Articles
            CreateMap<AddArticleBindingModel, Article>(MemberList.Source);
            CreateMap<EditArticleBindingModel, Article>(MemberList.Source);
            CreateMap<AddArticleCategoryBindingModel, ArticleCategory>(MemberList.Source);
            //Books
            CreateMap<BookBindingModel, Book>(MemberList.Source);
            CreateMap<AddBookAuthorBindingModel, BookAuthor>(MemberList.Source);
            CreateMap<AddBookAuthorGenreBindingModel, BookAuthorGenre>(MemberList.Source);
            CreateMap<AddBookCategoryBindingModel, BookCategory>(MemberList.Source);
            CreateMap<EditBookBindingModel, Book>(MemberList.Source);
            //Brands
            CreateMap<BrandBindingModel, Brand>(MemberList.Source);
            CreateMap<EditBrandBindingModel, Brand>(MemberList.Source);
            CreateMap<BrandTypeBindingModel, BrandType>(MemberList.Source);
            //Fun
            CreateMap<AddMemeBindingModel, Meme>(MemberList.Source);
            CreateMap<EditMemeBindingModel, Meme>(MemberList.Source);
            CreateMap<AddJokeBindingModel, Joke>(MemberList.Source);
            CreateMap<EditJokeBindingModel, Joke>(MemberList.Source);
            //Games
            CreateMap<AddGameBindingModel, Game>(MemberList.Source);
            CreateMap<EditGameBindingModel, Game>(MemberList.Source);
            CreateMap<AddGameTypeBindingModel, GameType>(MemberList.Source);
            //Music
            // -->> Artists
            CreateMap<AddArtistBindingModel, Artist>(MemberList.Source);
            CreateMap<EditArtistBindingModel, Artist>(MemberList.Source);
            CreateMap<AddArtistTypeBindingModel, ArtistType>(MemberList.Source);
            // -->> Instruments
            CreateMap<AddInstrumentBindingModel, Instrument>(MemberList.Source);
            CreateMap<EditInstrumentBindingModel, Instrument>(MemberList.Source);
            CreateMap<AddInstrumentTypeBindingModel, InstrumentType>(MemberList.Source);
            // -->> Songs
            CreateMap<AddSongBindingModel, Song>(MemberList.Source);
            CreateMap<EditSongBindingModel, Song>(MemberList.Source);
            CreateMap<AddSongGenreBindingModel, SongGenre>(MemberList.Source);
            //Products
            CreateMap<AddProductBindingModel, Product>(MemberList.Source);
            CreateMap<EditProductBindingModel, Product>(MemberList.Source);
            CreateMap<AddProductTypeBindingModel, ProductType>(MemberList.Source);
            //Reviews
            CreateMap<AddReviewBindingModel, Review>(MemberList.Source);
            CreateMap<EditReviewBindingModel, Review>(MemberList.Source);
            CreateMap<AddReviewTypeBindingModel, ReviewType>(MemberList.Source);


            //ViewModels Mappings

            //Articles
            CreateMap<Article, ArticleConciseViewModel>(MemberList.Destination);
            CreateMap<Article, ArticleDetailsViewModel>(MemberList.Destination);
            CreateMap<ArticleCategory, ArticlesCategoryViewModel>(MemberList.Destination);
            //Books
            CreateMap<Book, BookConciseViewModel>(MemberList.Destination);
            CreateMap<Book, BookDetailsViewModel>(MemberList.Destination);
            CreateMap<BookAuthor, BookAuthorViewModel>(MemberList.Destination);
            CreateMap<BookCategory, BookCategoryViewModel>(MemberList.Destination);
            //Brands
            CreateMap<Brand, BrandConciseViewModel>(MemberList.Destination);
            CreateMap<Brand, BrandDetailsViewModel>(MemberList.Destination);
            CreateMap<BrandType, BrandTypeViewModel>(MemberList.Destination);
            //Fun
            CreateMap<Meme, MemeConciseViewModel>(MemberList.Destination);
            CreateMap<Meme, MemeDetailsViewModel>(MemberList.Destination);
            CreateMap<Joke, JokeConciseViewModel>(MemberList.Destination);
            CreateMap<Joke, JokeDetailsViewModel>(MemberList.Destination);
            //Games
            CreateMap<Game, GameConciseViewModel>(MemberList.Destination);
            CreateMap<Game, GameDetailsViewModel>(MemberList.Destination);
            CreateMap<GameType, GameTypeViewModel>(MemberList.Destination);
            //Music
            // -->> Artists
            CreateMap<Artist, ArtistConciseViewModel>(MemberList.Destination);
            CreateMap<Artist, ArtistDetailsViewModel>(MemberList.Destination);
            CreateMap<ArtistType, ArtistTypeViewModel>(MemberList.Destination);
            // -->> Instruments
            CreateMap<Instrument, InstrumentConciseViewModel>(MemberList.Destination);
            CreateMap<Instrument, InstrumentDetailsViewModel>(MemberList.Destination);
            CreateMap<InstrumentType, InstrumentTypeViewModel>(MemberList.Destination);
            // -->> Songs
            CreateMap<Song, SongConciseViewModel>(MemberList.Destination);
            CreateMap<Song, SongDetailsViewModel>(MemberList.Destination);
            CreateMap<SongGenre, SongGenreViewModel>(MemberList.Destination);
            //Products
            CreateMap<Product, ProductConciseViewModel>(MemberList.Destination);
            CreateMap<Product, ProductDetailsViewModel>(MemberList.Destination);
            CreateMap<Product, PremiumOfferDetailsViewModel>(MemberList.Destination);
            CreateMap<ProductType, ProductTypeViewModel>(MemberList.Destination);
            //Reviews
            CreateMap<Review, ReviewConciseViewModel>(MemberList.Destination);
            CreateMap<Review, ReviewDetailsViewModel>(MemberList.Destination);
            CreateMap<ReviewType, ReviewTypeViewModel>(MemberList.Destination);

            //Users
            CreateMap<User, UserConciseViewModel>(MemberList.Destination);
            CreateMap<User, UserDetailsViewModel>(MemberList.Destination);

        }
    }
}
