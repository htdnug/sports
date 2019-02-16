using HT.Sports.UI.Web.External.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HT.Sports.UI.Web.External.Controllers
{
    public class AccountController : SportsController
    {
        public IActionResult Login(int? id)
        {
            if (!id.HasValue)
            {
                return this.NotFound();
            }
            this.HttpContext.Session.SetInt32(SessionKeys.CurrentUserId, id.Value);
            return this.RedirectToPage("/Index");
        }

        public IActionResult Logout()
        {
            this.HttpContext.Session.Remove(SessionKeys.CurrentUserId);
            return this.RedirectToPage("/Index");
        }
    }
}
