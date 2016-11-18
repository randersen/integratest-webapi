using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Integratest.Data.DataModels;
using Integratest.WebApi.Models;
using Integratest.WebApi.Services.Interfaces;

namespace Integratest.WebApi.Host.Controllers
{
    [RoutePrefix("test-cases")]
    public class TestCasesController : ApiController
    {

        private readonly ITestCaseService _testCaseService;

        public TestCasesController(ITestCaseService testCaseService)
        {
            _testCaseService = testCaseService;
        }

        [HttpGet]
        [Route("")]
        public async Task<TestCasesDto> GetTestCase([FromUri]Guid testCaseId, [FromUri]Guid accountId)
        {
            return await _testCaseService.GetTestCase(testCaseId, accountId);
        }

        [HttpGet]
        [Route("{accountId}")]
        public async Task<List<TestCasesDto>> GetTestCasesForAccount([FromUri]Guid accountId)
        {
            return await _testCaseService.GetTestCasesForAccount(accountId);
        }

        [HttpPost]
        [Route("")]
        public async Task<Guid> AddTestCase([FromBody]TestCaseRequest testCaseRequest)
        {
            return await _testCaseService.AddTestCase(testCaseRequest);
        }

        
        
        [HttpDelete]
        [Route("")]
        public async Task<HttpResponseMessage> DeleteTestCase([FromUri]Guid testCaseId, [FromUri]Guid accountId)
        {
            await _testCaseService.DeleteTestCase(testCaseId, accountId);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }


    }
}
