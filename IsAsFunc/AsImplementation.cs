using System;

namespace IsAsFunc
{
    class AsImplementation
    {
        ///<summary>
        ///This method will check whether the valueType is of type 'T' or not, if it is of type 'T' then
        ///it will return the value, ortherwise it will return null. 
        ///<summary>
        public static T? As<T>(ValueType value) where T : struct
        {
            bool isType = IsImplementation.Is<T>(value);
            if (isType)
            {
                return (T)(object)value;
            }
            return null;
        }

        ///<summary>
        ///This method will check whether the object is of type 'T' or not, if it is of type 'T' then
        ///it will return the object, ortherwise it will return null. 
        ///<summary>
        public static T As<T>(object obj)
        {
            bool isType = IsImplementation.Is<T>(obj);
            if (isType)
            {
                return (T)(object)obj;
            }
            return default(T);
        }
    }    
}