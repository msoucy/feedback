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
using System.Windows.Shapes;
using System.Timers;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows.Threading;

namespace FeedbackControls
{
    /// <summary>
    /// Interaction logic for FeedbackWindow.xaml
    /// </summary>
    public partial class FeedbackWindow : Window
    {
        public static bool IsRunning { get; private set; }

        public static IList<bool> GetOutputs()
        {
            return _activeWindow.model.Output.Select(x => x.IsEnabled).ToList().AsReadOnly();
        }

        public static IList<bool> GetInputs()
        {
            return _activeWindow.model.Input.Select(x => x.IsEnabled).ToList().AsReadOnly();
        }

        public static void SetOutput(int channel, bool enabled)
        {
            _activeWindow.model.Output[channel].IsEnabled = enabled;
        }

        public static bool GetInput(int channel)
        {
            return _activeWindow.model.Input[channel].IsEnabled;
        }

        private readonly FeedbackWindowViewModel model = new FeedbackWindowViewModel();

        public FeedbackWindow(int numberOfOutputs, int numberOfInputs)
            : this()
        {
            var outputs = Enumerable.Range(0, numberOfOutputs).Select((_, index) => new DigitalViewModel { Name = $"Output {index + 1}" });
            var inputs = Enumerable.Range(0, numberOfInputs).Select((_, index) => new DigitalViewModel { Name = $"Input {index + 1}" });
            model.Output = new ObservableCollection<DigitalViewModel>(outputs);
            model.Input = new ObservableCollection<DigitalViewModel>(inputs);
        }

        public FeedbackWindow()
        {
            InitializeComponent();
            DataContext = model;
        }

        private static FeedbackWindow _activeWindow = new FeedbackWindow(0, 0);

        public static void Display(int numberOfOutputs, int numberOfInputs)
        {            
            // Create a thread
            Thread newWindowThread = new Thread(new ThreadStart(() =>
            {
                // Create our context, and install it:
                SynchronizationContext.SetSynchronizationContext(new DispatcherSynchronizationContext(Dispatcher.CurrentDispatcher));

                _activeWindow = new FeedbackWindow(numberOfInputs, numberOfOutputs);
                // When the window closes, shut down the dispatcher
                _activeWindow.Closed += (s, e) =>
                {
                    Dispatcher.CurrentDispatcher.BeginInvokeShutdown(DispatcherPriority.Background);
                    IsRunning = false;
                };

                _activeWindow.Show();

                // Start the Dispatcher Processing
                Dispatcher.Run();
            }));

            // Set the apartment state
            newWindowThread.SetApartmentState(ApartmentState.STA);
            // Make the thread a background thread
            newWindowThread.IsBackground = true;
            // Start the thread
            newWindowThread.Start();

            IsRunning = true;

            Thread.Sleep(250);
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {

            Close();
        }
    }
}
