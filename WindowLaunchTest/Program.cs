using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using FB = FeedbackControls.FeedbackWindow;

namespace WindowLaunchTest
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            FB.Display(4, 4);

            Console.WriteLine("Hello World");

            while (FB.IsRunning)
            {
                foreach (var channel in Enumerable.Range(0, FB.GetInputs().Count))
                    FB.SetOutput(channel, FB.GetInput(channel));

                //Thread.Sleep(500);
                Thread.Sleep(10);
            }

            Console.WriteLine("Done!");
        }
    }
}
