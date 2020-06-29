﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GitHub.Models
{
    public class Relationship

    {
        [Key]
        [Column(Order =1)]
        public string FollowerId { get; set; }

        [Key]
        [Column(Order =2)]
        public string FolloweeId { get; set; }

        public ApplicationUser Follower { get; set; }

        public ApplicationUser Followee { get; set; }
    }
}