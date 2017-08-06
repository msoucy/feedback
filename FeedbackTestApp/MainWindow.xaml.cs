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
using System.Collections.ObjectModel;
using System.Timers;

namespace FeedbackTestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ViewModel model = new ViewModel();
        private readonly Timer timer = new Timer();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = model;

            var options = Enumerable.Range(0, 6).Select((_, index) => new OptionViewModel { Name = $"Output {index + 1}", IsEnabled = index % 2 == 0 });
            model.DigitalOutput = new ObservableCollection<OptionViewModel>(options);

            timer.Interval = 500;
            timer.Elapsed += Tick;
            timer.Start();
        }

        private void Tick(object sender, ElapsedEventArgs e)
        {
            foreach (var output in model.DigitalOutput)
                output.IsEnabled = !output.IsEnabled;
        }
    }
}
