using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace EmployeeManagerRelation
{
    /// <summary>
    /// Interaction logic for Details.xaml
    /// </summary>
    public partial class Details : UserControl
    {
        public Details()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
        /// <summary>
        /// Processing the Record OF the Employee by dividing the value received as a parameter into column names and values
        /// </summary>
        /// <param name="str">String of colName and values separated by = and concatenate with  |  symbol.</param>
        public void ProcessEmployeeDetails(string str)
        {
            string[] arr = str.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            string[] colNames = arr.Select(x => x.Substring(0, x.IndexOf('='))).ToArray<string>();
            string[] colValues = arr.Select(x => x.Substring(x.IndexOf('=') + 1)).ToArray<string>();
            CreateRows(colNames, colValues);
        }

        /// <summary>
        /// This function will create rows at runtime based on the no of Column Names and Values.
        /// </summary>
        /// <param name="colNames">Column Names to be displayed on the Grid.</param>
        /// <param name="colValues">Values to be displayed on the Grid.</param>
        private void CreateRows(string[] colNames, string[] colValues)
        {
            myGrid.Children.Clear();
            for (int i = 0; i < colValues.Length; i++)
            {
                if (i == 0)
                {
                    RowDefinition row = new RowDefinition();
                    row.Height = new GridLength(120);
                    Image img = new Image();
                    img.Name = "profilePic";
                    img.Width = 100;
                    img.Height = 100;
                    img.SetValue(Grid.ColumnSpanProperty, 2);
                    img.Source = new BitmapImage(new Uri(colValues[i], UriKind.Relative));
                    Grid.SetRow(img, i);
                    Grid.SetColumn(img, 0);
                    myGrid.Children.Add(img);
                    myGrid.RowDefinitions.Add(row);
                }
                else
                {
                    RowDefinition row = new RowDefinition();
                    row.Height = new GridLength(25);
                    myGrid.RowDefinitions.Add(row);

                    TextBlock tblHeaders = new TextBlock();
                    tblHeaders.Name = "tbl" + colNames[i];
                    tblHeaders.Text = colNames[i];
                    Grid.SetColumn(tblHeaders, 0);
                    Grid.SetRow(tblHeaders, i);
                    myGrid.Children.Add(tblHeaders);

                    TextBlock tblValues = new TextBlock();
                    tblValues.Name = "tbl";
                    tblValues.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);
                    tblValues.Text =  colValues[i];
                    Grid.SetColumn(tblValues, 1);
                    Grid.SetRow(tblValues, i);
                    myGrid.Children.Add(tblValues);
                }
            }
        }
    }
}
