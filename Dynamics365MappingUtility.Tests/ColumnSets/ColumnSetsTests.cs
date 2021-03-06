﻿using D365.Samples.WebHooks.Models;
using Microsoft.Xrm.Sdk.Query;
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
            Assert.Equal(4, columnSet.Columns.Count);            
        }
    }
}
