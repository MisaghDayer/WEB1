using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Sales.window;
using Microsoft.Win32;

namespace Sales
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void APP_StartUp(object sender, StartupEventArgs args)
        {
            Win_login w_l = new Win_login();
            w_l.ShowDialog();

            RegistryKey loginkey = Registry.CurrentUser.CreateSubKey("Software\\Sales");

            String login_status = (String)loginkey.GetValue("Login_Success");

            if (login_status == "1")
            {
                Win_main w_m = new Win_main();
                w_m.ShowDialog();
            }

            this.Shutdown();
        }
    }
}
