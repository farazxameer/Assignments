using System;

namespace ObjectImplementation
{
    public class ObjectImplementation
    {
        public virtual bool MyEquals(object obj)
        {
            return this == obj;
        }

        public static bool MyEquals(object objA, object objB)
        {
            if (objA == objB)
            {
                return true;
            }
            if (objA == null || objB == null)
            {
                return false;
            }
            return objA.Equals(objB);
        }

        public static bool MyReferenceEquals(object objA, object objB)
        {
            return objA == objB;
        }
    }

    public class Person : ObjectImplementation
    {
        public string name { get; set; }
        public Person(string name)
        {
            this.name = name;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Person person1a = new Person("John");
            Person person1b = person1a;
            Person person2 = new Person(person1a.ToString());

            Console.WriteLine("Calling Equals:");
            Console.WriteLine("person1a and person1b: {0}", person1a.Equals(person1b));
            Console.WriteLine("person1a and person2: {0}", person1a.Equals(person2));
            Console.WriteLine("person1a and person1b: {0}", person1a.MyEquals(person1b));
            Console.WriteLine("person1a and person2: {0}", person1a.MyEquals(person2));

        }
    }
}
