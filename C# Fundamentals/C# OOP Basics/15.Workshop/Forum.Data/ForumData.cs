namespace Forum.Data
{
    using Forum.Models;
    using System.Collections.Generic;

    /// <summary>
    /// This is going to be the holder of all of our data. It will have properties for all the entity groups
    /// </summary>
    public class ForumData
    {
        public List<Category> Categories { get; set; }

        public List<User> Users { get; set; }

        public List<Post> Posts { get; set; }

        public List<Reply> Replies { get; set; }

        /// <summary>
        /// Initialize collections.
        /// </summary>
        public ForumData()
        {
            this.Categories = DataMapper.LoadCategories();
            this.Users = DataMapper.LoadUsers();
            this.Posts = DataMapper.LoadPosts();
            this.Replies = DataMapper.LoadReplies();
        }

        /// <summary>
        /// Saves the changes made to the collections.
        /// </summary>
        public void SaveChanges()
        {
            DataMapper.SaveCategories(this.Categories);
            DataMapper.SaveUsers(this.Users);
            DataMapper.SavePosts(this.Posts);
            DataMapper.SaveReplies(this.Replies);
        }
    }
}
