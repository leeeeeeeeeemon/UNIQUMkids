using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNIQUMkidsCore
{
    public class DeleteFromBD
    {
        public void deleteChild(int id)
        {
            Child obj = (Child)bd_connection.connection.Child.Where(a => a.id_Child == id);
            obj.IsDeleted = true; 
            bd_connection.connection.SaveChanges();
        }

        public void deleteLessonChild(int id)
        {
            LessonChild obj = (LessonChild)bd_connection.connection.Child.Where(a => a.id_Child == id);
            obj.IsDeleted = true;
            bd_connection.connection.SaveChanges();
        }

        public void deleteTeacher(int id)
        {
            Teacher obj = (Teacher)bd_connection.connection.Child.Where(a => a.id_Child == id);
            obj.IsDeleted = true;
            bd_connection.connection.SaveChanges();
        }
        public void deleteRaspisanie(int id)
        {
            Raspisanie obj = (Raspisanie)bd_connection.connection.Child.Where(a => a.id_Child == id);
            obj.IsDeleted = true;
            bd_connection.connection.SaveChanges();
        }
        public void deleteLesson(int id)
        {
            Lesson obj = (Lesson)bd_connection.connection.Child.Where(a => a.id_Child == id);
            obj.IsDeleted = true;
            bd_connection.connection.SaveChanges();
        }
    }
}
