using System.Linq;
using System.Threading.Tasks;
using HT.Sports.Data;
using HT.Sports.UI.Web.External.ViewModels.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HT.Sports.UI.Web.External.Models
{
    [ViewComponent]
    public class LoginStatusViewComponent : SportsViewComponent
    {
        private readonly IUserProfileRepo _userProfileRepo;

        public LoginStatusViewComponent(IUserProfileRepo userProfileRepository)
        {
            this._userProfileRepo = userProfileRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var users = await this._userProfileRepo.GetAllAsync();
            var vm = new LoginStatusViewModel
            {
                UserProfiles = users.Select(x => new UserProfileViewModel { Id = x.Id, DisplayName = x.DisplayName })
            };

            var id = this.HttpContext.Session.GetInt32(SessionKeys.CurrentUserId);
            if (id.HasValue)
            {
                vm.IsLoggedIn = true;
                vm.CurrentUser = vm.UserProfiles.FirstOrDefault(x => x.Id == id.Value);
            }

            return View(vm);
        }
    }
}
