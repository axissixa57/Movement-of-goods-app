using System.Data.Entity;
using System.Windows;
using System.Windows.Data;

namespace SQL_WPF
{
    public partial class ShippersWindow : Window
    {
        public static CollectionViewSource shipViewSource;

        public ShippersWindow()
        {
            InitializeComponent();
            shipViewSource = ((CollectionViewSource)(FindResource("поставщикиViewSource")));
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            App.Context.поставщики.Load();
            shipViewSource.Source = App.Context.поставщики.Local;
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            ShippersAddDialog add = new ShippersAddDialog();
            bool? wasAdded = add.ShowDialog();
            if (wasAdded == true)
            {
                shipViewSource.View.Refresh();
            }
        }

        private void ПоставщикиDataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            поставщики selectedShipper = поставщикиDataGrid.SelectedItem as поставщики;
            ShippersEditDialog add = new ShippersEditDialog(selectedShipper);

            bool? wasAdded = add.ShowDialog();

            if (wasAdded == true)
            {
                shipViewSource.View.Refresh();
                App.Context.SaveChanges();
            }
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            поставщики selectedShipper = поставщикиDataGrid.SelectedItem as поставщики;

            MessageBoxResult confirmDelete = MessageBox.Show("Вы уверены, что хотите удалить выбранную позицию?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (confirmDelete == MessageBoxResult.Yes)
            {
                App.Context.поставщики.Remove(selectedShipper);
                shipViewSource.View.Refresh();
                App.Context.SaveChanges();
            }
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            ShippersSearchDialog search = new ShippersSearchDialog();
            bool? wasSearched = search.ShowDialog();
            if (wasSearched == true)
            {
                shipViewSource.View.Refresh();
            }
        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            shipViewSource.Source = App.Context.поставщики.Local; // добавлена, потому что после операции поиска, операция добавления(например) не обновляла результат в DataGrid-e
        }

        private void Button_Click_Copy(object sender, RoutedEventArgs e)
        {
            поставщики selectedShipper = поставщикиDataGrid.SelectedItem as поставщики;
            ShippersCopyDialog copy = new ShippersCopyDialog(selectedShipper);

            bool? wasAdded = copy.ShowDialog();
            if (wasAdded == true)
            {
                shipViewSource.View.Refresh();
                App.Context.SaveChanges();
            }
        }
    }
}
