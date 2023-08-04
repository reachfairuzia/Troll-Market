using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrollMarket.ViewModel.Account;

namespace TrollMarket.Provider.Impl
{
    public interface IAccountProvider
    {
        bool RegistrationAccount(RegistAccountViewModel model);
        bool IsAuthentication(LoginViewModel model);
        string GetRoleName(string username);
        List<SelectListItem> GetDropdownRole();


    }
}
