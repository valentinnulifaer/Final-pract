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
    /// Логика взаимодействия для Window5.xaml
    /// </summary>
    public partial class Window5 : Window
    {
        Rule_trueTableAdapter rule = new Rule_trueTableAdapter();
        public Window5()
        {
            InitializeComponent();
            Autorization.ItemsSource = rule.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window2 win = new Window2();
            win.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window6 win = new Window6();
            win.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window4 win = new Window4();
            win.Show();
            this.Close();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Autorization.SelectedItem != null)
                {
                    rule.InsertQuery(NameTcx.Text);
                    Autorization.ItemsSource = rule.GetData();
                }
                else
                {
                    MessageBox.Show("Всё неправильно");
                }
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
                    rule.DeleteQuery(Convert.ToInt32(sel));
                    Autorization.ItemsSource = rule.GetData();
              
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
                rule.UpdateQuery(NameTcx.Text, Convert.ToInt32(sel));
                Autorization.ItemsSource = rule.GetData();
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
