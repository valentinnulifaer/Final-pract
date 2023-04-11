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
    public partial class Window2 : Window
    {
        AccountTableAdapter account = new AccountTableAdapter();
        Rule_trueTableAdapter rule = new Rule_trueTableAdapter();
        public Window2()
        {
            InitializeComponent();
            Autorization.ItemsSource = account.GetData();
            IdCbx.ItemsSource = rule.GetData();
            IdCbx.DisplayMemberPath = "Name_true_Rule";
            IdCbx.SelectedValuePath = "Rule_true_id";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                account.InsertQuery((int)IdCbx.SelectedValue, LoginLol.Text, ParolLol.Text);
                Autorization.ItemsSource = account.GetData();
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

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();
            this.Close();
        }
    }
}
