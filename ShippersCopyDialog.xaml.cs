using System;
using System.Linq;
using System.Windows;

namespace SQL_WPF
{

    public partial class ShippersCopyDialog : Window
    {
        public ShippersCopyDialog(поставщики copied)
        {
            InitializeComponent();

            код_поставкиTextBox.Text = copied.код_поставки;
            код_поставщикаTextBox.Text = copied.код_поставщика;
            наименованиеTextBox.Text = copied.наименование;
            адресTextBox.Text = copied.адрес;
            телефонTextBox.Text = copied.телефон;
            код_товараTextBox.Text = copied.код_товара;
            наименование_товараTextBox.Text = copied.наименование_товара;
            цена_за_еденицу_бел_рубTextBox.Text = Convert.ToString(copied.цена_за_еденицу_бел_руб);
            еденицы_измеренияTextBox.Text = copied.еденицы_измерения;
            срок_гарантииTextBox.Text = copied.срок_гарантии;
            кол_во_поставляемогоTextBox.Text = Convert.ToString(copied.кол_во_поставляемого);
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            поставщики newShipper = new поставщики();

            var shipper = App.Context.поставщики.FirstOrDefault(u => u.код_поставки == код_поставкиTextBox.Text);
            if (shipper != null)
            {
                MessageBox.Show($"Код \"{код_поставкиTextBox.Text}\" поставщика уже существует!");
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
    }
}
