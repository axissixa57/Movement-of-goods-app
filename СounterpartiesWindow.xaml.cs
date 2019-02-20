using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace SQL_WPF
{
    public partial class СounterpartiesWindow : Window
    {
        //Этот класс используется как связующее звено между элементом управления 
        //(только для тех, которые отображают коллекции элементов) и источником данных, 
        //которые он в себе отображает. Он нам и нужен будет только для того, чтобы связать DbSet контрагенты с таблицей DataGrid в окне.
        CollectionViewSource counterpartViewSource; // используется для связи таблицы интерфейса с таблицей базы данных. Здесь будет храниться ссылка на объект источника данных для DataGrid-a

        public СounterpartiesWindow()
        {
            InitializeComponent();
            // С помощью метода FindResource получаем объект из XAML ресурсов
            // По имени контрагентыViewSource. Это объект источника данных для таблицы в окне
            counterpartViewSource = ((CollectionViewSource)(FindResource("контрагентыViewSource")));
            // Устанавливаем DataContext для текущего окна (this) на себя же (this)
            // Для того, чтобы в XAML редакторе можно было использовать
            // Binding и к свойствам текущего класса
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Загружает данные в DbSet "контрагеты" из базы
            App.Context.контрагенты.Load(); //  Этот метод перечисляет результаты запроса, аналогично ToList, но без создания списка. При использовании с Linq to Entities этот метод создает объекты сущностей и добавляет их в контекст.
            // Устанавливаем источник данных для DataGrid-a на локальное содержимое DbSet-a "контрагенты"
            counterpartViewSource.Source = App.Context.контрагенты.Local; // После загрузки данных вызовите свойство DbSet.Local, чтобы использовать DbSet в качестве источника привязки.
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            CounterpartiesAddDialog add = new CounterpartiesAddDialog();
            // Запускаем окно в модальном режиме и ожидаем возврата значения
            // которое придёт сюда, когда модальное окно будет закрыто
            // тип - nullable bool; фактически запись ? является упрощенной формой использования структуры System.Nullable<T>
            bool? wasAdded = add.ShowDialog();

            if(wasAdded == true)
            {
                // обновляем отображаемые данные таблицы DataGrid.
                // чтобы она отобразила изменения DbSet-a
                counterpartViewSource.View.Refresh();
            }
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            контрагенты selectedCounterparty = контрагентыDataGrid.SelectedItem as контрагенты;
            // вернёт MessageBoxResult, который хранит информацию, о том на какую кнопку нажал пользователь
            MessageBoxResult confirmDelete = MessageBox.Show("Вы уверены, что хотите удалить выбранную позицию?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question); 

            if (confirmDelete == MessageBoxResult.Yes)
            {
                App.Context.контрагенты.Remove(selectedCounterparty);
                // обновляем отображение таблицы
                counterpartViewSource.View.Refresh();
                // сохраняем изменения DbSet-a в оригинальную БД
                App.Context.SaveChanges();
            }
        }

        private void КонтрагентыDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            контрагенты selectedCounterparty = контрагентыDataGrid.SelectedItem as контрагенты;
            CounterpartiesEditDialog add = new CounterpartiesEditDialog(selectedCounterparty);

            bool? wasAdded = add.ShowDialog();

            if(wasAdded == true)
            {
                counterpartViewSource.View.Refresh();
                App.Context.SaveChanges();
            }
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchById = код_контрагентаTextBox.Text;
            string searchByName = наименованиеTextBox.Text;
            string searchByAddress = адресTextBox.Text;
            string searchByPhone = телефонTextBox.Text;

            var counterparty = from counterparties in App.Context.контрагенты
                               select counterparties;

            counterparty = counterparty.Where(cp => cp.код_контрагента.Contains(searchById));
            counterparty = counterparty.Where(cp => cp.наименование.Contains(searchByName));
            counterparty = counterparty.Where(cp => cp.адрес.Contains(searchByAddress));
            counterparty = counterparty.Where(cp => cp.телефон.Contains(searchByPhone));

            counterpartViewSource.Source = counterparty.ToList();
        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            counterpartViewSource.Source = App.Context.контрагенты.Local; // добавлена, потому что после операции поиска, операция добавления(например) не обновляла результат в DataGrid-e
        }
    }
}
