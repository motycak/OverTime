using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

namespace OverTime
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Calculate _calculate;

        public MainWindow()
        {
            InitializeComponent();
            _calculate = new Calculate();
            DataContext = _calculate;
        }



        #region TabCalculate

        private void btnRefreshActualTime_Click(object sender, RoutedEventArgs e)
        {
            _calculate.SetActualTime();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            _calculate.CalculateOvertime();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            _calculate.Clear();
        }

        #endregion




        #region TabPayOvertime

        private void btnSendPayOvertime_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSavePayOvertime_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion


    }
}
