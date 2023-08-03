using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Core.Entities;

namespace VideoClub.Core.Interfaces
{
    public interface ICopyService
    {
        IEnumerable<Copy> GetAvailableCopies();
        int GetFirstAvailableCopyIDFromMovieID(int movieID);
        string GetTitleFromCopyID(int copyID);
    }
}
