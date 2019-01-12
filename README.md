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

```csharp
DynamicsCrmAutoMapper<AccountModel>.CustomMappingMethod = customMapping<AccountModel>;  
AccountModel accountModel = DynamicsCrmAutoMapper<AccountModel>.MapDataCrmToModel(postImage, accountModel);
```

## Contributing

## Roadmap

## Backlog

## Special Thanks

Automate The Planet, this article helped a lot with expressions. https://www.automatetheplanet.com/get-property-names-using-lambda-expressions/