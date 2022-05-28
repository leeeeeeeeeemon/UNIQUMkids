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
    /// Логика взаимодействия для EmpMainPage.xaml
    /// </summary>
    public partial class EmpMainPage : Page
    {
        int idRole;
        int idEmp;
        List<LessonChildToList> lessonChildToLists = new List<LessonChildToList>();
        List<Child> children = GetDataFromDB.GetChild();
        List<LessonChild> lessonsRequest;
        public EmpMainPage(int empId, int roleId)
        {
            InitializeComponent();
            idRole = roleId;
            idEmp = empId;
            this.DataContext = this;
            if(idRole == 1)
            {
                lessonsRequest = GetDataFromDB.GetLessonChild().Where(p => p.id_Teacher == idEmp).ToList();
            }
            else
            {
                lessonsRequest = GetDataFromDB.GetLessonChild();
            }
            
            foreach (LessonChild lessonChild in lessonsRequest)
            {
                LessonChildToList getLes = new LessonChildToList();
                getLes.NameChild = MainFunc.nameChildOnId((int)lessonChild.id_Child);
                getLes.NameLesson = MainFunc.nameLessoOnId((int)lessonChild.id_Lesson);
                getLes.NumberParent = MainFunc.getParentNumberOnChildID((int)lessonChild.id_Child);
                getLes.isConfirmed = (bool)lessonChild.IsConfirmed;
                lessonChildToLists.Add(getLes);
            }

            lessonChild_list.ItemsSource = lessonChildToLists;
            allChild_list.ItemsSource = children;

            if(idRole == 1)
            {
                lessonChild_list.IsEnabled = false;
                allChild_CheckBox.Visibility = Visibility.Hidden;
            }
        }

        public class LessonChildToList
        {
            public string NameLesson { get; set; }
            public string NameChild { get; set; }
            public string NumberParent { get; set; }
            public bool isConfirmed { get; set; }
        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(searchBox.Text != "")
            {
                List<LessonChildToList> toListsFilter = lessonChildToLists.Where( p => p.NameChild.Contains(searchBox.Text)).ToList();
                lessonChild_list.ItemsSource = toListsFilter;
                List<Child> toListChild = children.Where(p => p.Name.Contains(searchBox.Text)  || p.Surname.Contains(searchBox.Text)).ToList();
                allChild_list.ItemsSource = toListChild;
            }
        }

        private void allChild_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if(allChild_CheckBox.IsChecked == true)
            {
                allChild_list.Visibility = Visibility.Visible;
                lessonChild_list.Visibility=Visibility.Hidden;
            }
            else
            {
                allChild_list.Visibility = Visibility.Hidden;
                lessonChild_list.Visibility = Visibility.Visible;
            }
        }
    }
}
