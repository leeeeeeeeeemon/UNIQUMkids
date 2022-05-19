// See https://aka.ms/new-console-template for more 
using System.Collections.ObjectModel;

using UNIQUMkidsCore;

Parent usr;
bool auth = false;

Console.WriteLine("[+] Добро пожаловать в UNIQUMkids!");
while (!auth)
{
    Console.WriteLine("[+] Для авторизации введите /login, для регистрации /registration");
    string answer = Console.ReadLine();
    if (answer == "/login")
    {
        Console.WriteLine("[+] Введите логин для авторизации: ");
        string loginUsr = Console.ReadLine();
        Console.WriteLine("[+] Введите пароль для авторизации: ");
        string passwUsr = Console.ReadLine();
        Console.WriteLine("[+] Загрузка...");
        usr = MainFunc.Authorization(loginUsr, passwUsr);
        if (usr != null)
        {
            Console.WriteLine($"Приветсвуем Вас, {usr.Name}");
            auth = true;
        }
    }
    else if (answer == "/registration")
    {
        bool correcInput = false;
        while (!correcInput)
        {
            Console.WriteLine("[+] Введите Ваше имя:");
            string usrName = Console.ReadLine();
            Console.WriteLine("[+] Введите Вашу фамилию:");
            string usrSurname = Console.ReadLine();
            Console.WriteLine("[+] Введите Ваш номер телефона :");
            string usrNumber = Console.ReadLine();
            Console.WriteLine("[+] Введите Ваш логин:");
            string usrLogin = Console.ReadLine();
            Console.WriteLine("[+] Введите Ваш пароль:");
            string usrPassword = Console.ReadLine();
            if (usrLogin != null && usrName != null && usrSurname != null && usrPassword != null)
            {
                correcInput = true;
                Console.WriteLine("[+] Загрузка...");
                usr = MainFunc.Registration(usrName, usrSurname, usrNumber, usrLogin, usrPassword);
                Console.WriteLine($"Приветсвуем Вас, {usr.Name}");
                auth = true;
            }
        }
    }
    else
    {
        Console.WriteLine("Неизвестная команда!");
    }
}