using Microsoft.AspNetCore.Mvc;
using TrollMarket.Provider;

namespace TrollMarket.Web.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index(string searchName = "", string searchCategory = "", string searchDescription = "")
        {
            var model = ProductProvider.GetProvider().getIndex(searchName, searchCategory, searchDescription);
            return View(model);
        }
        public IActionResult Detail(int id)
        {
            var model = ProductProvider.GetProvider().getDetail(id);
            return Json(model);
        }
    }
}
