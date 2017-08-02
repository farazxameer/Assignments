using static System.Console;

namespace Mapper
{
    class ViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int ph_No;
        public string address;
        public InnerClass obj = new InnerClass();
    }
}