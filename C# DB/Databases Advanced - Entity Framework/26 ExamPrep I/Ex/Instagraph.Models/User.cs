﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Instagraph.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public int ProfilePictureId { get; set; }
        public Picture ProfilePicture { get; set; }

        [InverseProperty("User")]
        public ICollection<UserFollower> Followers { get; set; } = new HashSet<UserFollower>();

        [InverseProperty("Follower")]
        public ICollection<UserFollower> UsersFollowing { get; set; } = new HashSet<UserFollower>();

        public ICollection<Post> Posts { get; set; } = new HashSet<Post>();

        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    }
}
