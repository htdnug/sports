using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HT.Sports.UI.Web.External.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
