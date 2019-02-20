using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;


namespace SQL_WPF
{
    public partial class LoginScreen : Window
    {
        public List<User> Users { get; set; }

        public LoginScreen()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            var user = App.Context.Users.FirstOrDefault(u => u.Username == txtUsername.Text);
            if (user != null)
            {
                if (user.Password == txtPassword.Password)
                {
                    Menu menu = new Menu();
                    menu.Show();
                    this.Close();
                }
                else
                    MessageBox.Show("Неправильный пароль!");
            }
            else
                MessageBox.Show($"Пользователь с именем \"{txtUsername.Text}\" не найден!");
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            var user = App.Context.Users.FirstOrDefault(u => u.Username == txtUsername.Text);

            if (user != null)
                MessageBox.Show("Пользователь с таким именем уже зарегестрирован!");
            else
            {
                if(txtUsername.Text.Length > 0 && txtPassword.Password.Length > 0)
                {
                    User newUser = new User();
                    newUser.Id = App.Context.Users.ToList().Count + 1;
                    newUser.Username = txtUsername.Text;
                    newUser.Password = txtPassword.Password;

                    App.Context.Users.Add(newUser);
                    App.Context.SaveChanges();
                    MessageBox.Show("Спасибо за регистрацию!");
                }
                else
                    MessageBox.Show("Поля не должны быть пустыми!");
            }

            //var item = App.Context.Users.ToList();
            //Users = item;

            //User newUser = new User();
            //newUser.Id = Users.Count + 1;
            //newUser.Username = txtUsername.Text;
            //newUser.Password = txtPassword.Password;

            //for (int i = 0; i < Users.Count; i++)
            //{
            //    if (Users[i].Username == newUser.Username)
            //    {
            //        MessageBox.Show($"Пользователь {txtUsername.Text} уже зарегестрирован!");
            //        return;
            //    }
            //}

            //App.Context.Users.Add(newUser);
            //App.Context.SaveChanges();
            //MessageBox.Show("Спасибо за регистрацию!");
        }
    }
}
