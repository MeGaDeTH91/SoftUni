using System;

using Instagraph.Data;
using System.Linq;
using System.Collections.Generic;
using Instagraph.Models;
using Instagraph.DataProcessor.Dto.Export;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using System.Xml.Linq;

namespace Instagraph.DataProcessor
{
    public class Serializer
    {
        public static string ExportUncommentedPosts(InstagraphContext context)
        {
            var posts = context.Posts
                .Include(x => x.Picture)
                .Include(x => x.User)
                .Where(x => !x.Comments.Any())
                .OrderBy(x => x.Id)
                .ToList();

            var exporting = new List<ExpUncomPostsDto>();

            foreach (var post in posts)
            {
                var exp = new ExpUncomPostsDto()
                {
                    Id = post.Id,
                    Picture = post.Picture.Path,
                    User = post.User.Username
                };

                exporting.Add(exp);
            }

            var jsonString = JsonConvert.SerializeObject(exporting);

            return jsonString;
        }

        public static string ExportPopularUsers(InstagraphContext context)
        {
            var userFollow = context.UsersFollowers.ToList();

            var users = context.Users
                .Where(u => u.Posts
                .Any(p => p.Comments
                .Any(c => u.Followers
                .Any(f => f.FollowerId == c.UserId))))
                .OrderBy(x => x.Id)
                .ProjectTo<PopularUserDto>()
                .ToList();

            var jsonString = JsonConvert.SerializeObject(users);

            return jsonString;
        }

        public static string ExportCommentsOnPosts(InstagraphContext context)
        {
            var users = context.Users
                .Include(x => x.Posts)
                .ThenInclude(y => y.Comments)
                .Select(x => new
                {
                    Username = x.Username,
                    MostComments = x.Posts.Select(c => c.Comments.Count).ToArray()
                });

            var userDtos = new List<MostCommentsDto>();

            var xDoc = new XDocument();
            xDoc.Add(new XElement("users"));

            foreach (var user in users)
            {
                string username = user.Username;
                int commentsCount = 0;
                if (user.MostComments.Any())
                {
                    commentsCount = user.MostComments.OrderByDescending(x => x).First();
                }

                var userDto = new MostCommentsDto()
                {
                    Username = user.Username,
                    MostComments = commentsCount
                };

                userDtos.Add(userDto);

                        
            }
            userDtos = userDtos.OrderByDescending(x => x.MostComments)
                    .ThenBy(x => x.Username).ToList();

            foreach (var dto in userDtos)
            {
                xDoc.Root.Add(new XElement("user",
                    new XElement("Username", dto.Username),
                    new XElement("MostComments", dto.MostComments)));
            }

            string result = xDoc.ToString();
            return result;
        }
    }
}
