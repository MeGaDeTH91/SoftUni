namespace Forum.Data
{
    using Forum.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class DataMapper
    {
        private const string DATA_PATH = "../data/";
        private const string CONFIG_PATH = "config.ini";
        private const string DEFAULT_CONFIG = "users=users.csv\r\ncategories=categories.csv\r\nposts=posts.csv\r\nreplies=replies.csv";
        private static readonly Dictionary<string, string> config = new Dictionary<string, string>();

        static DataMapper()
        {
            Directory.CreateDirectory(DATA_PATH);
            config = LoadConfig(DATA_PATH + CONFIG_PATH);
        }

        /// <summary>
        /// Checks whether a file form the path exists and Create a new one with the string form DEFAULT_CONFIG constant if it doesn’t.
        /// </summary>
        private static void EnsureConfigFile(string configFilePath)
        {
            if (!File.Exists(configFilePath))
            {
                File.WriteAllText(configFilePath, DEFAULT_CONFIG);
            }
        }

        /// <summary>
        /// Checks whether a file form the path exists and Create a new empty one.
        /// </summary>
        private static void EnsureFile(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }

        /// <summary>
        /// After Calling the EnsureConfigFile method, here the data is read, split by delimiter '=', convert to Dictionary and return the config(load).
        /// </summary>
        /// <returns>Dictionary<string.string></string></returns>
        private static Dictionary<string, string> LoadConfig(string configPath)
        {
            EnsureConfigFile(configPath);

            var contents = ReadLines(configPath);

            var config = contents
                .Select(x => x.Split('='))
                .ToDictionary(x => x[0], x => DATA_PATH + x[1]);

            return config;
        }

        /// <summary>
        /// Reads the lines of the file from the path specified and returns string array.
        /// </summary>
        /// <returns>String[]</returns>
        public static string[] ReadLines(string path)
        {
            EnsureFile(path);
            var lines = File.ReadAllLines(path);
            return lines;
        }

        /// <summary>
        /// Writes the string[] to file
        /// </summary>
        public static void WriteLines(string path, string[] lines)
        {
            File.WriteAllLines(path, lines);
        }

        /// <summary>
        /// Gets categories from a given file
        /// </summary>
        /// <returns>List of categories</returns>
        public static List<Category> LoadCategories()
        {
            var categories = new List<Category>();
            var dataLines = ReadLines(config["categories"]);

            foreach (var line in dataLines)
            {

                var args = line.Split(";", StringSplitOptions.RemoveEmptyEntries);
                var id = int.Parse(args[0]);
                var name = args[1];
                int[] postIds;

                if (args.Length > 2)
                {
                     postIds = args[2]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                }
                else
                {
                    postIds = new int[0];
                }

                var category = new Category(id, name, postIds);
                categories.Add(category);
            }

            return categories;
        }

        /// <summary>
        /// Takes categories and writes them in their respective file
        /// </summary>
        public static void SaveCategories(List<Category> categories)
        {
            var lines = new List<string>();
            const string categoryFormat = "{0};{1};{2}";
            foreach (var category in categories)
            {
                string line = string.Format(categoryFormat,
                    category.Id,
                    category.Name,
                    string.Join(",", category.PostIds)
                    );
                lines.Add(line);
            }

            WriteLines(config["categories"], lines.ToArray());
        }

        /// <summary>
        /// Gets users from a given file
        /// </summary>
        /// <returns>List of users</returns>
        public static List<User> LoadUsers()
        {
            var users = new List<User>();
            var dataLines = ReadLines(config["users"]);

            foreach (var line in dataLines)
            {
                var args = line.Split(";", StringSplitOptions.RemoveEmptyEntries);
                var id = int.Parse(args[0]);
                var username = args[1];
                var password = args[2];
                int[] postIds;

                if (args.Length > 3)
                {
                    postIds = args[3]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                }
                else
                {
                    postIds = new int[0];
                }

                var user = new User(id, username, password, postIds);
                users.Add(user);
            }

            return users;
        }

        /// <summary>
        /// Takes users and writes them in their respective file
        /// </summary>
        public static void SaveUsers(List<User> users)
        {
            var lines = new List<string>();
            const string userFormat = "{0};{1};{2};{3}";
            foreach (var user in users)
            {
                string line = string.Format(userFormat,
                    user.Id,
                    user.Username,
                    user.Password,
                    string.Join(",", user.PostIds)
                    );
                lines.Add(line);
            }

            WriteLines(config["users"], lines.ToArray());
        }

        /// <summary>
        /// Gets posts from a given file
        /// </summary>
        /// <returns>List of posts</returns>
        public static List<Post> LoadPosts()
        {
            var posts = new List<Post>();
            var dataLines = ReadLines(config["posts"]);

            foreach (var line in dataLines)
            {
                var args = line.Split(";", StringSplitOptions.RemoveEmptyEntries);
                var id = int.Parse(args[0]);
                var title = args[1];
                var content = args[2];
                var categoryId = int.Parse(args[3]);
                var authorId = int.Parse(args[4]);
                int[] replyIds;

                if (args.Length > 5)
                {
                    replyIds = args[5]
                        .Split(',', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                }
                else
                {
                    replyIds = new int[0];
                }

                var post = new Post(id, title, content, categoryId, authorId, replyIds);
                posts.Add(post);
            }

            return posts;
        }

        /// <summary>
        /// Takes posts and writes them in their respective file
        /// </summary>
        public static void SavePosts(List<Post> posts)
        {
            var lines = new List<string>();
            const string postFormat = "{0};{1};{2};{3};{4};{5}";
            foreach (var post in posts)
            {
                string line = string.Format(postFormat,
                    post.Id,
                    post.Title,
                    post.Content,
                    post.CategoryId,
                    post.AuthorId,
                    string.Join(",", post.ReplyIds)
                    );
                lines.Add(line);
            }

            WriteLines(config["posts"], lines.ToArray());
        }

        /// <summary>
        /// Gets replies from a given file
        /// </summary>
        /// <returns>List of replies</returns>
        public static List<Reply> LoadReplies()
        {
            var replies = new List<Reply>();
            var dataLines = ReadLines(config["replies"]);

            foreach (var line in dataLines)
            {
                var args = line.Split(";", StringSplitOptions.RemoveEmptyEntries);
                var id = int.Parse(args[0]);
                var content = args[1];
                var authorId = int.Parse(args[2]);
                var postId = int.Parse(args[3]);
                var reply = new Reply(id, content, authorId, postId);
                replies.Add(reply);
            }

            return replies;
        }

        /// <summary>
        /// Takes replies and writes them in their respective file
        /// </summary>
        public static void SaveReplies(List<Reply> replies)
        {
            var lines = new List<string>();
            const string replyFormat = "{0};{1};{2};{3}";
            foreach (var reply in replies)
            {
                string line = string.Format(replyFormat,
                    reply.Id,
                    reply.Content,
                    reply.AuthorId,
                    reply.PostId
                    );
                lines.Add(line);
            }

            WriteLines(config["replies"], lines.ToArray());
        }
    }
}
