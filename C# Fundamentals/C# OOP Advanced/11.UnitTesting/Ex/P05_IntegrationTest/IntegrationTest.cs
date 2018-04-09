namespace P05_IntegrationTest
{
    using NUnit.Framework;
    using P05_Integration;
    using P05_Integration.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class IntegrationTest
    {
        private User testUserDahaka = new User("Dahaka");
        private User testUserHulk = new User("Hulk");
        private User testUserThor = new User("Thor");

        [Test]
        public void AddCategoriesShouldWorkCorrectly()
        {
            Type integrationType = typeof(Integration);
            Type categoryType = typeof(Category);

            Integration integrationInstance = (Integration)Activator.CreateInstance(integrationType);
            Category parentCategory = (Category)Activator.CreateInstance(categoryType, new object[] { "BossParentCategory" });
            Category childCategory = (Category)Activator.CreateInstance(categoryType, new object[] { "ChildCategory" });

            MethodInfo addCategory = integrationType.GetMethod("AddCategory", BindingFlags.Instance | BindingFlags.Public);
            
            addCategory.Invoke(integrationInstance, new object[] { parentCategory });
            addCategory.Invoke(integrationInstance, new object[] { childCategory });

            List<Category> expectedCategories = new List<Category>();
            
            expectedCategories.Add(parentCategory);
            expectedCategories.Add(childCategory);

            HashSet<Category> actualHashCategories = (HashSet<Category>)integrationType.GetField("categories", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(integrationInstance);

            List<Category> actualCategories = actualHashCategories.ToList();

            int expectedCategoriesCount = expectedCategories.Count;
            int actualCategoriesCount = actualCategories.Count;

            Assert.AreEqual(actualCategoriesCount, expectedCategoriesCount);

            for (int index = 0; index < expectedCategories.Count; index++)
            {
                Assert.That(expectedCategories[index].Name, Is.EqualTo(actualCategories[index].Name));
            }
        }

        [Test]
        public void AssignChildCategoryToSingleCategoryShouldWorkCorrectly()
        {
            Type integrationType = typeof(Integration);
            Type categoryType = typeof(Category);

            Integration integrationInstance = (Integration)Activator.CreateInstance(integrationType);
            Category parentCategory = (Category)Activator.CreateInstance(categoryType, new object[] { "BossParentCategory" });
            Category childCategory = (Category)Activator.CreateInstance(categoryType, new object[] { "ChildCategory" });

            MethodInfo addCategory = integrationType.GetMethod("AddCategory", BindingFlags.Instance | BindingFlags.Public);

            addCategory.Invoke(integrationInstance, new object[] { parentCategory });
            addCategory.Invoke(integrationInstance, new object[] { childCategory });

            integrationInstance.AssignChildCategory(parentCategory, childCategory);

            HashSet<Category> actualHashCategories = (HashSet<Category>)integrationType.GetField("categories", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(integrationInstance);

            List<Category> actualCategories = actualHashCategories.ToList();

            Category parentActualCategory = actualCategories[0];
            Category childActualCategory = actualCategories[1];

            Category childCategoryTakenFromParent = parentActualCategory.SubCategories.FirstOrDefault(x => x.Name == childCategory.Name);

            Assert.AreEqual(childCategoryTakenFromParent.Name, childActualCategory.Name);
            Assert.AreEqual(childActualCategory.ParentCategory.Name, parentActualCategory.Name);
        }

        [Test]
        public void AssignUserToSpecificCategoryShouldWorkCorrectly()
        {
            Type integrationType = typeof(Integration);
            Type categoryType = typeof(Category);

            Integration integrationInstance = (Integration)Activator.CreateInstance(integrationType);
            Category category = (Category)Activator.CreateInstance(categoryType, new object[] { "BossParentCategory" });

            MethodInfo addCategory = integrationType.GetMethod("AddCategory", BindingFlags.Instance | BindingFlags.Public);

            addCategory.Invoke(integrationInstance, new object[] { category });

            integrationInstance.AssignUserToSpecificCategory(category, testUserDahaka);

            HashSet<Category> actualHashCategories = (HashSet<Category>)integrationType.GetField("categories", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(integrationInstance);

            List<Category> actualCategories = actualHashCategories.ToList();

            Category actualCategoryWithSingleUser = actualCategories[0];
            User actualUserTakenFromCategory = actualCategoryWithSingleUser.Users.FirstOrDefault(x => x.Name == testUserDahaka.Name);

            Assert.AreEqual(actualUserTakenFromCategory.Name, testUserDahaka.Name);

            Category testCategoryTakenFromUser = actualUserTakenFromCategory.Categories.FirstOrDefault(x => x.Name == category.Name);

            Assert.AreEqual(testCategoryTakenFromUser.Name, category.Name);
        }

        [Test]
        public void RemoveCategoriesAndAssignUsersToChildrenShouldWorkCorrectly()
        {
            Type integrationType = typeof(Integration);
            Type categoryType = typeof(Category);

            Integration integrationInstance = (Integration)Activator.CreateInstance(integrationType);
            Category parentCategory = (Category)Activator.CreateInstance(categoryType, new object[] { "BossParentCategory" });
            Category childCategory1 = (Category)Activator.CreateInstance(categoryType, new object[] { "ChildCategory" });
            Category childCategory2 = (Category)Activator.CreateInstance(categoryType, new object[] { "ChildCategory2" });

            parentCategory.Users.Add(testUserDahaka);
            parentCategory.Users.Add(testUserHulk);
            parentCategory.Users.Add(testUserThor);

            MethodInfo addCategory = integrationType.GetMethod("AddCategory", BindingFlags.Instance | BindingFlags.Public);
            MethodInfo removeCategoryMethod = integrationType.GetMethod("RemoveOneOrMoreCategories", BindingFlags.Instance | BindingFlags.Public);

            addCategory.Invoke(integrationInstance, new object[] { parentCategory });
            addCategory.Invoke(integrationInstance, new object[] { childCategory1 });
            addCategory.Invoke(integrationInstance, new object[] { childCategory2 });

            integrationInstance.AssignChildCategory(parentCategory, childCategory1);
            integrationInstance.AssignChildCategory(parentCategory, childCategory2);

            integrationInstance.RemoveOneOrMoreCategories(parentCategory);

            HashSet<Category> actualHashCategories = (HashSet<Category>)integrationType.GetField("categories", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(integrationInstance);

            List<Category> actualCategories = actualHashCategories.ToList();

            foreach (var category in actualCategories)
            {
                for (int index = 0; index < parentCategory.Users.Count; index++)
                {
                    string username1 = category.Users[index].Name;
                    string username2 = parentCategory.Users[index].Name;

                    Assert.AreEqual(username1, username2);
                }
            }
        }
    }
}
