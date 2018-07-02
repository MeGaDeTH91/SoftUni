namespace SoftUni.WebServer.App.ViewModels
{
    using System;
    using SoftUni.WebServer.Models;

    public class AllOrdersViewModel
    {
        public Guid Id { get; set; }
    
        public int ProductId { get; set; }

        public Product Product { get; set; }
        
        public int ClientId { get; set; }

        public User Client { get; set; }
        
        public DateTime OrderedOn { get; set; }
    }
}
