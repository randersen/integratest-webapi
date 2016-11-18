using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integratest.Data.DataModels;
using Integratest.WebApi.Models;

namespace Integratest.WebApi.Services.Interfaces
{
    public interface ITestCaseService
    {
        Task<Guid> AddTestCase(TestCaseRequest testCaseRequest);
        Task<TestCasesDto> GetTestCase(Guid id, Guid accountId);
        Task<List<TestCasesDto>> GetTestCasesForAccount(Guid accountId);
        Task DeleteTestCase(Guid id, Guid accountId);
    }
}
