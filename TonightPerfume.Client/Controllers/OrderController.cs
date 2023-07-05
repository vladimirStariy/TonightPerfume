using Microsoft.AspNetCore.Mvc;

namespace TonightPerfume.Client.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
