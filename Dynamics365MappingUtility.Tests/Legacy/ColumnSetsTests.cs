using D365.Samples.WebHooks.Models;
using Microsoft.Xrm.Sdk.Query;
using Xunit;

namespace DynamicsCrmMappingUtility.Tests.Legacy {
    public class ColumnSetsTests {
        [Fact]
        [Trait("Category", "Legacy")]
        public void GetColumnSetsTests() {
             ColumnSet columnSet = DynamicsCrmMappingUtility<AccountModel>.GetColumnSetByFields(
                x => x.AccountId, 
                x => x.AccountName, 
                x => x.AccountNumber, 
                x => x.CreatedOn);

            // assert
            Assert.Equal(4, columnSet.Columns.Count);
            Assert.Equal("accountid", columnSet.Columns[0]);
            Assert.Equal("name", columnSet.Columns[1]);
            Assert.Equal("accountnumber", columnSet.Columns[2]);
            Assert.Equal("createdon", columnSet.Columns[3]);
        }
    }
}
