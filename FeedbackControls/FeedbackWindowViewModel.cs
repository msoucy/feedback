using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ByteViewModel = FeedbackControls.ValueViewModel<byte>;
using LongViewModel = FeedbackControls.ValueViewModel<long>;

namespace FeedbackControls
{
    class FeedbackWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<DigitalViewModel> Output
        {
            get { return _output; }
            set { _output = value; FirePropertyChanged(); }
        }

        public ObservableCollection<DigitalViewModel> Input
        {
            get { return _input; }
            set { _input = value; FirePropertyChanged(); }
        }

        public ObservableCollection<ByteViewModel> PWM
        {
            get { return _pwms; }
            set { _pwms = value; FirePropertyChanged(); }
        }
        public ObservableCollection<LongViewModel> AnalogInput
        {
            get { return _analogInput; }
            set { _analogInput = value; FirePropertyChanged(); }
        }

        private ObservableCollection<DigitalViewModel> _output = new ObservableCollection<DigitalViewModel>();
        private ObservableCollection<DigitalViewModel> _input = new ObservableCollection<DigitalViewModel>();
        private ObservableCollection<ByteViewModel> _pwms = new ObservableCollection<ByteViewModel>();
        private ObservableCollection<LongViewModel> _analogInput = new ObservableCollection<LongViewModel>();

        private void FirePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
