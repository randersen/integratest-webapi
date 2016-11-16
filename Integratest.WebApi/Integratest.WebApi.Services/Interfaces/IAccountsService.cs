using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integratest.WebApi.Models;

namespace Integratest.WebApi.Services.Interfaces
{
    public interface IAccountsService
    {
        Task AddNewAccount(AccountRequest accountRequest);
        Task<Account> GetAccountByEmail(string userEmail);
        Task<Account> GetAccountById(Guid userId);

    }
}
