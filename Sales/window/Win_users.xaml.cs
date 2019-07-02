using System;
using System.Collections.Generic;
using System.Data;
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
using DataModelLibrary;
using Sales.window;

namespace Sales.window
{
    /// <summary>
    /// Interaction logic for Win_users.xaml
    /// </summary>
    public partial class Win_users : Window
    {

        Archive_Db_newEntities database = new Archive_Db_newEntities();
        public Win_users()
        {
            InitializeComponent();
        }







        //////////          Event handlers

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Search_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowGridInfo(CreateSearchStatement);
        }
        private void Rdb_active_Checked(object sender, RoutedEventArgs e)
        {
            ShowGridInfo(CreateSearchStatement);
        }

        private void Rdb_deactive_Checked(object sender, RoutedEventArgs e)
        {
            ShowGridInfo(CreateSearchStatement);
        }


        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
            this.Focus();
        }

        private void Rect_search_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Focus();
        }

        private void Rect_background_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Focus();
        }

        private void Rect_button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Focus();
        }

        private void Txt_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                ShowGridInfo(CreateSearchStatement);
            }
        }

        private void Btn_newuser_Click(object sender, RoutedEventArgs e)
        {
            Win_AddUsers win = new Win_AddUsers();
            this.Hide();
            win.ShowDialog();
            this.Show();
        }

        private void Btn_UserInfo_Click(object sender, RoutedEventArgs e)
        {
            
            Win_UserInfo win = new Win_UserInfo();
            object item = datagrid_user.SelectedItem;
            win.selectedUserID = Convert.ToInt32((datagrid_user.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
            

            this.Hide();
            win.ShowDialog();
            this.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //var query = from u in database.Vw_People select u;
            //var user = query.ToList();
            //datagrid_user.ItemsSource = user;

            ShowGridInfo(CreateSearchStatement);
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }






        //////////          My methods

        private void ShowGridInfo(Func<string> NameForSearchFunct)
        {
            var query = database.Database.SqlQuery<Vw_People>("Select * From Vw_People Where 1=1" + NameForSearchFunct());
            var u = query.ToList();
            datagrid_user.ItemsSource = u;
        }

        private string CreateSearchStatement()
        {
            string searchstring = "";
            if (rdb_active.IsChecked==true)
            {
                searchstring += " And ACTIVE = 1";
            }

            if (rdb_deactive.IsChecked==true)
            {
                searchstring += " And ACTIVE = 0";
            }

            if (!String.IsNullOrEmpty(txt_name.Text.Trim()))
            {
                searchstring += " And Name Like '%" + txt_name.Text.Trim() + "%'";
            }

            if(!String.IsNullOrEmpty(txt_family.Text.Trim()))
            {
                searchstring += " And Family Like '%" + txt_family.Text.Trim() + "%'";
            }
            return searchstring;
        }


    }
}
