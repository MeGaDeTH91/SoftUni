namespace MyBlog.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using MyBlog.App.Helpers.HtmlUtilities;
    using MyBlog.CommonModels.BindingModels.Fun;
    using MyBlog.CommonModels.ViewModels.Fun;
    using MyBlog.Data;
    using MyBlog.Models.Fun;
    using MyBlog.Models.Users;
    using MyBlog.Services.Interfaces;

    public class JokeService : BaseBlogService, IJokeService
    {
        public JokeService(BlogDataDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public bool AddToFavourites(string userId, int jokeId)
        {
            var user = this.DbContext
                .Users
                .FirstOrDefault(x => x.Id == userId);

            var joke = this.DbContext
                .Jokes
                .FirstOrDefault(x => x.Id == jokeId);

            if (user == null || joke == null)
            {
                return false;
            }

            var userJoke = new UserJokes()
            {
                UserId = userId,
                JokeId = jokeId,
                AddedToFavouritesOn = DateTime.UtcNow
            };

            bool alreadyInFavourites = this.DbContext.FavouriteUserJokes
                .Any(x => x.UserId == userId && x.JokeId == jokeId);

            if (alreadyInFavourites)
            {
                return false;
            }

            user.FavouriteJokes.Add(userJoke);
            this.DbContext.SaveChanges();

            return true;
        }

        public async Task<int> AddJokeAsync(AddJokeBindingModel model)
        {
            var checkForDuplicate = this.DbContext
                .Jokes
                .FirstOrDefault(x => x.Title == model.Title);

            if (checkForDuplicate != null)
            {
                return ErrorId;
            }

            var joke = this.Mapper.Map<Joke>(model);

            joke.Title = Html_String_Utility.EncodeThisPropertyForMe(joke.Title);
            joke.PhotoURL = Html_String_Utility.EncodeThisPropertyForMe(joke.PhotoURL);
            joke.Content = Html_String_Utility.EncodeThisPropertyForMe(joke.Content);

            await this.DbContext.Jokes.AddAsync(joke);
            await this.DbContext.SaveChangesAsync();

            return joke.Id;
        }

        public async Task<bool> DeleteJokeAsync(int id)
        {
            var joke = this.DbContext
                .Jokes
                .FirstOrDefault(x => x.Id == id);

            if (joke == null)
            {
                return false;
            }

            this.DbContext.Jokes.Remove(joke);

            await this.DbContext.SaveChangesAsync();

            return true;
        }

        public async Task<int> EditJokeAsync(EditJokeBindingModel model)
        {
            var joke = this.DbContext
                .Jokes
                .FirstOrDefault(x => x.Id == model.Id);

            if (joke == null)
            {
                return ErrorId;
            }

            joke.Title = model.Title;
            joke.Content = model.Content;
            joke.PhotoURL = model.PhotoURL;

            joke.Title = Html_String_Utility.EncodeThisPropertyForMe(joke.Title);
            joke.PhotoURL = Html_String_Utility.EncodeThisPropertyForMe(joke.PhotoURL);
            joke.Content = Html_String_Utility.EncodeThisPropertyForMe(joke.Content);

            await this.DbContext.SaveChangesAsync();

            return joke.Id;
        }

        public ICollection<JokeConciseViewModel> GetAllJokes()
        {
            var jokes = this.DbContext
                .Jokes
                .Select(this.Mapper.Map<JokeConciseViewModel>)
                .ToList();

            jokes.ForEach(x => x.Title = Html_String_Utility.DecodeThisPropertyForMe(x.Title));
            jokes.ForEach(x => x.PhotoURL = Html_String_Utility.DecodeThisPropertyForMe(x.PhotoURL));
            
            return jokes;
        }

        public JokeDetailsViewModel GetJoke(int id)
        {
            var actualJoke = this.DbContext
                .Jokes
                .Include(x => x.AddedToFavoritesBy)
                .FirstOrDefault(x => x.Id == id);

            if (actualJoke == null)
            {
                return null;
            }

            var joke = this.Mapper.Map<JokeDetailsViewModel>(actualJoke);

            joke.Title = Html_String_Utility.DecodeThisPropertyForMe(joke.Title);
            joke.PhotoURL = Html_String_Utility.DecodeThisPropertyForMe(joke.PhotoURL);
            joke.Content = Html_String_Utility.DecodeThisPropertyForMe(joke.Content);

            return joke;
        }
    }
}
