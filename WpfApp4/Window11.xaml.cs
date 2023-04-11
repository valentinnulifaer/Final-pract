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
    public partial class Window11 : Window
    {
        SuppliersTableAdapter suppliers = new SuppliersTableAdapter();
        List<suppliersModel> models = new List<suppliersModel>();
        public Window11()
        {
            InitializeComponent();
            Autorization.ItemsSource = suppliers.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           var selected = (Autorization.SelectedItem as DataRowView);
            suppliersModel m = new suppliersModel();
            m.Services_of_suppliers = selected.Row[1].ToString();
            m.Price_of_services = (int)selected.Row[2];
            models.Add(m);

            Tovars.ItemsSource = null;
            Tovars.ItemsSource = models;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();
            this.Close();
        }
    }
}
