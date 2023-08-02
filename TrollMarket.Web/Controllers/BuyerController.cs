using Microsoft.AspNetCore.Mvc;
using TrollMarket.Provider;

namespace TrollMarket.Web.Controllers
{
    public class BuyerController : Controller
    {
        public IActionResult Index()
        {
            var model = BuyerProvider.GetProvider().GetProfileTransaction();
            return View(model);
        }
    }
}
