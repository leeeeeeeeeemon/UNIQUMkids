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
using UNIQUMkidsCore;

namespace UNIQUMkidsWPF
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        List<Parent> parents;
        List<Teacher> teachers;
        public RegistrationPage()
        {
            InitializeComponent();
        }
        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btn_Ok_Click(object sender, RoutedEventArgs e)
        {
            if (CorrectPass())
            {
                int role = 2;
                var new_user = new Parent();

                new_user.Login = tb_login.Text;
                new_user.Surname = tb_Surname.Text;
                new_user.Name = tb_Name.Text;
                new_user.Password = tb_password.Text;
                new_user.id_Role = role;

                if (cb_gender.Text == "Мужской")
                {
                    new_user.id_Role = 1;
                }
                else if (cb_gender.Text == "Женский")
                {
                    new_user.id_Role = 2;
                }

                new_user.Number = tb_phone.Text;

                AddToBD.AddParent(new_user);
                MessageBox.Show("All OK");
                NavigationService.GoBack();
            }
        }

        public bool CorrectPass()
        {
            parents = GetDataFromDB.GetParent();
            teachers = GetDataFromDB.GetTeacher();
            bool login_unic = true;
            foreach (var i in parents)
            {
                if (i.Login == tb_login.Text)
                {
                    login_unic = false;
                }
            }
            foreach (var i in teachers)
            {
                if (i.Login == tb_login.Text)
                {
                    login_unic = false;
                }
            }

            if (login_unic)
            {
                string pas = tb_password.Text;
                bool buk = false;
                bool cif = false;
                bool spec = false;
                foreach (var i in pas)
                {
                    if (Char.IsLetter(i))
                    {
                        buk = true;
                    }
                }

                foreach (var i in pas)
                {
                    if (Char.IsNumber(i))
                    {
                        cif = true;
                    }
                }

                foreach (var i in pas)
                {
                    if (i == '!' || i == '@' || i == '#' || i == '$' || i == '%' || i == '^')
                    {
                        spec = true;
                    }
                }

                if (pas.Length > 6 && buk && cif && spec)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Пароль должен содержать буквы, цифры и спец.символы");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Такой логин уже существует, придумайте новый");
                return false;
            }
        }

        private void tb_phone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
