namespace P05_Integration
{
    using P05_Integration.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Integration
    {
        private HashSet<Category> categories;

        public Integration()
        {
            this.categories = new HashSet<Category>();
        }

        public void AddCategory(Category category)
        {
            this.categories.Add(category);
        }

        public void RemoveOneOrMoreCategories(params Category[] categories)
        {
            foreach (var cat in categories)
            {
                List<Category> subCategories = cat.SubCategories;

                while (subCategories.Count > 0)
                {
                    Category currentCategory = subCategories[0];
                    this.AddCategory(currentCategory);
                    cat.RemoveSubCategoryFromCategory(currentCategory);
                }
                this.categories.Remove(cat);
            }
        }

        public void AssignChildCategory(Category parentCategory, Category childCategory)
        {
            var parent = this.categories.FirstOrDefault(x => x == parentCategory);

            parent.AddSubCategoryToCategory(childCategory);
        }

        public void AssignUserToSpecificCategory(Category category, User user)
        {
            var specificCategory = this.categories.FirstOrDefault(x => x == category);

            specificCategory.AddUserToCategory(user);
        }
    }
}
