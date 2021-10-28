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
                if(MessageBox.Show("Вы уверены что хотите удалить?", "Удалить", MessageBoxButton.YesNo)== MessageBoxResult.Yes)
                {
                    BL.Delete.Deleted(Games.Games);
                    MessageBox.Show("Успешно удаленно");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
                if(MessageBox.Show("Вы уверены что хотитие сохранить?","Сохранить изменения", MessageBoxButton.YesNo)== MessageBoxResult.Yes)
                {
                    BL.AddAndChangeGame.ChangeGame(tbName.Text, tbPrice.Text, tbDescription.Text, tbImage.Text, cbSteam.SelectedItem, cbEpic.SelectedItem, cbUbisoft.SelectedItem, Games.Games);
                    MessageBox.Show("Успешно отредактировано");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            BL.WindowOpen.OpenNewWindow(this, new AllGameWindow());
        }
    }
}
