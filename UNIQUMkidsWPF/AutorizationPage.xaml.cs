﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace UNIQUMkidsWPF
{
    /// <summary>
    /// Логика взаимодействия для AutorizationPage.xaml
    /// </summary>
    public partial class AutorizationPage : Page
    {
        public AutorizationPage()
        {
            InitializeComponent();
            public static int pass_count = 0;
        public static ObservableCollection<User> users { get; set; }
        public AutorizationPage()
        {
            InitializeComponent();
            tb_login.Text = Properties.Settings.Default.Login;

            tb_password.Visibility = Visibility.Hidden;
            if (Properties.Settings.Default.Password < DateTime.Now)
            {
                tb_password.Visibility = Visibility.Visible;
            }
        }

        private void btn_reg_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new RegistrationPage());
        }

        private void btn_authorization_Click(object sender, RoutedEventArgs e)
        {
            //users = new ObservableCollection<User>(bd_connection.connection.User.ToList());
            //var usr = users.Where(a => a.Login == tb_login.Text && a.Password == tb_password.Password).FirstOrDefault();
            //if (usr != null)
            //{
            //    if (cb_save.IsChecked.GetValueOrDefault())
            //    {
            //        Properties.Settings.Default.Login = tb_login.Text;
            //        Properties.Settings.Default.Save();
            //    }
            //    else
            //    {
            //        Properties.Settings.Default.Login = null;
            //        Properties.Settings.Default.Save();
            //    }
            //    pass_count = 0;
            //    //NavigationService.Navigate(new ListPage(usr));
            //}
            //else
            //{



            //    if (pass_count == 3)
            //    {
            //        pass_count = 0;
            //        Properties.Settings.Default.Password = DateTime.Now.AddMinutes(1);
            //        Properties.Settings.Default.Save();
            //        tb_password.Visibility = Visibility.Hidden;
            //    }
            //    if (Properties.Settings.Default.Password > DateTime.Now)
            //    {
            //        MessageBox.Show($"Слишком много попыток ввода, вход заморожен осталось: {Properties.Settings.Default.Password - DateTime.Now}", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Неверный логин или пароль", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            //        pass_count++;
            //    }
            //}
        }
    }
}
