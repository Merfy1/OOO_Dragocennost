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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OOO_Dragocennost.UserController
{
    /// <summary>
    /// Логика взаимодействия для ProductController.xaml
    /// </summary>
    public partial class ProductController : UserControl
    {
        Product product; 
        public ProductController(Product product)
        {
            InitializeComponent();
            this.product = product;
            DataContext = product;
        }
    }
}
