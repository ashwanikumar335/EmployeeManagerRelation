using EmployeeManagerRelation.Model;
using EmployeeManagerRelation.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmployeeManagerRelation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TreeWindowViewModel twVM;
        ClsGlobal objGlobal;
        public MainWindow()
        {
            InitializeComponent();
            objGlobal = new ClsGlobal();
            twVM = objGlobal.TreeViewModel;
            this.DataContext = twVM;
        }

        private void treeview1_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
          detailsPane.ProcessEmployeeDetails(twVM.GettingEmployeeDetails(treeview1.SelectedValue));
        }
    }
}
