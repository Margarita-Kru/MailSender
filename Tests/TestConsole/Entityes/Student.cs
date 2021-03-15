using System;
using System.Collections.Generic;

namespace TestConsole.Entityes
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
        public double Rating { get; set; }
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
