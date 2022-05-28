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
    /// Логика взаимодействия для ParentAddOrRedactChildWindow.xaml
    /// </summary>
    public partial class ParentAddOrRedactChildWindow : Window
    {
        Child child;
        bool createNew = false;
        int idParent;
        ListView current;
        List<LessonChild> lessonChildren;
        public List<LessonChildToString> lessonChildToStringsList;
        public ParentAddOrRedactChildWindow(Child child1, ref ListView list)
        {
            InitializeComponent();
            this.child = child1;
            tb_Name.Text = child1.Name;
            tb_Surname.Text = child1.Surname;
            tb_year.Text = Convert.ToString(child1.Year);
            current = list;
            lessonChildren = GetDataFromDB.GetLessonChild().Where(p => p.id_Child == child1.id_Child).ToList();

            lessonChildToStringsList = new List<LessonChildToString>();
            foreach (LessonChild lessonChild in lessonChildren)
            {
                LessonChildToString lessonChildToString = new LessonChildToString();
                lessonChildToString.nameLesson = MainFunc.nameLessoOnId((int)lessonChild.id_Lesson);
                lessonChildToString.raspisaneLesson = MainFunc.nameRaspOnId((int)lessonChild.id_Raspisanie);
                if(lessonChild.id_Teacher != null)
                {
                    lessonChildToString.fioTeacherLesson = MainFunc.nameTeacherOnId((int)lessonChild.id_Teacher);
                }
                lessonChildToStringsList.Add(lessonChildToString);
            }
            lessonChild_list.ItemsSource = lessonChildToStringsList;
            
        }
        public ParentAddOrRedactChildWindow(int parentId, ref ListView list)
        {
            InitializeComponent();
            createNew = true;
            idParent = parentId;
            current = list;
        }

        private void addChild_btn_Click(object sender, RoutedEventArgs e)
        {
            if (createNew)
            {
                if(tb_Name.Text != "" && tb_Surname.Text != "" && tb_year.Text != "")
                {
                    Child newChild = new Child();
                    newChild.Name = tb_Name.Text;
                    newChild.Surname = tb_Surname.Text;
                    newChild.Year = Convert.ToInt32(tb_year.Text);
                    newChild.id_Parent = idParent;
                    newChild.IsDeleted = false;
                    AddToBD.AddChild(newChild);
                    current.ItemsSource = GetDataFromDB.GetChild().Where(p => p.id_Parent == idParent);
                    Close();
                }
                else
                {
                    MessageBox.Show("Заполните все поля!");
                }
            }
            else
            {
                Child childToRedact = GetDataFromDB.GetChild().FirstOrDefault(p => p.id_Child == child.id_Child);
                    if (tb_Name.Text != "" && tb_Surname.Text != "" && tb_year.Text != "")
                    {
                        childToRedact.Name = tb_Name.Text;
                        childToRedact.Surname = tb_Surname.Text;
                        childToRedact.Year = Convert.ToInt32(tb_year.Text);
                        MainFunc.SaveChangeDB();
                        current.ItemsSource = GetDataFromDB.GetChild().Where(p => p.id_Parent == idParent);
                        Close();
                    }
                }
        }

        private void deleteChild_btn_Click(object sender, RoutedEventArgs e)
        {
            if (createNew)
            {
                Close();
            }
            else
            {
                child.IsDeleted = true;
                MainFunc.SaveChangeDB();
                current.ItemsSource = GetDataFromDB.GetChild().Where(p => p.id_Parent == idParent);
                Close();
            }
        }

        public class LessonChildToString
        {
            public string nameLesson { get; set; }
            public string raspisaneLesson { get; set; }
            public string fioTeacherLesson { get; set; }
        }

    }
}
