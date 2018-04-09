namespace P05_Integration
{
    using P05_Integration.Models;
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            Integration integration = new Integration();
            
            Category parent = new Category("Boss");
            Category child = new Category("Emp");

            User user1 = new User("Pepkata1");
            User user2 = new User("Pepkata2");
            User user3 = new User("Pepkata3");
            
            integration.AddCategory(parent);
            integration.AddCategory(child);

            integration.AssignUserToSpecificCategory(parent, user1);
            integration.AssignUserToSpecificCategory(parent, user2);
            integration.AssignUserToSpecificCategory(parent, user3);

            integration.AssignChildCategory(parent, child);

            integration.RemoveOneOrMoreCategories(parent);
        }
    }
}
