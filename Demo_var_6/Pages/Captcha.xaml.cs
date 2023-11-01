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

namespace Demo_var_6.Pages
{
    /// <summary>
    /// Логика взаимодействия для Captcha.xaml
    /// </summary>
    public partial class Captcha : Page
    {
        private string captchaText;
        public static bool Check_Captcha;
        public Captcha()
        {
            InitializeComponent();
            GenerateCaptcha(4);
        }

        private void Auto_Click(object sender, RoutedEventArgs e)
        {
            if (txtCaptcha.Text == captchaText)
            {
                Check_Captcha = true;
                //this.Close();
            }
            else
            {
                Check_Captcha = false;
                MessageBox.Show("Неверный текст с капчи!");
                GenerateCaptcha(4);
                txtCaptcha.Text = "";
            }
        }

        private void GenerateCaptcha(int digits)
        {
            // Generate a random string for the CAPTCHA text
            RandomNumberGenerator rng = new RNGCryptoServiceProvider();
            byte[] data = new byte[4];
            rng.GetBytes(data);
            int value = BitConverter.ToInt32(data, 0) % 10000;
            captchaText = value.ToString("D4");

            // Create an image of the CAPTCHA text
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("https://dummyimage.com/200x80/000/fff&text=" + captchaText);
            bitmap.EndInit();
            captchaImage.Source = bitmap;
        }
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            GenerateCaptcha(captchaText.Length);
            txtCaptcha.Text = "";
        }
    }
}
