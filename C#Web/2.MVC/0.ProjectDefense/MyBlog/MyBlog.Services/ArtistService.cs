namespace MyBlog.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using MyBlog.Common;
    using MyBlog.Common.Helpers;
    using MyBlog.CommonModels.BindingModels.Music.Artists;
    using MyBlog.CommonModels.ViewModels.Music.Artists;
    using MyBlog.Data;
    using MyBlog.Models.Music.Artists;
    using MyBlog.Models.Users;
    using MyBlog.Services.Interfaces;

    public class ArtistService : BaseBlogService, IArtistService
    {
        public ArtistService(BlogDataDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public bool AddToFavourites(string userId, int artistId)
        {
            var user = this.DbContext
                .Users
                .FirstOrDefault(x => x.Id == userId);

            var artist = this.DbContext
                .Artists
                .FirstOrDefault(x => x.Id == artistId);

            if (user == null || artist == null)
            {
                return false;
            }

            var userArtist = new UserArtists()
            {
                UserId = userId,
                ArtistId = artistId,
                AddedToFavouritesOn = DateTime.UtcNow
            };

            bool alreadyInFavourites = this.DbContext.FavouriteUserArtists
                .Any(x => x.UserId == userId && x.ArtistId == artistId);

            if (alreadyInFavourites)
            {
                return false;
            }

            user.FavouriteArtists.Add(userArtist);
            this.DbContext.SaveChanges();

            return true;
        }

        public async Task<int> AddArtistAsync(AddArtistBindingModel model)
        {
            var checkForDuplicate = this.DbContext
                .Artists
                .FirstOrDefault(x => x.FullName == model.FullName);

            if (checkForDuplicate != null)
            {
                return ErrorId;
            }

            var artist = this.Mapper.Map<Artist>(model);

            if (artist.HighLightVideoURL.Contains(CommonConstants.OriginalVideoUrlPart))
            {
                artist.HighLightVideoURL = ModifyVideoURL_Embeded.ModifyEmbed(artist.HighLightVideoURL);
            }

            await this.DbContext.Artists.AddAsync(artist);
            await this.DbContext.SaveChangesAsync();

            return artist.Id;
        }

        public async Task<int> AddArtistTypeAsync(AddArtistTypeBindingModel model)
        {
            var existingType = this.DbContext
                .ArtistTypes
                .FirstOrDefault(x => x.ArtistTypeName == model.ArtistTypeName);

            if (existingType != null)
            {
                return ErrorId;
            }

            var type = this.Mapper.Map<ArtistType>(model);

            await this.DbContext.ArtistTypes.AddAsync(type);
            await this.DbContext.SaveChangesAsync();

            return type.Id;
        }
        
        public async Task<bool> DeleteArtistAsync(int id)
        {
            var artist = this.DbContext
                .Artists
                .FirstOrDefault(x => x.Id == id);

            if (artist == null)
            {
                return false;
            }

            this.DbContext.Artists.Remove(artist);

            await this.DbContext.SaveChangesAsync();

            return true;
        }

        public async Task<int> EditArtistAsync(EditArtistBindingModel model)
        {
            var artist = this.DbContext
                .Artists
                .FirstOrDefault(x => x.Id == model.Id);

            if (artist == null)
            {
                return ErrorId;
            }
            
            artist.Description = model.Description;
            artist.PhotoURL = model.PhotoURL;
            artist.HighLightVideoURL = model.HighLightVideoURL;
            artist.AdditionalInfoURL = model.AdditionalInfoURL;

            if (artist.HighLightVideoURL.Contains(CommonConstants.OriginalVideoUrlPart))
            {
                artist.HighLightVideoURL = ModifyVideoURL_Embeded.ModifyEmbed(artist.HighLightVideoURL);
            }

            await this.DbContext.SaveChangesAsync();

            return artist.Id;
        }

        public ICollection<ArtistConciseViewModel> GetAllArtists()
        {
            var artists = this.DbContext
                .Artists
                .Select(this.Mapper.Map<ArtistConciseViewModel>)
                .ToList();

            return artists;
        }

        public AddArtistBindingModel GetAllArtistTypes()
        {
            var artistTypes = this.DbContext
                .ArtistTypes
                .Select(this.Mapper.Map<ArtistTypeViewModel>)
                .ToList();

            var artistTypesQuery = artistTypes.Select(b => new SelectListItem() { Text = b.ArtistTypeName, Value = b.Id.ToString() });

            var model = new AddArtistBindingModel()
            {
                AllArtistTypes = artistTypesQuery.ToList()
            };

            return model;
        }

        public ArtistDetailsViewModel GetArtist(int id)
        {
            var actualArtist = this.DbContext
                .Artists
                .Include(x => x.ArtistType)
                .Include(x => x.Songs)
                .Include(x => x.AddedToFavoritesBy)
                .FirstOrDefault(x => x.Id == id);

            if (actualArtist == null)
            {
                return null;
            }

            var artist = this.Mapper.Map<ArtistDetailsViewModel>(actualArtist);

            return artist;
        }

        public ArtistTypeViewModel GetArtistType(int id)
        {
            var artistType = this.DbContext
                .ArtistTypes
                .Include(x => x.Artists)
                .FirstOrDefault(x => x.Id == id);

            if (artistType == null)
            {
                return null;
            }

            var artistTypeModel = new ArtistTypeViewModel()
            {
                ArtistTypeName = artistType.ArtistTypeName,
                Artists = this.Mapper.Map<ICollection<ArtistConciseViewModel>>(artistType.Artists)
            };

            return artistTypeModel;
        }
    }
}
