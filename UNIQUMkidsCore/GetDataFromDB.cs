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
            return new List<Child>(bd_connection.connection.Child.ToList());
        }

        public static List<Parent> GetParent()
        {
            return new List<Parent>(bd_connection.connection.Parent.ToList());
        }

        public List<Gender> GetGender()
        {
            return new List<Gender>(bd_connection.connection.Gender.ToList());
        }

        public List<Lesson> GetLesson()
        {
            return new List<Lesson>(bd_connection.connection.Lesson.ToList());
        }

        public List<LessonChild> GetLessonChild()
        {
            return new List<LessonChild>(bd_connection.connection.LessonChild.ToList());
        }

        public List<Raspisanie> GetRaspisanie()
        {
            return new List<Raspisanie>(bd_connection.connection.Raspisanie.ToList());
        }
    }
}
