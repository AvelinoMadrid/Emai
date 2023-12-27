using Microsoft.AspNetCore.Mvc;

namespace emai.Controllers
{
    public class BalanceController : Controller
    {
        public IActionResult VerBalance()
        {
            return View();
        }
    }
}
