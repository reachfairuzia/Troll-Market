using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrollMarket.DataAccess.Models;
using TrollMarket.Utility;

namespace TrollMarket.Repository
{
    public class HistoryRepository : IRepository<History>
    {
        private static IRepository<History> _instance = new HistoryRepository();
        public static IRepository<History> GetRepository()
        {
            return _instance;
        }
        public IQueryable<History> GetAll()
        {
            var context = new TrollMarketContext();
            return context.Histories;
        }


        public History GetSingle(object id)
        {
            var context = new TrollMarketContext();
            return context.Histories.SingleOrDefault(a => a.Id == (int)id);
        }

        public bool Insert(History model)
        {
            try
            {
                using (var context = new TrollMarketContext())
                {
                    context.Histories.Add(model);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Update(History model)
        {
            try
            {
                using (var context = new TrollMarketContext())
                {
                    var history = context.Histories.SingleOrDefault(a => a.Id == model.Id);
                    UtilitiesFunction.MappingModel<History, History>(history, model);
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
                    var history = context.Histories.SingleOrDefault(a => a.Id == (int)id);
                    context.Histories.Remove(history);
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
