using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratest.WebApi.Models
{
    public class Account
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public List<string> Roles { get; set; }
    }
}
