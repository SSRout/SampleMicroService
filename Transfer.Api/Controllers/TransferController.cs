using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Transfer.Application.Interfaces;
using Transfer.Domain.Models;

namespace Transfer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize("ClientIdPolicy")]
    public class TransferController : ControllerBase
    {
        private readonly ITransferService _transferService;
        private readonly ILogger<TransferController> _logger;

        public TransferController(ITransferService transferService,ILogger<TransferController> logger)
        {
            _transferService = transferService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TransferLog>> Get()
        {
            return Ok(_transferService.GetTransferLogs());
        }
    }
}
