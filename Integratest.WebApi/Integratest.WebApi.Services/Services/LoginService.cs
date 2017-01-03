using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Integratest.Security;
using Integratest.WebApi.Models;
using Integratest.WebApi.Services.Interfaces;

namespace Integratest.WebApi.Services.Services
{
    public class LoginService : ILoginService
    {

        private readonly IAccountsService _accountsService;

        public LoginService(IAccountsService accountsService)
        {
            _accountsService = accountsService;
        }

        public async Task<string> Login(LoginRequest request)
        {
            var account = await _accountsService.GetFullAccountByEmail(request.Email).ConfigureAwait(false);
            if (account == null)
            {
                throw new Exception("Login failed");
            }

            var valid = IntegraTestEncryption.IsCorrectPassword(request.Password, account.PasswordHash);

            if (!valid)
                throw new Exception("Login failed");

            return JwtHelpers.CreateJwt(new JwtRequest()
            {
                UserEmail = account.Email,
                UserId = account.Id
            });
        }

    }
}
