using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrollMarket.Repository;
using TrollMarket.ViewModel;
using TrollMarket.ViewModel.Products;

namespace TrollMarket.Provider
{
    public class ProductProvider
    {
        private static ProductProvider _instance = new ProductProvider();
        public static ProductProvider GetProvider()
        {
            return _instance;
        }

        public IEnumerable<ProductViewModel> getData()
        {
            return (from prod in ProductRepository.GetRepository().GetAll()
                    select new ProductViewModel
                    {
                        ProductId = prod.ProductId,
                        CategoryName = prod.Category,
                        Description = prod.Description,
                        Discontinue = prod.Discontinue == true ? "Discontinue" : "Continue",
                        Price = prod.Price,
                        StringPrice = prod.Price == null ? "N/A" : prod.Price.Value.ToString("C2", CultureInfo.CurrentCulture),
                        ProductName = prod.ProductName,
                        SellerName = prod.Seller.Name
                    }).ToList();
        }
        public IndexProductViewModel getIndex(string searchName, string searchCategory, string searchDescription)
        {
            var data = getData();
            if (!string.IsNullOrEmpty(searchName))
            {
                data = data.Where(a => a.ProductName.Contains(searchName));
            }
            if (!string.IsNullOrEmpty(searchCategory))
            {
                data = data.Where(a => a.CategoryName.Contains(searchCategory));
            }
            if (!string.IsNullOrEmpty(searchDescription))
            {
                data = data.Where(a => a.Description.Contains(searchDescription));
            }
            return new IndexProductViewModel
            {
                searchDescription = searchDescription,
                searchName = searchName,
                searchCategory = searchCategory,
                listProduct = data
            };
        }
        public ProductViewModel getDetail(int id)
        {
            var data = (from prod in ProductRepository.GetRepository().GetAll()
                        where prod.ProductId == id
                        select new ProductViewModel
                        {
                            ProductId = prod.ProductId,
                            CategoryName = prod.Category,
                            Description = prod.Description,
                            Discontinue = prod.Discontinue == true ? "Discontinue" : "Continue",
                            Price = prod.Price,
                            StringPrice = prod.Price == null ? "N/A" : prod.Price.Value.ToString("C2", CultureInfo.CurrentCulture),
                            ProductName = prod.ProductName,
                            SellerName = prod.Seller.Name
                        }).SingleOrDefault();
            return data;
        }


        public JsonResultViewModel GetProductById(int id)
        {
            var check = ProductRepository.GetRepository().GetSingle(id);
            if (check != null)
            {
                var data = (from prod in ProductRepository.GetRepository().GetAll()
                            where prod.ProductId == id
                            select new ProductViewModel
                            {
                                ProductId = prod.ProductId,
                                CategoryName = prod.Category,
                                Description = prod.Description,
                                Discontinue = prod.Discontinue == true ? "Discontinue" : "Continue",
                                Price = prod.Price,
                                StringPrice = prod.Price == null ? "N/A" : prod.Price.Value.ToString("C2", CultureInfo.CurrentCulture),
                                ProductName = prod.ProductName,
                                SellerName = prod.Seller.Name
                            }).SingleOrDefault();

                var result = new JsonResultViewModel
                {
                    Success = true,
                    Message = "Product Found",
                    ReturnObject = data
                };
                return result;
            }

            else
            {
                var result = new JsonResultViewModel
                {
                    Success = false,
                    Message = "Product Not Found",
                    ReturnObject = check
                };
                return result;
            }
        }
    }
}
