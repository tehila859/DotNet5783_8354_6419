﻿using BlApi;
using BlImplementation;
using DO;
using System;
using System.Windows;


namespace PL
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ProductListWindow : Window
    {
        private IBl bl = new Bl();
        public ProductListWindow()
        {
           InitializeComponent();
           ProductsList.ItemsSource=bl.Product.GetListedProducts();
           CategorySelector.ItemsSource= Enum.GetValues(typeof(BO.Category));   
        }

        /// <summary>
        /// Filter - list products by category
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CategorySelector_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            BO.Category category = (BO.Category)CategorySelector.SelectedItem;
            Func<DO.Product?, bool>? predicate = item =>
            {
                bool b1 = item?.Category == (DO.Category)category;
                return b1;
            };

            ProductsList.ItemsSource = bl.Product.GetListedProducts(predicate);
        }

        /// <summary>
        /// Click Button of adding products 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new AddProductWindow().Show();
        }

        /// <summary>
        /// click on product from list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductsList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            BO.ProductForList product = new BO.ProductForList();
            product = (BO.ProductForList)sender;//צריך להמיר את המוצר שנבחר מתוך הרשימה לטיפוס מוצר כי זה בטיפוס של עצם
            new AddProductWindow(product.ID).Show();
        }
    }
}
