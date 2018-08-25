namespace MyBlog.Models.Users
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using MyBlog.Models.Music.Instruments;

    public class UserInstruments
    {
        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

        [Required]
        public int InstrumentId { get; set; }

        public Instrument Instrument { get; set; }

        [Required]
        public DateTime AddedToFavouritesOn { get; set; }
    }
}
