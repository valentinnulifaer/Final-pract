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
using WpfApp4.kiloDataSetTableAdapters;

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        Services_trueTableAdapter services = new Services_trueTableAdapter();
        ProductTableAdapter product = new ProductTableAdapter();
        public Window4()
        {
            InitializeComponent();
            Autorization.ItemsSource = services.GetData();
            IdCbx.ItemsSource = product.GetData();
            IdCbx.DisplayMemberPath = "Product_id";
            IdCbx.SelectedValuePath = "Product_id";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window2 win = new Window2();
            win.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window5 win = new Window5();
            win.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window3 win = new Window3();
            win.Show();
            this.Close();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                string test = NameTbx.Text;
                int Test = Convert.ToInt32(test);
                services.InsertQuery((int)IdCbx.SelectedValue, NameTcx.Text, Test);
                Autorization.ItemsSource = services.GetData();
            }
            catch
            {
                MessageBox.Show("Всё неправильно");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                object sel = (Autorization.SelectedItem as DataRowView).Row[0];
                product.DeleteQuery(Convert.ToInt32(sel));
                Autorization.ItemsSource = product.GetData();
            }
            catch
            {
                MessageBox.Show("Всё неправильно");
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                string test = NameTcx.Text;
                int Test = Convert.ToInt32(test);
                object sel = (Autorization.SelectedItem as DataRowView).Row[0];
                services.UpdateQuery((int)IdCbx.SelectedValue, NameTcx.Text, Test, Convert.ToInt32(sel));
                Autorization.ItemsSource = product.GetData();
            }
            catch
            {
                MessageBox.Show("Всё неправильно");
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();
            this.Close();
        }
    }
}
