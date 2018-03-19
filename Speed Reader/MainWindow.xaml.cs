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
        Boolean needSpace = false;
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
                fileContent = fileContent.Replace("\n", " ");
                fileWords = fileContent.Split(' ');
                //System.IO.StreamWriter outputfile = new System.IO.StreamWriter("C:\\Users\\landini\\Desktop\\output");
                //outputfile.Write(fileWords);
                //return;
                WordPane.Text = fileWords[0];
                Page2.Visibility = Visibility.Visible;

                timer.Interval = 1000 / (200 / 60) ;
                timer.Elapsed += OnTimedEvent;
                timer.Enabled = false;
                BackButton.IsEnabled = false;

                wordCountEnd.Text = "of " + Convert.ToString(fileWords.Length);
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
                else if(!needSpace)
                {
                    wordCountStart.Text = Convert.ToString(place);
                    WordPane.Text = fileWords[place];
                    
                    if (fileWords[place].EndsWith("."))
                    {
                        needSpace = true;
                    }
                    place++;
                    
                }
                else
                {
                    WordPane.Text = " ";
                    needSpace = false;
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
                    wordCountStart.IsEnabled = true;
                    BackButton.IsEnabled = true;
                }
                else
                {

                    try
                    {
                        timer.Interval = 1000 / (Int32.Parse(WPM.Text) / 60);
                        timer.Enabled = true;
                        wordCountStart.IsEnabled = false;
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
            timer.Enabled = false;
            WPM.IsEnabled = true;
            wordCountStart.IsEnabled = true;
            BackButton.IsEnabled = true;
            place = 1;
            wordCountStart.Text = "1";
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Page2.Visibility = Visibility.Hidden;
            Page1.Visibility = Visibility.Visible;
        }

        private void wordCountStart_TextChanged(object sender, TextChangedEventArgs e)
        {
           
            try
            {
                
               
                place = Convert.ToInt32(wordCountStart.Text);
                if (place > fileWords.Length)
                {
                    WordPane.Text = fileWords[fileWords.Length - 1];
                    wordCountStart.Text = Convert.ToString(fileWords.Length);
                }
                else if (place < 1)
                {
                    WordPane.Text = fileWords[0];
                    wordCountStart.Text = "1";
                }
                else
                {
                    WordPane.Text = fileWords[Convert.ToInt32(wordCountStart.Text) - 1];
                    
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void BackwordButton_Click(object sender, RoutedEventArgs e)
        {
            wordCountStart.Text = Convert.ToString(Convert.ToInt32(wordCountStart.Text) - 1);
        }
    }
}
