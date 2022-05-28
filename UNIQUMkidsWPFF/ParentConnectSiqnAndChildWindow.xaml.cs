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
    /// Логика взаимодействия для ParentConnectSiqnAndChildWindow.xaml
    /// </summary>
    public partial class ParentConnectSiqnAndChildWindow : Window
    {
        int idParent;
        int idLesson;
        List<Child> children;
        LessonChild lessonChild;
        public ParentConnectSiqnAndChildWindow(int lessonid, int parentId)
        {
            InitializeComponent();
            idLesson = lessonid;
            idParent = parentId;
            children = MainFunc.childsOnParent(idParent);
            childsComboBox.ItemsSource = children;
            childsComboBox.DisplayMemberPath = "Name";

        }

        private void addSiqnUp_btn_Click(object sender, RoutedEventArgs e)
        {
            var comboItem = (Child)childsComboBox.SelectedValue;
            if (MainFunc.childOnLesson(children.FirstOrDefault(p => p.Name == comboItem.Name).id_Child, idLesson))
            {
                lessonChild = new LessonChild();
                Child child = children.FirstOrDefault(p => p.Name == comboItem.Name);
                lessonChild.id_Child = child.id_Child;
                lessonChild.IsDeleted = false;
                lessonChild.id_Lesson = idLesson;

                if(raspComboBox.SelectedIndex == 0)
                {
                    lessonChild.id_Raspisanie = 1;
                }
                else
                {
                    lessonChild.id_Raspisanie = 1;
                }
                AddToBD.AddLessonChild(lessonChild);
                MessageBox.Show("Заявка успешно создана, в скором времени с вами свяжутся");
            }
            else
            {
                MessageBox.Show("Ребенок уже записан на этот курс");
            }
            
            Close();


        }
    }


}
