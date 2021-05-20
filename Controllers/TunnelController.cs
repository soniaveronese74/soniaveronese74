using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinelecBE.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class TunnelController : ControllerBase
    {
        private readonly LocalDb _localDb;
        private readonly ILogger<TunnelController> _logger;
        public TunnelController(LocalDb localDb, ILogger<TunnelController> logger)
        {
            _localDb = localDb;
            _logger = logger;
        }

        [HttpGet("/SetTunnel")]
        [EnableCors("SinelecPolicy")]
        public IActionResult SetTunnel(string name, int length, bool isFree)
        {
            _localDb.SetTunnel(name, length, isFree);
            return new OkResult();
        }

        [HttpGet("/GetTunnel")]
        [EnableCors("SinelecPolicy")]
        public IActionResult GetTunnel(string name)
        {
            return new OkObjectResult(_localDb.GeTtunnels(name).ToArray());
        }
    }
}
