using System;

namespace IsAsFunc
{
    interface ISchool
    { }
    interface ICollage
    { }
    class Student
    {
        public string name { get; set; }
    }
    class SchoolStudent : Student, ISchool
    { }
    class CollageStudent : Student, ICollage
    { }
}