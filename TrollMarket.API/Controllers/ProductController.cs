using Microsoft.AspNetCore.Mvc;
using TrollMarket.Provider;
using TrollMarket.ViewModel.Products;
using TrollMarket.ViewModel;

namespace TrollMarket.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        [HttpGet]
        [Route("GetProduct")]
        public IEnumerable<ProductViewModel> GetProduct()
        {
            var result = ProductProvider.GetProvider().getData();
            return result;
        }

        [HttpGet("GetProductById/{id}")]
        public JsonResultViewModel GetProductById(int id)
        {
            var result = ProductProvider.GetProvider().GetProductById(id);
            return result;
        }

    }
}
