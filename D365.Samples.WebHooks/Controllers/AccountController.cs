using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace D365.Samples.WebHook.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase {
        [HttpGet]
        public string Get() {
            return "Dynamics 365 Entity/WebHook AutoMapper";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] JObject data) {
            string test = "";
            //JObject postImage = data?.PostEntityImages[0]?.value;
        }
    }
}
