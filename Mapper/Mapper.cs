using System;
using System.Collections.Generic;
using System.Reflection;

namespace Mapper
{
    class Mapper
    {
        static List<Type> source = new List<Type>() { null };
        static List<Type> destination = new List<Type>() { null };
        static List<object> objects = new List<object>() { null };
        
        ///<summary>
        ///This method will create a Map between TSource and Tdestination. If Map is Already created it will output Already Map Exists!!.
        ///</summary>
        public static void CreateMap<TSource, TDestination>()
        {
            if (!IsMapped<TSource, TDestination>())
            {
                NewMap<TSource, TDestination>();
            }
            else
            {
                Console.WriteLine("Map Already Exists !!!");
            }
        }
        ///<summary>
        ///This method will create a Map with the custom configuration.
        ///</summary>
        public static void Config<TSource, TDestination>(Dictionary<string, string> customMap)
        {
            if (!IsMapped<TSource, TDestination>())
            {
                NewMap<TSource, TDestination>();
                int index = GetIndex<TSource, TDestination>();
                InstanceMapper<TSource, TDestination> obj = (InstanceMapper<TSource, TDestination>)objects[index];
                obj.CustomMap(customMap);
            }
            else
            {
                int index = GetIndex<TSource, TDestination>();
                InstanceMapper<TSource, TDestination> obj = (InstanceMapper<TSource, TDestination>)objects[index];
                obj.CustomMap(customMap);
            }
        }
        ///<summary>
        ///This method checks that map already exists or not, if already exist it returns true otherwise false
        ///</summary>
        private static bool IsMapped<TSource, TDestination>()
        {
            for (int i = 0; i < source.Count; i++)
            {
                if (source[i] == typeof(TSource) && destination[i] == typeof(TDestination))
                {
                    return true;
                }
            }
            return false;
        }

        ///<summary>
        ///This method will create a new map between TSource and Tdestination
        ///</summary>
        private static void NewMap<TSource, TDestination>()
        {
            source.Add(typeof(TSource));
            destination.Add(typeof(TDestination));
            objects.Add(new InstanceMapper<TSource, TDestination>());
        }
        ///<summary>
        ///This method returns will return the index value of the kist where the Map is present 
        ///</summary>
        private static int GetIndex<TSource, TDestination>()
        {
            for (int i = 0; i <= source.Count; i++)
            {
                if (source[i] == typeof(TSource) && destination[i] == typeof(TDestination))
                {
                    return i;
                }
            }
            return -1;
        }

        ///<summary>
        ///This method will map the source parameter to the TDestination object. 
        ///</summary>
        public static TDestination Map<TSource, TDestination>(TSource source)
        {
            if (IsMapped<TSource, TDestination>())
            {
                int index = GetIndex<TSource, TDestination>();
                InstanceMapper<TSource, TDestination> obj = (InstanceMapper<TSource, TDestination>)objects[index];
                TDestination destination = obj.Map(source);
                return destination;
            }
            else
            {
                Console.WriteLine("No Map Exists !!!");
                return default(TDestination);
            }
        }
    }
}
