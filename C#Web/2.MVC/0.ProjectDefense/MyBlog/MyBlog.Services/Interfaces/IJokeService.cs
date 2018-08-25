namespace MyBlog.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MyBlog.CommonModels.BindingModels.Fun;
    using MyBlog.CommonModels.ViewModels.Fun;

    public interface IJokeService
    {
        bool AddToFavourites(string userId, int jokeId);

        ICollection<JokeConciseViewModel> GetAllJokes();

        JokeDetailsViewModel GetJoke(int id);

        Task<int> AddJokeAsync(AddJokeBindingModel model);

        Task<int> EditJokeAsync(EditJokeBindingModel model);

        Task<bool> DeleteJokeAsync(int id);
    }
}
