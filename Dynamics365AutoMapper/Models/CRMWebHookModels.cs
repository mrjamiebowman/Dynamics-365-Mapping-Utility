using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamics365AutoMapper.Models {
    public class Rootobject {
        public string BusinessUnitId { get; set; }
        public string CorrelationId { get; set; }
        public int Depth { get; set; }
        public string InitiatingUserId { get; set; }
        public Inputparameter3[] InputParameters { get; set; }
        public bool IsExecutingOffline { get; set; }
        public bool IsInTransaction { get; set; }
        public bool IsOfflinePlayback { get; set; }
        public int IsolationMode { get; set; }
        public string MessageName { get; set; }
        public int Mode { get; set; }
        public DateTime OperationCreatedOn { get; set; }
        public string OperationId { get; set; }
        public string OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public object[] OutputParameters { get; set; }
        public Owningextension OwningExtension { get; set; }
        public Parentcontext ParentContext { get; set; }
        public Postentityimage1[] PostEntityImages { get; set; }
        public object[] PreEntityImages { get; set; }
        public string PrimaryEntityId { get; set; }
        public string PrimaryEntityName { get; set; }
        public string RequestId { get; set; }
        public string SecondaryEntityName { get; set; }
        public object[] SharedVariables { get; set; }
        public int Stage { get; set; }
        public string UserId { get; set; }
    }

    public class Owningextension {
        public string Id { get; set; }
        public object[] KeyAttributes { get; set; }
        public string LogicalName { get; set; }
        public object Name { get; set; }
        public object RowVersion { get; set; }
    }

    public class Parentcontext {
        public string BusinessUnitId { get; set; }
        public string CorrelationId { get; set; }
        public int Depth { get; set; }
        public string InitiatingUserId { get; set; }
        public Inputparameter2[] InputParameters { get; set; }
        public bool IsExecutingOffline { get; set; }
        public bool IsInTransaction { get; set; }
        public bool IsOfflinePlayback { get; set; }
        public int IsolationMode { get; set; }
        public string MessageName { get; set; }
        public int Mode { get; set; }
        public DateTime OperationCreatedOn { get; set; }
        public string OperationId { get; set; }
        public string OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public object[] OutputParameters { get; set; }
        public Owningextension1 OwningExtension { get; set; }
        public Parentcontext1 ParentContext { get; set; }
        public object[] PostEntityImages { get; set; }
        public object[] PreEntityImages { get; set; }
        public string PrimaryEntityId { get; set; }
        public string PrimaryEntityName { get; set; }
        public string RequestId { get; set; }
        public string SecondaryEntityName { get; set; }
        public object[] SharedVariables { get; set; }
        public int Stage { get; set; }
        public string UserId { get; set; }
    }

    public class Owningextension1 {
        public string Id { get; set; }
        public object[] KeyAttributes { get; set; }
        public string LogicalName { get; set; }
        public object Name { get; set; }
        public object RowVersion { get; set; }
    }

    public class Parentcontext1 {
        public string BusinessUnitId { get; set; }
        public string CorrelationId { get; set; }
        public int Depth { get; set; }
        public string InitiatingUserId { get; set; }
        public Inputparameter1[] InputParameters { get; set; }
        public bool IsExecutingOffline { get; set; }
        public bool IsInTransaction { get; set; }
        public bool IsOfflinePlayback { get; set; }
        public int IsolationMode { get; set; }
        public string MessageName { get; set; }
        public int Mode { get; set; }
        public DateTime OperationCreatedOn { get; set; }
        public string OperationId { get; set; }
        public string OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public object[] OutputParameters { get; set; }
        public Owningextension2 OwningExtension { get; set; }
        public Parentcontext2 ParentContext { get; set; }
        public Postentityimage[] PostEntityImages { get; set; }
        public Preentityimage[] PreEntityImages { get; set; }
        public string PrimaryEntityId { get; set; }
        public string PrimaryEntityName { get; set; }
        public string RequestId { get; set; }
        public string SecondaryEntityName { get; set; }
        public object[] SharedVariables { get; set; }
        public int Stage { get; set; }
        public string UserId { get; set; }
    }

    public class Owningextension2 {
        public string Id { get; set; }
        public object[] KeyAttributes { get; set; }
        public string LogicalName { get; set; }
        public object Name { get; set; }
        public object RowVersion { get; set; }
    }

    public class Parentcontext2 {
        public string BusinessUnitId { get; set; }
        public string CorrelationId { get; set; }
        public int Depth { get; set; }
        public string InitiatingUserId { get; set; }
        public Inputparameter[] InputParameters { get; set; }
        public bool IsExecutingOffline { get; set; }
        public bool IsInTransaction { get; set; }
        public bool IsOfflinePlayback { get; set; }
        public int IsolationMode { get; set; }
        public string MessageName { get; set; }
        public int Mode { get; set; }
        public DateTime OperationCreatedOn { get; set; }
        public string OperationId { get; set; }
        public string OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public object[] OutputParameters { get; set; }
        public Owningextension3 OwningExtension { get; set; }
        public object ParentContext { get; set; }
        public object[] PostEntityImages { get; set; }
        public object[] PreEntityImages { get; set; }
        public string PrimaryEntityId { get; set; }
        public string PrimaryEntityName { get; set; }
        public string RequestId { get; set; }
        public string SecondaryEntityName { get; set; }
        public Sharedvariable[] SharedVariables { get; set; }
        public int Stage { get; set; }
        public string UserId { get; set; }
    }

    public class Owningextension3 {
        public string Id { get; set; }
        public object[] KeyAttributes { get; set; }
        public string LogicalName { get; set; }
        public object Name { get; set; }
        public object RowVersion { get; set; }
    }

    public class Inputparameter {
        public string key { get; set; }
        public object value { get; set; }
    }

    public class Sharedvariable {
        public string key { get; set; }
        public Value[] value { get; set; }
    }

    public class Value {
        public string __type { get; set; }
        public string key { get; set; }
        public string value { get; set; }
    }

    public class Inputparameter1 {
        public string key { get; set; }
        public object value { get; set; }
    }

    public class Postentityimage {
        public string key { get; set; }
        public Value1 value { get; set; }
    }

    public class Value1 {
        public Attribute[] Attributes { get; set; }
        public object EntityState { get; set; }
        public Formattedvalue[] FormattedValues { get; set; }
        public string Id { get; set; }
        public object[] KeyAttributes { get; set; }
        public string LogicalName { get; set; }
        public object[] RelatedEntities { get; set; }
        public object RowVersion { get; set; }
    }

    public class Attribute {
        public string key { get; set; }
        public object value { get; set; }
    }

    public class Formattedvalue {
        public string key { get; set; }
        public object value { get; set; }
    }

    public class Preentityimage {
        public string key { get; set; }
        public Value2 value { get; set; }
    }

    public class Value2 {
        public Attribute1[] Attributes { get; set; }
        public object EntityState { get; set; }
        public Formattedvalue1[] FormattedValues { get; set; }
        public string Id { get; set; }
        public object[] KeyAttributes { get; set; }
        public string LogicalName { get; set; }
        public object[] RelatedEntities { get; set; }
        public object RowVersion { get; set; }
    }

    public class Attribute1 {
        public string key { get; set; }
        public object value { get; set; }
    }

    public class Formattedvalue1 {
        public string key { get; set; }
        public object value { get; set; }
    }

    public class Inputparameter2 {
        public string key { get; set; }
        public object value { get; set; }
    }

    public class Inputparameter3 {
        public string key { get; set; }
        public object value { get; set; }
    }

    public class Postentityimage1 {
        public string key { get; set; }
        public Value3 value { get; set; }
    }

    public class Value3 {
        public Attribute2[] Attributes { get; set; }
        public object EntityState { get; set; }
        public Formattedvalue2[] FormattedValues { get; set; }
        public string Id { get; set; }
        public object[] KeyAttributes { get; set; }
        public string LogicalName { get; set; }
        public object[] RelatedEntities { get; set; }
        public object RowVersion { get; set; }
    }

    public class Attribute2 {
        public string key { get; set; }
        public object value { get; set; }
    }

    public class Formattedvalue2 {
        public string key { get; set; }
        public object value { get; set; }
    }
}
