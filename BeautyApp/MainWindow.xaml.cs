using BeautyApp.Views.Pages;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace BeautyApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainFrame.Navigate(new MainPage());


            //если нажата клавиша F1, то файл справки станет видимым
            KeyDown += (s, e) => {
                if (e.Key == Key.F1)
                {
                    string filename = $"{AppDomain.CurrentDomain.BaseDirectory}help.pdf";
                    if (File.Exists(filename)) //если файл не найден то ничего не делает
                    {
                        MainWebFrame.Visibility = Visibility.Visible;
                        MainWebFrame.Navigate(filename);
                        this.Title = "Руководство пользователя";
                        StatusTextBlock.Text = "Для выхода из справки нажмите ESC";
                    }
                }
                if (e.Key == Key.Escape) //если нажата esc то становиться невидимой
                {
                    MainWebFrame.Visibility = Visibility.Collapsed;
                    this.Title = "Салон красоты";
                    StatusTextBlock.Text = String.Empty;
                }
            };
        }

        /// <summary>
        /// кнопка для перехода на авторизацию
        /// </summary>
        private void LogInTextBlockMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new AuthPage());
            LogInTextBlock.Visibility = Visibility.Collapsed;
        }
        /// <summary>
        /// Изменение интерфейса при загрузке страницы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFrameNavigated(object sender, NavigationEventArgs e)
        {
            if (App.CurrentUser!=null)
            {
                PersonTextBlock.Text = $"Пользователь: { App.CurrentUser.UserLogin}";//отображение логина пользователя после авторизации
            }
        }
    }
}
