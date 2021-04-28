using EmployeeManagerRelation.Model;
using EmployeeManagerRelation.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EmployeeManagerRelation.ViewModels
{
    public class TreeWindowViewModel : ViewModelBase
    {
        #region Enum Declaration
        public enum Projects { FinanceDomain, HealthDomain, MedicalDomain };
        public enum Roles { Manager, SoftwareDev, TechnicalLead, AssociateConsultant };
        public enum SexualCategory { Male, Female };
        #endregion

        #region Properties Declaration
        #region EmployeeProperties

        public string EmployeeName
        {
            get
            {
                return EmployeeModel.EmployeeName;
            }
            set
            {
                EmployeeModel.EmployeeName = value;
                OnPropertyChanged("EmployeeName");
            }
        }

        public int EmployeeId
        {
            get
            {
                return EmployeeModel.EmployeeId;
            }
            set
            {
                EmployeeModel.EmployeeId = value;
                OnPropertyChanged("EmployeeId");
            }
        }

        public int EmployeeAssignedTo
        {
            get
            {
                return EmployeeModel.AssignedTo;
            }
            set
            {
                EmployeeModel.AssignedTo = value;
                OnPropertyChanged("AssignedTo");
            }
        }

        #endregion
        #region ManagerProperties

        public string ManagerName
        {
            get
            {
                return ManagerModel.ManagerName;
            }
            set
            {
                ManagerModel.ManagerName = value;
                OnPropertyChanged("ManagerName");
            }
        }

        public int ManagerId
        {
            get
            {
                return ManagerModel.ManagerId;
            }
            set
            {
                ManagerModel.ManagerId = value;
                OnPropertyChanged("ManagerId");
            }
        }

        #endregion
        public string Address { get; set; }
        public SexualCategory Gender { get; set; }
        public string Email { get; set; }
        public Roles Designation { get; set; }
        public Projects Project { get; set; }
        public string ProfilePic { get; set; }
        #endregion

        //Profile Pic Of Employee
        string profilePics = "./img/h1.jpg";

        public BindingProperty BindingProperty { get; set; }
        public Manager ManagerModel { get; set; }
        public Employee EmployeeModel { get; set; }
        private ItemsChangeObservableCollection<Manager> _managers;
        public ItemsChangeObservableCollection<Manager> Managers
        {
            get
            {
                return _managers;
            }
            set
            {
                _managers = value;

                OnPropertyChanged();
            }
        }
        
        public TreeWindowViewModel() 
        {
            ManagerModel = new Manager();
            EmployeeModel = new Employee();
            _managers = new ItemsChangeObservableCollection<Manager>();
            LoadData();
        }
       
        public ItemsChangeObservableCollection<Manager> LoadData()
        {
            BindingProperty = new BindingProperty();
            //Create list of employees and add them under the assigned managers
            Manager manager1 = new Manager()
            {
                ManagerId = 1,
                ManagerName = "Binod Sharma",
                Address = "Dadar",
                Email = "binod.sharma01@nagarro.com",
                Gender = "Male",
                ProfilePic = profilePics,
                Designation = "Manager",
                Project = "FinanceDomain",
                Employees =new ItemsChangeObservableCollection<Employee>()
            };
            manager1.Employees.Add(new Employee {
                EmployeeId = 5,
                EmployeeName = "Ashwani Kumar",
                Address = "Dadar",
                Email = "ashwani.kumar01@nagarro.com",
                Gender = "Male",
                ProfilePic = profilePics,
                Designation = "TechnicalLead",
                Project = "FinanceDomain"
            });
            manager1.Employees.Add(new Employee
            {
                EmployeeId = 6,
                EmployeeName = "Akash Yada",
                Address = "Bandra",
                Gender = "Male",
                Email = "akash.yadav01@nagarro.com",
                ProfilePic = profilePics,
                Designation = "AssociateConsultant",
                Project = "HealthDomain"
            });
            Manager manager2 = new Manager()
            {
                ManagerId = 2,
                ManagerName = "Naveen Chhabra",
                Address = "Faridabad",
                Gender = "Male",
                Email = "naveen.chhabra01@nagarro.com",
                ProfilePic = profilePics,
                Designation = "Manager",
                Project = "MedicalDomain",
                Employees = new ItemsChangeObservableCollection<Employee>()
            };
            manager2.Employees.Add(new Employee 
            {
                EmployeeId = 7,
                EmployeeName = "Neeraj Gupta",
                Address = "Faridabad",
                Gender = "Male",
                Email = "neeraj.gupta01@nagarro.com",
                ProfilePic = profilePics,
                Designation = "SoftwareDev",
                Project = "MedicalDomain"
            });
            manager2.Employees.Add(new Employee
            {
                EmployeeId = 8,
                EmployeeName = "Varun Kumar",
                Address = "Worli",
                Gender = "Male",
                Email = "varun.kumar01@nagarro.com",
                ProfilePic = profilePics,
                Designation = "SoftwareDev",
                Project = "MedicalDomain"
            });
            Manager manager3 = new Manager()
            {
                ManagerId = 3,
                ManagerName = "Umesh kaushal",
                Address = "Noida",
                Gender = "Male",
                Email = "umesh.kaushal01@nagarro.com",
                ProfilePic = profilePics,
                Designation = "Manager",
                Project = "HealthDomain",
                Employees = new ItemsChangeObservableCollection<Employee>()
            };
            manager3.Employees.Add(new Employee 
            {
                EmployeeId = 9,
                EmployeeName = "Arun Yadav",
                Address = "Dadar",
                Email = "arun.yadav01@nagarro.com",
                Gender = "Female",
                ProfilePic = profilePics,
                Designation = "TechnicalLead",
                Project = "FinanceDomain"
            });
            manager3.Employees.Add(new Employee
            {
                EmployeeId = 10,
                EmployeeName = "Ashish Bohra",
                Address = "Noida",
                Gender = "Male",
                Email = "ashish.bohra01@nagarro.com",
                ProfilePic = profilePics,
                Designation = "AssociateConsultant",
                Project = "HealthDomain"
            });
            manager3.Employees.Add(new Employee
            {
                EmployeeId = 11,
                EmployeeName = "Amrinder Singh",
                Address = "Faridabad",
                Gender = "Male",
                Email = "amrinder.singh01@nagarro.com",
                ProfilePic = profilePics,
                Designation = "TechnicalLead",
                Project = "MedicalDomain"
            });
           
            Manager manager4 = new Manager()
            {
                ManagerId = 3,
                ManagerName = "Vivek Gupta",
                Address = "Faridabad",
                Gender = "Male",
                Email = "vivek.gupta01@nagarro.com",
                ProfilePic = profilePics,
                Designation = "Manager",
                Project = "MedicalDomain",
                Employees = new ItemsChangeObservableCollection<Employee>()
            };
            manager4.Employees.Add(new Employee 
            {
                EmployeeId = 12,
                EmployeeName = "Sumeet Singh",
                Address = "Faridabad",
                Gender = "Male",
                Email = "sumeet.singh01@nagarro.com",
                ProfilePic = profilePics,
                Designation = "SoftwareDev",
                Project = "MedicalDomain"
            });
            manager4.Employees.Add(new Employee
            {
                EmployeeId = 13,
                EmployeeName = "Sumit Dahiya",
                Address = "Dadar",
                Email = "sumit.dahiya01@nagarro.com",
                Gender = "Female",
                ProfilePic = profilePics,
                Designation = "AssociateConsultant",
                Project = "FinanceDomain"
            });
            manager4.Employees.Add(new Employee
            {
                EmployeeId = 14,
                EmployeeName = "Shariq Iqbal",
                Address = "Andheri",
                Gender = "Male",
                Email = "shariq.iqbal01@nagarro.com",
                ProfilePic = profilePics,
                Designation = "SoftwareDev",
                Project = "HealthDomain"
            });
            
            Managers.Add(manager1);
            Managers.Add(manager2);
            Managers.Add(manager3);
            Managers.Add(manager4);
            return Managers;
        }
       
        private object _selectedItem;
        public object SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        //Add New Employee dynamically
        private ICommand _addEmployeeCommand;
        public ICommand AddEmployeeCommand
        {
            get
            {
                if (_addEmployeeCommand == null)
                {
                    _addEmployeeCommand = new RelayCommand(param => this.AddEmployeeExecute(), null);
                }

                return _addEmployeeCommand;
            }

        }
        private void AddEmployeeExecute()
        {
            for (int i = 0; i < Managers.Count; i++)
            {
                if (Managers[i].ManagerId == EmployeeModel.AssignedTo)
                {
                    Managers[i].Employees.Add(new Employee { EmployeeId = EmployeeModel.EmployeeId, EmployeeName = EmployeeModel.EmployeeName, Designation = "Software Dev", Gender = "Male", Email = EmployeeModel.EmployeeName + "@nagarro.com", Address = "Gurugram", Project = "FinanceDomain", ProfilePic = @"img\h1.jpg", AssignedTo = EmployeeModel.AssignedTo });
                }
            }
        }
        #region AddManagerCommandRegion
        private ICommand _addManagerCommand;
        public ICommand AddManagerCommand
        {
            get
            {
                if (_addManagerCommand == null)
                {
                    _addManagerCommand = new RelayCommand(param => this.AddManagerExecute(), null);
                }

                return _addManagerCommand;
            }
           
        }
        private void AddManagerExecute()
        {
            Manager newManager = new Manager() { ManagerId = ManagerModel.ManagerId, ManagerName = ManagerModel.ManagerName,Designation="Manager", Gender="Male",Email= ManagerModel.ManagerName + "@nagarro.com", Address="Gurugram", ProfilePic=@"img\h1.jpg", Project = "FinanceDomain", Employees = new ItemsChangeObservableCollection<Employee>() };
            Managers.Add(newManager);
        }

        #endregion

        #region EditEmployeeCommandRegion

        public ICommand _editEmployeeCommand;

        public void CreateEditEmployeeCommand()
        {
            _editEmployeeCommand = new RelayCommand(new Action<object>(EditEmployeeExecute));
        }
        private void EditEmployeeExecute(object obj)
        {
            if (EmployeeModel.AssignedTo == 0)
            {
                Manager newManager = new Manager() { ManagerId = EmployeeId, ManagerName = EmployeeName, Employees = new ItemsChangeObservableCollection<Employee>() };
                foreach (Employee employee in Managers[EmployeeId].Employees)
                {
                    newManager.Employees.Add(employee);
                }
                Managers.RemoveAt(EmployeeId);
                Managers.Add(newManager);
            }
        }
        #endregion

        //Display details of employees and managers by selecting it from the treeview
        public string GettingEmployeeDetails(Object trViewSelectedItem)
        {
            string record = "";
            if (trViewSelectedItem is Manager)
            {
                Manager manager = trViewSelectedItem as Manager;
                record = "ProfilePic=" + manager.ProfilePic + "|" + "ID=" + manager.ManagerId + "|" + "Name=" + manager.ManagerName + "|" + "Email=" + manager.Email + "|" + "Address=" + manager.Address + "|" + "Gender=" + manager.Gender + "|" + "Designation=" + manager.Designation + "|" + "Projects=" + manager.Project;
            }
            else
            {
                Employee employee = trViewSelectedItem as Employee;
                record = "ProfilePic=" + employee.ProfilePic + "|" + "ID=" + employee.EmployeeId + "|" + "Name=" + employee.EmployeeName + "|" + "Email=" + employee.Email + "|" + "Address=" + employee.Address + "|" + "Gender=" + employee.Gender + "|" + "Designation=" + employee.Designation + "|" + "Projects=" + employee.Project + "|" + "AssignedTo=" + employee.AssignedTo;
            }
            return record;
        }

    }
}
