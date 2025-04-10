using Microsoft.AspNetCore.Identity;

namespace ASCWeb.Areas.Accounts.Models
{
    public class ServiceEngineerViewModel
    {
        public List<IdentityUser> ServiceEngineers { get; set; }

        public ServiceEngineerRegistrationViewModel Registration { get; set; }
    }
}
