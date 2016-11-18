using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Integratest.Data.DataModels;
using Integratest.Data.RequestModels;
using Integratest.Data.ServiceInterfaces;
using Integratest.WebApi.Models;
using Integratest.WebApi.Services.Interfaces;

namespace Integratest.WebApi.Services.Services
{
    public class TestCaseService : ITestCaseService
    {
        private readonly IDataTestCaseService _dataTestCaseService;

        public TestCaseService(IDataTestCaseService dataTestCaseService)
        {
            _dataTestCaseService = dataTestCaseService;
        }

        public async Task<Guid> AddTestCase(TestCaseRequest testCaseRequest)
        {
            if (testCaseRequest.AccountId == null)
                throw new ArgumentNullException(nameof(testCaseRequest.AccountId));

            var testCase = new DataTestCaseRequest()
            {
                AccountId = testCaseRequest.AccountId,
                Title = testCaseRequest.Title
            };

            var id = await _dataTestCaseService.AddTestCase(testCase);

            return Guid.Parse(id);
        }

        public async Task<TestCasesDto> GetTestCase(Guid id, Guid accountId)
        {
            return await _dataTestCaseService.GetTestCase(id.ToString(), accountId.ToString());

        }

        public async Task<List<TestCasesDto>> GetTestCasesForAccount(Guid accountId)
        {
            return await _dataTestCaseService.GetTestCasesForAccount(accountId.ToString());
        }

        public async Task DeleteTestCase(Guid id, Guid accountId)
        {
            await _dataTestCaseService.DeleteTestCase(id.ToString(), accountId.ToString());
        }
    }
}
