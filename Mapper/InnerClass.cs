using System;

namespace Mapper
{
    public class InnerClass
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int pin = 0;
        public InnerInnerClass obj2 = new InnerInnerClass();
    }
}