namespace MyBlog.CommonModels.ViewModels.Music.Instruments
{
    using System.Collections.Generic;
    using MyBlog.CommonModels.ViewModels.Brands;
    using MyBlog.Models.Users;

    public class InstrumentDetailsViewModel
    {
        public string ModelName { get; set; }

        public int BrandId { get; set; }

        public BrandConciseViewModel Brand { get; set; }
        
        public string PhotoURL { get; set; }
        
        public string HighLightVideoURL { get; set; }
        
        public string AdditionalInfoURL { get; set; }
        
        public string Description { get; set; }
        
        public int InstrumentTypeId { get; set; }

        public InstrumentTypeViewModel InstrumentType { get; set; }

        public ICollection<UserInstruments> AddedToFavoritesBy { get; set; }
    }
}
