using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DAL.Context;
using WebStore.Data;
using WebStore.Infrastructure.Services.Interfaces;
using WebStore.Models;

namespace WebStore.Infrastructure.Services
{
    public class InDbEmployeesData : IEmployeesData
    {
        private int _CurrentMaxId;
        private readonly AppDbContext _db;

        //public InDbEmployeesData(AppDbContext db)
        //{
        //    _db = db;
        //    _CurrentMaxId = _db.Employees.ToList().DefaultIfEmpty().Max(x => x?.Id ?? 1);
        //}
        //public IEnumerable<Employee> Get()
        //{
        //    return _db.Employees;
        //}

        //public Employee Get(int id)
        //{
        //    return _db.Employees.FirstOrDefault(x => x.Id == id);
        //}

        //public int Add(Employee employee)
        //{
        //    if (employee == null)
        //        throw new ArgumentNullException();

        //    var dbEmployee = Get(employee.Id);
        //    if (dbEmployee != null)
        //        return dbEmployee.Id;

        //    ++_CurrentMaxId;
        //    _db.Employees.Add(employee);
        //    _db.SaveChanges();

        //    return employee.Id;
        //}

        //public void Update(Employee employee)
        //{
        //    if (employee == null)
        //        throw new ArgumentNullException();

        //    var dbEmployee = Get(employee.Id);
        //    if (dbEmployee == null)
        //        return;

        //    dbEmployee.FirstName = employee.FirstName;
        //    dbEmployee.LastName = employee.LastName;
        //    dbEmployee.Patronymic = employee.Patronymic;
        //    dbEmployee.BirthDate = employee.BirthDate;
        //    dbEmployee.CityDepartment = employee.CityDepartment;
        //    dbEmployee.Salary = employee.Salary;

        //    _db.Employees.Update(dbEmployee);
        //    _db.SaveChanges();
        //}

        //public bool Delete(int id)
        //{
        //    var dbEmployee = Get(id);

        //    if (dbEmployee != null)
        //    {
        //        _db.Employees.Remove(dbEmployee);
        //        _db.SaveChanges();
        //    }
            
        //    return dbEmployee != null;
        //}
        public IEnumerable<Employee> Get()
        {
            throw new NotImplementedException();
        }

        public Employee Get(int id)
        {
            throw new NotImplementedException();
        }

        public int Add(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void Update(Employee employee)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
