using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SQL_WPF
{
    public partial class App : Application
    {
        public static movement_of_goodsEntities Context;

        public void Application_Start(object sender, StartupEventArgs args)
        {
            Context = new movement_of_goodsEntities();
            LoginScreen ls = new LoginScreen();
            ls.Show();
        }
    }
}
