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

namespace Sales.window
{
    /// <summary>
    /// Interaction logic for Win_main.xaml
    /// </summary>
    public partial class Win_main : Window
    {
        public Win_main()
        {
            InitializeComponent();
        }


        public void Btn_Exit_Click(Object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        public void Btn_ShowUser_Click(Object sender, RoutedEventArgs e)
        {
            Win_users win_Users = new Win_users();
            win_Users.ShowDialog();
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetWinowSize();
        }

        private void SetWinowSize()
        {
            this.MaxHeight = 810;
            this.MinHeight = 810;

            this.MaxWidth = 1200;
            this.MinWidth = 1200;
        }

        private void Btn_ShowCustomer_Click(object sender, RoutedEventArgs e)
        {
            Win_customers win_Customers = new Win_customers();
            win_Customers.ShowDialog();
        }
    }
}
