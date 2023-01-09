﻿
using PL.Order;
using System.Windows;
using System;


namespace PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private void MainWindow_Click(object sender, RoutedEventArgs e) => new ProductListWindow().Show();

        public MainWindow()
        {
           InitializeComponent();
           Orders_List.Visibility = Visibility.Hidden;//hide butten of Orderslist
           Products_List.Visibility = Visibility.Hidden;//hide butten of Productslist
        }
        BlApi.IBl? bl = BlApi.Factory.Get();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Manager_Click(object sender, RoutedEventArgs e)
        {
            Manager.Visibility = Visibility.Hidden;//hide butten of Manager
            New_Order.Visibility = Visibility.Hidden;//hide butten of New_Order
            Order_Tracking.Visibility = Visibility.Hidden;//hide butten of  Order_Tracking
            Orders_List.Visibility = Visibility.Visible;//Show butten of Orderslist
            Products_List.Visibility = Visibility.Visible;//Show butten of Productslist
        }

        private void NewOrder_Click(object sender, RoutedEventArgs e)
        {
            new CatalogWindow().Show();
        }

        private void OrderTracking_Click(object sender, RoutedEventArgs e)
        {
            new OrderTrackingWindow().Show();
            Close();
        }

        private void ProductsList_Click(object sender, RoutedEventArgs e)
        {
            new ProductListWindow().Show();
            Close();
        }

        private void OrdersList_Click(object sender, RoutedEventArgs e)
        {
            new OrderListWindow().Show();
            Close ();
        }
    }
}
