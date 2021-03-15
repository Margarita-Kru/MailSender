﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TestConsole.Data;
using TestConsole.Entityes;

namespace TestConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<StudentsDb>()
                .UseSqlServer(connectionString: @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Students.DB;")
                .Options;

            using (var db = new StudentsDb(options))
                await InitializedDB(db);
            using (var db = new StudentsDb(options))
            {
                var query = db.Students.Where(s => s.Birthday >= new DateTime(2000, 5, 1) && s.Birthday < new DateTime(2000, 5, 31));
                var students = await query.ToArrayAsync();

                var students_last_names = await query.Select(s => s.LastName).Distinct().ToArrayAsync();

                foreach (var student in students)
                    Console.WriteLine("{0} {1} {2} - {3:d}", student.LastName, student.Name, student.Patronymic, student.Birthday);
            }
                Console.WriteLine("Completed");
            Console.ReadKey();
        }

        private static async Task InitializedDB(StudentsDb db)
        {
            //await db.Database.EnsureDeletedAsync();
            //await db.Database.EnsureCreatedAsync();

            await db.Database.MigrateAsync();

            if (!await db.Courses.AnyAsync())
            {
                var courses = Enumerable.Range(1, 10)
                    .Select(i => new Course { Name = $"Предмет {i}" })
                    .ToArray();

                await db.Courses.AddRangeAsync(courses);

                await db.SaveChangesAsync();

                if (!await db.Students.AnyAsync())
                {
                    var rnd = new Random();
                    var students = Enumerable.Range(1, 1000)
                        .Select(i => new Student
                        {
                            Name = $"Имя - {i}",
                            LastName = $"Фамилия - {i}",
                            Patronymic = $"Отчество - {i}",
                            Birthday = DateTime.Now.Date.AddYears(-rnd.Next(17, 28)).AddDays(rnd.Next(365)),
                            Courses = Enumerable.Range(0, rnd.Next(1, 8)).Select(_ => courses[rnd.Next(courses.Length)])
                            .Distinct().ToArray()
                        });
                    await db.Students.AddRangeAsync(students);
                    await db.SaveChangesAsync();

                }
            }
        }
    }
}
