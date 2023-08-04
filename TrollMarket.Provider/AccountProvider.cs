using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TrollMarket.DataAccess.Models;
using TrollMarket.Provider.Impl;
using TrollMarket.Repository;
using TrollMarket.Utility;
using TrollMarket.ViewModel.Account;

namespace TrollMarket.Provider
{
    public class AccountProvider : IAccountProvider
    {
        public string GetRoleName(string username)
        {
            return AccountRepository.GetRepository().GetRole(username);
        }

        public bool IsAuthentication(LoginViewModel model)
        {
            return AccountRepository.GetRepository().GetIsAuthentication(model.Username, model.Password , model.Role);
        }

        public List<SelectListItem> GetDropdownRole()
        {
            var allData = AccountRepository.GetRepository().GetAll();
            var roles = allData.Select(a => new SelectListItem
            {
                Value = a.Role,
                Text = a.Role
            }).Distinct().ToList();

            return roles;
        }

        public bool RegistrationAccount(RegistAccountViewModel model)
        {
            using (var scope = new TransactionScope())
            {
                try
                {
                    Account newAccount = new Account();
                    UtilitiesFunction.MappingModel<Account, RegistAccountViewModel>(newAccount, model);
                    AccountRepository.GetRepository().Insert(newAccount);
                    if (model.Role == "Buyer")
                    {
                        Buyer newBuyer = new Buyer();
                        UtilitiesFunction.MappingModel<Buyer, RegistAccountViewModel>(newBuyer, model);
                        BuyerRepository.GetRepository().Insert(newBuyer);
                    }
                    else
                    {
                        Seller newSeller = new Seller();
                        UtilitiesFunction.MappingModel<Seller, RegistAccountViewModel>(newSeller, model);
                        SellerRepository.GetRepository().Insert(newSeller);
                    }
                    scope.Complete();
                    return true;
                }
                catch (Exception ex)
                {

                    return false;
                }
            }
        }
    }
}
