﻿using Microsoft.Win32;
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
using CsvHelper;
using System.IO;
using SE2.CourseWork.Models;

namespace SE2.CourseWork
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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                readPersonData(openFileDialog.FileName);
            }
        }

        private void readPersonData(string fileName)
        {
            using (StreamReader file = new StreamReader(fileName))
            {
                using (CsvReader reader = new CsvReader(file))
                {
                    List<Person> persons = new List<Person>(reader.GetRecords<Person>());
                    PersonTable.ItemsSource = persons;
                }
            }
        }
    }
}
