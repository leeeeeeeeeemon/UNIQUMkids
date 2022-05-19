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

        public static Parent Registration(string Name, string Surname, string Number, string login, string password)
        {
            Parent usr = new Parent();
            usr.Login = login;
            usr.Password = password;
            usr.Name = Name;
            usr.Surname = Surname;
            usr.Number = Number;
            AddToBD.AddParent(usr);
            return usr;
        }
    }
}
