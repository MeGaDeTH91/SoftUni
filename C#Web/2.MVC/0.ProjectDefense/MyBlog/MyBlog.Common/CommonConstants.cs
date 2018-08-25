namespace MyBlog.Common
{
    public class CommonConstants
    {
        public const string ConfigSuffix = "Config";
        public const string ErrorUserId = "NoSuchUser";
        public const int AccountLockOutInMonths = 1;
        public const int AccountUnLockOutInDays = -1;
        public const decimal PremiumProductPriceReduce = 0.5m;

        public const string OwnerSuffix = "Owner";
        public const string AdminSuffix = "Administrator";
        public const string PremiumAreaSuffix = "Premium";
        public const string PremiumUserSuffix = "PremiumUser";

        public const string DefaultOwnerUsername = "owner";
        public const string DefaultOwnerPassword = "owner1";
        public const string DefaultOwnerEmail = "owner@cool.bg";
        public const string DefaultOwnerFullName = "Application owner";
        public const int RolesListOwnerIndex = 0;

        public const string DefaultAdminUsername = "admin";
        public const string DefaultAdminPassword = "admin1";
        public const string DefaultAdminEmail = "admin@cool.bg";
        public const string DefaultAdminFullName = "Initial Administrator";
        public const int RolesListAdminIndex = 1;

        public const string TitleSuffix = "Title";
        public const string ArticleSuffix = "Article";
        public const string ArtistSuffix = "Artist";
        public const string BookSuffix = "Book";
        public const string BrandSuffix = "Brand";
        public const string JokeSuffix = "Joke";
        public const string MemeSuffix = "Meme";
        public const string GameSuffix = "Game";
        public const string InstrumentSuffix = "Instrument";
        public const string SongSuffix = "Song";
        public const string ProductSuffix = "Product";
        public const string ReviewSuffix = "Review";

        
        public const string LayoutMessageKey = "__Message";
        public const string SuccessMessage = "{0} added successfully!";
        public const string DangerMessage = "Please type all fields correctly.";
        public const string DuplicateMessage = "Duplicates are not allowed.";
        public const string NotFoundMessage = "Resouce not found.";

        public const string AddedToFavouritesSuccessfullyMessage = "Added to favourites successfully!";
        public const string AlreadyInFavouritesOrInvalidErrorMessage = "Already in favourites or invalid data!";

        public const string BoughtSuccessfullyMessage = "Product bought Successfully!";
        public const string AlreadyBoughtOrInvalidDataErrorMessage = "Product already bought!";

        public const string OpenControlLabel = "control-label col-sm-2";
        public const string FormControl = "form-control";
        public const string TextDanger = "text-danger";
        public const string DivClass_FormGroup = "<div class=\"form-group row\">";
        public const string DivClass_ColSm = "<div class=\"col-sm-10\">";
        public const string DivClosing = "</div></div><br />";

        //Display
        public const string ArticleCategoryDisplay = "Article category";
        public const string ArticleContentDisplay = "Article Content";
        public const string ArtistFullNameDisplay = "Full Name";
        public const string ArtistTypeDisplay = "Artist type";
        public const string BookAuthorDisplay = "Book author";
        public const string BookAuthorGenreDisplay = "Book author genre";
        public const string BookCategoryDisplay = "Book category";
        public const string BrandTypeDisplay = "Brand type";
        public const string BrandNameDisplay = "Brand name";
        public const string BrandDescriptionDisplay = "Brand description";
        public const string GameTypeDisplay = "Game type";
        public const string GameNameDisplay = "Game name";
        public const string GameDescriptionDisplay = "Game description";
        public const string InstrumentModelNameDisplay = "Model Name";
        public const string InstrumentTypeDisplay = "Instrument type";
        public const string SongNameDisplay = "Song name";
        public const string SongGenreDisplay = "Song genre";
        public const string ProductNameDisplay = "Product name";
        public const string ProductTypeDisplay = "Product type";
        public const string ReviewTypeDisplay = "Review type";

        public const string PhotoUrlDisplay = "Image URL";
        public const string VideoUrlDisplay = "Video URL";
        public const string CategoryNameDisplay = "Category name";
        public const string TypeNameDisplay = "Type Name";
        public const string AdditionalInfoDisplay = "Additional Information URL";

        public const string OriginalVideoUrlPart = "watch?v=";
        public const string ModifiedEmbedURL = "embed/";

        public const string ProductPriceColumnFormat = "decimal(18,2)";
    }
}
