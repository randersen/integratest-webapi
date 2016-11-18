using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Integratest.Data.ServiceInterfaces;
using Integratest.WebApi.Models;
using Integratest.WebApi.Services.Interfaces;
using Integratest.WebApi.Services.Services;
using Microsoft.Ajax.Utilities;

namespace Integratest.WebApi.Host.Controllers
{
    [RoutePrefix("accounts")]
    public class AccountsController : ApiController
    {
        private readonly IAccountsService _accountsService;

        public AccountsController(IAccountsService accountsService)
        {
            _accountsService = accountsService;
        }

        [HttpGet]
        [Route("")]
        public async Task<Account> GetAccount([FromUri]string email = null, [FromUri]string id = null)
        {
            var account = new Account();

            if (email.IsNullOrWhiteSpace() && id.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(email));

            if (email != null)
                return await _accountsService.GetAccountByEmail(email);

            var userIdAsGuid = Guid.Parse(id);

            return await _accountsService.GetAccountById(userIdAsGuid);
        }


        [HttpPost]
        [Route("")]
        public async Task<HttpResponseMessage> AddAccount(AccountRequest accountRequest)
        {
            if (accountRequest == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            await _accountsService.AddNewAccount(accountRequest);

            return new HttpResponseMessage(HttpStatusCode.Created);

        }


    }
}
