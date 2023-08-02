using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoClub.Core.Entities
{
    public class Copy
    {
        public int CopyID { get; set; }
        public int MovieID { get; set; }
        public bool CopyIsBooked { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
