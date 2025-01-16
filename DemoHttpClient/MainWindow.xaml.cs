﻿using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HttpClientDemo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        readonly HttpClient client = new HttpClient();

        private async void viewHTML_Click(object sender, RoutedEventArgs e)
        {
            string uri = txtURL.Text;

            try {
                string responseBody = await client.GetStringAsync(uri);
                txtContent.Text = responseBody.Trim();
            } catch(HttpRequestException ex) {
                MessageBox.Show($"Message: {ex.Message }");
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtContent.Text = string.Empty;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}