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
    /// Логика взаимодействия для AllGameWindow.xaml
    /// </summary>
    public partial class AllGameWindow : Window
    {
        List<BL.ViewGame> content = new List<BL.ViewGame>();
        public AllGameWindow()
        {
            InitializeComponent();
            lbContent.MouseDoubleClick += lbContent_DoubleClick;
            content = BL.GetGame.GetGames();
            lbContent.ItemsSource = content;
        }

        private void lbContent_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            var sours = e.OriginalSource as Border;
            if(sours == null)
            {
                return;
            }
            var game = sours.DataContext as BL.ViewGame;
            BL.WindowOpen.OpenNewWindow(this, new ChangeGameWindow(game));
        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            BL.WindowOpen.OpenNewWindow(this, new MenuWindow());
        }

        /// <summary>
        /// Поиск
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var s = content.Where(x => x.Games.Name.ToUpper().StartsWith
            (tbSearch.Text.ToUpper()) || x.Games.Description.ToUpper().StartsWith(tbSearch.Text.ToUpper())).ToList();
            if (s.Count < 1)
            {
                MessageBox.Show("Обьект не найден");
                tbSearch.Text = string.Empty;
                content = BL.GetGame.GetGames();
                lbContent.ItemsSource = content;
                return;
            }
            if (tbSearch.Text == string.Empty)
            {
                content = BL.GetGame.GetGames();
                lbContent.ItemsSource = content;
                return;
            }
            content = s;
            lbContent.ItemsSource = content;
        }
    }
}
