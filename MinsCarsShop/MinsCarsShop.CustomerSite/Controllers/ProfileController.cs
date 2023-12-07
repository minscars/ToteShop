using Microsoft.AspNetCore.Mvc;
using MinsCarsShop.Integration;

namespace MinsCarsShop.CustomerSite.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IOrderAPI _orderAPI;
        public IActionResult Index()
        {
            return View();
        }


    }
}
