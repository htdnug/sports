using System.Linq;
using System.Threading.Tasks;
using HT.Sports.Data.EF;
using HT.Sports.UI.Web.External.ViewModels.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HT.Sports.UI.Web.External.Models
{
    [ViewComponent]
    public class LoginStatusViewComponent : ViewComponent
    {
        private readonly SportsContext context;

        public LoginStatusViewComponent(SportsContext sportsContext)
        {
            this.context = sportsContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var users = await this.context.UserProfiles.ToListAsync();
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
