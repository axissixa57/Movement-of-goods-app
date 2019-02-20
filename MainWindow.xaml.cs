using System.Windows;

namespace SQL_WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            СounterpartiesWindow сounterparties = new СounterpartiesWindow();
            сounterparties.Show();
        }

        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
