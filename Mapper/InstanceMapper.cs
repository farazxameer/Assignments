using System;
using System.Collections.Generic;
using System.Reflection;

namespace Mapper
{
    class InstanceMapper<TSource, TDestination>
    {
        //Declaring a Dictationay that stores the fields info pairs of the Source and Destination that has to be mapped.
        Dictionary<FieldInfo, FieldInfo> fields = new Dictionary<FieldInfo, FieldInfo>();
        //Declaring the Dictionary that stores the properties info pairs of the Source and Destination that has to be mapped.
        Dictionary<PropertyInfo, PropertyInfo> properties = new Dictionary<PropertyInfo, PropertyInfo>();

        //This is the Default Constructor Which Finds the Identical Fields and Properties and stores them in respective Dictionaries 
        public InstanceMapper()
        {
            //Loops through every field in the Source and finds the identical field in Destination and Adds it to the field dictionary.
            foreach (FieldInfo fieldOfSource in typeof(TSource).GetFields())
            {
                FieldInfo fieldOfDestination = typeof(TDestination).GetField(fieldOfSource.Name);
                if (fieldOfDestination != null)
                {
                    fields.Add(fieldOfSource, fieldOfDestination);
                }
            }
            //Loops through every property in the Source and finds the identical property in Destination and Adds it to the property dictionary.
            foreach (PropertyInfo propertyOfSource in typeof(TSource).GetProperties())
            {
                PropertyInfo propertyOfDestination = typeof(TDestination).GetProperty(propertyOfSource.Name);
                if (propertyOfDestination != null)
                {
                    properties.Add(propertyOfSource, propertyOfDestination);
                }
            }
        }

        ///<summary>
        ///This Method will Manipulate the mapping and create a custom mapping along with the normal one. It adds the maps to fields and properties 
        ///which have different names.
        ///</summary>
        ///<param name="customMap" This is the Dictionary that has Custom maps>
        public void CustomMap(Dictionary<string, string> customMap)
        {
            Type typeOfSource = typeof(TSource);
            Type typeOfDestination = typeof(TDestination);
            //Loops through every pair in the dictionary and adds the map to the dictionary if not persent, if key already exist it updates the
            //dictionary with new value for that key.
            foreach (KeyValuePair<string, string> pair in customMap)
            {
                FieldInfo fieldOfSource = typeOfSource.GetField(pair.Key);
                FieldInfo fieldOfDestination = typeOfDestination.GetField(pair.Value);
                PropertyInfo propertyOfSource = typeOfSource.GetProperty(pair.Key);
                PropertyInfo propertyOfDestination = typeOfDestination.GetProperty(pair.Value);
                if (fieldOfSource != null && fieldOfDestination != null)
                {

                    if (fields.ContainsKey(fieldOfSource))
                    {
                        fields[fieldOfSource] = fieldOfDestination;
                    }
                    else
                    {
                        fields.Add(fieldOfSource, fieldOfDestination);
                    }
                }
                else if (propertyOfSource != null && propertyOfDestination != null)
                {
                    if (properties.ContainsKey(propertyOfSource))
                    {
                        properties[propertyOfSource] = propertyOfDestination;
                    }
                    else
                    {
                        properties.Add(propertyOfSource, propertyOfDestination);
                    }
                }
                else
                {
                    Console.WriteLine($"Error!! cannot find the elements to pair : {pair.Key} => {pair.Value} ");
                }
            }
        }

        ///<summary>
        ///This method willmap the elements of the dictionary the key will be mapped to the value of the dictionary. 
        ///</summary>
        public TDestination Map(TSource source)
        {
            TDestination destination = (TDestination)Activator.CreateInstance(typeof(TDestination));

            //Copy fields
            foreach (KeyValuePair<FieldInfo, FieldInfo> pair in fields)
            {
                if (pair.Key.FieldType.IsValueType || pair.Key.FieldType == Type.GetType("System.String"))
                {
                    pair.Value.SetValue(destination, pair.Key.GetValue(source));
                }
                else
                {
                    Type TSource = pair.Key.FieldType;
                    Type TDestination = typeof(TDestination).GetField(pair.Key.Name).FieldType;

                    MethodInfo methodinfo = typeof(Mapper).GetMethod("CreateMap");
                    MethodInfo genericMethod = methodinfo.MakeGenericMethod(TSource, TDestination);
                    genericMethod.Invoke(null, null);

                    methodinfo = typeof(Mapper).GetMethod("Map");
                    genericMethod = methodinfo.MakeGenericMethod(TSource, TDestination);
                    pair.Value.SetValue(destination, genericMethod.Invoke(null, new object[] { pair.Key.GetValue(source) }));
                }
            }
            //Copy properties
            foreach (KeyValuePair<PropertyInfo, PropertyInfo> pair in properties)
            {
                if (pair.Key.PropertyType.IsValueType || pair.Key.PropertyType == Type.GetType("System.String"))
                {
                    pair.Value.SetValue(destination, pair.Key.GetValue(source));
                }
            }
            return destination;
        }
    }
}