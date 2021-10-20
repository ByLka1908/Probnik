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
using WpfApp7.BL;

namespace WpfApp7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void btGo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BL.Auntificator.Auntification(tbLogin.Text, tbPassword.Text);
                WindowOpen.OpenNewWindow(this, new View.MenuWindow());
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void btExist_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
