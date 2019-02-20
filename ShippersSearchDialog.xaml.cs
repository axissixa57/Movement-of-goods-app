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

namespace SQL_WPF
{
    public partial class ShippersSearchDialog : Window
    {
        public ShippersSearchDialog()
        {
            InitializeComponent();
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            string searchByIdOfShipment = код_поставкиTextBox.Text;
            string searchByIdOfShipper = код_поставщикаTextBox.Text;
            string searchByNameOfShipper = наименованиеTextBox.Text;
            string searchByAddressOfShipper = адресTextBox.Text;
            string searchByPhoneOfShipper = телефонTextBox.Text;
            string searchByIdOfProduct = код_товараTextBox.Text;
            string searchByNameOfProduct = наименование_товараTextBox.Text;

            var shipper = from shippers in App.Context.поставщики
                               select shippers;

            shipper = shipper.Where(s => s.код_поставки.Contains(searchByIdOfShipment));
            shipper = shipper.Where(s => s.код_поставщика.Contains(searchByIdOfShipper));
            shipper = shipper.Where(s => s.наименование.Contains(searchByNameOfShipper));
            shipper = shipper.Where(s => s.адрес.Contains(searchByAddressOfShipper));
            shipper = shipper.Where(s => s.телефон.Contains(searchByPhoneOfShipper));
            shipper = shipper.Where(s => s.код_товара.Contains(searchByIdOfProduct));
            shipper = shipper.Where(s => s.наименование_товара.Contains(searchByNameOfProduct));

            ShippersWindow.shipViewSource.Source = shipper.ToList();
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
