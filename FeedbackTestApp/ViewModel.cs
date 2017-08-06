using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace FeedbackTestApp
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<OptionViewModel> DigitalOutput
        {
            get { return _digitalOutput; }
            set { _digitalOutput = value; FirePropertyChanged(); }
        }

        private ObservableCollection<OptionViewModel> _digitalOutput = new ObservableCollection<OptionViewModel>();

        private void FirePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
