﻿using LogServiceRequests;
using LogServiceResponseMessages;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Security.Claims;

namespace FusionIndex_Calculator.Controllers
{
    /// <summary>
    /// TODO TRY CATCH
    /// </summary>
    [Route("saloomon/[controller]")]
    [Authorize(Policy = "AdministratorsOnly")]
    public class LogController : Controller
    {
        private readonly IRequestClient<FusionIndex_Calculator.LogServiceRequests.GetAllLogsRequest, LogListResponse> _allLogsClient;
        private readonly IRequestClient<GetLogsByDateAfter, LogListResponse> _logsByDateAfterClient;
        private readonly IRequestClient<GetLogsByDateBefore, LogListResponse> _logsByDateBeforeClient;
        private readonly IRequestClient<GetLogsByDateBetween, LogListResponse> _logsByDateBetweenClient;
        private readonly IRequestClient<GetLogsByLevelRequest, LogListResponse> _getLogsByLevelClient;


        public LogController(IRequestClient<GetAllLogsRequest, LogListResponse> allLogsClient, IRequestClient<GetLogsByDateAfter, LogListResponse> logsByDateAfterClient,
            IRequestClient<GetLogsByDateBefore, LogListResponse> logsByDateBeforeClient, IRequestClient<GetLogsByDateBetween, LogListResponse> logsByDateBetweenClient,
            IRequestClient<GetLogsByLevelRequest, LogListResponse> getLogsByLevelClient)
        {
            _allLogsClient = allLogsClient;
            _logsByDateAfterClient = logsByDateAfterClient;
            _logsByDateBeforeClient = logsByDateBeforeClient;
            _logsByDateBetweenClient = logsByDateBetweenClient;
            _getLogsByLevelClient = getLogsByLevelClient;
        }



        [HttpGet]
        [ProducesResponseType(500)]
        [ProducesResponseType(200, Type = typeof(List<LogEntry>))]
        public async Task<IActionResult> GetAllLogs()
        {
            try
            {
                var userId = HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var res = await _allLogsClient.Request(new { AdminId = userId });
                if (res == null) return StatusCode(500);
                return Ok(res);
            }
            catch (Exception e)
            {
                Log.Error($"Exception thrown in LogController -> GetAllLogs  Message : {e}");
                return StatusCode(500);
            }

        }

        [HttpGet("/logsAfter")]
        [ProducesResponseType(500)]
        [ProducesResponseType(200, Type = typeof(List<LogEntry>))]
        public async Task<IActionResult> GetLogsByDateAfter([FromQuery(Name = "after")] DateTime date)
        {
            var userId = HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var res = await _logsByDateAfterClient.Request(new { AdminId = userId, Date = date });
            if (res == null) return StatusCode(500);
            return Ok(res);
        }

        [HttpGet("/logsBefore")]
        [ProducesResponseType(500)]
        [ProducesResponseType(200, Type = typeof(List<LogEntry>))]
        public async Task<IActionResult> GetLogsByDateBefore([FromQuery(Name = "before")] DateTime date)
        {
            var userId = HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var res = await _logsByDateBeforeClient.Request(new { AdminId = userId, Date = date });
            if (res == null) return StatusCode(500);
            return Ok(res);
        }

        [HttpGet("/logsBetween")]
        [ProducesResponseType(500)]
        [ProducesResponseType(200, Type = typeof(List<LogEntry>))]
        public async Task<IActionResult> GetLogsByDateBetween([FromQuery(Name = "after")] DateTime lower, [FromQuery(Name = "before")] DateTime upper)
        {
            var userId = HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var res = await _logsByDateBetweenClient.Request(new { AdminId = userId, DateAfter = lower, DateBefore = upper });
            if (res == null) return StatusCode(500);
            return Ok(res);
        }

        [HttpGet("/logsByLevel/{level}")]
        [ProducesResponseType(500)]
        [ProducesResponseType(200, Type = typeof(List<LogEntry>))]
        public async Task<IActionResult> GetLogsByLevel(ELevel level)
        {
            var userId = HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var res = await _getLogsByLevelClient.Request(new { AdminId = userId, Level = level });
            if (res == null) return StatusCode(500);
            return Ok(res);
        }
    }
}
