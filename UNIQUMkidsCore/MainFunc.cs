using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNIQUMkidsCore
{
    public class MainFunc
    {

        public static  Parent Authorization(string login, string password)
        {
            List<Parent> usr = GetDataFromDB.GetParent();
            Parent parent = usr.Where(a => a.Login == login && a.Password == password).FirstOrDefault();
            return parent;
        }

        public static void SaveChangeDB()
        {
            bd_connection.connection.SaveChanges();
        }

        public static string nameTeacherOnId(int id)
        {
            Teacher teacher = GetDataFromDB.GetTeacher().FirstOrDefault(p => p.id_Teacher == id);
            if(teacher == null)
            {
                return "";
            }
            else
            {
                return teacher.Surname + " " + teacher.Name;

            }
        }
        public static bool CheckRegistrationLogin(string login)
        {
            List<Parent> usr = GetDataFromDB.GetParent();
            Parent parent = usr.Where(a => a.Login == login).FirstOrDefault();
            List<Teacher> teach = GetDataFromDB.GetTeacher();
            Teacher teacher = teach.Where(a => a.Login == login).FirstOrDefault();
            if (parent == null && teach == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Teacher AuthorizationTeacher(string login, string password)
        {   
            List<Teacher> usr = GetDataFromDB.GetTeacher();
            Teacher teacher = usr.Where(a => a.Login == login && a.Password == password).FirstOrDefault();
            return teacher;
        }

        public static List<Child> childsOnParent(int id_Parent)
        {
            List<Child> childs = GetDataFromDB.GetChild();
            List<Child> currentChilds = childs.Where(p => p.id_Parent == id_Parent).ToList();
            return currentChilds;
        }

        public static string nameTeacherOnLesson(Lesson les)
        {
            List<Teacher> teach = GetDataFromDB.GetTeacher();
            Teacher currentTeach = teach.Where(p => p.id_Teacher == les.id_Teacher).FirstOrDefault();
            return currentTeach.Name + " " + currentTeach.Surname;
        }

        public static string nameLessoOnId(int id)
        {
            Lesson lessons = GetDataFromDB.GetLesson().Where(p => p.id_Lesson == id).FirstOrDefault();
            return lessons.Name;
        }

        public static bool childOnLesson(int idChild, int idLesson)
        {
            LessonChild lesChild = GetDataFromDB.GetLessonChild().FirstOrDefault(p => p.id_Child == idChild && p.id_Lesson == idLesson);
            if(lesChild != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static string nameChildOnId(int id)
        {
            Child child = GetDataFromDB.GetChild().Where(p => p.id_Child == id).FirstOrDefault();
            return child.Surname + " " + child.Name;
        }
        public static string nameRaspOnId(int id)
        {
            Raspisanie raspisanie = GetDataFromDB.GetRaspisanie().Where(p => p.id_Raspisanie == id).FirstOrDefault();
            return raspisanie.Days + " " + raspisanie.Time;
        }

        public static string getParentNumberOnChildID(int id)
        {
            Child child = GetDataFromDB.GetChild().Where(p => p.id_Child == id).FirstOrDefault();
            Parent parent = GetDataFromDB.GetParent().Where(p => p.id_Parent == child.id_Parent).FirstOrDefault();
            return parent.Number;
        }
    }
}
