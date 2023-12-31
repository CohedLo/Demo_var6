﻿using Demo_var_6.DataBase;
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
using System.Windows.Threading;

namespace Demo_var_6.Pages
{
    /// <summary>
    /// Логика взаимодействия для GuestPage.xaml
    /// </summary>
    public partial class GuestPage : Page
    {
        public GuestPage()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += UpdateData;
            timer.Start();
        }
        public void UpdateData(object sender, object e)
        {
            var HistoryProduct = ConnectObj.conObj.Product.ToList();
            ListProd.ItemsSource = HistoryProduct;
            ListProd.ItemsSource = ConnectObj.conObj.Product.Where(x => x.ProductName.StartsWith(TxtSearch.Text) || x.ProductDescription.StartsWith(TxtSearch.Text)).ToList();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new PageAddInBasket());
        }

    }
}
