using System;
using System.Collections.Generic;
namespace Mapper
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating the ViewModel Object that will act as Source.
            ViewModel vmo = new ViewModel();
            //Initializing the ViewModel(vmo) Object with data.
            vmo.FirstName = "faraz";
            vmo.LastName = "zameer";
            vmo.Age = 19;
            vmo.Id = 1565;
            vmo.ph_No = 123456;
            vmo.address = "9999";
            vmo.obj.Id = 10;
            vmo.obj.pin = 1565;
            vmo.obj.FullName = "Xameer";
            vmo.obj.obj2.Phone = 5555;
            vmo.obj.obj2.Email = "faraz@zameer.com";

            Mapper.Config<ViewModel, DataModel>(new Dictionary<string, string>
            {
                ["ph_No"] = "phNo"
            });
            DataModel dto = Mapper.Map<ViewModel, DataModel>(vmo);

            Console.WriteLine("\t***OuterClass***\n" + dto.Id + " : " + dto.FirstName + " " + dto.LastName + " : " + dto.Age + " => " +dto.phNo + " " + dto.address);
            Console.WriteLine("\n\t***InnerClass***\n" + dto.obj.Id + " " + dto.obj.pin + " " + dto.obj.FullName);
            Console.WriteLine("\n\t***InnerInnerClass***\n" + dto.obj.obj2.Phone + " " + dto.obj.obj2.Email);
        }
    }
}
