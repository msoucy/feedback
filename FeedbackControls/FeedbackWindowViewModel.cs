using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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

        private ObservableCollection<DigitalViewModel> _output = new ObservableCollection<DigitalViewModel>();
        private ObservableCollection<DigitalViewModel> _input = new ObservableCollection<DigitalViewModel>();

        private void FirePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
