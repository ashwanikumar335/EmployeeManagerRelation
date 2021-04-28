using EmployeeManagerRelation.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagerRelation.Model
{
    public class ClsGlobal
    {
        public static TreeWindowViewModel _treeWindowVM = null;
        public TreeWindowViewModel TreeViewModel
        {
            get
            {
                if (_treeWindowVM == null) _treeWindowVM = new TreeWindowViewModel();
                return _treeWindowVM;
            }
        }
    }
}
