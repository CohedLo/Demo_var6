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
using Demo_var_6.DataBase;
using Demo_var_6.Properties;

namespace Demo_var_6.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistPage.xaml
    /// </summary>
    public partial class RegistPage : Page
    {
        public RegistPage()
        {
            InitializeComponent();
        }
        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new AuthPage());
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void Btn_Reg_Click(object sender, RoutedEventArgs e)
        {
            string id = ID.Text.Trim();
            string fio = FIO.Text.Trim();
            string login = Label.Text.Trim();
            string pass = PassLabel.Password.Trim();
            string role = IDRole.Text.Trim();

            if (login.Length < 5)
            {
                Label.ToolTip = "Логин должен содержать более 5 символов!";
                Label.Background = Brushes.White;
            }
            else if (pass.Length < 5)
            {
                PassLabel.ToolTip = "Пароль должен содержать более 5 символов!";
                PassLabel.Background = Brushes.White;
            }
            else
            {
                Label.ToolTip = "";
                Label.Background = Brushes.Transparent;
                PassLabel.ToolTip = "";
                PassLabel.Background = Brushes.Transparent;

                try
                {
                    using (SqlConnection connection = new SqlConnection())
                    {
                        connection.Open();

                        SqlCommand command = new SqlCommand("INSERT INTO User (UserID, UserFIO, UserLogin, UserPassword, UserRole) VALUES (@id, @fio, @login, @password, @role)", connection);
                        command.Parameters.AddWithValue("@UserID", id);
                        command.Parameters.AddWithValue("@UserFIO", fio);
                        command.Parameters.AddWithValue("@UserLogin", login);
                        command.Parameters.AddWithValue("@UserPassword", pass);
                        command.Parameters.AddWithValue("@UserRole", role);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            MessageBox.Show("Ошибка добавления пользователя!");
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("An error occurred while adding the user. Error message: " + ex.Message);
                }
            }
        }


    }
}
