using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace D365.Samples.WebHook.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase {
        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value) {

        }
    }
}
