using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EmployeeApp.Model
{
    public class EmployeeList:INotifyPropertyChanged
    {
        public IList<Employee> employees { get; set; }
        public bool visible { get; set; }

        public EmployeeList()
        {
            employees = new List<Employee>();
            visible = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void SetEmployees(IList<Employee> employees)
        {
            this.employees = employees;
            visible = true;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("employees"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("visible"));
        }
    }
}
