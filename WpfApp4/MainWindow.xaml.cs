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
using WpfApp4.kiloDataSetTableAdapters;
namespace WpfApp4
{
    public partial class MainWindow : Window
    {
        AccountTableAdapter account = new AccountTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var allLogins = account.GetData().Rows;
            bool Cool = false;
            for (int i = 0; i < allLogins.Count; i++)
            {
                if (allLogins[i][2].ToString() == LoginTbx.Text &&
                        allLogins[i][3].ToString() == PasswordTbx.Password)
                {
                    int roleid = (int)allLogins[i][0];
                    switch (roleid)
                    {
                        case 1:
                            Window1 role = new Window1();
                            role.Show();
                            this.Close();
                            Cool = true;
                            break;
                        case 2:
                            Window11 second = new Window11();
                            second.Show();
                            this.Close();
                            Cool = true;
                            break;
                    }
                }
            }
            if (Cool == false)
            {
                MessageBox.Show("Вы не ввели значения логина или пароля");
            }
        }
    }
}
