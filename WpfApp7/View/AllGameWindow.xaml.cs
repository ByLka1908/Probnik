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
            ChangeGameWindow change = new ChangeGameWindow(game);
            change.Show();
            this.Close();
        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menu = new MenuWindow();
            menu.Show();
            this.Close();
        }
    }
}
