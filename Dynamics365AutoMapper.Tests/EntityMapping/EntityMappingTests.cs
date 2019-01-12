using D365.Samples.WebHooks.Models;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Dynamics365AutoMapper.Tests.EntityMapping {
    
    public class EntityMappingTests {
        [Fact]
        public void MapModelToEntityTest() {
            AccountModel model = new AccountModel();
            model.AccountId = new Guid("B14AD0D0-83FB-4D86-BE02-4549436F8B43");
            model.AccountName = "Alpine Ski House";
            model.AccountNumber = "ACCT1234";

            // map jobject data to model
            //DynamicsCrmAutoMapper<AccountModel>.CustomMappingMethod = CustomAutoMapsHelper.CustomMapping;
            Entity accountEntity = DynamicsCrmMappingUtility<AccountModel>.MapToEntity(model, null);

            
        }
    }
}
