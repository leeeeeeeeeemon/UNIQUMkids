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
    }
}
