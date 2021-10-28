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

            #region Валидация
            try
            {
                int q = Convert.ToInt32(tbPrice.Text);
            }
            catch
            {
                MessageBox.Show("Укажите цену в правильном формате");
                return;
            }

            if (tbName.Text == string.Empty)
            {
                MessageBox.Show("Введите имя");
                return;

            }
            if (tbPrice.Text == string.Empty)
            {
                MessageBox.Show("Введите цену");
                return;

            }
            if (tbDescription.Text == string.Empty)
            {
                MessageBox.Show("Введите описание");
                return;

            }

            if (cbSteam.SelectedIndex == -1)
            {
                MessageBox.Show("Укажите есть ли игра в стиме");
                return;

            }
            if (cbEpic.SelectedIndex == -1)
            {
                MessageBox.Show("Укажите есть ли игра в епик геймс");
                return;

            }
            if (cbUbisoft.SelectedIndex == -1)
            {
                MessageBox.Show("Укажите есть ли игра в юбисофте");
                return;
            }
            #endregion

            try
            {
                if (MessageBox.Show("Вы уверены что хотите добавить игру?", "Добавить", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    BL.AddAndChangeGame.AddGames(tbName.Text, tbPrice.Text, tbDescription.Text, tbImage.Text, cbSteam.SelectedItem, cbEpic.SelectedItem, cbUbisoft.SelectedItem);
                    MessageBox.Show("Успешно добавленно");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            BL.WindowOpen.OpenNewWindow(this, new MenuWindow());
        }
    }
}