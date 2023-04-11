using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
    /// Логика взаимодействия для Window8.xaml
    /// </summary>
    public partial class Window8 : Window
    {
        Check_listTableAdapter check = new Check_listTableAdapter();
        SalonTableAdapter salon= new SalonTableAdapter();
        Services_trueTableAdapter services = new Services_trueTableAdapter();
        StaffTableAdapter staff= new StaffTableAdapter();
        public Window8()
        {
            InitializeComponent();
            Autorization.ItemsSource = check.GetData();
            ComN.ItemsSource = salon.GetData();
            ComN.DisplayMemberPath = "Address";
            ComN.SelectedValuePath = "Salon_id";
            CemN.ItemsSource = services.GetData();
            CemN.DisplayMemberPath = "Name_of_services";
            CemN.SelectedValuePath = "Services_true_id";
            CrmN.ItemsSource = staff.GetData();
            CrmN.DisplayMemberPath = "name";
            CrmN.SelectedValuePath = "Staff_id";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window2 win = new Window2();
            win.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window1 win = new Window1();
            win.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window7 win = new Window7();
            win.Show();
            this.Close();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                string test = NameTcx.Text;
                int Test = Convert.ToInt32(test);
                check.InsertQuery((int)ComN.SelectedValue, Test, (int)CemN.SelectedValue, (int)CrmN.SelectedValue);
                Autorization.ItemsSource = check.GetData();
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
                 check.DeleteQuery(Convert.ToInt32(sel));
                 Autorization.ItemsSource = check.GetData();
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
                check.UpdateQuery((int)ComN.SelectedValue, Test, (int)CemN.SelectedValue, (int)CrmN.SelectedValue, Convert.ToInt32(sel));
                Autorization.ItemsSource = check.GetData();
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
