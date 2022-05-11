using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNIQUMkids.BD;
namespace UNIQUMkids.BD
{
    public class GetDataBD
    {
        public ObservableCollection<Child> GetChild()
        {
            return new ObservableCollection<Child>(bd_connection.connection.Child.ToList());
        }

        public ObservableCollection<Parent> GetParent()
        {
            return new ObservableCollection<Parent>(bd_connection.connection.Parent.ToList());
        }

        public ObservableCollection<Gender> GetGender()
        {
            return new ObservableCollection<Gender>(bd_connection.connection.Gender.ToList());
        }

        public ObservableCollection<Lesson> GetLesson()
        {
            return new ObservableCollection<Lesson>(bd_connection.connection.Lesson.ToList());
        }

        public ObservableCollection<LessonChild> GetLessonChild()
        {
            return new ObservableCollection<LessonChild>(bd_connection.connection.LessonChild.ToList());
        }

        public ObservableCollection<Raspisanie> GetRaspisanie()
        {
            return new ObservableCollection<Raspisanie>(bd_connection.connection.Raspisanie.ToList());
        }
    }
}
