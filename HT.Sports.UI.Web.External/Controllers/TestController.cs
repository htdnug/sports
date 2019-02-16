using Microsoft.AspNetCore.Mvc;

namespace HT.Sports.UI.Web.External.Controllers
{
    public class TestController : SportsController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
