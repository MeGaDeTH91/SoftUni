namespace SoftUni.WebServer.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Role
    {
        public Role()
        {
            this.Users = new List<User>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string TypeName { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
