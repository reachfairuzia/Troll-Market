using Microsoft.AspNetCore.Mvc;
using TrollMarket.Provider;
using TrollMarket.ViewModel;

namespace TrollMarket.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuyerController : Controller
    {
        [HttpGet]
        [Route("GetTransactionBuyerById/{id}")]
        public JsonResultViewModel GetTransactionBuyerById(int id)
        {
            return BuyerProvider.GetProvider().GetTransactionBuyerById(id);
        }
    }
}
