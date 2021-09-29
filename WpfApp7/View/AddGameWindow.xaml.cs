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
using System.Windows.Shapes;

namespace WpfApp7.View
{
    /// <summary>
    /// Логика взаимодействия для AddGameWindow.xaml
    /// </summary>
    public partial class AddGameWindow : Window
    {
        public AddGameWindow()
        {
            InitializeComponent();
            this.Loaded += Window_Loaded;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbSteam.ItemsSource = BL.GetStore.GetSteam();
            cbEpic.ItemsSource = BL.GetStore.GetEpic();
            cbUbisoft.ItemsSource = BL.GetStore.GetUbisoft();
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BL.AddAndChangeGame.AddGames(tbName.Text, tbPrice.Text, tbDescription.Text, tbImage.Text, cbSteam.SelectedItem, cbEpic.SelectedItem, cbUbisoft.SelectedItem);
                MessageBox.Show("Complete");
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menu = new MenuWindow();
            menu.Show();
            this.Close();
        }
    }
}
