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

namespace FeedbackControls
{
    /// <summary>
    /// Interaction logic for Led.xaml
    /// </summary>
    public partial class Led : UserControl
    {
        public static readonly DependencyProperty IsActiveProperty = DependencyProperty.Register("IsActive", typeof(bool), typeof(Led), new PropertyMetadata(new PropertyChangedCallback(Led.IsActivePropertyChanged)));
        public static readonly DependencyProperty ColorOnProperty = DependencyProperty.Register("ColorOn", typeof(Color), typeof(Led), new PropertyMetadata(Colors.Green, new PropertyChangedCallback(Led.OnColorOnPropertyChanged)));
        public static readonly DependencyProperty ColorOffProperty = DependencyProperty.Register("ColorOff", typeof(Color), typeof(Led), new PropertyMetadata(Colors.Red, new PropertyChangedCallback(Led.OnColorOffPropertyChanged)));

        public bool IsActive
        {
            get { return (bool)GetValue(IsActiveProperty); }
            set { SetValue(IsActiveProperty, value); }
        }

        public Color ColorOff
        {
            get { return (Color)GetValue(ColorOffProperty); }
            set { SetValue(ColorOffProperty, value); }
        }

        public Color ColorOn
        {
            get { return (Color)GetValue(ColorOnProperty); }
            set { SetValue(ColorOnProperty, value); }
        }

        public Led()
        {
            InitializeComponent();
            backgroundColor.Color = IsActive ? ColorOn : ColorOff;
        }

        private static void IsActivePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var led = (Led)d;
            led.backgroundColor.Color = (bool)e.NewValue ? led.ColorOn : led.ColorOff;
        }

        private static void OnColorOnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var led = (Led)d;
            led.ColorOn = (Color)e.NewValue;
            led.backgroundColor.Color = led.IsActive ? led.ColorOn : led.ColorOff;
        }

        private static void OnColorOffPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var led = (Led)d;
            led.ColorOff = (Color)e.NewValue;
            led.backgroundColor.Color = led.IsActive ? led.ColorOn : led.ColorOff;
        }
    }
}
