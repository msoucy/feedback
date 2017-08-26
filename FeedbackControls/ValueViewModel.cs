using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FeedbackControls
{
    class ValueViewModel<ValueType> : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get { return _name; }
            set { _name = value; FirePropertyChanged(); }
        }

        public ValueType Value
        {
            get { return _value; }
            set { _value = value; FirePropertyChanged(); }
        }

        private string _name;
        private ValueType _value;

        private void FirePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
