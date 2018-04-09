namespace P05_Integration.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class User
    {
        private string name;
        private List<Category> categories;

        public User(string name)
        {
            this.Name = name;
            this.categories = new List<Category>();
        }

        public void AddCategoryToThisUser(Category categoryToAdd)
        {
            this.categories.Add(categoryToAdd);
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public List<Category> Categories
        {
            get
            {
                return this.categories;
            }
            set
            {
                this.categories = value;
            }
        }
    }
}
