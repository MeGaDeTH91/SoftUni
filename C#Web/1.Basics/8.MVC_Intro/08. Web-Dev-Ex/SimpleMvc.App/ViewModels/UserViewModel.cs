namespace SimpleMvc.App.ViewModels
{
    using SimpleMvc.Domain;
    using System.Collections.Generic;

    public class UserViewModel
    {
        public int Id { get; set; }
        
        public string Username { get; set; }

        public ICollection<Note> Notes { get; set; } = new List<Note>();
    }
}
