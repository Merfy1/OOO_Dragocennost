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
    /// Логика взаимодействия для ProductMenuWindow.xaml
    /// </summary>
    public partial class ProductMenuWindow : Window
    {
        User user;
        Order order;
        TradeContext contex = new TradeContext();
        public ProductMenuWindow(User user = null)
        {
            InitializeComponent();
            this.user = user;
            UpdateData();
        }
        public void UpdateData()
        {
            ProductList.Items.Clear();
            List<Product> products = contex.Products.ToList();

            foreach(Product product in products)
            {
                ProductList.Items.Add(new ProductController(product));
            }
        }

        private void AddCard_Click(object sender, RoutedEventArgs e)
        {
            ProductController productController  = ProductList.SelectedItem as ProductController;
            if (productController != null)
            {
                if (order == null)
                {
                    order = new Order();
                }
                OrderProduct orderProduct = new OrderProduct();
                orderProduct.Order = order;
                orderProduct.ProductArticleNumberNavigation = productController.DataContext as Product;
                orderProduct.Count = 1;
                order.OrderProducts.Add(orderProduct);
                
            }
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            new OrderTicket(contex.Products.ToList()[0]).Show();
        }
    }
}
