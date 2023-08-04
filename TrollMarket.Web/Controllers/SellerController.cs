using Microsoft.AspNetCore.Mvc;
using TrollMarket.Provider;

namespace TrollMarket.Web.Controllers
{
    public class SellerController : Controller
    {
        public IActionResult Index()
        {
            var model = SellerProvider.GetProvider().GetProfileTransaction();
            return View(model);
        }
    }
}
