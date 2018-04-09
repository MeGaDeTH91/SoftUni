namespace P05_Integration.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Category
    {
        private string name;
        private List<User> users;
        private Category parentCategory;
        private List<Category> subCategories;

        public Category ParentCategory => this.parentCategory;
        
        public Category(string name)
        {
            this.Name = name;
            this.users = new List<User>();
            this.subCategories = new List<Category>();
        }
        

        public void AddSubCategoryToCategory(Category category)
        {
            if(category.ParentCategory == default(Category))
            {
                this.subCategories.Add(category);
                category.AddParentToCategory(this);
            }
            else
            {
                Category oldParent = category.ParentCategory;

                oldParent.RemoveSubCategoryFromCategory(category);

                this.subCategories.Add(category);
                category.AddParentToCategory(this);
            }
        }

        private void AddParentToCategory(Category parentCategory)
        {
            this.parentCategory = parentCategory;
        }

        public void RemoveSubCategoryFromCategory(Category category)
        {
            this.subCategories.Remove(category);
            category.RemoveParentCategory(this);
        }

        private void RemoveParentCategory(Category parentCategory)
        {
            List<User> parentCatUsers = parentCategory.Users;

            this.Users.AddRange(parentCatUsers);

            this.parentCategory = default(Category);
        }

        public void AddUserToCategory(User user)
        {
            this.users.Add(user);
            user.AddCategoryToThisUser(this);
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public List<User> Users
        {
            get
            {
                return this.users;
            }
            set
            {
                this.users = value;
            }
        }

        public List<Category> SubCategories
        {
            get
            {
                return this.subCategories;
            }
            set
            {
                this.subCategories = value;
            }
        }
    }
}
