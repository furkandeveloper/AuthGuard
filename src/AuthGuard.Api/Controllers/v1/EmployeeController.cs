﻿using AuthGuard.Application.Dtos;
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
    }
}
