using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Services.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    [Authorize]
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

        [Authorize(Roles = Role.Administrators)]
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

        [Authorize(Roles = Role.Administrators)]
        public IActionResult Create() => View("Edit", new EmployeeViewModel());

        [Authorize(Roles = Role.Administrators)]
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

            if (!string.IsNullOrEmpty(employee.FirstName) && employee.FirstName.Any(char.IsDigit))
                ModelState.AddModelError("FirstName", "Name should not contain digits.");

            if (!string.IsNullOrEmpty(employee.LastName) && employee.LastName.Any(char.IsDigit))
                ModelState.AddModelError("LastName", "LastName should not contain digits.");

            if (!string.IsNullOrEmpty(employee.Patronymic) && employee.Patronymic.Any(char.IsDigit))
                ModelState.AddModelError("Patronymic", "Patronymic should not contain digits.");

            if (!string.IsNullOrEmpty(employee.CityDepartment) && employee.CityDepartment.Any(char.IsDigit))
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

        [Authorize(Roles = Role.Administrators)]
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

        [Authorize(Roles = Role.Administrators)]
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
