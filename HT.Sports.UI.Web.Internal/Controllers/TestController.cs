using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HT.Sports.UI.Web.Internal.Controllers
{
    public class TestController : SportsController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
