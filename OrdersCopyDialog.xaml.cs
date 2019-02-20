using System;
using System.Linq;
using System.Windows;

namespace SQL_WPF
{
    public partial class OrdersCopyDialog : Window
    {
        public OrdersCopyDialog(заказы copied)
        {
            InitializeComponent();

            ттнTextBox.Text = copied.ттн;
            код_заказаTextBox.Text = copied.код_заказа;
            дата_заказаDatePicker.Text = Convert.ToString(copied.дата_заказа);
            код_контрагентаTextBox.Text = copied.код_контрагента;
            наименование_контрагентаTextBox.Text = copied.наименование_контрагента;
            код_товараTextBox.Text = copied.код_товара;
            наименование_товараTextBox.Text = copied.наименование_товара;
            код_поставщикаTextBox.Text = copied.код_поставщика;
            наименование_поставщикаTextBox.Text = copied.наименование_поставщика;
            цена_за_еденицу_бел_рубTextBox.Text = Convert.ToString(copied.цена_за_еденицу_бел_руб);
            еденицы_измеренияTextBox.Text = copied.еденицы_измерения;
            срок_гарантииTextBox.Text = copied.срок_гарантии;
            количество_заказанногоTextBox.Text = Convert.ToString(copied.количество_заказанного);
            оплаченоCheckBox.IsChecked = copied.оплачено;
            вид_оплатыTextBox.Text = copied.вид_оплаты;
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            заказы newOrder = new заказы();

            var ttn = App.Context.заказы.FirstOrDefault(t => t.ттн == ттнTextBox.Text);
            var warehouse = App.Context.склад.FirstOrDefault(u => u.код_заказа == код_заказаTextBox.Text);
            var counterparty = App.Context.контрагенты.FirstOrDefault(u => u.код_контрагента == код_контрагентаTextBox.Text);

            if (ttn != null)
                MessageBox.Show($"Код \"{ттнTextBox.Text}\" ттн уже существует!");
            else if (warehouse == null && код_заказаTextBox.Text.Length > 0)
                MessageBox.Show($"Кода \"{код_заказаTextBox.Text}\" заказа не существует!");
            else if (counterparty == null && код_контрагентаTextBox.Text.Length > 0)
                MessageBox.Show($"Кода \"{код_контрагентаTextBox.Text}\" контрагента не существует!");
            else if (ттнTextBox.Text == string.Empty)
                MessageBox.Show($"Поле \"ттн\" не должно быть пустым!");
            else if (код_заказаTextBox.Text == string.Empty)
                MessageBox.Show($"Поле \"код заказа\" не должно быть пустым!");
            else if (код_контрагентаTextBox.Text == string.Empty)
                MessageBox.Show($"Поле \"код контрагента\" не должно быть пустым!");
            else if (цена_за_еденицу_бел_рубTextBox.Text == string.Empty)
                MessageBox.Show($"Поле \"цена бел. руб.\" не должно быть пустым!");
            else if (количество_заказанногоTextBox.Text == string.Empty)
                MessageBox.Show($"Поле \"количество заказанного\" не должно быть пустым!");
            else
            {
                newOrder.ттн = ттнTextBox.Text;
                newOrder.код_заказа = код_заказаTextBox.Text;

                if (дата_заказаDatePicker.Text.Length > 0)
                    newOrder.дата_заказа = Convert.ToDateTime(дата_заказаDatePicker.Text);
                else
                {
                    DateTime? myTime = null;
                    newOrder.дата_заказа = myTime;
                }

                newOrder.код_контрагента = код_контрагентаTextBox.Text;
                newOrder.наименование_контрагента = наименование_контрагентаTextBox.Text;
                newOrder.код_товара = код_товараTextBox.Text;
                newOrder.наименование_товара = наименование_товараTextBox.Text;
                newOrder.код_поставщика = код_поставщикаTextBox.Text;
                newOrder.наименование_поставщика = наименование_поставщикаTextBox.Text;
                newOrder.цена_за_еденицу_бел_руб = int.Parse(цена_за_еденицу_бел_рубTextBox.Text);
                newOrder.еденицы_измерения = еденицы_измеренияTextBox.Text;
                newOrder.срок_гарантии = срок_гарантииTextBox.Text;
                newOrder.количество_заказанного = double.Parse(количество_заказанногоTextBox.Text);
                newOrder.оплачено = оплаченоCheckBox.IsChecked;
                newOrder.вид_оплаты = вид_оплатыTextBox.Text;

                App.Context.заказы.Add(newOrder);
                App.Context.SaveChanges();
                this.DialogResult = true;
                this.Close();
            }
        }

        private void Button_Click_Warehouse(object sender, RoutedEventArgs e)
        {
            WarehouseWindow wh = new WarehouseWindow();
            wh.Show();
        }
    }
}
