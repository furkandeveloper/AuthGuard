using AuthGuard.Application.Dtos;
using AuthGuard.Application.Services.Abstractions;
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
        private readonly IEmployeeApplicationService employeeApplicationService;

        public EmployeeController(IEmployeeApplicationService employeeApplicationService)
        {
            this.employeeApplicationService = employeeApplicationService;
        }

        /// <summary>
        /// Advanced Filter for Employee
        /// </summary>
        /// <param name="model">
        /// Employee Filter Data Transfer Object. <see cref="EmployeeFilterDto"/>
        /// </param>
        /// <returns>
        /// List of Employee Response Data Transfer Object. <see cref="List{EmployeeResponseDto}"/>
        /// </returns>
        [HttpGet(Name = "AdvancedFilter")]
        [ProducesResponseType(typeof(EmployeeResponseDto[]), 200)]
        public async Task<IActionResult> AdvancedFilterAsync([FromQuery] EmployeeFilterDto model)
        {
            return Ok(await employeeApplicationService.FilterAsync(model), new Dictionary<string, int>
            {
                { "TotalCount",await employeeApplicationService.CountAsync() }
            });
        }

        /// <summary>
        /// Insert Employee
        /// </summary>
        /// <param name="model">
        /// Employee Request Data Transfer Object. <see cref="EmployeeRequestDto"/>
        /// </param>
        /// <returns>
        /// Employe Response Data Transfer Object. <see cref="EmployeeResponseDto"/>
        /// </returns>
        [HttpPost(Name = "Insert")]
        [ProducesResponseType(typeof(EmployeeResponseDto), 200)]
        public async Task<IActionResult> InsertAsync([FromBody] EmployeeRequestDto model)
        {
            return Ok(await employeeApplicationService.AddAsync(model));
        }

        /// <summary>
        /// Update Employee
        /// </summary>
        /// <param name="id">
        /// PK of Employee
        /// </param>
        /// <param name="model">
        /// Employee Request Data Transfer Object. <see cref="EmployeeRequestDto"/>
        /// </param>
        /// <returns>
        /// Employe Response Data Transfer Object. <see cref="EmployeeResponseDto"/>
        /// </returns>
        [HttpPut("{id}", Name = "Update")]
        [ProducesResponseType(typeof(EmployeeResponseDto), 200)]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] EmployeeRequestDto model)
        {
            return Ok(await employeeApplicationService.UpdateAsync(id, model));
        }

        /// <summary>
        /// Delete Employee
        /// </summary>
        /// <param name="id">
        /// PK of Employee
        /// </param>
        /// <returns>
        /// No Content Result. <see cref="NoContentResult"/>
        /// </returns>
        [HttpDelete("{id}", Name = "Delete")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            await employeeApplicationService.DeleteAsync(id);
            return NoContent();
        }
    }
}
