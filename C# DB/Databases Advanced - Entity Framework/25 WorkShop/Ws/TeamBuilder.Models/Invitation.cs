using System;
using System.Collections.Generic;
using System.Text;

namespace TeamBuilder.Models
{
    public class Invitation
    {
        public Invitation()
        {
            this.IsActive = true;
        }
        public int InvitationId { get; set; }

        public int InvitedUserId { get; set; }
        public User InvitedUser { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }

        public bool IsActive { get; set; }
    }
}
