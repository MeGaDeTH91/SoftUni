namespace MyLibrary.Web.ViewModels
{
    using System.Collections.Generic;

    public class MovieStatusViewModel
    {
        public string MovieTitle { get; set; }
        
        public IEnumerable<StartEndDateModel> DateHistory { get; set; }
    }
}
