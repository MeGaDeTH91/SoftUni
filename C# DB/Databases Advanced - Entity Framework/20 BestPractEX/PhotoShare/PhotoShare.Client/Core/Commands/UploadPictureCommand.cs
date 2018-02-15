namespace PhotoShare.Client.Core.Commands
{
    using Microsoft.EntityFrameworkCore;
    using PhotoShare.Data;
    using PhotoShare.Models;
    using System;
    using System.Linq;

    public class UploadPictureCommand
    {
        // UploadPicture <albumName> <pictureTitle> <pictureFilePath>
        public static string Execute(string[] data)
        {
            string albumName = data[1];
            string picTitle = data[2];
            string picPath = data[3];

            string result = string.Empty;

            using(var context = new PhotoShareContext())
            {
                Album album = context.Albums
                    .Include(x => x.AlbumRoles)
                    .ThenInclude(ar => ar.User)
                    .FirstOrDefault(x => x.Name == albumName);

                if(album == null)
                {
                    throw new ArgumentException($"Album {albumName} not found!");
                }

                if (Session.User == null)
                {
                    throw new InvalidOperationException($"Invalid credentials!");
                }

                bool isOwner = album.AlbumRoles.Any(ar => ar.Role == Role.Owner &&
                ar.User.Username == Session.User.Username);

                if (!isOwner)
                {
                    throw new InvalidOperationException($"Invalid credentials!");
                }

                Picture currPic = new Picture()
                {
                    Title = picTitle,
                    Path = picPath
                };
                album.Pictures.Add(currPic);
                context.SaveChanges();

                result = $"Picture {picTitle} added to {albumName}!";
            }

            return result;
        }
    }
}
