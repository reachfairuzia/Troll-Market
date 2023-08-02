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
            var result = ShipmentProvider.GetProvider().GetIndex();
            return result;
        }

        [HttpGet]
        [Route("GetShipmentById/{id}")]
        public JsonResultViewModel GetShipmentDetailById(int id)
        {
            var result = ShipmentProvider.GetProvider().GetShipmentById(id);
            return result;
        }


    }
}
