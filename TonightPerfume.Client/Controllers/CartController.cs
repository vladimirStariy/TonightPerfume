using Microsoft.AspNetCore.Mvc;

namespace TonightPerfume.Client.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
