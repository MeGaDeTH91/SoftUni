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
    using MyBlog.CommonModels.BindingModels.Music.Songs;
    using MyBlog.CommonModels.ViewModels.Music.Artists;
    using MyBlog.CommonModels.ViewModels.Music.Songs;
    using MyBlog.Data;
    using MyBlog.Models.Music.Songs;
    using MyBlog.Models.Users;
    using MyBlog.Services.Interfaces;

    public class SongService : BaseBlogService, ISongService
    {
        public SongService(BlogDataDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public bool AddToFavourites(string userId, int songId)
        {
            var user = this.DbContext
                .Users
                .FirstOrDefault(x => x.Id == userId);

            var song = this.DbContext
                .Songs
                .FirstOrDefault(x => x.Id == songId);

            if (user == null || song == null)
            {
                return false;
            }

            var userSong = new UserSongs()
            {
                UserId = userId,
                SongId = songId,
                AddedToFavouritesOn = DateTime.UtcNow
            };

            bool alreadyInFavourites = this.DbContext.FavouriteUserSongs
                .Any(x => x.UserId == userId && x.SongId == songId);

            if (alreadyInFavourites)
            {
                return false;
            }

            user.FavouriteSongs.Add(userSong);
            this.DbContext.SaveChanges();

            return true;
        }

        public async Task<int> AddSongAsync(AddSongBindingModel model)
        {
            var checkForDuplicate = this.DbContext
                .Songs
                .FirstOrDefault(x => x.SongName == model.SongName);

            if (checkForDuplicate != null)
            {
                return ErrorId;
            }

            var song = this.Mapper.Map<Song>(model);

            if (song.HighLightVideoURL.Contains(CommonConstants.OriginalVideoUrlPart))
            {
                song.HighLightVideoURL = ModifyVideoURL_Embeded.ModifyEmbed(song.HighLightVideoURL);
            }

            await this.DbContext.Songs.AddAsync(song);
            await this.DbContext.SaveChangesAsync();

            return song.Id;
        }

        public async Task<int> AddSongGenreAsync(AddSongGenreBindingModel model)
        {
            var existingType = this.DbContext
                .SongGenres
                .FirstOrDefault(x => x.GenreName == model.GenreName);

            if (existingType != null)
            {
                return ErrorId;
            }

            var songGenre = this.Mapper.Map<SongGenre>(model);

            await this.DbContext.SongGenres.AddAsync(songGenre);
            await this.DbContext.SaveChangesAsync();

            return songGenre.Id;
        }
        
        public async Task<bool> DeleteSongAsync(int id)
        {
            var song = this.DbContext
                .Songs
                .FirstOrDefault(x => x.Id == id);

            if (song == null)
            {
                return false;
            }

            this.DbContext.Songs.Remove(song);

            await this.DbContext.SaveChangesAsync();

            return true;
        }

        public async Task<int> EditSongAsync(EditSongBindingModel model)
        {
            var song = this.DbContext
                .Songs
                .FirstOrDefault(x => x.Id == model.Id);

            if (song == null)
            {
                return ErrorId;
            }

            song.Description = model.Description;
            song.PhotoURL = model.PhotoURL;
            song.HighLightVideoURL = model.HighLightVideoURL;
            song.AdditionalInfoURL = model.AdditionalInfoURL;

            if (song.HighLightVideoURL.Contains(CommonConstants.OriginalVideoUrlPart))
            {
                song.HighLightVideoURL = ModifyVideoURL_Embeded.ModifyEmbed(song.HighLightVideoURL);
            }

            await this.DbContext.SaveChangesAsync();

            return song.Id;
        }

        public AddSongBindingModel GetAllArtistsAndSongGenres()
        {
            var artists = this.DbContext
                .Artists
                .Select(this.Mapper.Map<ArtistConciseViewModel>)
                .ToList();

            var songGenres = this.DbContext
                .SongGenres
                .Select(this.Mapper.Map<SongGenreViewModel>)
                .ToList();

            var artistsQuery = artists.Select(b => new SelectListItem() { Text = b.FullName, Value = b.Id.ToString() });

            var songGenresQuery = songGenres.Select(b => new SelectListItem() { Text = b.GenreName, Value = b.Id.ToString() });

            var model = new AddSongBindingModel()
            {
                AllArtists = artistsQuery.ToList(),
                AllSongGenres = songGenresQuery
            };

            return model;
        }

        public ICollection<SongConciseViewModel> GetAllSongs()
        {
            var songs = this.DbContext
                .Songs
                .Select(this.Mapper.Map<SongConciseViewModel>)
                .ToList();

            return songs;
        }

        public SongDetailsViewModel GetSong(int id)
        {
            var actualSong = this.DbContext
                .Songs
                .Include(x => x.Artist)
                .Include(x => x.SongGenre)
                .Include(x => x.AddedToFavoritesBy)
                .FirstOrDefault(x => x.Id == id);

            if (actualSong == null)
            {
                return null;
            }

            var song = this.Mapper.Map<SongDetailsViewModel>(actualSong);

            return song;
        }

        public SongGenreViewModel GetSongGenre(int id)
        {
            var songGenre = this.DbContext
                .SongGenres
                .Include(x => x.Songs)
                .FirstOrDefault(x => x.Id == id);

            if (songGenre == null)
            {
                return null;
            }

            var songGenreModel = new SongGenreViewModel()
            {
                GenreName = songGenre.GenreName,
                Songs = this.Mapper.Map<ICollection<SongConciseViewModel>>(songGenre.Songs)
            };

            return songGenreModel;
        }
    }
}
