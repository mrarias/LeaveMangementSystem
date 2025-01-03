using LeaveMangementSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeaveMangementSystem.Web.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            var data = new TestViewModel
            {
                Name = "Student of MVC Mastery",
                DateOfBirth = new DateTime(1972,12,08)
            };
            return View(data);
        }
    }
}
