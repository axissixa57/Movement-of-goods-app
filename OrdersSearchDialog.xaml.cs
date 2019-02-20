using System;
using System.Linq;
using System.Windows;

namespace SQL_WPF
{

    public partial class OrdersSearchDialog : Window
    {
        public OrdersSearchDialog()
        {
            InitializeComponent();
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            string searchByIdOfTTN = ттнTextBox.Text;
            string searchByIdOfOrder = код_заказаTextBox.Text;
            string searchByIdOfCounterparty = код_контрагентаTextBox.Text;
            string searchByNameOfCounterparty = наименование_контрагентаTextBox.Text;
            string searchByIdOfShipper = код_поставщикаTextBox.Text;
            string searchByNameOfShipper = наименование_поставщикаTextBox.Text;
            string searchByIdOfProduct = код_товараTextBox.Text;
            string searchByNameOfProduct = наименование_товараTextBox.Text;
            string searchByDeliveryDate = дата_заказаDatePicker.Text;

            var order = from orders in App.Context.заказы
                                    select orders;

            order = order.Where(ord => ord.ттн.Contains(searchByIdOfTTN));
            order = order.Where(ord => ord.код_заказа.Contains(searchByIdOfOrder));
            order = order.Where(ord => ord.код_контрагента.Contains(searchByIdOfCounterparty));
            order = order.Where(ord => ord.наименование_контрагента.Contains(searchByNameOfCounterparty));
            order = order.Where(ord => ord.код_поставщика.Contains(searchByIdOfShipper));
            order = order.Where(ord => ord.наименование_поставщика.Contains(searchByNameOfShipper));
            order = order.Where(ord => ord.код_товара.Contains(searchByIdOfProduct));
            order = order.Where(ord => ord.наименование_товара.Contains(searchByNameOfProduct));

            OrdersWIndow.ordViewSource.Source = order.ToList();

            if (дата_заказаDatePicker.Text.Length > 0)
            {
                using (var db = new movement_of_goodsEntities())
                {
                    var tempSearchByDeliveryDate = DateTime.Parse(searchByDeliveryDate);
                    var filteredData = db.заказы.Where(t => t.дата_заказа == tempSearchByDeliveryDate);
                    OrdersWIndow.ordViewSource.Source = filteredData.ToList();
                }
            }
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
