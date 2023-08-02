using Microsoft.AspNetCore.Mvc;
using TrollMarket.Provider;
using TrollMarket.ViewModel.Shipment;

namespace TrollMarket.Web.Controllers
{
    public class ShipmentController : Controller
    {
        public IActionResult Index()
        {
            var model = ShipmentProvider.GetProvider().GetIndex();
            return View(model);
        }

        public IActionResult ShipmentDropdown()
        {
            var model = ShipmentProvider.GetProvider().GetShipmentDropdown();
            return Json(model);
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult Save([FromBody] UpsertShipmentViewModel model)
        {
            try
            {
                ShipmentProvider.GetProvider().Save(model);
                return Json(new { success = true, message = "Berhasil menambahkan shipment" });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Gagal menambahkan shipment" });
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = ShipmentProvider.GetProvider().Edit(id);
            return Json(model);
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult StopService(int id)
        {
            try
            {
                ShipmentProvider.GetProvider().StopService(id);
                return Json(new { success = true, message = "Berhasil stop " + ShipmentProvider.GetProvider().Detail(id).Name
                    + " service" });
            }
            catch
            {
                return Json(new { success = false, message = ShipmentProvider.GetProvider().Detail(id).Name + " service tidak bisa di stop" });
            }
        }
        [AcceptVerbs("GET", "POST")]
        public IActionResult Detail(int id)
        {
            var model =  ShipmentProvider.GetProvider().Detail(id);
            return Json(model);
        }
    }
}
