using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для Window6.xaml
    /// </summary>
    public partial class Window6 : Window
    {
        StaffTableAdapter staff = new StaffTableAdapter();
        jobTableAdapter job= new jobTableAdapter();
        AccountTableAdapter account = new AccountTableAdapter();
        public Window6()
        {
            InitializeComponent();
            Autorization.ItemsSource = staff.GetData();
            NameJ.ItemsSource = job.GetData();
            NameJ.DisplayMemberPath = "Name_job";
            NameJ.SelectedValuePath = "job_id";
            NameE.ItemsSource = account.GetData();
            NameE.DisplayMemberPath = "User_login";
            NameE.SelectedValuePath = "Account_id";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window2 win = new Window2();
            win.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window7 win = new Window7();
            win.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window5 win = new Window5();
            win.Show();
            this.Close();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                if (NameTdx.Text == null)
                {
                    staff.InsertQuery((int)NameJ.SelectedValue, (int)NameE.SelectedValue, NameTcx.Text, NameTbx.Text, NameTdx.Text, NameTfx.Text);
                    Autorization.ItemsSource = staff.GetData();
                }
                else
                {
                    staff.InsertQuery((int)NameJ.SelectedValue, (int)NameE.SelectedValue, NameTcx.Text, NameTbx.Text, NameTdx.Text, NameTfx.Text);
                    Autorization.ItemsSource = staff.GetData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Всё неправильно: " + ex.Message);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                object sel = (Autorization.SelectedItem as DataRowView).Row[0];
                staff.DeleteQuery(Convert.ToInt32(sel));
                Autorization.ItemsSource = staff.GetData();
               
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
                staff.UpdateQuery((int)NameJ.SelectedValue, (int)NameE.SelectedValue, NameTcx.Text, NameTbx.Text, NameTdx.Text, NameTfx.Text, Convert.ToInt32(sel));
                Autorization.ItemsSource = staff.GetData();
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
