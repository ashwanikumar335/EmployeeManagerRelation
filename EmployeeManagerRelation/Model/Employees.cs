using EmployeeManagerRelation.ViewModel;
using EmployeeManagerRelation.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagerRelation.Model
{
    public class Employee : ViewModelBase
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string ProfilePic { get; set; }
        public string Designation { get; set; }
        public string Project { get; set; }
        public int AssignedTo { get; set; }
       
    }

    public class Manager:Employee
    {
        public int ManagerId { get; set; }
        public string ManagerName { get; set; }
        //public ItemsChangeObservableCollection<Employee> Employees { get; set; }
        private ItemsChangeObservableCollection<Employee> _employees;
        public ItemsChangeObservableCollection<Employee> Employees
        {
            get
            {
                return _employees;
            }
            set
            {
                _employees = value;
                OnPropertyChanged("Employees");
            }
        }


    }
}
