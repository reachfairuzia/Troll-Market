using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrollMarket.DataAccess.Models;
using TrollMarket.Utility;

namespace TrollMarket.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        private static IRepository<Product> _instance = new ProductRepository();
        public static IRepository<Product> GetRepository()
        {
            return _instance;
        }
        public IQueryable<Product> GetAll()
        {
            var context = new TrollMarketContext();
            return context.Products;
        }


        public Product GetSingle(object id)
        {
            var context = new TrollMarketContext();
            return context.Products.SingleOrDefault(a => a.ProductId == (int)id);
        }

        public bool Insert(Product model)
        {
            try
            {
                using (var context = new TrollMarketContext())
                {
                    context.Products.Add(model);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Update(Product model)
        {
            try
            {
                using (var context = new TrollMarketContext())
                {
                    var product = context.Products.SingleOrDefault(a => a.ProductId == model.ProductId);
                    UtilitiesFunction.MappingModel<Product, Product>(product, model);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(object id)
        {
            try
            {
                using (var context = new TrollMarketContext())
                {
                    var product = context.Products.SingleOrDefault(a => a.ProductId == (int)id);
                    context.Products.Remove(product);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
