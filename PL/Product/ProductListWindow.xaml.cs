﻿using BlApi;
using BlImplementation;
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
           CategorySelector.SelectedItem= Enum.GetValues(typeof(BO.Category));
           CategorySelector.ItemsSource = /*bl.Product(CategorySelector.SelectedItem);*/
        }

        private void ProductsList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
