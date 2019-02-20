using System.Data.Entity;
using System.Windows;
using System.Windows.Data;

namespace SQL_WPF
{

    public partial class OrdersWIndow : Window
    {
        public static CollectionViewSource ordViewSource;

        public OrdersWIndow()
        {
            InitializeComponent();
            ordViewSource = ((CollectionViewSource)(FindResource("заказыViewSource")));
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            App.Context.заказы.Load();
            ordViewSource.Source = App.Context.заказы.Local;
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            OrdersAddDialog add = new OrdersAddDialog();
            bool? wasAdded = add.ShowDialog();
            if (wasAdded == true)
            {
                ordViewSource.View.Refresh();
            }
        }

        private void Button_Click_Copy(object sender, RoutedEventArgs e)
        {
            заказы selectedOrder = заказыDataGrid.SelectedItem as заказы;
            OrdersCopyDialog copy = new OrdersCopyDialog(selectedOrder);

            bool? wasAdded = copy.ShowDialog();

            if (wasAdded == true)
            {
                ordViewSource.View.Refresh();
                App.Context.SaveChanges();
            }
        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            ordViewSource.Source = App.Context.заказы.Local;
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            OrdersSearchDialog search = new OrdersSearchDialog();
            bool? wasSearched = search.ShowDialog();
            if (wasSearched == true)
            {
                ordViewSource.View.Refresh();
            }
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            заказы selectedOrder = заказыDataGrid.SelectedItem as заказы;

            MessageBoxResult confirmDelete = MessageBox.Show("Вы уверены, что хотите удалить выбранную позицию?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (confirmDelete == MessageBoxResult.Yes)
            {
                App.Context.заказы.Remove(selectedOrder);
                ordViewSource.View.Refresh();
                App.Context.SaveChanges();
            }
        }

        private void ЗаказыDataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            заказы selectedOrder = заказыDataGrid.SelectedItem as заказы;
            OrdersEditDialog edit = new OrdersEditDialog(selectedOrder);

            bool? wasAdded = edit.ShowDialog();

            if (wasAdded == true)
            {
                ordViewSource.View.Refresh();
                App.Context.SaveChanges();
            }
        }
    }
}
