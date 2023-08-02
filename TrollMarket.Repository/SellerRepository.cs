using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrollMarket.DataAccess.Models;
using TrollMarket.Utility;

namespace TrollMarket.Repository
{
    public class SellerRepository : IRepository<Seller>
    {
        private static IRepository<Seller> _instance = new SellerRepository();
        public static IRepository<Seller> GetRepository()
        {
            return _instance;
        }
        public IQueryable<Seller> GetAll()
        {
            var context = new TrollMarketContext();
            return context.Sellers;
        }


        public Seller GetSingle(object id)
        {
            var context = new TrollMarketContext();
            return context.Sellers.SingleOrDefault(a => a.Id == (int)id);
        }

        public bool Insert(Seller model)
        {
            try
            {
                using (var context = new TrollMarketContext())
                {
                    context.Sellers.Add(model);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Update(Seller model)
        {
            try
            {
                using (var context = new TrollMarketContext())
                {
                    var seller = context.Sellers.SingleOrDefault(a => a.Id == model.Id);
                    UtilitiesFunction.MappingModel<Seller, Seller>(seller, model);
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
                    var seller = context.Sellers.SingleOrDefault(a => a.Id == (int)id);
                    context.Sellers.Remove(seller);
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
