using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Integratest.Data.DataModels;
using Integratest.Data.RequestModels;
using Integratest.Data.ServiceInterfaces;
using Integratest.Data.Services;
using Integratest.WebApi.Models;
using Integratest.WebApi.Services.Interfaces;

namespace Integratest.WebApi.Services.Services
{

    public class AccountsService : IAccountsService
    {

        private readonly IDataAccountsService _dataAccountsService;

        public AccountsService(IDataAccountsService dataAccountsService)
        {
            _dataAccountsService = dataAccountsService;
        }


        public async Task AddNewAccount(AccountRequest accountRequest)
        {
            var dataRequest = new DataAccountsRequest()
            {
                CompanyName = accountRequest.CompanyName,
                Email = accountRequest.Email,
                Password = accountRequest.Password
            };

            await _dataAccountsService.AddAccount(dataRequest);
        }

        public async Task<Account> GetAccountByEmail(string userEmail)
        {
            var dataAccount = await _dataAccountsService.GetAccountByEmail(userEmail);

            if (dataAccount.Count == 0)
            {
                return null;
            }

            if (dataAccount.Count > 1)
            {
                throw new DuplicateNameException($"Multiple Accounts exist with email: {userEmail}");
            }

            var user = dataAccount.FirstOrDefault();

            var account = new Account()
            {
                CompanyName = user.CompanyName,
                Email = user.Email,
                Id = user.Id,
                Roles = user.Roles
            };

            return account;

        }

        public async Task<AccountsDto> GetFullAccountByEmail(string userEmail)
        {
            var dataAccount = await _dataAccountsService.GetAccountByEmail(userEmail);

            if (dataAccount.Count == 0)
            {
                return null;
            }

            if (dataAccount.Count > 1)
            {
                throw new DuplicateNameException($"Multiple Accounts exist with email: {userEmail}");
            }

            var user = dataAccount.FirstOrDefault();

            return user;

        }

        public async Task<Account> GetAccountById(Guid userId)
        {
            var dataAccount = await _dataAccountsService.GetAccountById(userId.ToString());

            var account = new Account()
            {
                CompanyName = dataAccount.CompanyName,
                Email = dataAccount.Email,
                Id = dataAccount.Id,
                Roles = dataAccount.Roles
            };

            return account;
        }

    }
}
