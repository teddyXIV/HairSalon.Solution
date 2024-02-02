using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet("/")]
        public ActionResult Index()
        {
            ViewBag.PageTitle = "Eau Claire's Salon";
            return View();
        }

    }
}