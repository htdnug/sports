using System.Collections.Generic;
using System.Linq;
using HT.Sports.Entities;

namespace HT.Sports.UI.Web.External.ViewModels.Components
{
    public class LoginStatusViewModel
    {
        public IEnumerable<UserProfileViewModel> UserProfiles { get; set; } = Enumerable.Empty<UserProfileViewModel>();
        public bool IsLoggedIn { get; set; } = false;
        public UserProfileViewModel CurrentUser { get; set; } = null;
    }
}
