using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrollMarket.DataAccess.Models;
using TrollMarket.Utility;

namespace TrollMarket.Repository
{
    public class CartRepository : IRepository<Cart>
    {
            private static IRepository<Cart> _instance = new CartRepository();
            public static IRepository<Cart> GetRepository()
            {
                return _instance;
            }
            public IQueryable<Cart> GetAll()
            {
                var context = new TrollMarketContext();
                return context.Carts;
            }


            public Cart GetSingle(object id)
            {
                var context = new TrollMarketContext();
                return context.Carts.SingleOrDefault(a => a.Id == (int)id);
            }

            public bool Insert(Cart model)
            {
                try
                {
                    using (var context = new TrollMarketContext())
                    {
                        context.Carts.Add(model);
                        context.SaveChanges();
                    }
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }

            public bool Update(Cart model)
            {
                try
                {
                    using (var context = new TrollMarketContext())
                    {
                        var carts = context.Carts.SingleOrDefault(a => a.Id == model.Id);
                        UtilitiesFunction.MappingModel<Cart, Cart>(carts, model);
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
                        var carts = context.Carts.SingleOrDefault(a => a.Id == (int)id);
                        context.Carts.Remove(carts);
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
