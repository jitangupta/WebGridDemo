using System.Collections.Generic;
using System.Data.Entity;
using WebGridDemo.Context;
using WebGridDemo.Models;

namespace WebGridDemo.Data
{
    public class StudentInitializer : DropCreateDatabaseIfModelChanges<DefaultConnection>
    {
        protected override void Seed(DefaultConnection context)
        {
            var students = new List<Student>() {
                new Student {Name="Rahul",Phone="9000000000",Address="Borivali Mumbai",Class="B Tech" },
                new Student {Name="Swati",Phone="9000000000",Address="Virar Mumbai",Class="MCA" },
                new Student {Name="Swpnesh",Phone="9000000000",Address="Virar Mumbai",Class="B Tech" },
                new Student {Name="Sunil",Phone="9000000000",Address="Goregaon Mumbai",Class="B Tech" },
                new Student {Name="Rehana",Phone="9000000000",Address="Mankhurd Mumbai",Class="MBA" },
                new Student {Name="Jitan",Phone="9000000000",Address="Malad Mumbai",Class="BSC" }
            };

            students.ForEach(x => context.Students.Add(x));
            context.SaveChanges();
        }
    }
}