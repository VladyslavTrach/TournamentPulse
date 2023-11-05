using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentPulse.Infrastructure.Data;

namespace TournamentPulse.Application.Service
{
    public class UserService
    {
        private readonly ApplicationDataContext _applicationDataContext;

        public UserService(ApplicationDataContext applicationDataContext)
        {
            _applicationDataContext = applicationDataContext;
        }

        List<IdentityUser> GetUsers()
        {
            return _applicationDataContext.Users.OrderBy(u => u.UserName).ToList();
        }
    }
}
