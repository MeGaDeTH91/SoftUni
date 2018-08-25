namespace MyBlog.CommonModels.ViewModels.Brands
{
    using System.Collections.Generic;

    public class BrandTypeViewModel
    {
        public string BrandTypeName { get; set; }

        public ICollection<BrandConciseViewModel> Brands { get; set; }
    }
}
