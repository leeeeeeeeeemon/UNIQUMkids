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
        public EmpMainPage(int empId, int roleId)
        {
            InitializeComponent();
            idRole = roleId;
            idEmp = empId;
            this.DataContext = this;
            List<LessonChildToList> lessonChildToLists = new List<LessonChildToList>();
            foreach (LessonChild lessonChild in GetDataFromDB.GetLessonChild().Where(p => p.id_Teacher == idEmp))
            {
                LessonChildToList getLes = new LessonChildToList();
                getLes.NameChild = MainFunc.nameChildOnId((int)lessonChild.id_Child);
                getLes.NameLesson = MainFunc.nameLessoOnId((int)lessonChild.id_Lesson);
                getLes.NumberParent = MainFunc.getParentNumberOnChildID((int)lessonChild.id_Child);
                getLes.isConfirmed = (bool)lessonChild.IsConfirmed;
                lessonChildToLists.Add(getLes);
            }

            lessonChild_list.ItemsSource = lessonChildToLists;

        }

        public class LessonChildToList
        {
            public string NameLesson { get; set; }
            public string NameChild { get; set; }
            public string NumberParent { get; set; }
            public bool isConfirmed { get; set; }
        }
    }
}
