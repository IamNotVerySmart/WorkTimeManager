using System;
using System.IO;
using System.Windows;
using System.Windows.Threading;

namespace WorkTimeManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new();

        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void save()
        {
            StreamWriter DBWriter = File.AppendText("databasefile.txt");
            DBWriter.WriteLine(TikTakAleNieTenDoJedzenia.Content);
            DBWriter.Close();
        }
        
        //StreamReader DBReader = new("databasefile.txt");
        private void WorkStart(object sender, RoutedEventArgs e)
        {

            save();
        }

        private void WorkEnd(object sender, RoutedEventArgs e)
        {

        }

        private void BreakStart(object sender, RoutedEventArgs e)
        {

        }

        private void BreakEnd(object sender, RoutedEventArgs e)
        {

        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            TikTakAleNieTenDoJedzenia.Content = DateTime.Now.ToString("d/M/yyy HH:mm:ss");
        }

    }
}
