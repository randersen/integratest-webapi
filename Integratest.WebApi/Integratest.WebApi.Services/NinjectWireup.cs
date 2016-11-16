using Integratest.Data.ServiceInterfaces;
using Integratest.Web;
using Integratest.WebApi.Services.Interfaces;
using Integratest.WebApi.Services.Services;
using Ninject.Modules;

namespace Integratest.WebApi.Services
{
    public class NinjectWireup : NinjectModule, INinjectWireup
    {
        public override void Load()
        {
            Bind<IAccountsService>().To<AccountsService>();


        }
    }
}