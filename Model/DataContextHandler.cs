using EmployeeApp.EntityFramework;
using EmployeeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace EmployeeApp.Model
{
    public class DataContextHandler
    {
        private EmployeeDataContext _context;

        public DataContextHandler()
        {
            _context = new EmployeeDataContext();
        }


        public void AddEmployeeList(IList<Employee> employees, ref EmployeeList resultEmployees)
        {
            try
            {
                foreach (var empl in employees)
                {
                    if (_context.Employees.FirstOrDefault(x => x.EmployeeId == empl.EmployeeId) == default(Employee)) // unikanie duplikatów
                    {
                        _context.Employees.Add(empl);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("Wystąpił nieoczekiwany wyjątek, treść komunikatu : {0}",e.Message), "Uwaga", MessageBoxButton.OK ,MessageBoxImage.Error);
                return;
            }
            resultEmployees.SetEmployees(GetAllEmployees());
        }

        public IList<Employee> GetAllEmployees()
        {
            IList<Employee> employees = new List<Employee>();
            try
            {
                employees = _context.Employees.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
            return employees;
        }
    }
}
