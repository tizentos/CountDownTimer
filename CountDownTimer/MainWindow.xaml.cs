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
using System.Windows.Threading;

namespace CountDownTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int TotalTime = 123;
        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer timer2 = new DispatcherTimer();
        DateTime CurrentTime;

        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer2.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer2.Tick += Timer_Tick1;
        }

        private void Timer_Tick1(object sender, EventArgs e)
        {
            CurrentTime = DateTime.Now;
            DigitalClockText.Text = ((CurrentTime.Hour <= 10) ? "0" + CurrentTime.Hour : CurrentTime.Hour.ToString()) + ":" + ((CurrentTime.Minute <= 10) ? "0" + CurrentTime.Minute : CurrentTime.Minute.ToString());
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            CurrentTime = DateTime.Now;
            DigitalClockText.Text = ((CurrentTime.Hour <= 10) ? "0" + CurrentTime.Hour : CurrentTime.Hour.ToString()) + ":" + ((CurrentTime.Minute <= 10) ? "0" + CurrentTime.Minute : CurrentTime.Minute.ToString());
            var time = ((TotalTime / 60 >= 10) ? (TotalTime / 60).ToString() : "0" + TotalTime / 60) + ":" + ((TotalTime % 60 >= 10) ? (TotalTime % 60).ToString() : "0" + TotalTime % 60).ToString();
            labelCountDown.Content = time;
            if (TotalTime <= 0)
            {
                timer.Stop();
                labelCountDown.Content = "00:00";
                TotalTime = 123;
                buttonStart.Content = "START";
                timer2.Start();
            }
            else
            {
                if (TotalTime <= 300 & labelCountDown.Visibility == Visibility.Visible)
                    labelCountDown.Visibility = Visibility.Hidden;
                else
                    labelCountDown.Visibility = Visibility.Visible;
                TotalTime--;
            }
        }

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            if (buttonStart.Content == (object)"START")
            {
                timer2.Stop();
                timer.Start();
                buttonStart.Content = "STOP";
            }
            else
            {
                timer.Stop();
                labelCountDown.Content = "00:00";
                TotalTime = 123;
                buttonStart.Content = "START";
                timer2.Start();
            }
        }

        private void CountDown_Loaded(object sender, RoutedEventArgs e)
        {
            CurrentTime = DateTime.Now;
            labelCountDown.Content = "00:00";
            //  CurrentTime = new DateTime(2009, 12, 2, 2, 3, 2);
            DigitalClockText.Text = ((CurrentTime.Hour <= 10) ? "0" + CurrentTime.Hour : CurrentTime.Hour.ToString()) + ":" + ((CurrentTime.Minute <= 10) ? "0" + CurrentTime.Minute : CurrentTime.Minute.ToString());
            timer2.Start();
        }
    }
}
