namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Client.Utilities;
    using PhotoShare.Data;
    using PhotoShare.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CreateAlbumCommand
    {
        // CreateAlbum <username> <albumTitle> <BgColor> <tag1> <tag2>...<tagN>
        public static string Execute(string[] data)
        {
            string username = data[1];
            string albumTitle = data[2];
            string bgColor = data[3];
            List<string> tags = data.Skip(4).Select(x => x.ValidateOrTransform()).ToList();
            bool tagsAreValid = true;

            

            using (var context = new PhotoShareContext())
            {
                var user = context.Users
                    .Where(x => x.Username == username)
                    .FirstOrDefault();

                if (user == null)
                {
                    throw new ArgumentException($"User {username} not found!");
                }
                if (context.Albums.Any(x => x.Name == albumTitle))
                {
                    throw new ArgumentException($"Album {albumTitle} exists!");
                }

                if (Session.User == null || username != Session.User.Username)
                {
                    throw new InvalidOperationException($"Invalid credentials!");
                }

                Color color;
                if (!Enum.TryParse(bgColor, out color))
                {
                    throw new ArgumentException($"Color {bgColor} not found!");
                }

                var tagList = context.Tags.ToList();

                foreach (var t in tags)
                {
                    if(!tagList.Select(x => x.Name).Contains(t))
                    {
                        tagsAreValid = false;
                        break;
                    }
                }
                if (!tagsAreValid)
                {
                    throw new ArgumentException($"Invalid tags!");
                }

                Album newAlbum = new Album()
                {
                    Name = albumTitle,
                    BackgroundColor = color,
                    AlbumRoles = new List<AlbumRole>()
                    {
                        new AlbumRole
                        {
                            User = user,
                            Role = Role.Owner
                        }
                    },
                    AlbumTags = tags.Select(x =>  new AlbumTag()
                    {
                        Tag = context.Tags.FirstOrDefault(ct => ct.Name == x)
                    }).ToArray()
                };
                context.Albums.Add(newAlbum);
                context.SaveChanges();
            }

            return $"Album {albumTitle} successfully created!";
        }
    }
}
