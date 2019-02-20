using System;
using System.Linq;
using System.Windows;

namespace SQL_WPF
{

    public partial class WarehouseSearchDialog : Window
    {
        public WarehouseSearchDialog()
        {
            InitializeComponent();
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            string searchByIdOfOrder = код_заказаTextBox.Text;
            string searchByIdOfshipment = код_поставкиTextBox.Text;
            string searchByIdOfShipper = код_поставщикаTextBox.Text;
            string searchByNameOfShipper = наименование_поставщикаTextBox.Text;
            string searchByIdOfProduct = код_товараTextBox.Text;
            string searchByNameOfProduct = наименование_товараTextBox.Text;
            string searchByDeliveryDate = дата_поступленияDatePicker.Text;
            string searchByDateOfShipment = дата_выбытияDatePicker.Text;

            var warehousePosition = from warehousePositions in App.Context.склад
                                    select warehousePositions;

            warehousePosition = warehousePosition.Where(wh => wh.код_заказа.Contains(searchByIdOfOrder));
            warehousePosition = warehousePosition.Where(wh => wh.код_поставки.Contains(searchByIdOfshipment));
            warehousePosition = warehousePosition.Where(wh => wh.код_поставщика.Contains(searchByIdOfShipper));
            warehousePosition = warehousePosition.Where(wh => wh.наименование_поставщика.Contains(searchByNameOfShipper));
            warehousePosition = warehousePosition.Where(wh => wh.код_товара.Contains(searchByIdOfProduct));
            warehousePosition = warehousePosition.Where(wh => wh.наименование_товара.Contains(searchByNameOfProduct));

            WarehouseWindow.warehViewSource.Source = warehousePosition.ToList();

            if (дата_поступленияDatePicker.Text.Length > 0)
            {
                using (var db = new movement_of_goodsEntities())
                {
                    var tempSearchByDeliveryDate = DateTime.Parse(searchByDeliveryDate);
                    var filteredData = db.склад.Where(t => t.дата_поступления == tempSearchByDeliveryDate);
                    WarehouseWindow.warehViewSource.Source = filteredData.ToList();
                }
            }

            if (дата_выбытияDatePicker.Text.Length > 0)
            {
                using (var db = new movement_of_goodsEntities())
                {
                    var tempSearchByDateOfShipment = DateTime.Parse(searchByDateOfShipment);
                    var filteredData = db.склад.Where(t => t.дата_выбытия == tempSearchByDateOfShipment);
                    WarehouseWindow.warehViewSource.Source = filteredData.ToList();
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
