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
    /// Логика взаимодействия для ChangeGameWindow.xaml
    /// </summary>
    public partial class ChangeGameWindow : Window
    {
        public ChangeGameWindow()
        {
            InitializeComponent();
        }
        public BL.ViewGame Games { get; set; }
        public ChangeGameWindow(BL.ViewGame game) : this()
        {

            Games = game;

            tbName.Text = Games.Games.Name;
            tbDescription.Text = Games.Games.Description;
            tbPrice.Text = Convert.ToString(Games.Games.Price);
            tbImage.Text = Games.Games.ImagePatch;

            cbSteam.ItemsSource = BL.GetStore.GetSteam();
            cbEpic.ItemsSource = BL.GetStore.GetEpic();
            cbUbisoft.ItemsSource = BL.GetStore.GetUbisoft();
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BL.Delete.Deleted(Games.Games);
                MessageBox.Show("Complete");
            }
            catch
            {
                throw new Exception("Error");
            }
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BL.AddAndChangeGame.ChangeGame(tbName.Text, tbPrice.Text, tbDescription.Text, tbImage.Text, cbSteam.SelectedItem, cbEpic.SelectedItem, cbUbisoft.SelectedItem, Games.Games);
                MessageBox.Show("Complete");
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            AllGameWindow all = new AllGameWindow();
            all.Show();
            this.Close();
        }
    }
}
