﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentPulse.Core.Entities;

namespace TournamentPulse.Application.Interface
{
    public interface ITournamentRepository
    {
        ICollection<Tournament> GetTournaments();
    }
}