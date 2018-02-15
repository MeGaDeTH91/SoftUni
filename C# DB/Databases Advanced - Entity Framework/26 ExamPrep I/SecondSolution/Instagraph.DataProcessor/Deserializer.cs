using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;
using Newtonsoft.Json;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Xml.Serialization;
using System.IO;
using Instagraph.Data;
using Instagraph.Models;
using System.ComponentModel.DataAnnotations;
using Instagraph.DataProcessor.Dto.Import;

namespace Instagraph.DataProcessor
{
    public class Deserializer
    {
        private static string errorMessage = "Error: Invalid data.";
        private static string successMessage = "Successfully imported {0}.";

        public static string ImportPictures(InstagraphContext context, string jsonString)
        {
            var deserializedPics = JsonConvert.DeserializeObject<Picture[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            var validPictures = new List<Picture>();

            foreach (var picture in deserializedPics)
            {
                bool picAlreadyExists = validPictures.Any(x => x.Path == picture.Path) ||
                    context.Pictures.Any(x => x.Path == picture.Path);

                if(!IsValid(picture) || picAlreadyExists)
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                validPictures.Add(picture);
                sb.AppendLine(string.Format(successMessage, $"Picture {picture.Path}"));
            }
            context.Pictures.AddRange(validPictures);
            context.SaveChanges();

            string result = sb.ToString().Trim();
            return result;
        }

        public static string ImportUsers(InstagraphContext context, string jsonString)
        {
            var deserializedUsers = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            var validUsers = new List<User>();

            foreach (var user in deserializedUsers)
            {
                bool userAlreadyExists = validUsers.Any(x => x.Username == user.Username) ||
                    context.Users.Any(x => x.Username == user.Username);

                var picture = context.Pictures
                    .FirstOrDefault(x => x.Path == user.ProfilePicture);

                if(!IsValid(user) || userAlreadyExists || picture == null)
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                var currUser = new User()
                {
                    Username = user.Username,
                    Password = user.Password,
                    ProfilePicture = picture
                };

                validUsers.Add(currUser);
                sb.AppendLine(string.Format(successMessage, $"User {user.Username}"));
            }
            context.AddRange(validUsers);
            context.SaveChanges();

            string result = sb.ToString().Trim();
            return result;
        }

        public static string ImportFollowers(InstagraphContext context, string jsonString)
        {
            var deserializedUF = JsonConvert.DeserializeObject<ImportUserFollowerDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            var validUserFollowers = new List<UserFollower>();

            foreach (var userFollowDto in deserializedUF)
            {
                var user = context.Users
                    .FirstOrDefault(x => x.Username == userFollowDto.User);

                var follower = context.Users
                    .FirstOrDefault(x => x.Username == userFollowDto.Follower);

                bool bothExist = user != null && follower != null;

                if(!IsValid(userFollowDto) || !bothExist)
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                bool alreadyFollower = validUserFollowers.Any(x => x.UserId == user.Id &&
                x.FollowerId == follower.Id);

                if (alreadyFollower)
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                var userFollow = new UserFollower()
                {
                    UserId = user.Id,
                    FollowerId = follower.Id
                };
                validUserFollowers.Add(userFollow);
                sb.AppendLine(string.Format(successMessage, $"Follower {follower.Username} to User {user.Username}"));
            }
            context.UsersFollowers.AddRange(validUserFollowers);
            context.SaveChanges();

            string result = sb.ToString().Trim();
            return result;
        }

        public static string ImportPosts(InstagraphContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImpPostDto[]), new XmlRootAttribute("posts"));
            var deserializedPosts = (ImpPostDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            StringBuilder sb = new StringBuilder();

            var validPosts = new List<Post>();

            foreach (var postDto in deserializedPosts)
            {
                var user = context.Users
                    .FirstOrDefault(x => x.Username == postDto.User);

                var picture = context.Pictures
                    .FirstOrDefault(x => x.Path == postDto.Picture);

                bool bothExist = user != null && picture != null;

                if(!IsValid(postDto) || !bothExist)
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                var postAlreadiExists = validPosts.Any(x => x.PictureId == picture.Id && x.Caption == postDto.Caption && x.UserId == user.Id);

                if (postAlreadiExists)
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                var post = new Post()
                {
                    Caption = postDto.Caption,
                    PictureId = picture.Id,
                    UserId = user.Id
                };
                validPosts.Add(post);
                sb.AppendLine(string.Format(successMessage, $"Post {post.Caption}"));
            }
            context.Posts.AddRange(validPosts);
            context.SaveChanges();

            string result = sb.ToString().Trim();
            return result;
        }

        public static string ImportComments(InstagraphContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImpCommentDto[]), new XmlRootAttribute("comments"));
            var deserializedComments = (ImpCommentDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));
            StringBuilder sb = new StringBuilder();

            var validComments = new List<Comment>();

            foreach (var commDto in deserializedComments)
            {
                if (!IsValid(commDto))
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }
                var user = context.Users
                    .FirstOrDefault(x => x.Username == commDto.User);

                var post = context.Posts
                    .FirstOrDefault(x => x.Id == commDto.Post.Id);

                bool bothExist = user != null && post != null;

                if(!bothExist)
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                var comment = new Comment()
                {
                    Content = commDto.Content,
                    UserId = user.Id,
                    PostId = post.Id
                };
                validComments.Add(comment);
                sb.AppendLine(string.Format(successMessage, $"Comment {comment.Content}"));
            }

            context.Comments.AddRange(validComments);
            context.SaveChanges();

            string result = sb.ToString().Trim();
            return result;
        }
        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);

            return isValid;
        }
    }
}
