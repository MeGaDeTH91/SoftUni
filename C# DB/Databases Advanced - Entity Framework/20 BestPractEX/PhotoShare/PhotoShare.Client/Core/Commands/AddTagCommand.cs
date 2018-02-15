namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using Data;
    using Utilities;
    using System.Linq;
    using System;

    public class AddTagCommand
    {
        // AddTag <tag>
        public static string Execute(string[] data)
        {
            string tag = data[1].ValidateOrTransform();

            if (Session.User == null)
            {
                throw new InvalidOperationException($"Invalid credentials!");
            }

            using (PhotoShareContext context = new PhotoShareContext())
            {
                if(context.Tags.Any(x => x.Name == tag))
                {
                    throw new ArgumentException($"Tag {tag} exists!");
                }
                context.Tags.Add(new Tag
                {
                    Name = tag
                });

                context.SaveChanges();
            }

            return $"Tag {tag} was added successfully!";
        }
    }
}
