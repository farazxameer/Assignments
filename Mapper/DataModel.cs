using static System.Console;

namespace Mapper
{
    class DataModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int phNo = 0;
        public string address = string.Empty;
        public InnerClass obj = new InnerClass();
    }
}