using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
        string filename = string.Empty;
        List<string> messages = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = @"D:\ITHS_Repositories";
            if (dlg.ShowDialog() == true)
                filename = dlg.FileName;

            FileStream inputStream;
            StreamReader reader;


            try
            {
                inputStream = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite);
                reader = new StreamReader(inputStream);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cannot open {filename}.html!" + ex);
                return;
            }
            webText.Text = reader.ReadToEnd();
            reader.Dispose();
            inputStream.Close();
        }

        private void saveButton1_Click(object sender, RoutedEventArgs e)
        {
            FileStream outputStream;
            StreamWriter writer;

            string path = @"D:\ITHS\Programmering med C# - projekter\SimpleWebsiteGenerator\programmer-" + saveBox1.Text + ".html";
            try
            {
                outputStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter(outputStream);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot open WebsiteGenerator.html for writing" + ex);
                return;
            }

            writer.Write(webText.Text);
            writer.Close();
            outputStream.Close();
            MessageBox.Show("Saved!");

        }

        private void insertHeader_Click(object sender, RoutedEventArgs e)
        {
            string header = headerBox.Text;
            Button clickedButton = (Button)sender;
            clickedButton.Content = "Done!";
            clickedButton.IsEnabled = false;

        }

        private void Insertmessage_Click(object sender, RoutedEventArgs e)
        {
            messages.Add(messageBox.Text);
        }
    }
}
