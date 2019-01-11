using Dynamics365AutoMapper.Attributes;
using Dynamics365AutoMapper.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace D365.Samples.WebHooks.Models {
    public class AccountModel {

        [CRM(FieldName = "accountid")]
        public Guid? AccountId { get; set; }

        [CRM(FieldName = "accountid")]
        public string AccountName { get; set; }

        [CRM(FieldName = "createdon")]
        public DateTime? CreatedOn { get; set; }

        [CRM(FieldName = "modifiedon")]
        public DateTime? ModifiedOn { get; set; }
        
        // this field will have a custom map
        //[CRM(FieldName = "customertypecode", CustomFieldMap = CustomerTypeCode?.GetType())]
        public CustomerTypeCode? CustomerTypeCode { get; set; }
    } 
}
