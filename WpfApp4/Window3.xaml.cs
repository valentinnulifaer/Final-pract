using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Principal;
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
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        ProductTableAdapter product = new ProductTableAdapter();
        SuppliersTableAdapter suppliers= new SuppliersTableAdapter();

        public Window3()
        {
            InitializeComponent();
            Autorization.ItemsSource = product.GetData();
            IdCbx.ItemsSource = suppliers.GetData();
            IdCbx.DisplayMemberPath = "Services_of_suppliers";
            IdCbx.SelectedValuePath = "Suppliers_id";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window2 win = new Window2();
            win.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window4 win = new Window4();
            win.Show();
            this.Close();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                string test = NameTcx.Text;
                int Test = Convert.ToInt32(test);
                product.InsertQuery(Test, (int)IdCbx.SelectedValue);
                Autorization.ItemsSource = product.GetData();
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
                product.UpdateQuery(Test, (int)IdCbx.SelectedValue, Convert.ToInt32(sel));
                Autorization.ItemsSource = product.GetData();
            }
            catch
            {
                MessageBox.Show("Всё неправильно");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window1 win = new Window1();
            win.Show();
            this.Close();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();
            this.Close();
        }
    }
}
