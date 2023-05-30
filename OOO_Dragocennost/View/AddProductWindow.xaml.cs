using Microsoft.Win32;
using OOO_Dragocennost.Entity;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace OOO_Dragocennost.View
{
    /// <summary>
    /// Логика взаимодействия для AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        Product product = new Product();
        TradeContext context = new TradeContext();
        string fileName;
        public AddProductWindow()
        {
            InitializeComponent();
            DataContext = product;
            ManufacturerCombo.ItemsSource = context.Manufacturers.ToList();
            SupplierCombo.ItemsSource = context.Suppliers.ToList();
            CategoryCombo.ItemsSource = context.Categories.ToList();
        }
        
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";
            if(ofd.ShowDialog() == true)
            {
                fileName = ofd.FileName;
                PhotoText.Source = new BitmapImage(new Uri(fileName));
                MessageBox.Show(fileName);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(product.ProductArticleNumber) || string.IsNullOrWhiteSpace(product.ProductName) || string.IsNullOrWhiteSpace(product.ProductUnit) || product.ProductCost == 0 || string.IsNullOrWhiteSpace(ManufacturerCombo.Text) || string.IsNullOrWhiteSpace(SupplierCombo.Text) || product.ProductQuantityInStock == 0 || string.IsNullOrWhiteSpace(product.ProductDescription))
            {
                MessageBox.Show("Вы не заполнили все данные");
            }
            else
            {
                product.ProductImage = fileName;
                context.Products.Add(product);
                context.SaveChanges();
            }
        }
    }
}
