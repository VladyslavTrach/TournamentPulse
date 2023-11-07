using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentPulse.Core.Entities;

namespace TournamentPulse.Application.Interface
{
    public interface IAcademyRepository
    {
        ICollection<Academy> GetAllAcademies();
        Academy GetAcademyById(int id);
        Academy GetAcademyByName(string academyName);
        int CountAcademiesByAssociation(int id);
    }
}
