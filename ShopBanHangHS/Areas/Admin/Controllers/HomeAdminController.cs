using Microsoft.AspNetCore.Mvc;

namespace ShopBanHangHS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeAdminController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
