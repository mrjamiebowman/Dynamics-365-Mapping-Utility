using D365.Samples.WebHooks.Enums;
using DynamicsCrmMappingUtility.Attributes;
using System;

namespace D365.Samples.WebHooks.Models {
    [CRMEntity("account")]
    public class AccountModel {

        [CRM(FieldName = "accountid")]
        public Guid? AccountId { get; set; }

        [CRM(FieldName = "name")]
        public string AccountName { get; set; }

        [CRM(FieldName = "accountnumber")]
        public string AccountNumber { get; set; }

        [CRM(FieldName = "createdon")]
        public DateTime? CreatedOn { get; set; }

        [CRM(FieldName = "modifiedon")]
        public DateTime? ModifiedOn { get; set; }
        
        // this field will have a custom map
        [CRM(FieldName = "customertypecode", CustomFieldMap = typeof(CustomerTypeCodeType?))]
        public CustomerTypeCodeType? CustomerTypeCode { get; set; }
    } 
}
