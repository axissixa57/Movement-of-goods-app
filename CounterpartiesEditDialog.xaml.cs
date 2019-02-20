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
    public partial class CounterpartiesEditDialog : Window
    {
        private контрагенты editCounterparty; // поле для хранения редактируемого объекта
        // конструктор с параметром - тот объект контрагент, который будем редактировать
        string tempIdOfCounterparty;

        public CounterpartiesEditDialog(контрагенты edited)
        {
            InitializeComponent();
            this.editCounterparty = edited;
            this.код_контрагентаTextBox.Text = edited.код_контрагента;
            tempIdOfCounterparty = edited.код_контрагента;
            this.наименованиеTextBox.Text = edited.наименование;
            this.адресTextBox.Text = edited.адрес;
            this.телефонTextBox.Text = edited.телефон;
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            var сounterparty = App.Context.контрагенты.FirstOrDefault(u => u.код_контрагента == код_контрагентаTextBox.Text);
            if (сounterparty != null)
            {
                if(код_контрагентаTextBox.Text != tempIdOfCounterparty)
                    MessageBox.Show($"Код \"{код_контрагентаTextBox.Text}\" контрагента уже существует!");
                else
                {
                    this.editCounterparty.код_контрагента = код_контрагентаTextBox.Text;
                    this.editCounterparty.наименование = наименованиеTextBox.Text;
                    this.editCounterparty.адрес = адресTextBox.Text;
                    this.editCounterparty.телефон = телефонTextBox.Text;

                    this.DialogResult = true;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show($"\"Код контрагента\" нельзя изменять.");
            }
        }
    }
}
