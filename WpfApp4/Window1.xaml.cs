using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        SalonTableAdapter salon = new SalonTableAdapter();
        public Window1()
        {
            InitializeComponent();
            Autorization.ItemsSource = salon.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window2 win = new Window2();
            win.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window3 win = new Window3();
            win.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                salon.InsertQuery(NameTcx.Text, NameTdx.Text, NameTbx.Text);
                Autorization.ItemsSource = salon.GetData();
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
                    salon.DeleteQuery(Convert.ToInt32(sel));
                    Autorization.ItemsSource = salon.GetData();
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
                object sel = (Autorization.SelectedItem as DataRowView).Row[0];
                salon.UpdateQuery(NameTcx.Text, NameTdx.Text, NameTbx.Text, Convert.ToInt32(sel));
                Autorization.ItemsSource = salon.GetData();
            }
            catch
            {
                MessageBox.Show("Всё неправильно");
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();
            this.Close();
        }
    }
}
