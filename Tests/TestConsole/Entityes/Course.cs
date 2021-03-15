using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestConsole.Entityes
{
    public class Course
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
