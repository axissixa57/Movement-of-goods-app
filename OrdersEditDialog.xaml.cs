using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SQL_WPF
{
    public partial class OrdersEditDialog : Window
    {
        private заказы editOrder;
        string tempIdOfTTN;

        public OrdersEditDialog(заказы edited)
        {
            InitializeComponent();

            editOrder = edited;
            ттнTextBox.Text = edited.ттн;
            tempIdOfTTN = edited.ттн;
            код_заказаTextBox.Text = edited.код_заказа;
            дата_заказаDatePicker.Text = Convert.ToString(edited.дата_заказа);
            код_контрагентаTextBox.Text = edited.код_контрагента;
            наименование_контрагентаTextBox.Text = edited.наименование_контрагента;
            код_товараTextBox.Text = edited.код_товара;
            наименование_товараTextBox.Text = edited.наименование_товара;
            код_поставщикаTextBox.Text = edited.код_поставщика;
            наименование_поставщикаTextBox.Text = edited.наименование_поставщика;
            цена_за_еденицу_бел_рубTextBox.Text = Convert.ToString(edited.цена_за_еденицу_бел_руб);
            еденицы_измеренияTextBox.Text = edited.еденицы_измерения;
            срок_гарантииTextBox.Text = edited.срок_гарантии;
            количество_заказанногоTextBox.Text = Convert.ToString(edited.количество_заказанного);
            оплаченоCheckBox.IsChecked = edited.оплачено;
            вид_оплатыTextBox.Text = edited.вид_оплаты;
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            var ttn = App.Context.заказы.FirstOrDefault(t => t.ттн == ттнTextBox.Text);
            var warehouse = App.Context.склад.FirstOrDefault(u => u.код_заказа == код_заказаTextBox.Text);
            var counterparty = App.Context.контрагенты.FirstOrDefault(u => u.код_контрагента == код_контрагентаTextBox.Text);

            if (ttn != null)
            {
                if (warehouse == null && код_заказаTextBox.Text.Length > 0)
                    MessageBox.Show($"Кода \"{код_заказаTextBox.Text}\" заказа не существует!");
                else if (counterparty == null && код_контрагентаTextBox.Text.Length > 0)
                    MessageBox.Show($"Кода \"{код_контрагентаTextBox.Text}\" контрагента не существует!");
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
                    editOrder.ттн = ттнTextBox.Text;
                    editOrder.код_заказа = код_заказаTextBox.Text;

                    if (дата_заказаDatePicker.Text.Length > 0)
                        editOrder.дата_заказа = Convert.ToDateTime(дата_заказаDatePicker.Text);
                    else
                    {
                        DateTime? myTime = null;
                        editOrder.дата_заказа = myTime;
                    }

                    editOrder.код_контрагента = код_контрагентаTextBox.Text;
                    editOrder.наименование_контрагента = наименование_контрагентаTextBox.Text;
                    editOrder.код_товара = код_товараTextBox.Text;
                    editOrder.наименование_товара = наименование_товараTextBox.Text;
                    editOrder.код_поставщика = код_поставщикаTextBox.Text;
                    editOrder.наименование_поставщика = наименование_поставщикаTextBox.Text;
                    editOrder.цена_за_еденицу_бел_руб = int.Parse(цена_за_еденицу_бел_рубTextBox.Text);
                    editOrder.еденицы_измерения = еденицы_измеренияTextBox.Text;
                    editOrder.срок_гарантии = срок_гарантииTextBox.Text;
                    editOrder.количество_заказанного = double.Parse(количество_заказанногоTextBox.Text);
                    editOrder.оплачено = оплаченоCheckBox.IsChecked;
                    editOrder.вид_оплаты = вид_оплатыTextBox.Text;

                    this.DialogResult = true;
                    this.Close();
                }
            }
            else
                MessageBox.Show($"\"ттн\" нельзя изменять.");
        }
    }
}
