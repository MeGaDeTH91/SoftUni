namespace PhotoShare.Client.Core.Commands
{
    using Microsoft.EntityFrameworkCore;
    using PhotoShare.Data;
    using PhotoShare.Models;
    using System;
    using System.Linq;

    public class ShareAlbumCommand
    {
        // ShareAlbum <albumId> <username> <permission>
        // For example:
        // ShareAlbum 4 dragon321 Owner
        // ShareAlbum 4 dragon11 Viewer
        public static string Execute(string[] data)
        {
            int albumId = int.Parse(data[1]);
            string username = data[2];
            string permission = data[3];

            string result = string.Empty;

            using(var context = new PhotoShareContext())
            {
                Album album = context.Albums
                    .Include(x => x.AlbumRoles)
                    .ThenInclude(xy => xy.User)
                    .FirstOrDefault(x => x.Id == albumId);

                if(album == null)
                {
                    throw new ArgumentException($"Album {albumId} not found!");
                }

                var user = context.Users
                    .Where(x => x.Username == username)
                    .FirstOrDefault();

                if(user == null)
                {
                    throw new ArgumentException($"User {username} not found!");
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

                if (album.AlbumRoles.Any(x => x.User == user))
                {
                    AlbumRole currAR = album.AlbumRoles.Where(x => x.User == user).FirstOrDefault();
                    Role currRole = currAR.Role;
                    if(currRole == Role.Viewer)
                    {
                        throw new ArgumentException($"User {username} is already a viewer to this album");
                    }
                    else if(currRole == Role.Owner)
                    {
                        throw new ArgumentException($"User {username} is already an owner to this album");
                    }
                    
                }
                Role role = new Role();

                if(permission.ToLower() == "owner")
                {

                    role = Role.Owner;
                    result = $"Username {username} added to album {album.Name} ({permission})";
                }
                else if(permission.ToLower() == "viewer")
                {
                    role = Role.Viewer;                 

                    result = $"Username {username} added to album {album.Name} ({permission})";
                }
                else
                {
                    throw new ArgumentException($"Permission must be either “Owner” or “Viewer”!");
                }
                AlbumRole albRole = new AlbumRole()
                {
                    AlbumId = album.Id,
                    UserId = user.Id,
                    Role = role
                };
                album.AlbumRoles.Add(albRole);
                context.SaveChanges();
            }

            return result;
        }
    }
}
