using EmployeeApp.EntityFramework;
using EmployeeApp.Model;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace EmployeeApp.ViewModels
{
    public class EmployeeViewModel
    {
        public EmployeeList employees { get; set; }
        public ButtonCommand startButtonClicked { get; set; }
        private DataContextHandler dataContextHandler { get; set; }

        public EmployeeViewModel()
        {
            employees = new EmployeeList();
            dataContextHandler = new DataContextHandler();
            startButtonClicked = new ButtonCommand(dataContextHandler, this.employees);
        }

    }
}
