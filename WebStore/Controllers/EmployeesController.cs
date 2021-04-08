using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Infrastructure.Services.Interfaces;
using WebStore.Models;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeesData _EmployeesData;

        public EmployeesController(IEmployeesData EmployeesData)
        {
            _EmployeesData = EmployeesData;
        }
        public IActionResult Index()
        {
            return View(_EmployeesData.Get());
        }

        public IActionResult Details(int Id)
        {
            var employee = _EmployeesData.Get(Id);

            if (employee == null)
                return RedirectToAction("NotFoundPage", "Home");

            return View(new EmployeeViewModel()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Patronymic = employee.Patronymic,
                CityDepartment = employee.CityDepartment,
                Salary = employee.Salary,
                BirthDate = employee.BirthDate
            });
        }

        public IActionResult Edit(int? Id)
        {
            if (Id is null)
                return View(new EmployeeViewModel());

            var employee = _EmployeesData.Get((int)Id);

            if (employee == null)
                return RedirectToAction("NotFoundPage", "Home");

            return View(new EmployeeViewModel()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Patronymic = employee.Patronymic,
                CityDepartment = employee.CityDepartment,
                Salary = employee.Salary,
                BirthDate = employee.BirthDate
            });
        }

        public IActionResult Create() => View("Edit", new EmployeeViewModel());

        [HttpPost]
        public IActionResult Edit(EmployeeViewModel modifiedEmployee)
        {
            var employee = new Employee()
            {
                Id = modifiedEmployee.Id,
                FirstName = modifiedEmployee.FirstName,
                LastName = modifiedEmployee.LastName,
                Patronymic = modifiedEmployee.Patronymic,
                CityDepartment = modifiedEmployee.CityDepartment,
                Salary = modifiedEmployee.Salary,
                BirthDate = modifiedEmployee.BirthDate
            };

            if (employee.FirstName.Any(char.IsDigit))
                ModelState.AddModelError("FirstName", "Name should not contain digits.");

            if (employee.LastName.Any(char.IsDigit))
                ModelState.AddModelError("LastName", "LastName should not contain digits.");

            if (employee.Patronymic.Any(char.IsDigit))
                ModelState.AddModelError("Patronymic", "Patronymic should not contain digits.");

            if (employee.CityDepartment.Any(char.IsDigit))
                ModelState.AddModelError("CityDepartment", "CityDepartment should not contain digits.");

            if (!employee.Salary.All(char.IsDigit))
                ModelState.AddModelError("Salary", "Salary should contain only digits.");



            if (!ModelState.IsValid)
                return View(modifiedEmployee);


            if (employee.Id == 0)
                _EmployeesData.Add(employee);
            else
                _EmployeesData.Update(employee);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var employee = _EmployeesData.Get(Id);

            if (employee == null)
                return RedirectToAction("NotFoundPage", "Home");

            return View(new EmployeeViewModel()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Patronymic = employee.Patronymic,
                CityDepartment = employee.CityDepartment,
                Salary = employee.Salary,
                BirthDate = employee.BirthDate
            });
        }

        [HttpPost]
        public IActionResult Delete(EmployeeViewModel deletingEmployee)
        {
            var employee = _EmployeesData.Get(deletingEmployee.Id);

            if (employee == null)
                return RedirectToAction("NotFoundPage", "Home");

            _EmployeesData.Delete(deletingEmployee.Id);

            return RedirectToAction("Index");
        }
    }
}
