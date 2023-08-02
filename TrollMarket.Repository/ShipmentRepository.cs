using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrollMarket.DataAccess.Models;
using TrollMarket.Utility;

namespace TrollMarket.Repository
{
    public class ShipmentRepository : IRepository<Shipment>
    {
        private static IRepository<Shipment> _instance = new ShipmentRepository();
        public static IRepository<Shipment> GetRepository()
        {
            return _instance;
        }
        public IQueryable<Shipment> GetAll()
        {
            var context = new TrollMarketContext();
            return context.Shipments;
        }


        public Shipment GetSingle(object id)
        {
            var context = new TrollMarketContext();
            return context.Shipments.SingleOrDefault(a => a.ShipperId == (int)id);
        }

        public bool Insert(Shipment model)
        {
            try
            {
                using (var context = new TrollMarketContext())
                {
                    context.Shipments.Add(model);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Update(Shipment model)
        {
            try
            {
                using (var context = new TrollMarketContext())
                {
                    var shipper = context.Shipments.SingleOrDefault(a => a.ShipperId == model.ShipperId);
                    UtilitiesFunction.MappingModel<Shipment, Shipment>(shipper, model);
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
                    var shipment = context.Carts.SingleOrDefault(a => a.Id == (int)id);
                    context.Carts.Remove(shipment);
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
