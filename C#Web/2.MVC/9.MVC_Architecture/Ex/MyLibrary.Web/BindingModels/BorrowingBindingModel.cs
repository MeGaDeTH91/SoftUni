namespace MyLibrary.Web.BindingModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using MyLibrary.Models;

    public class BorrowingBindingModel
    {
        [Required(ErrorMessage = "You have to specify a borrower.")]
        [BindProperty]
        [Display(Name = "Borrower")]
        public int BorrowerId { get; set; }

        public int MovieId { get; set; }

        [BindProperty]
        [DataType(DataType.Date)]
        [Required]
        public DateTime StartDate { get; set; }

        [BindProperty]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        public IEnumerable<SelectListItem> Borrowers { get; set; }
    }
}
