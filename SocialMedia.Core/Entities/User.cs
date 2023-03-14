using SocialMedia.Core.Entities;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SocialMedial.Core.Etities
{
    public partial class User : BaseEntity
    {
        public User()
        {
            Commnets = new HashSet<Comment>();
            Posts = new HashSet<Post>();
        }

        //public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateBirth { get; set; }
        public string Telephone { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Comment> Commnets { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
