using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNIQUMkidsCore
{
    public  class AddToBD
    {
        public void AddLessonChild(LessonChild lessonChild)
        {
            bd_connection.connection.LessonChild.Add(lessonChild);
            bd_connection.connection.SaveChanges();
        }

        public void AddParent(Parent parent)
        {
            bd_connection.connection.Parent.Add(parent);
            bd_connection.connection.SaveChanges();
        }

        public void AddParent(Child child)
        {
            bd_connection.connection.Child.Add(child);
            bd_connection.connection.SaveChanges();
        }

        public void AddTeacher(Teacher teacher)
        {
            bd_connection.connection.Teacher.Add(teacher);
            bd_connection.connection.SaveChanges();
        }
    }
}
