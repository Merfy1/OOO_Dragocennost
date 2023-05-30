using OOO_Dragocennost.Entity;
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
using System.Windows.Shapes;

namespace OOO_Dragocennost.View
{
    /// <summary>
    /// Логика взаимодействия для UpdateProductWindow.xaml
    /// </summary>
    public partial class UpdateProductWindow : Window
    {
        Product product = new Product();
        TradeContext context = new TradeContext();
        public UpdateProductWindow(Product product)
        {
            InitializeComponent();
            this.product = product;
            DataContext = this.product;
            ManufacturerCombo.ItemsSource = context.Manufacturers.ToList();
            SupplierCombo.ItemsSource = context.Suppliers.ToList();
            CategoryCombo.ItemsSource = context.Categories.ToList();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            context.Products.Update(product);
            context.SaveChanges();
            Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
