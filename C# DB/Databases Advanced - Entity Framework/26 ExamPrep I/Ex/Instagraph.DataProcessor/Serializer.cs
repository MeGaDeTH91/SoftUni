using System;

using Instagraph.Data;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Instagraph.DataProcessor.DtoModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Instagraph.DataProcessor
{
    public class Serializer
    {
        public static string ExportUncommentedPosts(InstagraphContext context)
        {
            var postDtos = context.Posts
                .Where(x => !x.Comments.Any())
                .ProjectTo<UncommentedPostsDto>()
                .ToList()
                .OrderBy(x => x.Id);

            string jsonString = JsonConvert.SerializeObject(postDtos);

            return jsonString;
        }

        public static string ExportPopularUsers(InstagraphContext context)
        {
            var users = context.Users
                .Where(u => u.Posts
                .Any(p => p.Comments
                .Any(c => u.Followers
                .Any(f => f.FollowerId == c.UserId))))
                .OrderBy(x => x.Id)
                .ProjectTo<PopularUserDto>()
                .ToList();

            string jsonString = JsonConvert.SerializeObject(users);

            return jsonString;
        }

        public static string ExportCommentsOnPosts(InstagraphContext context)
        {
            var users = context.Users
                .Select(x => new
                {
                    Username = x.Username,
                    MostComments = x.Posts.Select(y => y.Comments.Count).ToArray()
                });

            var userDtos = new List<UserTopPostDto>();

            var xDoc = new XDocument();

            xDoc.Add(new XElement("users"));

            foreach (var us in users)
            {
                int commentNum = 0;
                if (us.MostComments.Any())
                {
                    commentNum = us.MostComments.OrderByDescending(x => x).First();
                }

                var userDto = new UserTopPostDto()
                {
                    Username = us.Username,
                    MostComments = commentNum
                };
                userDtos.Add(userDto);
            }

            userDtos = userDtos.OrderByDescending(x => x.MostComments)
                .ThenBy(x => x.Username).ToList();

            foreach (var usDto in userDtos)
            {
                xDoc.Root.Add(new XElement("user",
                    new XElement("Username", usDto.Username),
                    new XElement("MostComments", usDto.MostComments)));

            }
            string result = xDoc.ToString();

            return result;
        }
    }
}
