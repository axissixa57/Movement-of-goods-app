using System.Data.Entity;
using System.Windows;
using System.Windows.Data;


namespace SQL_WPF
{
    public partial class WarehouseWindow : Window
    {
        public static CollectionViewSource warehViewSource;

        public WarehouseWindow()
        {
            InitializeComponent();
            warehViewSource = ((CollectionViewSource)(FindResource("складViewSource")));
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            App.Context.склад.Load();
            warehViewSource.Source = App.Context.склад.Local; 
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            WarehouseAddDialog add = new WarehouseAddDialog();
            bool? wasAdded = add.ShowDialog();
            if (wasAdded == true)
            {
                warehViewSource.View.Refresh();
            }
        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            warehViewSource.Source = App.Context.склад.Local;
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            WarehouseSearchDialog search = new WarehouseSearchDialog();
            bool? wasSearched = search.ShowDialog();
            if (wasSearched == true)
            {
                warehViewSource.View.Refresh();
            }
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            склад selectedWarehousePosition = складDataGrid.SelectedItem as склад;

            MessageBoxResult confirmDelete = MessageBox.Show("Вы уверены, что хотите удалить выбранную позицию?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (confirmDelete == MessageBoxResult.Yes)
            {
                App.Context.склад.Remove(selectedWarehousePosition);
                warehViewSource.View.Refresh();
                App.Context.SaveChanges();
            }
        }

        private void СкладDataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            склад selectedWarehouse = складDataGrid.SelectedItem as склад;
            WarehouseEditDialog edit = new WarehouseEditDialog(selectedWarehouse);

            bool? wasAdded = edit.ShowDialog();

            if (wasAdded == true)
            {
                warehViewSource.View.Refresh();
                App.Context.SaveChanges();
            }
        }

        private void Button_Click_Copy(object sender, RoutedEventArgs e)
        {
            склад selectedShipper = складDataGrid.SelectedItem as склад;
            WarehouseCopyDialog copy = new WarehouseCopyDialog(selectedShipper);

            bool? wasAdded = copy.ShowDialog();
            if (wasAdded == true)
            {
                warehViewSource.View.Refresh();
                App.Context.SaveChanges();
            }
        }
    }
}
