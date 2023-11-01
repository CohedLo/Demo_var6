using Demo_var_6.DataBase;
using Demo_var_6.Properties;
using System;
using System.Collections.Generic;
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

namespace Demo_var_6.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        Settings settings = new Settings();
        public AuthPage()
        {
            InitializeComponent();
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new RegistPage());
        }
        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BtnGuest_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new GuestPage());
        }
        private void Btn_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginLabel.Text.Trim();
            string password = PassLabel.Password.Trim();

            if (login.Length < 5)
            {
                LoginLabel.ToolTip = "Логин должен содержать более 5 символов!";
                LoginLabel.Background = Brushes.White;
            }
            else if (password.Length < 5)
            {
                PassLabel.ToolTip = "Пароль должен содержать более 5 символов!";
                PassLabel.Background = Brushes.White;
            }
            else
            {
                LoginLabel.ToolTip = "";
                LoginLabel.Background = Brushes.Transparent;
                PassLabel.ToolTip = "";
                PassLabel.Background = Brushes.Transparent;

                string connectionString = @"Data Source=AMG03;Initial Catalog=Trade;Integrated Security=True";

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        SqlCommand command = new SqlCommand("SELECT UserRole FROM Users WHERE UserLogin = @login AND UserPassword = @password", connection);
                        command.Parameters.AddWithValue("@login", login);                       
                        command.Parameters.AddWithValue("@password", password);

                        object userRole = command.ExecuteScalar();

                        if (userRole != null)
                        {
                            switch (userRole.ToString())
                            {
                                case "1":
                                    MessageBox.Show("Вы вошли как Модератор!");
                                    FrameObj.frameMain.Navigate(new GuestPage());
                                    break;
                                case "3":
                                    MessageBox.Show("Вы вошли как Администратор!");
                                    FrameObj.frameMain.Navigate(new PageMain());
                                    break;
                                default:
                                    MessageBox.Show("Вы вошли как клиент!");
                                    FrameObj.frameMain.Navigate(new GuestPage());
                                    break;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Не удалось найти пользователя.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка при попытке входа: " + ex.Message);
                }
            }
        }
       


    }
}
