using Microsoft.AspNetCore.Mvc;
using TrollMarket.Provider;
using TrollMarket.ViewModel;

namespace TrollMarket.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SellerController : Controller
    {
        [HttpGet]
        [Route("GetTransactionSellerById/{id}")]
        public JsonResultViewModel GetTransactionSellerById(int id)
        {
            return SellerProvider.GetProvider().GetTransactionSellerById(id);
        }
    }
}