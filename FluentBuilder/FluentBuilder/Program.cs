using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace FluentBuilder
{

    class Employee
    {
        public static EmployeeBuilder CreateBuilder()
        {
            return new EmployeeBuilder();
        }
        public class User
        {
            public string name { get; set; }
            public string company { get; set; }
            public int age { get; set; }
            public bool isMarried { get; set; }
            public User() { }
            public User(string name, string company, int age, bool isMarried)
            {
                this.name = name;
                this.company = company;
                this.age = age > 0 ? age : 18;
                this.isMarried = isMarried;
            }
            public override string ToString()
            {
                return $"\tName: {name}\n\tCompany: {company}\n\tAge: {age}\n\tMarried?: {isMarried}";
            }
        }

        public class EmployeeBuilder
        {
            private User user;
            public EmployeeBuilder()
            {
                user = new User();
            }
            public EmployeeBuilder setName(string name)
            {
                user.name = name;
                return this;
            }
            public EmployeeBuilder setCompany(string company)
            {
                user.company = company;
                return this;
            }
            public EmployeeBuilder setAge(int age)
            {
                user.age = age > 0 ? age : 0;
                return this;
            }
            public EmployeeBuilder isMarried
            {
                get
                {
                    user.isMarried = true;
                    return this;
                }
            }
            public static implicit operator User(EmployeeBuilder builder)
            {
                return builder.user;
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                User Ivan = new EmployeeBuilder().setName("Ivan").setCompany("None").setAge(23);
                User Petro = new EmployeeBuilder().setName("Petro").isMarried.setAge(88);
                WriteLine(Ivan);
                WriteLine(Petro);
            }
        }
    }
}


