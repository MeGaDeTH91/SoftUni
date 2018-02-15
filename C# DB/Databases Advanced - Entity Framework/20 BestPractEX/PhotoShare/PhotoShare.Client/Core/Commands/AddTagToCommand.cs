namespace PhotoShare.Client.Core.Commands
{
    using Microsoft.EntityFrameworkCore;
    using PhotoShare.Client.Utilities;
    using PhotoShare.Data;
    using PhotoShare.Models;
    using System;
    using System.Linq;

    public class AddTagToCommand 
    {
        // AddTagTo <albumName> <tag>
        public static string Execute(string[] data)
        {
            string albumName = data[1];
            string tagName = data[2].ValidateOrTransform();

            using (PhotoShareContext context = new PhotoShareContext())
            {
                var album = context.Albums
                    .Include(x => x.AlbumTags)
                    .Include(x => x.AlbumRoles)
                    .ThenInclude(x => x.User)
                    .Where(x => x.Name == albumName)
                    .FirstOrDefault();

                var tag = context.Tags
                    .Where(x => x.Name == tagName)
                    .FirstOrDefault();

                if (album == null ||
                    tag == null)
                {
                    throw new ArgumentException($"Either tag or album do not exist!");
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

                AlbumTag at = new AlbumTag()
                {
                    Album = album,
                    Tag = tag
                };

                context.AlbumTags.Add(at);
                context.SaveChanges();
            }

            return $"Tag {tagName} added to {albumName}!";
        }
    }
}
