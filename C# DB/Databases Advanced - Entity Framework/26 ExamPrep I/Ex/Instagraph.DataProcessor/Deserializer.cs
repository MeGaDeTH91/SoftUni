namespace Instagraph.DataProcessor
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;
    using System.Xml.Linq;

    using Newtonsoft.Json;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;

    using Instagraph.Data;
    using Instagraph.Models;
    using Instagraph.DataProcessor.DtoModels;

    public class Deserializer
    {
        private static string errorMessage = "Error: Invalid data.";
        private static string successMessage = "Successfully imported {0}.";

        public static string ImportPictures(InstagraphContext context, string jsonString)
        {
            Picture[] pictures = JsonConvert.DeserializeObject<Picture[]>(jsonString);
            StringBuilder sb = new StringBuilder();

            var validPictures = new List<Picture>();

            foreach (var pic in pictures)
            {
                bool isValid = !String.IsNullOrWhiteSpace(pic.Path) && pic.Size > 0;

                bool pictureExists = context.Pictures.Any(x => x.Path == pic.Path) || validPictures.Any(x => x.Path == pic.Path);

                if(!isValid || pictureExists)
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }
                validPictures.Add(pic);
                sb.AppendLine(String.Format(successMessage, $"Picture {pic.Path}"));
            }
            context.Pictures.AddRange(validPictures);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportUsers(InstagraphContext context, string jsonString)
        {            
            UserDto[] users = JsonConvert.DeserializeObject<UserDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            var validUsers = new List<User>();

            foreach (var userDto in users)
            {
                bool fieldsAreValid = !String.IsNullOrWhiteSpace(userDto.ProfilePicture) &&
                    !String.IsNullOrWhiteSpace(userDto.Username) &&
                    !String.IsNullOrWhiteSpace(userDto.Password) &&
                    userDto.Username.Length <= 30 && userDto.Password.Length <= 20;

                bool userExists = context.Users.Any(x => x.Username == userDto.Username) ||
                    validUsers.Any(x => x.Username == userDto.Username);

                var picture = context.Pictures.FirstOrDefault(x => x.Path == userDto.ProfilePicture);

                if(!fieldsAreValid || userExists || picture == null)
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }
                var user = Mapper.Map<User>(userDto);
                user.ProfilePicture = picture;

                validUsers.Add(user);

                sb.AppendLine(String.Format(successMessage, $"User {userDto.Username}"));
            }
            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportFollowers(InstagraphContext context, string jsonString)
        {
            UserFollowerDto[] deserializedFollowers = JsonConvert.DeserializeObject<UserFollowerDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            var userFollowers = new List<UserFollower>();

            foreach (var dto in deserializedFollowers)
            {
                var user = context.Users
                    .FirstOrDefault(x => x.Username == dto.User);
                var follower = context.Users
                    .FirstOrDefault(x => x.Username == dto.Follower);

                bool bothExist = user != null && follower != null;
                

                if(!bothExist)
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                bool alreadyFollower = userFollowers.Any(x => x.UserId == user.Id && x.FollowerId == follower.Id);
                if (alreadyFollower)
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                var userFollower = new UserFollower()
                {
                    UserId = user.Id,
                    FollowerId = follower.Id
                };

                userFollowers.Add(userFollower);
                sb.AppendLine(String.Format(successMessage, $"Follower {dto.Follower} to User {dto.User}"));
            }
            context.UsersFollowers.AddRange(userFollowers);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportPosts(InstagraphContext context, string xmlString)
        {
            var xDoc = XDocument.Parse(xmlString);

            var elements = xDoc.Root.Elements();

            StringBuilder sb = new StringBuilder();

            var posts = new List<Post>();

            foreach (var element in elements)
            {
                string caption = element.Element("caption")?.Value;
                string username = element.Element("user")?.Value;
                string picturePath = element.Element("picture")?.Value;

                bool inputIsValid = !String.IsNullOrWhiteSpace(caption) &&
                    !String.IsNullOrWhiteSpace(username) &&
                    !String.IsNullOrWhiteSpace(picturePath);

                if (!inputIsValid)
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                int? userId = context.Users.FirstOrDefault(x => x.Username == username)?.Id;
                int? pictureId = context.Pictures.FirstOrDefault(x => x.Path == picturePath)?.Id;

                if(userId == null || pictureId == null)
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                var post = new Post()
                {
                    Caption = caption,
                    UserId = userId.Value,
                    PictureId = pictureId.Value
                };

                posts.Add(post);
                sb.AppendLine(String.Format(successMessage, $"Post {caption}"));
            }
            context.Posts.AddRange(posts);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportComments(InstagraphContext context, string xmlString)
        {
            var xDoc = XDocument.Parse(xmlString);

            var elements = xDoc.Root.Elements();

            StringBuilder sb = new StringBuilder();

            var comments = new List<Comment>();

            foreach (var element in elements)
            {
                string content = element.Element("content")?.Value;
                string username = element.Element("user")?.Value;
                string postIdStr = element.Element("post")?.Attribute("id")?.Value;

                
                bool isInputValid = !String.IsNullOrWhiteSpace(content) &&
                    !String.IsNullOrWhiteSpace(username) &&
                    !String.IsNullOrWhiteSpace(postIdStr);

                if (!isInputValid)
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                int? postId = int.Parse(postIdStr);
                int? userId = context.Users.FirstOrDefault(x => x.Username == username)?.Id;

                bool postExist = context.Posts.Any(x => x.Id == postId);

                bool userExists = userId != null;

                if (!userExists || !postExist)
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                var comment = new Comment()
                {
                    Content = content,
                    UserId = userId.Value,
                    PostId = postId.Value
                };
                comments.Add(comment);
                sb.AppendLine(String.Format(successMessage, $"Comment {content}"));
            }
            context.AddRange(comments);
            context.SaveChanges();

            return sb.ToString().Trim();
        }
    }
}
