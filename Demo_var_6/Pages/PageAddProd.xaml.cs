using Demo_var_6.DataBase;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;

namespace Demo_var_6.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAddProd.xaml
    /// </summary>
    public partial class PageAddProd : Page
    {
        public PageAddProd()
        {
            InitializeComponent();
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = new Product() {
                    ProductArticleNumber = TxtArticul.Text,
                    ProductName = TxtTitle.Text,
                    UnitOfMeasurement = TxtMesur.Text,
                    ProductCost = Convert.ToDecimal(TxtCost.Text),
                    SizeMaxDiscount = Convert.ToByte(TxtMaxDisc.Text),
                    ProductProvider = TxtProvider.Text,
                    ProductCategory = TxtCategory.Text,
                    ProductDiscountAmount = Convert.ToByte(TxtAmountDisc.Text),
                    ProductQuantityInStock = Convert.ToInt32(TxtQuntStock.Text),
                    ProductDescription = TxtDescription.Text,
                    ProductPhoto = TxtImage.Text,
                    ProductManufacturer = TxtManufact.Text
                };
                ConnectObj.conObj.Product.Add(product);
                ConnectObj.conObj.SaveChanges();
                MessageBox.Show("Данные успешно добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message.ToString());
            }
        }
    }
}
