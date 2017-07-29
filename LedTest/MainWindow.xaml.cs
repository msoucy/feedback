using System;
using System.Collections.Generic;
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
using System.ComponentModel;

namespace LedTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        bool ledStatus;
        public bool LedStatus { get { return ledStatus; } set { ledStatus = value; this.OnPropertyChanged("LedStatus"); } }


        public MainWindow()
        {
            InitializeComponent();
            led2.DataContext = this;
            led1.ColorOn = Colors.Blue;
            led1.ColorOff = Colors.Gray;
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            led1.IsActive = !led1.IsActive;
        }

        private void btnChange2_Click(object sender, RoutedEventArgs e)
        {
            LedStatus = !LedStatus;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}
