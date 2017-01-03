using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Integratest.Security;
using Integratest.WebApi.Models;
using Integratest.WebApi.Services.Interfaces;

namespace Integratest.WebApi.Host.Controllers
{
    [RoutePrefix("login")]
    public class LoginController : ApiController
    {

        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [Route("")]
        [HttpPost]
        public async Task<string> Login(LoginRequest request)
        {
            return await _loginService.Login(request).ConfigureAwait(false);


        }

    }
}
