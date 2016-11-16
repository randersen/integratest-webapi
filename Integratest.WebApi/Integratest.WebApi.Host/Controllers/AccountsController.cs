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

namespace Integratest.WebApi.Host.Controllers
{
    [RoutePrefix("accounts")]
    public class AccountsController : ApiController
    {
        //private readonly IAccountsService _accountsService;

        //public AccountsController(IAccountsService accountsService)
        //{
        //    _accountsService = accountsService;
        //}

        [HttpPost]
        [Route("")]
        public async Task<HttpResponseMessage> AddAccount(AccountRequest accountRequest)
        {
            if (accountRequest == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            await new AccountsService().AddNewAccount(accountRequest);

            return new HttpResponseMessage(HttpStatusCode.Created);

        }

    }
}
