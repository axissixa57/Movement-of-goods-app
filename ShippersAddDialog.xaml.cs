using System.Linq;
using System.Windows;

namespace SQL_WPF
{

    public partial class ShippersAddDialog : Window
    {
        public ShippersAddDialog()
        {
            InitializeComponent();
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            поставщики newShipper = new поставщики();

            var shipper = App.Context.поставщики.FirstOrDefault(u => u.код_поставки == код_поставкиTextBox.Text);

            if (shipper != null)
            {
                MessageBox.Show($"Код \"{код_поставкиTextBox.Text}\" поставки уже существует!");
            }
            else if (код_поставкиTextBox.Text == string.Empty)
            {
                MessageBox.Show($"Поле \"код поставки\" не должно быть пустым!");
            }
            else if (цена_за_еденицу_бел_рубTextBox.Text == string.Empty)
            {
                MessageBox.Show($"Поле \"цена бел. руб.\" не должно быть пустым!");
            }
            else if (кол_во_поставляемогоTextBox.Text == string.Empty)
            {
                MessageBox.Show($"Поле \"кол-во поставляемого\" не должно быть пустым!");
            }
            else
            {
                newShipper.код_поставки = код_поставкиTextBox.Text;
                newShipper.код_поставщика = код_поставщикаTextBox.Text;
                newShipper.наименование = наименованиеTextBox.Text;
                newShipper.адрес = адресTextBox.Text;
                newShipper.телефон = телефонTextBox.Text;
                newShipper.код_товара = код_товараTextBox.Text;
                newShipper.наименование_товара = наименование_товараTextBox.Text;
                newShipper.цена_за_еденицу_бел_руб = int.Parse(цена_за_еденицу_бел_рубTextBox.Text);
                newShipper.еденицы_измерения = еденицы_измеренияTextBox.Text;
                newShipper.срок_гарантии = срок_гарантииTextBox.Text;
                newShipper.кол_во_поставляемого = int.Parse(кол_во_поставляемогоTextBox.Text);

                App.Context.поставщики.Add(newShipper);
                App.Context.SaveChanges();
                this.DialogResult = true;
                this.Close();
            }  
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void Button_Click_Check(object sender, RoutedEventArgs e)
        {
            var shipperName = App.Context.поставщики.FirstOrDefault(u => u.код_поставщика == код_поставщикаTextBox.Text);

            if (shipperName != null)
                MessageBox.Show($"Код \"{код_поставщикаTextBox.Text}\" поставщика существует в базе данных.");
            else
                MessageBox.Show($"Код \"{код_поставщикаTextBox.Text}\" поставщика отсутствует в базе данных.");
        }
    }
}
