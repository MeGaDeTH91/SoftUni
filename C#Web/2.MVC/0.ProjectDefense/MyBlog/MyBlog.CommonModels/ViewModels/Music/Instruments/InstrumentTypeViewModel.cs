namespace MyBlog.CommonModels.ViewModels.Music.Instruments
{
    using System.Collections.Generic;

    public class InstrumentTypeViewModel
    {
        public int Id { get; set; }
        
        public string TypeName { get; set; }

        public ICollection<InstrumentConciseViewModel> Instruments { get; set; }

    }
}
