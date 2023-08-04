using Microsoft.AspNetCore.Mvc;
using TrollMarket.Provider;
using TrollMarket.ViewModel.Buyer;

namespace TrollMarket.Web.Controllers
{
    public class BuyerController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var model = BuyerProvider.GetProvider().GetProfileTransaction();
            return View(model);
        }

        [HttpGet]
        public IActionResult TopUpDana(int BuyerId)
        {
            var model = new TopupDanaViewModel();
            model.BuyerId = BuyerId;
            model.Dana = 0;

            return Json(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult TopUpDana([FromBody]TopupDanaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BuyerProvider.GetProvider().TambahDana(model);
                    return Json(new { success = true, message = "Berhasil Menyimpan", isvalid = true });
                }
                else
                {
                    return Json(new { success = false, message = "Gagal Menyimpan", isvalid = false });
                }
            }
            catch
            {
                return Json(new { success = false, message = "Exception", isvalid = false });
            }
        }
    }
}
