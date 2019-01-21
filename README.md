# Dynamics 365 (D365) Mapping Utility for C#
This tool will auto map data from Dynamics 365 entities, json, or webhook calls into C# model classes using property metadata.

| Master | Develop |
|:------:|:-------:|
|[![Build status](https://ci.appveyor.com/api/projects/status/7y6wth92quqr4ssn/branch/master?svg=true)](https://ci.appveyor.com/project/mrjamiebowman/dynamics-365-automapper/branch/master)|[![Build status](https://ci.appveyor.com/api/projects/status/7y6wth92quqr4ssn/branch/develop?svg=true)](https://ci.appveyor.com/project/mrjamiebowman/dynamics-365-automapper/branch/develop)|

| Issues | Forks | Starts | License | Tweets |
|:--------:|:-------:|:--------:|:---------:|:--------:|
| ![](https://img.shields.io/github/issues/mrjamiebowman/Dynamics-365-Mapping-Utility.svg?style=for-the-badge) | ![](https://img.shields.io/github/forks/mrjamiebowman/Dynamics-365-Mapping-Utility.svg?style=for-the-badge) | ![](https://img.shields.io/github/stars/mrjamiebowman/Dynamics-365-Mapping-Utility.svg?style=for-the-badge) | ![](https://img.shields.io/github/license/mrjamiebowman/Dynamics-365-Mapping-Utility.svg?style=for-the-badge) | ![](https://img.shields.io/twitter/url/https/github.com/mrjamiebowman/Dynamics-365-Mapping-Utility.svg?style=social?style=for-the-badge) |

## NuGet Package

## Getting Started

Create your POCO class that will represent the entity model. The CRM attribute classes will reference the entity and fieldnames in CRM.

#### AccountModel to represent Account Entity in Dynamics CRM

```csharp
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
````

#### Enumeration Type for OptionSetValue (Custom Mapping of Option Set to Enum)
````csharp
public enum CustomerTypeCodeType {
    Competitor = 1,
    Consultant = 2,
    Customer = 3,
    Investor = 4,
    Partner = 5,
    Influencer = 6,
    Press = 7,
    Prospect = 8,
    Reseller = 9,
    Supplier = 10,
    Vendor = 11,
    Other = 12
}
````

#### Custom Mapping Helper
````csharp
public class CustomMapsHelper {
    public static void CustomMapping<T>(T model, Type customFieldMap, PropertyInfo property, object value) where T : class {
        if (customFieldMap == typeof(CustomerTypeCodeType?)) {
            // CustomerTypeCodeType?
            OptionSetValue optSet = ((JObject)value).ToObject<OptionSetValue>();
            property.SetValue(model, (CustomerTypeCodeType)optSet.Value);
        }
    }
}
````

#### API WebHook
For this example we will be modeling the sample code after an API WebHook from Dynamics CRM.

```csharp
// POST api/values
[HttpPost]
public void Post([FromBody] JObject data) {            
    JObject postImage = (JObject)data["PostEntityImages"][0]["value"];

    // instantiate model
    AccountModel model = new AccountModel();

    // map JObject data to model
    DynamicsCrmMappingUtility<AccountModel>.CustomMappingMethod = CustomMapsHelper.CustomMapping;
    DynamicsCrmMappingUtility<AccountModel>.MapToModel(postImage, model);

    string accountName = model.AccountName;
    string accountNumber = model.AccountNumber;
}
```

### Legacy Support
As Dynamics CRM moves away from the SDK to the Web API endpoints, we will still provide support for the legacy CRM SDK. These tools will map data to and from the Entity object and ColumnSets.

#### Map Model to Entity

#### Map Entity to Model

#### Get ColumnSets from Model

## Contributing
@mrjamiebowman

## Roadmap
~ Ability to map data to view model  
~ Plugin tool for XrmToolBox to autogenerate POCO classes  
~ Work with Web API calls  

## Backlog

## Special Thanks

Automate The Planet, this article helped a lot with expressions. https://www.automatetheplanet.com/get-property-names-using-lambda-expressions/
