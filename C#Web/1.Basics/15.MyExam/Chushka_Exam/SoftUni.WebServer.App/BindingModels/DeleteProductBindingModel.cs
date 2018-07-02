namespace SoftUni.WebServer.App.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class DeleteProductBindingModel
    {
        [Required]
        public int Id { get; set; }
    }
}
