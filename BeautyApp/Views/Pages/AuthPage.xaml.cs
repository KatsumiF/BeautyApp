using BeautyApp.Controllers;
using BeautyApp.Models;
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

namespace BeautyApp.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
            LoginTextBox.Focus();
            RegTextBlock.Focusable = true;//либо указываем в две строки, либо первая строка и в гл. окне Focusable="True"
        }

        /// <summary>
        /// Авторизация
        /// </summary>
        private void SignInButtonClick(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show("Переход в авторизацию");//вывод сообщения при нажатии
          Users result=UsersController.GetUser(LoginTextBox.Text, PasswordPasswordBox.Password);
            if (result != null)
            {
                App.CurrentUser = result;//сохранение информации о пользователе
                this.NavigationService.Navigate(new MainPage());
                }
                else
                {
                MessageBox.Show("Пользователь отсутствует");
            }
            
        }
        /// <summary>
        /// Переход на регистрацию
        /// </summary>
        private void RegTextBlockMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Переход на регистрацию");//вывод сообщения при нажатии
        }


        /// <summary>
        /// Обработка события нажатия на клавиатуру
        /// </summary>
        private void RegTextBlockKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) //при нажатии на кнопку Enter выполняется условие RegTextBlockMouseLeftButtonDown
            {
                RegTextBlockMouseLeftButtonDown(RegTextBlock, null);
            }
        }
    }
}
