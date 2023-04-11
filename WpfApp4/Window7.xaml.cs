using System;
using System.Collections;
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
using System.Xml.Linq;
using WpfApp4.kiloDataSetTableAdapters;

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для Window7.xaml
    /// </summary>
    public partial class Window7 : Window
    {
        ProceedsTableAdapter proceeds = new ProceedsTableAdapter();
        Check_listTableAdapter check = new Check_listTableAdapter();
        public Window7()
        {
            InitializeComponent();
            Autorization.ItemsSource = proceeds.GetData();
            ComN.ItemsSource = check.GetData();
            ComN.DisplayMemberPath = "Date";
            ComN.SelectedValuePath = "Check_list_id";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window2 win = new Window2();
            win.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window6 win = new Window6();
            win.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window8 win = new Window8();
            win.Show();
            this.Close();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                string test = NameTcx.Text;
                int Test = Convert.ToInt32(test);
                proceeds.InsertQuery((int)ComN.SelectedValue, Test);
                Autorization.ItemsSource = proceeds.GetData();
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
                proceeds.DeleteQuery(Convert.ToInt32(sel));
                Autorization.ItemsSource = proceeds.GetData();
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
                proceeds.UpdateQuery((int)ComN.SelectedValue, Test, Convert.ToInt32(sel));
                Autorization.ItemsSource = proceeds.GetData();
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
