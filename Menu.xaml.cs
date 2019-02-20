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
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Button_Click_Сounterparties(object sender, RoutedEventArgs e)
        {
            СounterpartiesWindow сounterparties = new СounterpartiesWindow();
            сounterparties.Show();
        }

        private void Button_Click_Shippers(object sender, RoutedEventArgs e)
        {
            ShippersWindow shippers = new ShippersWindow();
            shippers.Show();
        }

        private void Button_Click_Warehouse(object sender, RoutedEventArgs e)
        {
            WarehouseWindow warehouse = new WarehouseWindow();
            warehouse.Show();
        }

        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_Orders(object sender, RoutedEventArgs e)
        {
            OrdersWIndow orders = new OrdersWIndow();
            orders.Show();
        }
    }
}
