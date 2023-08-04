using Microsoft.AspNetCore.Mvc;
using TrollMarket.Provider;
using TrollMarket.ViewModel;
using TrollMarket.ViewModel.Shipment;

namespace TrollMarket.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShipmentController : Controller
    {
        [HttpGet]
        [Route("GetShipment")]
        public IEnumerable<ShipmentViewModel> GetIndex()
        {
            return ShipmentProvider.GetProvider().GetIndex();
        }

        [HttpGet]
        [Route("GetShipmentById/{id}")]
        public JsonResultViewModel GetShipmentDetailById(int id)
        {
            return ShipmentProvider.GetProvider().GetShipmentById(id);
        }

        [HttpPost]
        public string UpsertShipment(UpsertShipmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (model.ShipperId == 0)
                    {
                        ShipmentProvider.GetProvider().Save(model);
                        return "Success insert shipment";
                    }
                    else
                    {
                        ShipmentProvider.GetProvider().Save(model);
                        return "Success update shipment";
                    }
                }
                catch (Exception ex)
                {
                    return "Yahh failed :(";
                    throw;
                }
            }
            else
            {
                return "Yahh failed :(";
            }
        }

        [HttpDelete("Delete/{id}")]
        public string DeleteShipment(int id)
        {
            if (ShipmentProvider.GetProvider().Delete(id))
            {
                return "Success delete shipment";
            }
            else
            {
                return "Fail delete shipment";
            }
        }

        [HttpPatch("StopService/{id}")]
        public string StopService(int id)
        {
            try
            {
                ShipmentProvider.GetProvider().StopService(id);
                return "Service has been stopped";
            }
            catch
            {
                return "Failed stop this service";
            }
        }
    }
}
