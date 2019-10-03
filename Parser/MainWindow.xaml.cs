using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
using xNet;
using xNet.Collections;
using xNet.Text;
using WinForms = System.Windows.Forms;

namespace Parser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string URL;
        string[] mass1 { get; set; }
        string[] mass2 { get; set; }
        string link;
        string SourcePage;
        WinForms.FolderBrowserDialog fbd = new WinForms.FolderBrowserDialog();

        public MainWindow()
        {
            InitializeComponent();
            menuItem1.Background = Brushes.LightGray;

            listView1.Visibility = Visibility.Visible;
            listView2.Visibility = Visibility.Visible;
            textBox2.Visibility = Visibility.Hidden;
            textBox4.Visibility = Visibility.Hidden;
            textBox1.Visibility = Visibility.Hidden;
            textBox3.Visibility = Visibility.Hidden;
            label2.Visibility = Visibility.Hidden;
            label4.Visibility = Visibility.Hidden;
            label3.Visibility = Visibility.Hidden;
            label5.Visibility = Visibility.Hidden;
            label6.Visibility = Visibility.Hidden;
            label7.Visibility = Visibility.Hidden;
            checkBox1.Visibility = Visibility.Visible;
            checkBox2.Visibility = Visibility.Visible;
            checkBox3.Visibility = Visibility.Hidden;
            checkBox4.Visibility = Visibility.Hidden;
            progressBar1.Visibility = Visibility.Hidden;
            textBox6.Visibility = Visibility.Hidden;
            label9.Visibility = Visibility.Hidden;
            textBox7.Visibility = Visibility.Hidden;
            button2.Visibility = Visibility.Hidden;

            menuItem1.Background = Brushes.LightGray;
            menuItem2.Background = Brushes.Snow;

            Form1.Height = 564;
            Form1.MinHeight = 564;
            Form1.MaxHeight = 564;
            Form1.Width = 816;
            Form1.MinWidth = 816;
            Form1.MaxWidth = 816;
        }
        public void Pars()
        {
            URL = textBox5.Text;
            fbd.SelectedPath = null;
            using (var Request = new xNet.Net.HttpRequest())
            {
                try
                {
                    Clipboard.Clear();
                    Clipboard.SetText(Request.Get(URL).ToText());
                    SourcePage = Clipboard.GetText().ToString();
                }
                catch (Exception ex)
                { MessageBox.Show("Проблеми з зєднанням!!! \n" + ex.Message); }
            }
            if (textBox1.Text == "" || textBox3.Text == "")
            { }
            else { mass1 = SourcePage.Substrings(textBox1.Text, textBox3.Text, 0); }
            if (textBox2.Text == "" || textBox4.Text == "")
            { }
            else { mass2 = SourcePage.Substrings(textBox2.Text, textBox4.Text, 0); }

            string check1 = Convert.ToBoolean(checkBox1.IsChecked) ? "Checked" : "Not Checked";
            string check2 = Convert.ToBoolean(checkBox2.IsChecked) ? "Checked" : "Not Checked";
            string check3 = Convert.ToBoolean(checkBox3.IsChecked) ? "Checked" : "Not Checked";
            string check4 = Convert.ToBoolean(checkBox4.IsChecked) ? "Checked" : "Not Checked";

            if (check1 == "Checked")
            {
                StreamWriter file1 = new StreamWriter("Column1.txt");
                try
                {
                    for (int i = 0; i < mass1.Length; i++)
                    {
                        file1.WriteLine(mass1[i]);
                    }
                    listView1.ItemsSource = mass1;
                    file1.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Парсер", MessageBoxButton.OK, MessageBoxImage.Information); }
            }
            if (check2 == "Checked")
            {
                StreamWriter file2 = new StreamWriter("Column2.txt");
                try
                {
                    for (int k = 0; k < mass2.Length; k++)
                    {
                        file2.WriteLine(mass2[k]);
                    }
                    listView2.ItemsSource = mass2;
                    file2.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Парсер", MessageBoxButton.OK, MessageBoxImage.Information); }
            }
            if (check3 == "Checked")
            {
                using (WebClient webClient = new WebClient())
                {
                    for (int i = 0; i < mass1.Length; i++)
                    {
                        if (check4 == "Checked")
                        { link = textBox7.Text + mass1[i]; }
                        try
                        {
                            if (fbd.SelectedPath == null)
                            {
                                string name = fbd.SelectedPath + @"/Files" + i + "." + textBox6.Text;
                                webClient.DownloadProgressChanged += DownloadProgressChanged;
                                webClient.DownloadFile(new System.Uri(link), name);
                            }
                            else
                            {
                                string path1 = Directory.GetCurrentDirectory();
                                DirectoryInfo di = Directory.CreateDirectory(path1+@"\\DownloadFiles");
                                string name = di + @"/file" + i + "." + textBox6.Text;
                                webClient.DownloadProgressChanged += DownloadProgressChanged;
                                webClient.DownloadFile(new System.Uri(link), name);
                            }
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                    }
                }
            }
        }

        private void MenuItem1_Click(object sender, RoutedEventArgs e)
        {
            listView1.Visibility = Visibility.Visible;
            listView2.Visibility = Visibility.Visible;
            textBox2.Visibility = Visibility.Hidden;
            textBox4.Visibility = Visibility.Hidden;
            textBox1.Visibility = Visibility.Hidden;
            textBox3.Visibility = Visibility.Hidden;
            label2.Visibility = Visibility.Hidden;
            label4.Visibility = Visibility.Hidden;
            label3.Visibility = Visibility.Hidden;
            label5.Visibility = Visibility.Hidden;
            label6.Visibility = Visibility.Hidden;
            label7.Visibility = Visibility.Hidden;
            checkBox1.Visibility = Visibility.Visible;
            checkBox2.Visibility = Visibility.Visible;
            checkBox3.Visibility = Visibility.Hidden;
            checkBox4.Visibility = Visibility.Hidden;
            progressBar1.Visibility = Visibility.Hidden;
            textBox6.Visibility = Visibility.Hidden;
            label9.Visibility = Visibility.Hidden;
            textBox7.Visibility = Visibility.Hidden;
            button2.Visibility = Visibility.Hidden;

            menuItem1.Background = Brushes.LightGray;
            menuItem2.Background = Brushes.Snow;
            textBox5.Margin = new Thickness(102, 500, 306, 0);
            label8.Margin = new Thickness(10, 497, 0, 0);
            label2.Margin = new Thickness(11, 417, 0, 0);
            label4.Margin = new Thickness(11, 445, 0, 0);
            textBox1.Margin = new Thickness(103, 420, 0, 0);
            textBox3.Margin = new Thickness(103, 448, 0, 0);

            button1.Margin = new Thickness(673, 452, 0, 0);

            Form1.Height = 564;
            Form1.MinHeight = 564;
            Form1.MaxHeight = 564;
            Form1.Width = 816;
            Form1.MinWidth = 816;
            Form1.MaxWidth = 816;
        }

        private void MenuItem2_Click(object sender, RoutedEventArgs e)
        {
            listView1.Visibility = Visibility.Hidden;
            listView2.Visibility = Visibility.Hidden;
            textBox2.Visibility = Visibility.Hidden;
            textBox4.Visibility = Visibility.Hidden;
            textBox1.Visibility = Visibility.Visible;
            textBox3.Visibility = Visibility.Visible;
            label2.Visibility = Visibility.Visible;
            label4.Visibility = Visibility.Visible;
            label3.Visibility = Visibility.Hidden;
            label5.Visibility = Visibility.Hidden;
            label6.Visibility = Visibility.Hidden;
            label7.Visibility = Visibility.Hidden;
            checkBox1.Visibility = Visibility.Hidden;
            checkBox2.Visibility = Visibility.Hidden;
            checkBox3.Visibility = Visibility.Visible;
            checkBox4.Visibility = Visibility.Hidden;
            progressBar1.Visibility = Visibility.Visible;
            textBox6.Visibility = Visibility.Hidden;
            label9.Visibility = Visibility.Hidden;
            textBox7.Visibility = Visibility.Hidden;
            button2.Visibility = Visibility.Visible;

            menuItem1.Background = Brushes.Snow;
            menuItem2.Background = Brushes.LightGray;
            label2.Margin = new Thickness(24, 56, 0, 0);
            label4.Margin = new Thickness(24, 84, 0, 0);
            label8.Margin = new Thickness(10, 119, 0, 0);
            label9.Margin = new Thickness(263, 89, 0, 0);
            textBox1.Margin = new Thickness(116, 59, 0, 0);
            textBox3.Margin = new Thickness(116, 87, 0, 0);
            textBox5.Margin = new Thickness(112, 122, 306, 0);
            textBox6.Margin = new Thickness(318, 92, 0, 0);
            textBox7.Margin = new Thickness(422, 92, 0, 0);
            checkBox3.Margin = new Thickness(557, 72, 0, 0);
            checkBox4.Margin = new Thickness(431, 72, 0, 0);
            button1.Margin = new Thickness(673, 75, 0, 0);
            button2.Margin = new Thickness(524, 92, 0, 0);
            progressBar1.Margin = new Thickness(10, 27, 0, 0);
            progressBar1.Width = 788;



            Form1.Height = 200;
            Form1.MinHeight = 200;
            Form1.MaxHeight = 200;
            Form1.Width = 816;
            Form1.MinWidth = 816;
            Form1.MaxWidth = 816;
        }

        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {
            textBox1.Visibility = Visibility.Visible;
            textBox3.Visibility = Visibility.Visible;
            label2.Visibility = Visibility.Visible;
            label4.Visibility = Visibility.Visible;
        }

        private void checkBox2_Checked(object sender, RoutedEventArgs e)
        {
            textBox2.Visibility = Visibility.Visible;
            textBox4.Visibility = Visibility.Visible;
            label3.Visibility = Visibility.Visible;
            label5.Visibility = Visibility.Visible;
        }

        private void checkBox3_Checked(object sender, RoutedEventArgs e)
        {
            textBox6.Visibility = Visibility.Visible;
            label9.Visibility = Visibility.Visible;
            checkBox4.Visibility = Visibility.Visible;
        }

        private void checkBox4_Checked(object sender, RoutedEventArgs e)
        {
            textBox7.Visibility = Visibility.Visible;
        }

        void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void checkBox1_Unchecked(object sender, RoutedEventArgs e)
        {
            textBox1.Visibility = Visibility.Hidden;
            textBox3.Visibility = Visibility.Hidden;
            label2.Visibility = Visibility.Hidden;
            label4.Visibility = Visibility.Hidden;
        }

        private void checkBox3_Unchecked(object sender, RoutedEventArgs e)
        {
            textBox6.Visibility = Visibility.Hidden;
            label9.Visibility = Visibility.Hidden;
            checkBox4.Visibility = Visibility.Hidden;
        }

        private void checkBox2_Unchecked(object sender, RoutedEventArgs e)
        {
            textBox2.Visibility = Visibility.Hidden;
            textBox4.Visibility = Visibility.Hidden;
            label3.Visibility = Visibility.Hidden;
            label5.Visibility = Visibility.Hidden;
        }

        private void checkBox4_Unchecked(object sender, RoutedEventArgs e)
        {
            textBox7.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK) { }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Pars();
            MessageBox.Show("Complete!", "Парсер", MessageBoxButton.OK, MessageBoxImage.Information);
        }


    }
}
