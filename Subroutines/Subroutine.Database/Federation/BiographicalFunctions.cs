using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Subroutine.Database.Services;
using Subroutine.Database.Data;
using LCARS.Core.Data.Federation;
using System.Net;

namespace Subroutine.Database.Federation
{
    public class BiographicalFunctions
    {
        private readonly BiographicalDataContext biographicalContext;

        public BiographicalFunctions(BiographicalDataContext biographicalContext)
        {
            this.biographicalContext = biographicalContext;
        }

        [FunctionName(nameof(GetBiographicalData))]
        public async Task<IActionResult> GetBiographicalData(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "federation/biographical/{name:alpha?}")] HttpRequest request,
            ILogger log,
            string name)
        {
            var queryParams = request.GetQueryParameterDictionary();
            queryParams.TryGetValue("name", out name);

            log.LogInformation($"Biographical {name} retrieval in progress...");

            var list = await biographicalContext.GetBiographicalDataProfileAsync();
            return new OkObjectResult(list);
        }

        [FunctionName(nameof(CreateBiographicalData))]
        public async Task<IActionResult> CreateBiographicalData(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "federation/biographical")] HttpRequest request, 
            ILogger logger)
        {
            logger.LogInformation("Biographical saving in progress...");

            string requestBody = await new StreamReader(request.Body).ReadToEndAsync();
            BiographicalData biographicalData = JsonConvert.DeserializeObject<BiographicalData>(requestBody);
            await biographicalContext.CreateBiographicalDataProfile(biographicalData);
            return new OkObjectResult("Biographical data saved...");
        }
    }
}
