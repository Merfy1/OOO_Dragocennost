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
    /// Логика взаимодействия для OrderTicket.xaml
    /// </summary>
    public partial class OrderTicket : Window
    {
        public OrderTicket(Product product)
        {
            InitializeComponent();
            DataContext = product;
        }

        private void Pdf_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                IDocumentPaginatorSource idp = PDF;
                printDialog.PrintDocument(idp.DocumentPaginator, Title);
            }
        }
    }
}
