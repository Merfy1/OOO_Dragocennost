using OOO_Dragocennost.Entity;
using OOO_Dragocennost.UserController;
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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        Product product;
        TradeContext contex = new TradeContext();
        User user;
        private Product selectedProduct;
        public AdminWindow(User user = null)
        {
            InitializeComponent();
            UpdateData();
        }
        public void UpdateData()
        {
            ProductList.Items.Clear();
            List<Product> products = contex.Products.ToList();
            foreach (Product product in products)
            {
                ProductList.Items.Add(new ProductController(product));
            }
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Product product = (ProductList.SelectedItem as ProductController).DataContext as Product;
            if (ProductList.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали товар для удаления");
            }
            else
            {
                if (product.OrderProducts.Count() > 0)
                {
                    MessageBox.Show("Этот товар в заказе");

                }
                else
                {
                    contex.Products.Remove(product);
                    contex.SaveChanges();
                }
            }
            UpdateData();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            new AddProductWindow().ShowDialog();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (selectedProduct != null)
            {
                new UpdateProductWindow(selectedProduct).ShowDialog();
                UpdateData();
            }
            else
            {
                MessageBox.Show("Вы не выбрали товар для изменения");
            }
  
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            new SignInWindow().Show();
            this.Close();
        }

        private void ProductList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductList.SelectedItem != null)
            {
                selectedProduct = (ProductList.SelectedItem as ProductController).DataContext as Product;

            }
        }
    }
}
