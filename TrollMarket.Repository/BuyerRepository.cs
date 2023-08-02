using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrollMarket.DataAccess.Models;
using TrollMarket.Utility;

namespace TrollMarket.Repository
{
    public class BuyerRepository : IRepository<Buyer>
    {
        private static IRepository<Buyer> _instance = new BuyerRepository();

        public static IRepository<Buyer> GetRepository()
        {
            return _instance;
        }

        public IQueryable<Buyer> GetAll()
        {
            var context = new TrollMarketContext();
            return context.Buyers;
        }


        public Buyer GetSingle(object id)
        {
            var context = new TrollMarketContext();
            return context.Buyers.SingleOrDefault(a => a.Id == (int)id);
        }

        public bool Insert(Buyer model)
        {
            try
            {
                using (var context = new TrollMarketContext())
                {
                    context.Buyers.Add(model);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Update(Buyer model)
        {
            try
            {
                using (var context = new TrollMarketContext())
                {
                    var buyer = context.Buyers.SingleOrDefault(a => a.Id == model.Id);
                    UtilitiesFunction.MappingModel<Buyer, Buyer>(buyer, model);
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
                using(var context = new TrollMarketContext())
                {
                    var buyer = context.Buyers.SingleOrDefault(a => a.Id == (int)id);
                    context.Buyers.Remove(buyer);
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
