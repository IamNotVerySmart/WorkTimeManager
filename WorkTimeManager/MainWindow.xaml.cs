using System;
using System.Diagnostics;
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

		private void save(string Type, string Description)
		{
			StreamWriter DBWriter = File.AppendText("databasefile.txt");
			DBWriter.WriteLine(Type + " | " + TikTakAleNieTenDoJedzenia.Content + "\n" + Description);
			DBWriter.Close();
		}
		
        private void save(string Type)
        {
            StreamWriter DBWriter = File.AppendText("databasefile.txt");
            DBWriter.WriteLine(Type + " | " + TikTakAleNieTenDoJedzenia.Content);
            DBWriter.Close();
        }

		private void RaportGenerate(object sender, RoutedEventArgs e)
		{
            Process.Start("notepad.exe", "databasefile.txt");
        }

        //
		//	WORK CODE
		//

        private void WorkStart(object sender, RoutedEventArgs e)
		{
            if (WorkDescription.Text.Trim() != "")
			{
                wStart.IsEnabled = false;
				save("Work start", WorkDescription.Text);
				bStart.IsEnabled = true;
				wEnd.IsEnabled = true;
			}
			else
			{
				MessageBox.Show("Description can't be empty or contain only white spaces!", "Error");
			}
		}

		private void WorkEnd(object sender, RoutedEventArgs e)
		{
			wEnd.IsEnabled = false;
			save("Work end");
			bStart.IsEnabled = false;
			wStart.IsEnabled = true;
		}

		//
		//	BREAK CODE
		//
		private void BreakStart(object sender, RoutedEventArgs e)
		{
			if (BreakDescription.Text.Trim() != "")
			{
				wEnd.IsEnabled = false;
                save("Break start", BreakDescription.Text);
                bStart.IsEnabled = false;
				bEnd.IsEnabled = true;
			}
			else
			{
				MessageBox.Show("Description can't be empty or contain only white spaces!", "Error");
			}
		}

		private void BreakEnd(object sender, RoutedEventArgs e)
		{
			wEnd.IsEnabled = true;
			save("Break end");
			bEnd.IsEnabled = false;
			bStart.IsEnabled = true;
		}

		private void Timer_Tick(object? sender, EventArgs e)
		{
			TikTakAleNieTenDoJedzenia.Content = DateTime.Now.ToString("d/M/yyy HH:mm:ss");
		}

	}
}
