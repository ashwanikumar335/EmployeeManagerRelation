using EmployeeManagerRelation.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagerRelation.Model
{
   public class BindingProperty : ViewModelBase
    {
        private string _textBox1;
        public string textBox1
        {
            get
            {
                return _textBox1;
            }
            set
            {
                _textBox1 = value;
                OnPropertyChanged();
            }
        }
    }
}
