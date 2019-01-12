using D365.Samples.WebHooks.Models;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DynamicsCrmMappingUtility.Tests.ColumnSets {
    public class ColumnSetsTests {
        [Fact]
        public void GetColumnSetsTests() {
             ColumnSet columnSet = DynamicsCrmMappingUtility<AccountModel>.GetColumnSetByFields(
                x => x.AccountId, 
                x => x.AccountName, 
                x => x.AccountNumber, 
                x => x.CreatedOn);

            // assert
            AccountModel model = new AccountModel();
            
        }
    }
}
