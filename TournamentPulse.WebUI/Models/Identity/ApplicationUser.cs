using Microsoft.AspNetCore.Identity;

namespace TournamentPulse.WebUI.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName {  get; set; }
    }
}
