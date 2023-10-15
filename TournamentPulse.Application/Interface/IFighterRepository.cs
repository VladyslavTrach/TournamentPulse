using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentPulse.Core.Entities;

namespace TournamentPulse.Application.Interface
{
    public interface IFighterRepository
    {
        ICollection<Fighter> GetAllFighters();
        Fighter GetFighterById(int id);
        int CountFightersByAcademy(int id);
    }
}
