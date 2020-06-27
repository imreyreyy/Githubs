﻿using GitHub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GitHub.ViewModel
{
    public class GigsFormViewModel
    {
     
        public DateTime GetDateTime()
        {
         return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }

        [Required]
        public string Venue { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }
        [TimeVal]
        [Required]
        public string Time { get; set; }

        [Required]
        public int Genre { get; set; }


        public IEnumerable<Genre> Genres { get; set; }


    }
}