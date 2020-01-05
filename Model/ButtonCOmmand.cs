using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Input;

namespace EmployeeApp.Model
{
    public class ButtonCommand : ICommand
    {
        private DataContextHandler _contextHandler;
        private EmployeeList employees;
        public ButtonCommand(DataContextHandler dataContextHandler, EmployeeList resultEmployees) 
        {
            _contextHandler = dataContextHandler;
            employees = resultEmployees;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Data files (*.csv)|*.csv|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                var lines = File.ReadAllLines(System.IO.Path.ChangeExtension(openFileDialog.FileName, ".csv"));
                CreateEmployeesFromFile(lines,ref employees);
            }
        }

        private void CreateEmployeesFromFile(string[] lines,ref EmployeeList resultEmployees)
        {
            IList<Employee> employees = new List<Employee>();
            foreach (var line in lines)
            {
                var data = line.Replace(',', ';').Split(';');
                if (data.Length != 5)
                    continue; // wrong data
                var result = int.TryParse(data[0], out int id);
                if (!result)
                    continue;
                employees.Add(new Employee(id, data[1], data[2], data[3], data[4]));
            }
            _contextHandler.AddEmployeeList(employees,ref resultEmployees);
        }
    }
}
