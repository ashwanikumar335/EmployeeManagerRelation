using EmployeeManagerRelation.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace EmployeeManagerRelation.ViewModels
{
    public class DetailsViewModel
    {
        public void ProcessEmployeeDetails(string str)
        {
            string[] arr = str.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            string[] colNames = arr.Select(x => x.Substring(0, x.IndexOf('='))).ToArray<string>();
            string[] colValues = arr.Select(x => x.Substring(x.IndexOf('=') + 1)).ToArray<string>();
            CreateRows(colNames, colValues);
        }

        private void CreateRows(string[] colNames, string[] colValues)
        {
            Grid myGrid = new Grid();
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
                    tblValues.Text = colValues[i];
                    Grid.SetColumn(tblValues, 1);
                    Grid.SetRow(tblValues, i);
                    myGrid.Children.Add(tblValues);
                }
            }
        }
    }
}
