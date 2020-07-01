﻿using System;
using System.ComponentModel.DataAnnotations;

namespace GitHub.Models
{
    public class Gigs
    {

        public int Id { get; set; }

        public bool IsCanceled { get; set; }

        public ApplicationUser Artist { get; set; }
        [Required]
        public string ArtistId { get; set; }

        public DateTime DateTime { get; set; }


        [Required]
        [StringLength(255)]
        public string Venue { get; set; }
      
        
        public Genre Genre { get; set; }

        [Required]
        public int GenreId { get; set; }
    }
}