using ApplicationLayer.Queries.EmployeeQuery;
using DomainLayer.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;
using Serilog;
using System.Configuration;
using System.Diagnostics;
using WebAPI.Fillters;

namespace WebAPI_2.Controllers
{

    [Route("api/OrganizationChart")]
    [ApiController]
    [Authorize]
    //[ServiceFilter(typeof(AwsTokenAuthorizationFilter))]  
    //[EnableCors("_myAllowSpecificOrigins")]
    
    public class OrganizationChartController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IMediator mediator;
        private readonly IConfiguration _config;
        public OrganizationChartController(IMediator mediator, ILoggerManager logger, IConfiguration configuration)
        {
            _logger = logger;
            this.mediator = mediator;
            _config = configuration;

         

        }

        [HttpPost]
        public async Task<IActionResult> Get(
             string? searchTerm,
          string? sortColumn,
          string? sortOrder,
          int page,
          int pageSize
            )
        {
            string ApplicationLogType = _config["ApplicationLogType"];
            if (ApplicationLogType == "1" || ApplicationLogType == "4")
            {
                _logger.LogInfo("Here is info message from the controller.");
                _logger.LogDebug("Here is debug message from the controller.");
                _logger.LogWarn("Here is warn message from the controller.");
                _logger.LogError(new Exception("Sample exception"), "Whoops!");
            }
            else
            {

                Serilog.Log.Information("Here is info message from the controller.");
                Serilog.Log.Information("Here is info message from the controller.");
                Serilog.Log.Error("Here is info message from the controller.");
                try
                {
                    var zero = 0;
                    var test = 111 / zero;

                }
                catch (Exception ex)
                {

                    Serilog.Log.Error(ex, "Whoops");
                }

            }


            return Ok(await mediator.Send(new GetOrganizationalChartListQuery
            {

                searchTerm = searchTerm,
                sortColumn = sortColumn,
                sortOrder = sortOrder,
                page = page,
                pageSize = pageSize
            }));

        }


        
        [HttpPost("GetReportingTo", Name = "GetReportingTo")]
        public async Task<IActionResult> GetReportingTo([FromQuery] string ManagerId)
        {
            try
            {
                return Ok(await mediator.Send(new GetReportingListQuery
                {
                    ManagerId = Convert.ToInt32(ManagerId),
                }));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }




        }

        [HttpPost("GetOrgnisationdetailesById", Name = "GetOrgnisationdetailesById")]
        public async Task<IActionResult> GetOrgnisationdetailesById([FromQuery] string Id="", [FromQuery] string UserPrincipalName="")
        {
            try
            {
              
                return Ok(await mediator.Send(new GetOrgnisationdetailesByIdQuery
                {
                    ID = string.IsNullOrEmpty(Id)?0:Convert.ToInt32(Id),
                    UserPrincipalName= UserPrincipalName
                }));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }




        }
       
        [HttpPost("Organizational_Vulnerability", Name = "Organizational_Vulnerability")]
        public async Task<IActionResult> GetOrganizational_Vulnerability([FromQuery] string OrganizationalId)
        {
            try
            {
                return Ok(await mediator.Send(new Organizational_VulnerabilityQuery
                {
                    OrganizationalId = Convert.ToInt32(OrganizationalId),
                }));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }




        }


    }
}
