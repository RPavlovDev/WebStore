using System;
using System.ComponentModel.DataAnnotations;

namespace WebStore.Domain.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public DateTime BirthDate { get; set; }

        public string CityDepartment { get; set; }

        public string Salary { get; set; }

        private double _age;

        
        public double Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - BirthDate.Year;

                if (BirthDate.Date > today.AddYears(-age)) age--;

                return age;
            }
            set => _age = value;
        }
    }
}
