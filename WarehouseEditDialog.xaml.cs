using System;
using System.Linq;
using System.Windows;

namespace SQL_WPF
{

    public partial class WarehouseEditDialog : Window
    {
        private склад editWarehouse;
        string tempIdOfOrder;

        public WarehouseEditDialog(склад edited)
        {
            InitializeComponent();

            editWarehouse = edited;
            код_заказаTextBox.Text = edited.код_заказа;
            tempIdOfOrder = edited.код_заказа;
            код_поставкиTextBox.Text = edited.код_поставки;
            код_поставщикаTextBox.Text = edited.код_поставщика;
            наименование_поставщикаTextBox.Text = edited.наименование_поставщика;
            код_товараTextBox.Text = edited.код_товара;
            наименование_товараTextBox.Text = edited.наименование_товара;
            еденицы_измеренияTextBox.Text = edited.еденицы_измерения;
            цена_за_еденицу_бел_рубTextBox.Text = Convert.ToString(edited.цена_за_еденицу_бел_руб);
            срок_гарантииTextBox.Text = edited.срок_гарантии;
            дата_поступленияDatePicker.Text = Convert.ToString(edited.дата_поступления);
            количество_поступившегоTextBox.Text = Convert.ToString(edited.количество_поступившего);
            дата_выбытияDatePicker.Text = Convert.ToString(edited.дата_выбытия);
            количество_выбывшегоTextBox.Text = Convert.ToString(edited.количество_выбывшего);
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            var warehouse = App.Context.склад.FirstOrDefault(u => u.код_заказа == код_заказаTextBox.Text);
            var shipper = App.Context.поставщики.FirstOrDefault(u => u.код_поставки == код_поставкиTextBox.Text);

            if (warehouse != null) 
            {
                if (shipper == null && код_поставкиTextBox.Text.Length > 0)
                    MessageBox.Show($"Кода \"{код_поставкиTextBox.Text}\" поставки не существует!");
                else if (цена_за_еденицу_бел_рубTextBox.Text == string.Empty)
                    MessageBox.Show($"Поле \"цена бел. руб.\" не должно быть пустым!");
                else if (количество_поступившегоTextBox.Text == string.Empty)
                    MessageBox.Show($"Поле \"количество поступившего\" не должно быть пустым!");
                else if (количество_выбывшегоTextBox.Text == string.Empty)
                    MessageBox.Show($"Поле \"количество выбывшего\" не должно быть пустым!");
                else
                {
                    editWarehouse.код_заказа = код_заказаTextBox.Text;

                    if (код_поставкиTextBox.Text.Length > 0)
                        editWarehouse.код_поставки = код_поставкиTextBox.Text;
                    else
                        editWarehouse.код_поставки = null;

                    editWarehouse.код_поставщика = код_поставщикаTextBox.Text;
                    editWarehouse.наименование_поставщика = наименование_поставщикаTextBox.Text;
                    editWarehouse.код_товара = код_товараTextBox.Text;
                    editWarehouse.наименование_товара = наименование_товараTextBox.Text;
                    editWarehouse.еденицы_измерения = еденицы_измеренияTextBox.Text;
                    editWarehouse.цена_за_еденицу_бел_руб = int.Parse(цена_за_еденицу_бел_рубTextBox.Text);
                    editWarehouse.срок_гарантии = срок_гарантииTextBox.Text;


                    if (дата_поступленияDatePicker.Text.Length > 0)
                        editWarehouse.дата_поступления = Convert.ToDateTime(дата_поступленияDatePicker.Text);
                    else
                    {
                        DateTime? myTime = null;
                        editWarehouse.дата_поступления = myTime;
                    }

                    editWarehouse.количество_поступившего = double.Parse(количество_поступившегоTextBox.Text);

                    if (дата_выбытияDatePicker.Text.Length > 0)
                        editWarehouse.дата_выбытия = Convert.ToDateTime(дата_выбытияDatePicker.Text);
                    else
                    {
                        DateTime? myTime1 = null;
                        editWarehouse.дата_выбытия = myTime1;
                    }

                    editWarehouse.количество_выбывшего = double.Parse(количество_выбывшегоTextBox.Text);

                    this.DialogResult = true;
                    this.Close();
                }
            }
            else
                MessageBox.Show($"\"Код заказа\" нельзя изменять.");
        }

        private void Button_Click_Shippers(object sender, RoutedEventArgs e)
        {
            ShippersWindow shippers = new ShippersWindow();
            shippers.Show();
        }
    }
}
