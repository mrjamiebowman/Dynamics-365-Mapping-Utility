using D365.Samples.WebHooks.Models;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Dynamics365AutoMapper.Tests.ColumnSets {
    public class ColumnSetsTests {
        [Fact]
        public void GetColumnSetsTests() {
            ColumnSet columnSet = DynamicsCrmAutoMapper<AccountModel>.GetColumnSetByProperties(x => x.AccountId, x => x.AccountName);

            // assert
            AccountModel model = new AccountModel();
            
        }
    }
}
