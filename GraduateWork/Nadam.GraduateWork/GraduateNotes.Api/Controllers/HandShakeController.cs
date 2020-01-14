using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduateNotes.API.Controllers
{
    [Route("api/handshake")]
    [ApiController]
    public class HandShakeController : ControllerBase
    {
        [Route("echo/{message}")]
        [HttpGet]
        public string Echo([FromHeader] string message)
        {
            return message.ToUpper();
        }

        [Route("hello")]
        [HttpGet]
        public string JustSayHi()
        {
            return "Hello from Gradue notes!";
        }
    }
}