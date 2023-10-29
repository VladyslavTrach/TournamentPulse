using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentPulse.Application.Interface
{
    public interface ISeedFightersInDbService
    {
        void GenerateFighter();
        void GenerateFighters();
    }
}
