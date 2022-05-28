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

namespace UNIQUMkidsWPF
{
    /// <summary>
    /// Логика взаимодействия для ParentSiqnUpPage.xaml
    /// </summary>
    public partial class ParentSiqnUpPage : Page
    {
        int idParent;
        public ParentSiqnUpPage(int parentId)
        {
            InitializeComponent();
            idParent = parentId;
        }

        private void MentalSiqnUp_btn_Click(object sender, RoutedEventArgs e)
        {
            Window window = new ParentSiqnUpForLessonWindow(1, idParent);
            window.Show();
        }

        private void speedReadingSiqnUp_btn_Click(object sender, RoutedEventArgs e)
        {
            Window window = new ParentSiqnUpForLessonWindow(2, idParent);
            window.Show();
        }

        private void readingSiqnUp_btn_Click(object sender, RoutedEventArgs e)
        {
            Window window = new ParentSiqnUpForLessonWindow(3, idParent);
            window.Show();
        }
    }
}
