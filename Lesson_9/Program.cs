using System;
using System.Windows.Forms;
using System.Timers;

namespace Lesson_9
{
    internal class Program
    {
        private static System.Timers.Timer aTimer;

        static void Main(string[] args)
        {
            DialogResult dialogResult = MessageBox.Show("Hello World!", "Tamagochi", 
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button2, 0);

            if (dialogResult == DialogResult.OK)
            {
                SetTimer();
                Console.ReadLine();
                aTimer.Stop();
                aTimer.Dispose();
            }
            else
            {
                Console.WriteLine("Cancel");
            }
        }

        private static void SetTimer()
        {
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object obj, ElapsedEventArgs e)
        {
            Console.WriteLine("{0:HH:mm:ss}", e.SignalTime);
        }
    }
}
