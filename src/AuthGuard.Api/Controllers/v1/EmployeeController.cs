using EasyWeb.AspNetCore.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthGuard.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    [Authorize]
    [Route("v{ver:apiVersion}/employees")]
    public class EmployeeController : BaseApiController
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Test");
        }
    }
}
