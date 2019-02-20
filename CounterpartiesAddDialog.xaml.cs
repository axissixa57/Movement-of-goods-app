using System.Linq;
using System.Windows;

namespace SQL_WPF
{

    public partial class CounterpartiesAddDialog : Window
    {
        public CounterpartiesAddDialog()
        {
            InitializeComponent();
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            контрагенты newCounterparty = new контрагенты();

            var сounterparty = App.Context.контрагенты.FirstOrDefault(u => u.код_контрагента == код_контрагентаTextBox.Text);
            if (сounterparty != null)
            {
                MessageBox.Show($"Код \"{код_контрагентаTextBox.Text}\" контрагента уже существует!");
            }
            else if(код_контрагентаTextBox.Text == string.Empty)
            {
                MessageBox.Show($"Поле \"код контрагента\" не должно быть пустым!");
            }
            else
            {
                newCounterparty.код_контрагента = код_контрагентаTextBox.Text;
                newCounterparty.наименование = наименованиеTextBox.Text;
                newCounterparty.адрес = адресTextBox.Text;
                newCounterparty.телефон = телефонTextBox.Text;

                // newCounterparty в DbSet контрагенты
                App.Context.контрагенты.Add(newCounterparty);
                // Сохраняем локальные изменения DbSet-a в реальную БД
                App.Context.SaveChanges();
                this.DialogResult = true;
                this.Close();
            }
        }
    }
}
