using System.Data.Entity;
using System.Windows;
using System.Windows.Data;

namespace SQL_WPF
{
    public partial class CustomerOrdersDialog : Window
    {
        CollectionViewSource customerOrdViewSource;

        public CustomerOrdersDialog()
        {
            InitializeComponent();
            customerOrdViewSource = ((CollectionViewSource)(FindResource("контрагентыViewSource")));
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            App.Context.контрагенты.Load();
            customerOrdViewSource.Source = App.Context.контрагенты.Local;
        }
    }
}
