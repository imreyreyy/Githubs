using GitHub.Models;
using System.Collections.Generic;

namespace GitHub.ViewModel
{
    public class GigsViewModel
    {
        public IEnumerable<Gigs> UpComingGig { get; set; }

        public bool ShowActions { get; set; }

        public string Heading { get; set; }
    }
}