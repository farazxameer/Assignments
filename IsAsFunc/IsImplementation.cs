using System;

namespace IsAsFunc
{
    class IsImplementation
    {
        ///<summary>
        ///This method will check whether the object is of type 'T' or not, if it is of type 'T' then
        ///it will return true ortherwise it will return false. 
        ///<summary>
        public static bool Is<T>(object obj)
        {
            if (obj.GetType() == null)
            {
                return false;
            }
            else if (typeof(T) == obj.GetType())
            {
                return true;
            }
            else if (obj.GetType().IsSubclassOf(typeof(T)))
            {
                return true;
            }
            else if (typeof(T).IsInterface)
            {
                return IsInterfaceImplemented(obj.GetType(), typeof(T));
            }
            return false;
        }

        public static bool Is(object firstObject, object secondObject)
        {
            return firstObject.GetHashCode() == secondObject.GetHashCode();
        }

        ///<summary>
        ///This method will check whether the object is implementes the interface type, if it implementes
        ///interfaceType it will return true otherwise false. 
        ///<summary>
        private static bool IsInterfaceImplemented(Type objectType, Type interfaceType)
        {
            while (objectType != null)
            {
                Type[] interfaces = objectType.GetInterfaces();
                if (interfaces != null)
                {
                    for (int i = 0; i < interfaces.Length; i++)
                    {
                        if (interfaces[i] == interfaceType || (interfaces[i] != null && IsInterfaceImplemented(interfaces[i], interfaceType)))
                            return true;
                    }
                }
                objectType = objectType.BaseType;
            }
            return false;
        }
    }
}