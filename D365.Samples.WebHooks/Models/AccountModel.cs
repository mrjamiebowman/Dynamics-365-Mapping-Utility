using D365.Samples.WebHooks.Enums;
using DynamicsCrmMappingUtility.Attributes;
using System;

namespace D365.Samples.WebHooks.Models {
    [CRMEntity("account")]
    public class AccountModel 
    {
        [CRM(FieldName = "accountid")]
        public Guid? AccountId { get; set; }

        [CRM(FieldName = "name")]
        public string AccountName { get; set; }

        [CRM(FieldName = "accountnumber")]
        public string AccountNumber { get; set; }

        [CRM(FieldName = "createdon")]
        public DateTime? CreatedOn { get; set; }

        [CRM(FieldName = "creditlimit")]
        public Decimal? CreditLimit { get; set; }

        // this field will have a custom map
        [CRM(FieldName = "customertypecode", CustomFieldMap = typeof(CustomerTypeCodeType?))]
        public CustomerTypeCodeType? CustomerTypeCode { get; set; }

        [CRM(FieldName = "donotemail")]
        public bool? DoNotEmail { get; set; }

        [CRM(FieldName = "entityimage")]
        public Decimal? EntityImage { get; set; }

        [CRM(FieldName = "modifiedon")]
        public DateTime? ModifiedOn { get; set; }

        [CRM(FieldName = "opendeals")]
        public int? OpenDeals { get; set; }

        [CRM(FieldName = "owninguser")]
        public string OwningUserName { get; set; }

        [CRM(FieldName = "owninguser")]
        public Guid? OwningUserId { get; set; }

        [CRM(FieldName = "ownerid")]
        public Guid? OwnerId { get; set; }

        [CRM(FieldName = "status")]
        public int? Status { get; set; }

        [CRM(FieldName = "websiteurl")]
        public string Website { get; set; }
        
        // address
        [CRM(FieldName = "address1_name")]
        public string Address1Name { get; set; }

        [CRM(FieldName = "address1_id")]
        public Guid? Address1LineId { get; set; }

        [CRM(FieldName = "address1_line1")]
        public string Address1Line1 { get; set; }

        [CRM(FieldName = "address1_city")]
        public string Address1City { get; set; }

        [CRM(FieldName = "address1_state")]
        public string Address1State { get; set; }

        [CRM(FieldName = "address1_postalcode")]
        public string Address1PostalCode { get; set; }

        [CRM(FieldName = "address1_country")]
        public string Address1Country { get; set; }

        [CRM(FieldName = "address1_composite")]
        public string Address1Composite { get; set; }

        [CRM(FieldName = "address1_longitude")]
        public string Address1Longitude { get; set; }
    } 
}
