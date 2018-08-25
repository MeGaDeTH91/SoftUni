namespace MyBlog.Services.Interfaces
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using MyBlog.CommonModels.ViewModels.Music.Instruments;
    using MyBlog.CommonModels.BindingModels.Music.Instruments;

    public interface IInstrumentService
    {
        bool AddToFavourites(string userId, int instrumentId);

        ICollection<InstrumentConciseViewModel> GetAllInstruments();

        AddInstrumentBindingModel GetAllBrandsAndInstrumentTypes();

        InstrumentDetailsViewModel GetInstrument(int id);

        InstrumentTypeViewModel GetInstrumentType(int id);

        Task<int> AddInstrumentAsync(AddInstrumentBindingModel model);

        Task<int> EditInstrumentAsync(EditInstrumentBindingModel model);

        Task<bool> DeleteInstrumentAsync(int id);

        Task<int> AddInstrumentTypeAsync(AddInstrumentTypeBindingModel model);
    }
}
