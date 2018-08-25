namespace MyBlog.Services.Interfaces
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using MyBlog.CommonModels.ViewModels.Fun;
    using MyBlog.CommonModels.BindingModels.Fun;

    public interface IMemeService
    {
        bool AddToFavourites(string userId, int memeId);

        ICollection<MemeConciseViewModel> GetAllMemes();

        MemeDetailsViewModel GetMeme(int id);

        Task<int> AddMemeAsync(AddMemeBindingModel model);

        Task<int> EditMemeAsync(EditMemeBindingModel model);

        Task<bool> DeleteMemeAsync(int id);
    }
}
