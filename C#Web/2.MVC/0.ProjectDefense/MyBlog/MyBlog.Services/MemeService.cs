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

    public class MemeService : BaseBlogService, IMemeService
    {
        public MemeService(BlogDataDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public bool AddToFavourites(string userId, int memeId)
        {
            var user = this.DbContext
                .Users
                .FirstOrDefault(x => x.Id == userId);

            var meme = this.DbContext
                .Memes
                .FirstOrDefault(x => x.Id == memeId);

            if (user == null || meme == null)
            {
                return false;
            }

            var userMeme = new UserMemes()
            {
                UserId = userId,
                MemeId = memeId,
                AddedToFavouritesOn = DateTime.UtcNow
            };

            bool alreadyInFavourites = this.DbContext.FavouriteUserMemes
                .Any(x => x.UserId == userId && x.MemeId == memeId);

            if (alreadyInFavourites)
            {
                return false;
            }

            user.FavouriteMemes.Add(userMeme);
            this.DbContext.SaveChanges();

            return true;
        }

        public async Task<int> AddMemeAsync(AddMemeBindingModel model)
        {
            var checkForDuplicate = this.DbContext
                .Memes
                .FirstOrDefault(x => x.Title == model.Title);

            if (checkForDuplicate != null)
            {
                return ErrorId;
            }

            var meme = this.Mapper.Map<Meme>(model);

            meme.Title = Html_String_Utility.EncodeThisPropertyForMe(meme.Title);
            meme.PhotoURL = Html_String_Utility.EncodeThisPropertyForMe(meme.PhotoURL);

            await this.DbContext.Memes.AddAsync(meme);
            await this.DbContext.SaveChangesAsync();

            return meme.Id;
        }
        
        public async Task<bool> DeleteMemeAsync(int id)
        {
            var meme = this.DbContext
                .Memes
                .FirstOrDefault(x => x.Id == id);

            if (meme == null)
            {
                return false;
            }

            this.DbContext.Memes.Remove(meme);

            await this.DbContext.SaveChangesAsync();

            return true;
        }

        public async Task<int> EditMemeAsync(EditMemeBindingModel model)
        {
            var meme = this.DbContext
                .Memes
                .FirstOrDefault(x => x.Id == model.Id);

            if (meme == null)
            {
                return ErrorId;
            }
            
            meme.Title = model.Title;
            meme.PhotoURL = model.PhotoURL;

            meme.Title = Html_String_Utility.EncodeThisPropertyForMe(meme.Title);
            meme.PhotoURL = Html_String_Utility.EncodeThisPropertyForMe(meme.PhotoURL);
            
            await this.DbContext.SaveChangesAsync();

            return meme.Id;
        }

        public ICollection<MemeConciseViewModel> GetAllMemes()
        {
            var memes = this.DbContext
                .Memes
                .Select(this.Mapper.Map<MemeConciseViewModel>)
                .ToList();

            memes.ForEach(x => x.Title = Html_String_Utility.DecodeThisPropertyForMe(x.Title));
            memes.ForEach(x => x.PhotoURL = Html_String_Utility.DecodeThisPropertyForMe(x.PhotoURL));

            return memes;
        }

        public MemeDetailsViewModel GetMeme(int id)
        {
            var actualMeme = this.DbContext
                .Memes
                .Include(x => x.AddedToFavoritesBy)
                .FirstOrDefault(x => x.Id == id);

            if (actualMeme == null)
            {
                return null;
            }

            var meme = this.Mapper.Map<MemeDetailsViewModel>(actualMeme);

            meme.Title = Html_String_Utility.DecodeThisPropertyForMe(meme.Title);
            meme.PhotoURL = Html_String_Utility.DecodeThisPropertyForMe(meme.PhotoURL);

            return meme;
        }
    }
}
