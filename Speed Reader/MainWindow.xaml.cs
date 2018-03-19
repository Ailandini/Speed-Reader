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
    /// Speed Reader is a little application that allows individuals to quickly read through text based documents.
    /// Currently in version 1.2 the user can now make use of a single backward feature. As well as selected a specific word to start with.
    /// 1.2 also contains a few formatting changes to allow for a more intuitive experience.
    /// 2.0 will include implementation for Microsoft Word documents and is expected to be released soon.
    /// </summary>
    public partial class MainWindow : Window
    {
        //This Boolean allows for spaces after periods
        Boolean needSpace = false;
        //This array holds the words contained within our document.
        String[] fileWords;
        //Timer initialization for speed reading.
        System.Timers.Timer timer = new System.Timers.Timer();
        //Default starting position.
        int place = 1;
        public MainWindow()
        {
            InitializeComponent();
        }

        //The Browse button allows users to select their desired file for reading. The filter option restricts file choice to only those
        //files that can be read in version 1.2
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

        //The Submit button does a myriad of things. But most importantly it opens and reads the file specified previously, and puts it into an
        //array for easy use. It sets the intial timer and word count values and also changes the visibility of the application from the choosing screen 
        //to the reading screen.
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(FileName.Text);
                Page1.Visibility = Visibility.Hidden;
                String fileContent = file.ReadToEnd();
                fileContent = fileContent.Replace("\n", " ");
                fileWords = fileContent.Split(' ');
                WordPane.Text = fileWords[0];
                Page2.Visibility = Visibility.Visible;

                timer.Interval = 1000 / (200 / 60) ;
                timer.Elapsed += OnTimedEvent;
                timer.Enabled = false;
                BackButton.IsEnabled = false;

                wordCountEnd.Text = "of " + Convert.ToString(fileWords.Length);
            }
            //This catch is mostly obsolete due to the filter selection above. However, it's never a bad idea to have extra protection.
            catch (Exception except)
            {
                FileName.Text = "-Please choose a valid text file-";
                return;
            }
            
        }

        //The timer steps through the words of the file at a certain rate determined by the WPM field. It also handles the display of empty following
        //words that end sentences. This makes the speed reading process feel more natural.
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

        //The Start/Pause Button is likely the most important of all functionalities. The button starts and stops the timer object to allow for client
        //manipulation of fields. This includes moving through words, changing the Words Per Minute, and returning to the previous screen. It also handles
        //the locking of these fields while the reader is processing.
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
                    //In the event the user tries to read at zero words per minute, the WPM field is returned to 200.
                    catch (DivideByZeroException)
                    {
                        WPM.Text = "200";
                    }
                }    
            }
        }

        //Our reset button returns the speed reader to the start of the text file.
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

        //The back button returns the user to the file selection screen.
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Page2.Visibility = Visibility.Hidden;
            Page1.Visibility = Visibility.Visible;
        }

        //The wordCountStart field refers to which word the reader is currently on. If the reader is paused (or yet to start) the user may change which word
        //he/she would like to begin with. The WordPane (which displays the current word) is updated immediately when this value is changed. 
        //This function also maintains that the user does not pick an index that is outside the scope of possible words (returning the count to the final word of 
        //the file if attempted word is more than the count of words, or to 1 if 0 and lower).
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

        //Lastly the back-word button declines the word count by one, allowing the user to step back and reread the last couple words if they are missed.
        private void BackwordButton_Click(object sender, RoutedEventArgs e)
        {
            wordCountStart.Text = Convert.ToString(Convert.ToInt32(wordCountStart.Text) - 1);
        }
    }
}
