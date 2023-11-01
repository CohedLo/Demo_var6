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

namespace Demo_var_6.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageEditNew.xaml
    /// </summary>
    public partial class PageEditNew : Page
    {
        public PageEditNew(Product product)
        {
            InitializeComponent();
            CmbxOwner.SelectedIndex = (int)product.ProductQuantityInStock - 1;
            CmbxOwner.SelectedValuePath = "Articul";
            CmbxOwner.DisplayMemberPath = "Name";
            CmbxOwner.ItemsSource = ConnectObj.conObj.Product.ToList();

            TxtArticul.Text = product.ProductArticleNumber;
            TxtTitle.Text = product.ProductName;
            TxtCost.Text = Convert.ToString(product.ProductCost);
            TxtMesur.Text = product.UnitOfMeasurement;
            TxtMaxDisc.Text = Convert.ToString(product.SizeMaxDiscount);
            TxtAmountDisc.Text = Convert.ToString(product.ProductDiscountAmount);
            TxtCategory.Text = product.ProductCategory;
            TxtProvider.Text = product.ProductProvider;
            TxtQuntStock.Text = Convert.ToString(product.ProductQuantityInStock);
            TxtDescription.Text = product.ProductDescription;
            TxtImage.Text = product.ProductPhoto;


        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                IEnumerable<Product> products = ConnectObj.conObj.Product.Where(x => x.ProductArticleNumber == ProductObj.Id).AsEnumerable().
                    Select(x =>
                    {
                        x.ProductArticleNumber = TxtTitle.Text;
                        x.ProductCost = Convert.ToDecimal(TxtCost.Text);

                        if (string.IsNullOrWhiteSpace(TxtDescription.Text))
                        {
                            x.ProductDescription = "";
                        }
                        else
                        {
                            x.ProductDescription = TxtDescription.Text;
                        }
                        if (string.IsNullOrWhiteSpace(TxtImage.Text))
                        {
                            x.ProductPhoto = "";
                        }
                        else
                        {
                            x.ProductPhoto = TxtImage.Text;
                        }
                        x.ProductManufacturer = (string)CmbxOwner.SelectedValue;

                        return x;
                    });
                foreach (Product prdct in products)
                {
                    ConnectObj.conObj.Entry(prdct).State = System.Data.Entity.EntityState.Modified;
                }
                ConnectObj.conObj.SaveChanges();
                MessageBox.Show("Данные успешно изменены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message.ToString());
            }
        }
    }
}
