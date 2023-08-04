using Microsoft.AspNetCore.Mvc;
using TrollMarket.Provider;
using TrollMarket.ViewModel.Buyer;

namespace TrollMarket.Web.Controllers
{
    public class BuyerController : BaseController
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
                    return Json(new { isException = false,isValidation = false , data = model});
                }
            }
            catch
            {
                return Json(new { isException = true, message = "Exception" });
            }
            var error = GetValidationViewModels(ModelState);
            return Json(new { isException = false, isValidation = true, data = error});
        }
    }
}
