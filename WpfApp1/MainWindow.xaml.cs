using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=myDatabase;Integrated Security=True");
            SqlCommand com = new SqlCommand();
            int i = 0;

            try
            {
                if ((UserTextBox.Text == string.Empty) || (PassTextBox1.Text == string.Empty))
                {
                    MessageBox.Show("Please enter a User Name and a Password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    UserTextBox.Focus();
                    return;
                }

                com = new SqlCommand("SELECT COUNT(*) FROM Table_1 WHERE UserName='" + UserTextBox.Text + "' AND Password='" + PassTextBox1.Text + "' AND Active='" + true + "'", con);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    i = (int)com.ExecuteScalar();
                }
                con.Close();

                if (i > 0)
                {
                    MessageBox.Show("Login Successfull", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Hide();
                }
                else
                    MessageBox.Show("Incorrect User Name or Password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                UserTextBox.Text = ""; PassTextBox1.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                i = 0;
                con.Close();
            }

            
        }
    }
}
