using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrollMarket.DataAccess.Models;

namespace TrollMarket.Repository
{
    public class AccountRepository : IRepository<Account>
    {
        private static IRepository<Account> _instance = new AccountRepository();
        public static IRepository<Account> GetRepository()
        {
            return _instance;
        }
        public IQueryable<Account> GetAll()
        {
            var context = new TrollMarketContext();
            return context.Accounts;
        }

        public Account GetSingle(object id)
        {
            var context = new TrollMarketContext();
            return context.Accounts.SingleOrDefault(a=>a.Username == (string)id);
        }

        public bool Insert(Account model)
        {
            try
            {
                using (var context = new TrollMarketContext())
                {
                    context.Accounts.Add(model);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Account model)
        {
            throw new NotImplementedException();
        }
        public bool Delete(object id)
        {
            throw new NotImplementedException();
        }
    }
}
