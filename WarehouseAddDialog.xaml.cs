using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace SQL_WPF
{
    public partial class WarehouseAddDialog : Window
    {
        public List<поставщики> Shippers { get; set; }

        public WarehouseAddDialog()
        {
            InitializeComponent();
            bindcombo();
        }

        private void bindcombo()
        {
            var item = App.Context.поставщики.ToList();

            Shippers = item;

            for (int i = 0; i < Shippers.Count; i++)
            {
                for (int j = i + 1; j < Shippers.Count; j++)
                {
                    if (Shippers[i].наименование == Shippers[j].наименование)
                        Shippers.Remove(Shippers[j]);
                }
            } 

            DataContext = Shippers;
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            склад newWarehouse = new склад();

            var warehouse = App.Context.склад.FirstOrDefault(u => u.код_заказа == код_заказаTextBox.Text);
            var shipper = App.Context.поставщики.FirstOrDefault(u => u.код_поставки == код_поставкиTextBox.Text);

            if (warehouse != null)
                MessageBox.Show($"Код \"{код_заказаTextBox.Text}\" заказа уже существует!");
            else if (код_заказаTextBox.Text == string.Empty)
                MessageBox.Show($"Поле \"код заказа\" не должно быть пустым!");
            else if (shipper == null && код_поставкиTextBox.Text.Length > 0)
                MessageBox.Show($"Кода \"{код_поставкиTextBox.Text}\" поставки не существует!");
            else if (цена_за_еденицу_бел_рубTextBox.Text == string.Empty)
                MessageBox.Show($"Поле \"цена бел. руб.\" не должно быть пустым!");
            else if (количество_поступившегоTextBox.Text == string.Empty)
                MessageBox.Show($"Поле \"количество поступившего\" не должно быть пустым!");
            else if (количество_выбывшегоTextBox.Text == string.Empty)
                MessageBox.Show($"Поле \"количество выбывшего\" не должно быть пустым!");
            else
            {
                newWarehouse.код_заказа = код_заказаTextBox.Text;

                if (код_поставкиTextBox.Text.Length > 0)
                    newWarehouse.код_поставки = код_поставкиTextBox.Text;
                else
                    newWarehouse.код_поставки = null;

                newWarehouse.код_поставщика = код_поставщикаComboBox.Text;
                newWarehouse.наименование_поставщика = наименование_поставщикаComboBox.Text;
                newWarehouse.код_товара = код_товараComboBox.Text;
                newWarehouse.наименование_товара = наименование_товараComboBox.Text;
                newWarehouse.цена_за_еденицу_бел_руб = int.Parse(цена_за_еденицу_бел_рубTextBox.Text); // при заполнении необходимо указывать значение, при пустой строке - зависнет
                newWarehouse.еденицы_измерения = еденицы_измеренияTextBox.Text;
                newWarehouse.срок_гарантии = срок_гарантииTextBox.Text;

                if (дата_поступленияDatePicker.Text.Length > 0)
                    newWarehouse.дата_поступления = Convert.ToDateTime(дата_поступленияDatePicker.Text);
                else
                {
                    DateTime? myTime = null;
                    newWarehouse.дата_поступления = myTime;
                }

                newWarehouse.количество_поступившего = double.Parse(количество_поступившегоTextBox.Text); // тоже замое, не должно быть пустым

                if (дата_выбытияDatePicker.Text.Length > 0)
                    newWarehouse.дата_выбытия = Convert.ToDateTime(дата_выбытияDatePicker.Text);
                else
                {
                    DateTime? myTime1 = null;
                    newWarehouse.дата_выбытия = myTime1;
                }

                newWarehouse.количество_выбывшего = double.Parse(количество_выбывшегоTextBox.Text); // тоже замое, не должно быть пустым

                App.Context.склад.Add(newWarehouse);
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

        private void Button_Click_Shippers(object sender, RoutedEventArgs e)
        {
            ShippersWindow shippers = new ShippersWindow();
            shippers.Show();
        }
    }
}
