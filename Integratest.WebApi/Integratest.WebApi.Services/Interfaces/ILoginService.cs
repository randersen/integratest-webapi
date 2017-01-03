using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integratest.WebApi.Models;

namespace Integratest.WebApi.Services.Interfaces
{
    public interface ILoginService
    {
        Task<string> Login(LoginRequest request);

    }
}
