using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Core.Enumerations;

namespace VideoClub.Core.Entities
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        public int CopiesAvailable { get; set; }
        public int CopiesTotal { get; set; }
        public virtual ICollection<Copy> Copies { get; set; }
    }
}
