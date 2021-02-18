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

namespace BallSpiel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer _animationsTimer = new DispatcherTimer();
        private bool walkToRight = true;
        private bool walkToTop = true;

        private int counter = 0;

        public MainWindow()
        {
            InitializeComponent();

            _animationsTimer.Interval = TimeSpan.FromMilliseconds(20);
            _animationsTimer.Tick += PositionierneBall;
        }

        private void PositionierneBall(object sender, EventArgs e)
        {
            var x = Canvas.GetLeft(Ball);
            var y = Canvas.GetTop(Ball);

            if (walkToRight)
            {
                Canvas.SetLeft(Ball, x + 5);
            }
            else
            {
                Canvas.SetLeft(Ball, x - 5);
            }

            if (x >= Playground.ActualWidth - Ball.ActualWidth)
            {
                walkToRight = false;
            }
            else if (x <= 0)
            {
                walkToRight = true;
            }

            if (walkToTop)
            {
                Canvas.SetTop(Ball, y + 5);
            }
            else
            {
                Canvas.SetTop(Ball, y - 5);
            }
            if (y >= Playground.ActualHeight - Ball.ActualHeight)
            {
                walkToTop = false;
            }
            else if(y <= 0)
            {
                walkToTop = true;
            }
            
            
            
        }

        private void StartStopButton_Click(object sender, RoutedEventArgs e)
        {
            if (_animationsTimer.IsEnabled)
            {
                _animationsTimer.Stop();
            }
            else
            {
                _animationsTimer.Start();
                counter = 0;
                PlaygroundLabel.Content = $"{counter} Clicks";
            }

            
            
        }

        private void Ball_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (_animationsTimer.IsEnabled)
            {
                counter += 1;
                PlaygroundLabel.Content = $"{counter} Clicks";
            }
        }

        private void Ball_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F)
            {
                Ball.Fill = Brushes.Red;
            }
        }
    }
}
