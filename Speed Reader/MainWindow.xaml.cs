using System;
using System.Collections.Generic;
using System.Collections;
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
using System.Windows.Forms;
using System.Timers;
namespace Speed_Reader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Boolean paused = false;
        String[] fileWords;
        System.Timers.Timer timer = new System.Timers.Timer();
        int place = 1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog files = new OpenFileDialog();
            files.InitialDirectory = "Desktop";
            files.Filter = "txt files (*.txt)|*.txt|All files (*.*|*.*";
            if(files.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileName.Text = files.FileName;
            }


        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(FileName.Text);
                Page1.Visibility = Visibility.Hidden;
                String fileContent = file.ReadToEnd();
                fileContent.Replace('\n', ' ');
                fileWords = fileContent.Split(' ');
                WordPane.Text = fileWords[0];
                Page2.Visibility = Visibility.Visible;

                timer.Interval = 1000 / (200 / 60) ;
                timer.Elapsed += OnTimedEvent;
                timer.Enabled = false;
                BackButton.IsEnabled = false;
            }
            catch (Exception except)
            {
                FileName.Text = "-Please choose a valid text file-";
                return;
            }
            
        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                if (place > fileWords.Length - 1)
                {
                    timer.Enabled = false;
                }
                else
                {
                    WordPane.Text = fileWords[place];
                    place++;
                }
            });
        }

        private void SPButton_Click(object sender, RoutedEventArgs e)
        {
            if (fileWords.Length > 0)
            {
                if (timer.Enabled == true)
                {
                    timer.Enabled = false;
                    WPM.IsEnabled = true;
                    BackButton.IsEnabled = true;
                }
                else
                {
                    try
                    {
                        timer.Interval = 1000 / (Int32.Parse(WPM.Text) / 60);
                        timer.Enabled = true;
                        WPM.IsEnabled = false;
                        BackButton.IsEnabled = false;
                    }
                    catch (DivideByZeroException)
                    {
                        WPM.Text = "200";
                    }
                }
            }
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            WordPane.Text = fileWords[0];
            paused = true;
            timer.Enabled = false;
            WPM.IsEnabled = true;
            BackButton.IsEnabled = true;
            place = 1;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Page2.Visibility = Visibility.Hidden;
            Page1.Visibility = Visibility.Visible;
        }

        
    }
}
