# Dynamics 365 (D365) Entity/WebHook Auto Mapper for C#
This tool will map data from Dynamics 365 entities, json, or webhook calls into C# model classes using property metadata.

| Master | Develop |
|:------:|:-------:|
|[![Build status](https://ci.appveyor.com/api/projects/status/7y6wth92quqr4ssn/branch/master?svg=true)](https://ci.appveyor.com/project/mrjamiebowman/dynamics-365-automapper/branch/master)|[![Build status](https://ci.appveyor.com/api/projects/status/7y6wth92quqr4ssn/branch/develop?svg=true)](https://ci.appveyor.com/project/mrjamiebowman/dynamics-365-automapper/branch/develop)|

| Issues | Forks | Starts | License | Tweets |
|:--------:|:-------:|:--------:|:---------:|:--------:|
| ![](https://img.shields.io/github/issues/mrjamiebowman/Dynamics-365-Mapping-Utility.svg?style=for-the-badge) | ![](https://img.shields.io/github/forks/mrjamiebowman/Dynamics-365-Mapping-Utility.svg?style=for-the-badge) | ![](https://img.shields.io/github/stars/mrjamiebowman/Dynamics-365-Mapping-Utility.svg?style=for-the-badge) | ![](https://img.shields.io/github/license/mrjamiebowman/Dynamics-365-Mapping-Utility.svg?style=for-the-badge) | ![](https://img.shields.io/twitter/url/https/github.com/mrjamiebowman/Dynamics-365-Mapping-Utility.svg?style=social?style=for-the-badge) |

## NuGet Package

## Getting Started

Create your POCO class that will represent the entity model. The CRM attribute classes will reference the entity and fieldnames in CRM.

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

```csharp
DynamicsCrmAutoMapper<AccountModel>.CustomMappingMethod = customMapping<AccountModel>;  
AccountModel accountModel = DynamicsCrmAutoMapper<AccountModel>.MapDataCrmToModel(postImage, accountModel);
```

## Contributing

## Roadmap

## Backlog

## Special Thanks

Automate The Planet, this article helped a lot with expressions. https://www.automatetheplanet.com/get-property-names-using-lambda-expressions/
