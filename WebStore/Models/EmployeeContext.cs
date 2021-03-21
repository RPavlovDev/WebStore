using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Models
{
    public class EmployeeContext
    {
        public static readonly List<Employee> Employees = new List<Employee>()
        {
            new Employee { Id = 1, LastName = "Иванов", FirstName = "Иван", Patronymic = "Иванович", CityDepartment = "Москва", BirthDate = new DateTime(1980, 1, 1), Salary = "55000"},
            new Employee { Id = 2, LastName = "Петров", FirstName = "Пётр", Patronymic = "Петрович", CityDepartment = "Санкт-Петербург", BirthDate = new DateTime(1995, 1, 1), Salary = "40000" },
            new Employee { Id = 3, LastName = "Сидоров", FirstName = "Сидор", Patronymic = "Сидорович", CityDepartment = "Казань", BirthDate = new DateTime(2001, 1, 1), Salary = "35000" }
        };
    }
}
