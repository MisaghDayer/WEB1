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
using DataModelLibrary;

namespace Sales.window
{
    /// <summary>
    /// Interaction logic for Win_AddUsers.xaml
    /// </summary>
    public partial class Win_AddUsers : Window
    {

        Archive_Db_newEntities database = new Archive_Db_newEntities();
        public Win_AddUsers()
        {
            InitializeComponent();
        }







        //////////          Event handlers

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
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
            CreateNewUser(CreateSQLCommand);
            ShowGridInfo(CreateSearchStatement);
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

            return searchstring;
        }



        private void CreateNewUser (Func<string> NameForCreateFunct)
        {
            //var query = database.Database.SqlQuery<Person>("Insert Into People " + NameForCreateFunct());
            database.Database.ExecuteSqlCommand("Insert Into People " + NameForCreateFunct());
            database.SaveChanges();
            
        }

        private string CreateSQLCommand()
        {
            int roleid = 1;
            string name = txt_name.Text.Trim();
            string family = txt_family.Text.Trim();
            string username = txt_username.Text.Trim();
            string password = txt_password.Password.Trim();
            int active = 1;
            string startdate = calender.Text.ToString();
            int gender;
            if (rdb_male.IsChecked==true)
            {
                gender = 1;
            } else
            {
                gender = 0;
            }

            string command = "(Role_ID, Name, Family, Username, Password, ACTIVE, UserStartDate, UserGender)";
            command += " Values('" + roleid +"', '" + name + "', '" + family + "', '" + username + "', '" + password + "', '" + active + "', '" + startdate + "', '" + gender + "')";
            return command;
        }
    }
}
