using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNIQUMkidsCore
{
    public class GetDataFromDB
    {
        public static List<Child> GetChild()
        {
            return new List<Child>(bd_connection.connection.Child.ToList().Where(p => p.IsDeleted == false));
        }

        public static List<Parent> GetParent()
        {
            return new List<Parent>(bd_connection.connection.Parent.ToList().Where(p => p.IsDeleted == false));
        }

        public static List<Gender> GetGender()
        {
            return new List<Gender>(bd_connection.connection.Gender.ToList());
        }

        public static List<Teacher> GetTeacher()
        {
            return new List<Teacher>(bd_connection.connection.Teacher.ToList().Where(p => p.IsDeleted == false));
        }

        public static List<Lesson> GetLesson()
        {
            return new List<Lesson>(bd_connection.connection.Lesson.ToList().Where(p => p.IsDeleted == false));
        }

        public static List<LessonChild> GetLessonChild()
        {
            return new List<LessonChild>(bd_connection.connection.LessonChild.ToList().Where(p => p.IsDeleted == false));
        }

        public static List<Raspisanie> GetRaspisanie()
        {
            return new List<Raspisanie>(bd_connection.connection.Raspisanie.ToList());
        }
    }
}
