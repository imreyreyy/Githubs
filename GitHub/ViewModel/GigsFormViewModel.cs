using GitHub.Models;
using System.Collections.Generic;

namespace GitHub.ViewModel
{
    public class GigsFormViewModel
    {

        public string Venue { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public int Genre { get; set; }


        public IEnumerable<Genre> Genres { get; set; }
    }
}