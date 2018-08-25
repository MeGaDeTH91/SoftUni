namespace MyBlog.CommonModels.ViewModels.Reviews
{
    using System.Collections.Generic;

    public class ReviewTypeViewModel
    {
        public int Id { get; set; }
        
        public string ReviewTypeName { get; set; }

        public ICollection<ReviewConciseViewModel> Reviews { get; set; }
    }
}
