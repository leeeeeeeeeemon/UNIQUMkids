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
using UNIQUMkidsCore;

namespace UNIQUMkidsWPF
{
    /// <summary>
    /// Логика взаимодействия для ParentSiqnUpForLessonWindow.xaml
    /// </summary>
    public partial class ParentSiqnUpForLessonWindow : Window
    {
        int idLesson;
        int idParent;
        Lesson lesson;
        public ParentSiqnUpForLessonWindow(int lessonId, int parentId)
        {
            InitializeComponent();
            idLesson = lessonId;
            idParent = parentId;
            lesson = GetDataFromDB.GetLesson().FirstOrDefault(p => p.id_Lesson == idLesson);
            lessonName_block.Text = lesson.Name;
            yeras_block.Text = Convert.ToString(lesson.MinYear);
            price_block.Text = Convert.ToString(lesson.Price);
            description_block.Text = lesson.Description;
        }

        private void siqnUp_btn_Click(object sender, RoutedEventArgs e)
        {
            Window window = new ParentConnectSiqnAndChildWindow(idLesson, idParent);
            window.Owner = this;
            window.Show();
        }
    }
}
