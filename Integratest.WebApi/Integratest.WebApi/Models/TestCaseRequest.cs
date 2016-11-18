using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratest.WebApi.Models
{
    public class TestCaseRequest
    {
        public Guid AccountId { get; set; }
        public string Title { get; set; }

    }
}
