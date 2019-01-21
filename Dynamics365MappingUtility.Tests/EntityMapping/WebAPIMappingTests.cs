using D365.Samples.WebHooks.Enums;
using D365.Samples.WebHooks.Helpers;
using D365.Samples.WebHooks.Models;
using DynamicsCrmMappingUtility.DataTypes;
using DynamicsCrmMappingUtility.Tests.Helpers;
using Microsoft.Xrm.Sdk;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DynamicsCrmMappingUtility.Tests.EntityMapping {
    public class WebAPIMappingTests {
        [Fact]
        public void MapWebAPIToModel() {
            AccountModel model = new AccountModel();

            // get web hook data
            JObject data = WebHookHelper.LoadWebHookData("account_update.txt");
            JObject postImage = (JObject)data["PostEntityImages"][0]["value"];

            // map jobject data to model
            DynamicsCrmMappingUtility<AccountModel>.CustomMappingMethod = CustomAutoMapsHelper.CustomMapping;
            DynamicsCrmMappingUtility<AccountModel>.MapToModel(postImage, model);

            // assert
            Assert.Equal(new Guid("aaa19cdd-88df-e311-b8e5-6c3be5a8b200"), model.AccountId);
            Assert.Equal("Alpine Ski House 2", model.AccountName);
            Assert.Equal("AFFSE9IK", model.AccountNumber);
            Assert.Equal(new Guid("{be403faf-2baf-4856-bbc7-ead86e179b4c}"), model.OwnerId);
            Assert.Equal(50000, model.CreditLimit);
            Assert.Equal(CustomerTypeCodeType.Customer, model.CustomerTypeCode);
            Assert.Equal("Alpine Ski House description", model.Description);
            Assert.Equal(false, model.DoNotEmail);
            Assert.Equal(true, model.DoNotPhone);
            Assert.Equal("Cathan@alpineskihouse.com", model.Email);
            //Assert.Equal(null, model.EntityImage);
            Assert.Equal(Convert.ToDateTime("1/21/2019 1:43:55 AM"), model.ModifiedOn);
            Assert.Equal(Convert.ToDateTime("1/20/2017 10:39:16 PM"), model.CreatedOn);
            Assert.Equal(0, (int)model.State);
            Assert.Equal(CRMStateType.Active, model.State);
            Assert.Equal(1, model.Status);
            Assert.Equal("http://www.alpineskihouse.com", model.Website);
            Assert.Equal(null, model.OpenDeals);
            Assert.Equal("Am Euro Platz 0101\nA-1111 Vienna State\nAustria", model.Address1Composite);
            

            // assert address
            Assert.Equal("Am Euro Platz 0101", model.Address1Line1);
            Assert.Equal("Vienna", model.Address1City);
            Assert.Equal("State", model.Address1State);
            Assert.Equal("A-1111", model.Address1PostalCode);
            Assert.Equal("Austria", model.Address1Country);           
        }
    }
}
