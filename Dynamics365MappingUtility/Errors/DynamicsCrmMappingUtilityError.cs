using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicsCrmMappingUtility.Errors
{
    [Serializable()]
    public class DynamicsCrmMappingUtilityError : System.Exception
    {
        public DynamicsCrmMappingUtilityError() : base() { }
        public DynamicsCrmMappingUtilityError(string message) : base(message) { }
        public DynamicsCrmMappingUtilityError(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client. 
        protected DynamicsCrmMappingUtilityError(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
