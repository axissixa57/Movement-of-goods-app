using System;
using System.Linq;
using System.Windows;

namespace SQL_WPF
{
    public partial class ShippersEditDialog : Window
    {
        private поставщики editShipper;
        string tempIdOfDelivery;

        public ShippersEditDialog(поставщики edited)
        {
            InitializeComponent();

            this.editShipper = edited;
            this.код_поставкиTextBox.Text = edited.код_поставки;
            tempIdOfDelivery = edited.код_поставки;
            this.код_поставщикаTextBox.Text = edited.код_поставщика;
            this.наименованиеTextBox.Text = edited.наименование;
            this.адресTextBox.Text = edited.адрес;
            this.телефонTextBox.Text = edited.телефон;
            this.код_товараTextBox.Text = edited.код_товара;
            this.наименование_товараTextBox.Text = edited.наименование_товара;
            this.цена_за_еденицу_бел_рубTextBox.Text = Convert.ToString(edited.цена_за_еденицу_бел_руб);
            this.еденицы_измеренияTextBox.Text = edited.еденицы_измерения;
            this.срок_гарантииTextBox.Text = edited.срок_гарантии;
            this.кол_во_поставляемогоTextBox.Text = Convert.ToString(edited.кол_во_поставляемого);
        }

        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            var shipper = App.Context.поставщики.FirstOrDefault(u => u.код_поставки == код_поставкиTextBox.Text);
            if (shipper != null)
            { 
                if (код_поставкиTextBox.Text != tempIdOfDelivery)
                    MessageBox.Show($"Код \"{код_поставкиTextBox.Text}\" поставки уже существует!");
                else if (цена_за_еденицу_бел_рубTextBox.Text == string.Empty)
                    MessageBox.Show($"Поле \"цена бел. руб.\" не должно быть пустым!");
                else if (кол_во_поставляемогоTextBox.Text == string.Empty)
                    MessageBox.Show($"Поле \"кол-во поставляемого\" не должно быть пустым!");
                else
                {
                    this.editShipper.код_поставки = код_поставкиTextBox.Text;
                    this.editShipper.код_поставщика = код_поставщикаTextBox.Text;
                    this.editShipper.наименование = наименованиеTextBox.Text;
                    this.editShipper.адрес = адресTextBox.Text;
                    this.editShipper.телефон = телефонTextBox.Text;
                    this.editShipper.код_товара = код_товараTextBox.Text;
                    this.editShipper.наименование_товара = наименование_товараTextBox.Text;
                    this.editShipper.цена_за_еденицу_бел_руб = int.Parse(цена_за_еденицу_бел_рубTextBox.Text);
                    this.editShipper.еденицы_измерения = еденицы_измеренияTextBox.Text;
                    this.editShipper.срок_гарантии = срок_гарантииTextBox.Text;
                    this.editShipper.кол_во_поставляемого = int.Parse(кол_во_поставляемогоTextBox.Text);

                    this.DialogResult = true;
                    this.Close();
                }
            }
            else
                MessageBox.Show($"\"Код поставки\" нельзя изменять.");
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
