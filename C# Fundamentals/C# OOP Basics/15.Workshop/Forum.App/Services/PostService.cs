﻿namespace Forum.App.Services
{
    using Forum.App.UserInterface.ViewModels;
    using Forum.Data;
    using Forum.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class PostService
    {
        public static IEnumerable<Post> GetPostsByCategory(int categoryId)
        {
            ForumData forumData = new ForumData();

            var postIds = forumData.Categories.First(c => c.Id == categoryId).PostIds;

            IEnumerable<Post> posts = forumData.Posts.Where(p => postIds.Contains(p.Id));

            return posts;
        }

        internal static Category GetCategory(int categoryId)
        {
            ForumData forumData = new ForumData();

            Category category = forumData.Categories.Find(x => x.Id == categoryId);

            return category;
        }

        internal static string[] GetAllCategoryNames()
        {
            ForumData forumData = new ForumData();

            var allCategories = forumData.Categories.Select(c => c.Name).ToArray();

            return allCategories;
        }

        internal static IList<ReplyViewModel> GetPostReplies(int postId)
        {
            ForumData forumData = new ForumData();

            Post post = forumData.Posts.Find(x => x.Id == postId);

            IList<ReplyViewModel> replies = new List<ReplyViewModel>();

            foreach (var replyId in post.ReplyIds)
            {
                var reply = forumData.Replies.Find(r => r.Id == replyId);
                replies.Add(new ReplyViewModel(reply));
            }

            return replies;
        }

        internal static bool TrySavePost(PostViewModel postView)
        {
            bool emptyCategory = string.IsNullOrWhiteSpace(postView.Category);
            bool emptyTitle = string.IsNullOrWhiteSpace(postView.Title);
            bool emptyContent = !postView.Content.Any(x => x.Trim().Length > 0);

            if (emptyContent || emptyTitle || emptyCategory)
            {
                return false;
            }

            var forumData = new ForumData();
            var category = EnsureCategory(postView, forumData);

            var posts = forumData.Posts;
            int postsId = posts.Any() ? posts.Last().Id + 1 : 1;
            User author = UserService.GetUser(postView.Author);
            int authorId = author.Id;
            string content = string.Join("", postView.Content);
            var post = new Post(postsId, postView.Title, content, category.Id, authorId, new List<int>());

            forumData.Posts.Add(post);
            author.PostIds.Add(post.Id);
            category.PostIds.Add(post.Id);
            forumData.SaveChanges();

            postView.PostId = postsId;

            return true;
        }

        internal static bool TryAddReply(int postId, ReplyViewModel replyView)
        {
            bool emptyAuthor = string.IsNullOrWhiteSpace(replyView.Author);
            bool emptyContent = !replyView.Content.Any(x => x.Trim().Length > 0);

            if (emptyContent || emptyAuthor)
            {
                return false;
            }

            var forumData = new ForumData();

            var replies = forumData.Replies;
            int replyId = replies.Any() ? replies.Last().Id + 1 : 1;

            User author = UserService.GetUser(replyView.Author);
            Post post = forumData.Posts.Find(p => p.Id == postId);
            int authorId = author.Id;

            string content = string.Join("", replyView.Content);
            var reply = new Reply(replyId, content, authorId, postId);

            forumData.Replies.Add(reply);
            post.ReplyIds.Add(replyId);

            forumData.SaveChanges();

            return true;
        }

        public static PostViewModel GetPostViewModel(int postId)
        {
            ForumData forumData = new ForumData();
            Post post = forumData.Posts.Find(x => x.Id == postId);
            PostViewModel pvm = new PostViewModel(post);

            return pvm;
        }

        private static Category EnsureCategory(PostViewModel postView, ForumData forumData)
        {
            var categoryName = postView.Category;
            Category category = forumData.Categories.FirstOrDefault(x => x.Name == categoryName);
            if (category == null)
            {
                var categories = forumData.Categories;
                int categoryId = categories.Any() ? categories.Last().Id + 1 : 1;
                category = new Category(categoryId, categoryName, new List<int>());
                forumData.Categories.Add(category);
            }

            return category;
        }
    }
}
