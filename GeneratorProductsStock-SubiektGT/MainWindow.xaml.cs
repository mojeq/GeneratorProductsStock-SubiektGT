using GeneratorProductsStock_SubiektGT.Models;
using GeneratorProductsStock_SubiektGT.Services;
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

namespace GeneratorProductsStock_SubiektGT
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
            try
            {
                var productsList = ProductService.GetAllProducts();

                ProductService.SaveProductsListAsJsonFile(productsList);
            }
            catch (Exception)
            {

                throw new Exception("Nie powiodło się generowanie pliku");
            }

            MessageBoxResult result = MessageBox.Show("Generowanie pliku powiodło się");
        }
    }
}
