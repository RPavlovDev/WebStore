using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebStore.ViewModels
{
    public class EmployeeViewModel //: IValidatableObject
    {
        [HiddenInput]
        public int Id { get; set; }
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Имя является обязательным")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Длина должна быть от 2 до 200 символов")]
        [RegularExpression(@"[А-ЯЁ][а-яё]+|[A-Z][a-z]+", ErrorMessage = "Неправильный формат ввода. Должно начинаться с заглавной буквы и все слово либо русскими либо английскими буквами.")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Фамилия является обязательной")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Длина должна быть от 2 до 200 символов")]
        [RegularExpression(@"[А-ЯЁ][а-яё]+|[A-Z][a-z]+", ErrorMessage = "Неправильный формат ввода. Должно начинаться с заглавной буквы и все слово либо русскими либо английскими буквами.")]
        public string LastName { get; set; }

        [Display(Name = "Отчество")]
        [StringLength(200, ErrorMessage = "Длина должна быть до 200 символов")]
        public string Patronymic { get; set; }

        [Display(Name = "Дата рождения")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Город отдела")]
        public string CityDepartment { get; set; }

        [Display(Name = "Зарплата")]
        public string Salary { get; set; }

        private double _age;
        [Display(Name = "Возраст")]
        [Range(18, 80, ErrorMessage = "Возраст должен быть от 18 до 80 лет")]
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

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    yield return ValidationResult.Success;
        //}
    }
}
