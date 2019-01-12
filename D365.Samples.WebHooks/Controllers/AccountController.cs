using D365.Samples.WebHooks.Helpers;
using D365.Samples.WebHooks.Models;
using Dynamics365AutoMapper;
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
            JObject postImage = (JObject)data["PostEntityImages"][0]["value"];

            // instantiate model
            AccountModel model = new AccountModel();

            // map jobject data to model
            DynamicsCrmMappingUtility<AccountModel>.CustomMappingMethod = CustomAutoMapsHelper.CustomMapping;
            DynamicsCrmMappingUtility<AccountModel>.MapToModel(postImage, model);

            string test = model.AccountName;
        }
    }
}
