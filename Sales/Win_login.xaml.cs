using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace Sales
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Win_login : Window
    {
        public Win_login()
        {
            InitializeComponent();
        }

        //////////          Event handlers
        
        private void Btn_login_Click(object sender, RoutedEventArgs e)
        {
            PerformLogin();
        }

        public string ComputeHash(string input)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            Byte[] hashedBytes = System.Security.Cryptography.SHA256.Create().ComputeHash(inputBytes);

            return Convert.ToBase64String(hashedBytes);
        }

        private void Btn_exit_Click(object sender, RoutedEventArgs e)
        {

            UpdateRegistry("Login_Success", "0");
            System.Environment.Exit(0);

        }

        private void Rectangle_Loaded(object sender, RoutedEventArgs e)
        {

            //////////////// Registry Commands
            RegistryKey registry = Registry.CurrentUser.CreateSubKey("Software\\Sales");
            txt_username.Text = (string)registry.GetValue("UserNameRegister");
            txt_password.Focus(); //// When Window Starts, The curser is on Password TextBox

            //////////////// Date Commands
            SetDate();

        }

        private void Calender_SelectedDateChanged(object sender, RoutedEventArgs e)
        {
            SetDate();  
        }
        private void Txt_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                PerformLogin();
            }
            
        }



        //////////          My methods

        private void SetDate()
        {
            lbl_dayName.Content = calender.SelectedDate.PersianDayOfWeek;
            lbl_daynum.Content = calender.SelectedDate.Day;
            lbl_month.Content = calender.SelectedDate.MonthAsPersianMonth;
            lbl_year.Content = calender.SelectedDate.Year;
        }


        private void PerformLogin()
        {
            if (txt_username.Text == "admin" && txt_password.Password == "admin")
            {
                UpdateRegistry("UserNameRegister", txt_username.Text.Trim());
                UpdateRegistry("Login_Success", "1");
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
                txt_password.Password = "";
            }

        }

        private void UpdateRegistry(String registerName, String registerValue)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\Sales");
            
            try
            {
                key.SetValue(registerName, registerValue);
            }
            catch
            {
                MessageBox.Show("There was an error saving registry");
            }
            finally
            {
                key.Close();
            }
        }


    }
}
