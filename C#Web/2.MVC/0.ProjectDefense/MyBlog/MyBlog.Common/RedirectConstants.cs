namespace MyBlog.Common
{
    public class RedirectConstants
    {
        //Administrator Area
        public const string AdminHomeRoute = "/Administrator/Home/AdminIndex";
        public const string PremiumHomeRoute = "/Premium/Home/PremiumIndex";
        public const string OwnerHomeRoute = "/Premium/Home/OwnerIndex";

        //Article related
        //Pages
        public const string AdministratorAreaArticleDetailsPage = "/Administrator/Articles/Details?id={0}";
        public const string AdministratorAreaBookDetailsPage = "/Administrator/Books/BookDetails?id={0}";
        public const string AdministratorAreaBrandDetailsPage = "/Administrator/Brands/BrandDetails?id={0}";
        public const string AdministratorAreaMemeDetailsPage = "/Administrator/Fun/MemeDetails?id={0}";
        public const string AdministratorAreaJokeDetailsPage = "/Administrator/Fun/JokeDetails?id={0}";
        public const string AdministratorAreaGameDetailsPage = "/Administrator/Games/GameDetails?id={0}";
        public const string AdministratorAreaArtistDetailsPage = "/Administrator/Music/ArtistDetails?id={0}";
        public const string AdministratorAreaInstrumentDetailsPage = "/Administrator/Music/InstrumentDetails?id={0}";
        public const string AdministratorAreaSongDetailsPage = "/Administrator/Music/SongDetails?id={0}";
        public const string AdministratorAreaProductDetailsPage = "/Administrator/Products/ProductDetails?id={0}";
        public const string AdministratorAreaReviewDetailsPage = "/Administrator/Reviews/ReviewDetails?id={0}";
        public const string AdministratorAreaUserDetailsPage = "/Administrator/Users/UserDetails?id={0}";

        //Owner
        public const string OwnerAreaUserDetailsPage = "/Owner/Users/UserDetails?id={0}";
        //Mvc
        public const string PremiumIndex = "PremiumIndex";
        public const string HomeControllexSuffix = "Home";
        public const string IndexSuffix = "Index";

        //Articles
        public const string ArticlesSuffix = "Articles";
        public const string ArticleCategorySuffix = "CategoryArticles";

        //Books
        public const string BooksSuffix = "Books";
        public const string BookAuthorSuffx = "BookAuthor";
        public const string BookCategorySuffix = "BookCategory";

        //Brands
        public const string BrandsSuffix = "Brands";
        public const string BrandTypeBrandsSuffix = "BrandTypeDetails";

        //Fun
        public const string JokesSuffix = "Jokes";
        public const string MemesSuffix = "Memes";

        //Games
        public const string GamesSuffix = "Games";
        public const string GameTypeDetailsSuffix = "GameTypeDetails";

        //Artists
        public const string ArtistsSuffix = "Artists";
        public const string ArtistTypeDetailsSuffix = "ArtistTypeDetails";

        //Instruments
        public const string InstrumentsSuffix = "Instruments";
        public const string InstrumentTypeDetailsSuffix = "InstrumentTypeDetails";

        //Songs
        public const string SongsSuffix = "Songs";
        public const string SongGenreDetailsSuffix = "SongGenreDetails";

        //Products
        public const string ProductsSuffix = "Products";
        public const string ProductTypeDetailsSuffix = "ProductTypeDetails";

        //Reviews
        public const string ReviewsSuffix = "Reviews";
        public const string ReviewTypeDetailsSuffix = "ReviewTypeDetails";

        //Standart User Related

        public const string ArticleDetailsPage = "/Articles/Details?id={0}";
        public const string BookDetailsPage = "/Books/BookDetails?id={0}";
        public const string BrandDetailsPage = "/Brands/BrandDetails?id={0}";
        public const string MemeDetailsPage = "/Fun/MemeDetails?id={0}";
        public const string JokeDetailsPage = "/Fun/JokeDetails?id={0}";
        public const string GameDetailsPage = "/Games/GameDetails?id={0}";
        public const string ArtistDetailsPage = "/Music/ArtistDetails?id={0}";
        public const string InstrumentDetailsPage = "/Music/InstrumentDetails?id={0}";
        public const string SongDetailsPage = "/Music/SongDetails?id={0}";
        public const string ProductDetailsPage = "/Products/ProductDetails?id={0}";
        public const string ReviewDetailsPage = "/Reviews/ReviewDetails?id={0}";
    }
}
