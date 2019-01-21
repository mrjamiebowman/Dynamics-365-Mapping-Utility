using D365.Samples.WebHooks.Models;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DynamicsCrmMappingUtility.Tests.Legacy {
    
    public class EntityMappingTests {
        [Fact]
        public void MapModelToEntityTestAll() {
            AccountModel model = new AccountModel();
            model.AccountId = new Guid("B14AD0D0-83FB-4D86-BE02-4549436F8B43");
            model.AccountName = "Alpine Ski House";
            model.AccountNumber = "ACCT1234";

            // map model to entity
            Entity accountEntity = DynamicsCrmMappingUtility<AccountModel>.MapToEntity(model, null);

            Assert.Equal("account", accountEntity.LogicalName);
            Assert.Equal(model.AccountName, accountEntity["name"].ToString());
            Assert.Equal(model.AccountNumber, accountEntity["accountnumber"].ToString());
        }

        [Fact]
        public void MapModelToEntityTestOnlySelected() {
            AccountModel model = new AccountModel();
            model.AccountId = new Guid("B14AD0D0-83FB-4D86-BE02-4549436F8B43");
            model.AccountName = "Alpine Ski House";
            model.AccountNumber = "ACCT1234";

            // map model to entity
            Entity accountEntity = DynamicsCrmMappingUtility<AccountModel>.MapToEntity(model, null, x => x.AccountName, x => x.AccountId);

            Assert.Equal("account", accountEntity.LogicalName);
            Assert.Equal(model.AccountId, (Guid)accountEntity["accountid"]);
            Assert.Equal(model.AccountName, accountEntity["name"].ToString());
            Assert.False(accountEntity.Attributes.Contains("accountnumber"));
        }
    }
}
