using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;


namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            text txt = new text();

            switch (button.Name)
            {
                case "SaveButton":
                    txt.Text = textBox1.Text;

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Title = $"{textBox1.Text}";
                    saveFileDialog.Filter = "Json files (*.json)|*.json";

                    if (saveFileDialog.ShowDialog() == true)
                    {
                        string filePath = saveFileDialog.FileName;

                        string filled = JsonSerializer.Serialize(txt);

                        File.WriteAllText(filePath, filled);

                        MessageBox.Show("Fayl yaddasa yazildi.");

                        ComboBox.Items.Add(filePath);
                        ComboBox.SelectedItem = filePath;
                    }

                    break;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox.SelectedItem != null)
            {
                string selectedFilePath = ComboBox.SelectedItem.ToString();
                string jsonContent = File.ReadAllText(selectedFilePath);

                text txt = JsonSerializer.Deserialize<text>(jsonContent);
 


                if (txt != null)
                {
                    textBox1.Text = txt.Text;
                }


            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.SelectedText))
            {
                Clipboard.SetText(textBox1.SelectedText);
                textBox1.SelectedText = string.Empty;
                MessageBox.Show("Secilmis hisse kopyalandi.");
            }
            else
            {
                MessageBox.Show("Kopyalanacaq hisse secilmeyeib.");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                string clipboardText = Clipboard.GetText();
                textBox1.Text = clipboardText;
            }
            else
            {
                MessageBox.Show("Text-de hecne yoxdur.");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                Clipboard.SetText(textBox1.Text);
                MessageBox.Show("Text  Kopyalandi.");
            }

            else
            {
                MessageBox.Show("Text-de hecne yoxdur.");
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            textBox1.Focus();
            textBox1.SelectAll();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            text txt = new text();
            txt.Text = textBox1.Text;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save Text";
            saveFileDialog.Filter = "Text files (*.txt)|*.txt";

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;

                File.WriteAllText(filePath, txt.Text);

                MessageBox.Show("Fayl txt. kimi yadda saxlanildi");


            }

        }
    }

    public class text
    {
        public string? Text { get; set; }
    }
}

