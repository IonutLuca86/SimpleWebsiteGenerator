using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
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


namespace SimpleWebsiteGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        string? header,colour = string.Empty;
        public List<string> messages = new List<string>();
        List<string> techniques = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.FileName = "Websitegenerator";
            dlg.DefaultExt = ".html";
            dlg.Filter = "HTML file (.html)|*.html";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string fileName = dlg.FileName;
                string read = "";
                using (StreamReader sr = new StreamReader(fileName))
                {
                    read = sr.ReadToEnd();
                }
                webText.Text = read;
            }
        }

        private void saveButton1_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = "Websitegenerator";
            dlg.DefaultExt = ".html";
            dlg.Filter = "HTML file (.html)|*.html";
            dlg.InitialDirectory = @"D:\ITHS_Repositories";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string fileName = dlg.FileName;
                using (StreamWriter sw = new StreamWriter($"{fileName}.html"))
                {
                    sw.WriteLine(webText.Text);
                }
                MessageBox.Show($"Saved as {fileName}");
            }
               
                //FileStream outputStream;
                //StreamWriter writer;

                //string path = @"D:\ITHS\Programmering med C# - projekter\SimpleWebsiteGenerator\programmer-" + saveBox1.Text + ".html";
                //try
                //{
                //    outputStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                //    writer = new StreamWriter(outputStream);
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("Cannot open WebsiteGenerator.html for writing" + ex);
                //    return;
                //}

                //writer.Write(webText.Text);
                //writer.Close();
                //outputStream.Close();
                //MessageBox.Show("Saved!");

            }

        private void insertHeader_Click(object sender, RoutedEventArgs e)
        {
            header = headerBox.Text;
            Button clickedButton = (Button)sender;
            clickedButton.Content = "Done!";
            clickedButton.IsEnabled = false;
            headerBox.Clear();

        }

        private void Insertmessage_Click(object sender, RoutedEventArgs e)
        {
            messages.Add(messageBox.Text);
            messageBox.Clear();
        }

        private void saveButton2_Click(object sender, RoutedEventArgs e)
        {
            string getcolour = GetColour();
            GetTechniques();
           

            StyledWebsiteGenerator perfectWebsite = new StyledWebsiteGenerator(header, getcolour, messages, techniques);
            perfectWebsite.Print();
        }

        private void GetTechniques()
        {
            if ((bool)kurs1.IsChecked)
                techniques.Add(kurs1.Content.ToString());
            if ((bool)kurs2.IsChecked)
                techniques.Add(kurs2.Content.ToString());
            if ((bool)kurs3.IsChecked)
                techniques.Add(kurs3.Content.ToString());
            if ((bool)kurs4.IsChecked)
                techniques.Add(kurs4.Content.ToString());

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string getcolour = GetColour();
            GetTechniques();
           

            StyledWebsiteGenerator perfectWebsite = new StyledWebsiteGenerator(header, getcolour, messages, techniques);
            previewBox.Text = perfectWebsite.PrintPage();
            previewBox.IsReadOnly = true;   
        }

        private string GetColour()
        {
           
            if ((bool)color1.IsChecked)
                colour = "red";
            else if ((bool)color2.IsChecked)
                colour = "blue";
            else if ((bool)color3.IsChecked)
                colour = "green";
            else if ((bool)color4.IsChecked)
                colour = "black";
            return colour;
        }
    }

}