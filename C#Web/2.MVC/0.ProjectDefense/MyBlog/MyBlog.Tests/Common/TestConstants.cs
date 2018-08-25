namespace MyBlog.Tests.Common
{
    using MyBlog.Models.Brands;
    using MyBlog.Models.ProductsForSale;

    public class TestConstants
    {
        public class Products
        {
            //Product Billy(IKEA)
            public const string BillyName = "Billy";
            public const string BillyDescription = "Once upon a time a little bookcase become a beloved classic around the world. And, like most things small, it grew. BILLY never lost touch with its origins - it’s still a great bookcase. But it’s now more customizable and used in many more ways. BILLY can be as small and humble or big and proud as you want it to be.";
            public const string BillyImageURL = "https://www.ikea.com/gb/en/images/campaign-seasonal/ikea-ikea-billy-oxberg-bookcase-with-glass-doors-white__1364390795636-s41.jpg";
            public const string BillyVideoURL = "https://www.youtube.com/embed/iWTBSGIR9es";
            public const string BillyAdditionalInfo = "https://www.ikea.bg/living-room/Living-room-storage/BILLY-system/";
            public const int BillyProductTypeId = 1;
            public const int BillyBrandId = 1;
            public const decimal BillyPrice = 100;

            //Product 2 (Same Billy)
            public const string Billy2Name = "Billy2";
            public const string Billy2Description = "Once upon a time a little bookcase become a beloved classic around the world. And, like most things small, it grew. BILLY never lost touch with its origins - it’s still a great bookcase. But it’s now more customizable and used in many more ways. BILLY can be as small and humble or big and proud as you want it to be.";
            public const string Billy2ImageURL = "https://www.ikea.com/gb/en/images/campaign-seasonal/ikea-ikea-billy-oxberg-bookcase-with-glass-doors-white__1364390795636-s41.jpg";
            public const string Billy2VideoURL = "https://www.youtube.com/embed/iWTBSGIR9es";
            public const string Billy2AdditionalInfo = "https://www.ikea.bg/living-room/Living-room-storage/BILLY-system/";
            public const int Billy2ProductTypeId = 2;
            public const int Billy2BrandId = 2;
            public const decimal Billy2Price = 100;

            public const string Billy3Name = "Billy3";
            public const string Billy4Name = "Billy4";

            //Product types
            public const string TypeName = "Home And Garden";
            public const string Type2Name = "Fun";


            //Brands
            public const string IKEAName = "Ikea";
            public const string IKEADescription = "IKEA strive to make good design accessible to everybody. The new AR app, IKEA Place, represents the latest effort towards this ambition, to perhaps change the way people buy furniture forever.";
            public const string IKEAImageURL = "https://brat-bg.com/images/ikea.jpg";
            public const string IKEAVideoURL = "https://www.youtube.com/embed/r0ViFTEb8aQ";
            public const string IKEAAdditionalInfo = "https://www.ikea.com/gb/en/";
            public const int IKEABrandTypeId = 1;

            public const string IKEA2Name = "Ikea2";
            public const string IKEA2Description = "IKEA strive to make good design accessible to everybody. The new AR app, IKEA Place, represents the latest effort towards this ambition, to perhaps change the way people buy furniture forever.";
            public const string IKEA2ImageURL = "https://brat-bg.com/images/ikea.jpg";
            public const string IKEA2VideoURL = "https://www.youtube.com/embed/r0ViFTEb8aQ";
            public const string IKEA2AdditionalInfo = "https://www.ikea.com/gb/en/";
            public const int IKEA2BrandTypeId = 2;
            //Brand Types
            public const string BrandTypeName = "Furniture";
            public const string BrandType2Name = "Housing";

            public const int ErrorId = -1;
            public const int NonExistingId = 80;
            public const int Id_Index_1 = 1;
            public const int Id_Index_2 = 2;
            public const int Id_Index_3 = 3;

            public const int ValidProductsAddedExpected = 2;
            public const int NoProductsAddedExpected = 0;
            public const int InValidProductsAddedExpected = 0;

            public const int ExpectedProductsAfterDeletion = 1;
            public const int ExpectedProductsAfterNoDeletion = 2;

            public const bool IsDeletedTrue = true;
            public const bool IsDeletedFalse = false;

            public static readonly Product validProduct1 = new Product()
            {
                ProductName = BillyName,
                ProductTypeId = BillyProductTypeId,
                BrandId = BillyBrandId,
                Description = BillyDescription,
                PhotoURL = BillyImageURL,
                HighLightVideoURL = BillyVideoURL,
                AdditionalInfoURL = BillyAdditionalInfo,
                Price = BillyPrice
            };

            public static readonly Product validProduct2 = new Product()
            {
                ProductName = Billy2Name,
                ProductTypeId = Billy2ProductTypeId,
                BrandId = Billy2BrandId,
                Description = Billy2Description,
                PhotoURL = Billy2ImageURL,
                HighLightVideoURL = Billy2VideoURL,
                AdditionalInfoURL = Billy2AdditionalInfo,
                Price = Billy2Price
            };

            public static readonly Product invalidProduct1 = new Product()
            {
                ProductName = Billy3Name,
                ProductTypeId = BillyProductTypeId,
                BrandId = BillyBrandId,
                Description = BillyDescription,
                PhotoURL = BillyImageURL,
                AdditionalInfoURL = BillyAdditionalInfo,
                Price = BillyPrice
            };

            public static readonly Product invalidProduct2 = new Product()
            {
                ProductName = Billy4Name,
                ProductTypeId = BillyProductTypeId,
                BrandId = BillyBrandId,
                PhotoURL = BillyImageURL,
                Price = BillyPrice
            };

            public static readonly ProductType productType1 = new ProductType() { TypeName = TypeName };
            public static readonly ProductType productType2 = new ProductType() { TypeName = Type2Name };

            public static readonly ProductType brandType1 = new ProductType() { TypeName = BrandTypeName };
            public static readonly ProductType brandType2 = new ProductType() { TypeName = BrandType2Name };

            public static readonly Brand brand1 = new Brand()
            {
                BrandName = IKEAName,
                BrandDescription = IKEADescription,
                BrandImageURL = IKEAImageURL,
                AdditionalInfoURL = IKEAAdditionalInfo,
                BrandTypeId = IKEABrandTypeId
            };

            public static readonly Brand brand2 = new Brand()
            {
                BrandName = IKEA2Name,
                BrandDescription = IKEA2Description,
                BrandImageURL = IKEA2ImageURL,
                AdditionalInfoURL = IKEA2AdditionalInfo,
                BrandTypeId = IKEA2BrandTypeId
            };

           
        }

        public class Helpers
        {
            //Helpers
            public const string VideoInputURL = "https://www.youtube.com/watch?v=qNIIMQPGq-0";
            public const string ForbiddenSymbolsInput = "<sometext>";

            public const string VideoExpectedOutputURL = "https://www.youtube.com/embed/qNIIMQPGq-0";
            public const string ForbiddenSymbolsExpectedOutput = "&lt;sometext&gt;";
        }

        public class Users
        {
            public const string Email = "mail@ask.bg";
            public const string UserName = "someguy";
            public const string PasswordHash = "pass";
            public const string FullName = "Some cool guy";

            public const bool TrueSuffix = true;
            public const bool FalseSuffix = false;
        }
    }
}
