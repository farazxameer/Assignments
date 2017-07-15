using System;

namespace IsAsFunc
{
    class Program
    {
        static void Main(string[] args)
        {
            SchoolStudent schoolStudentObject = new SchoolStudent();
            schoolStudentObject.name = "Xameer";
            CollageStudent collageStudentObject = new CollageStudent();
            collageStudentObject.name = "Zameer";
            int i = 5;

            Console.WriteLine($"schoolStudentObject is a school going student : {(IsImplementation.Is<ISchool>(schoolStudentObject))}");
            Console.WriteLine($"collageStudentObject is a school going student : {(IsImplementation.Is<ISchool>(collageStudentObject))}");
            Console.WriteLine($"i is 5 : {(IsImplementation.Is(i,5))}");
            Console.WriteLine($"i is 50 : {(IsImplementation.Is(i,50))}");

            double? z = AsImplementation.As<int>(i);
            string result = "The value inside 'z' is ";
            result += (z == null) ? "null" : $"{z}";
            System.Console.WriteLine(result);

            Student resultObject = (AsImplementation.As<Student>(schoolStudentObject));
            result = (resultObject == null) ? "This is not a student !!!" : $"This is a student, and his/her name is {resultObject.name}";
            System.Console.WriteLine(result);
            System.Console.ReadLine();
        }
    }
}