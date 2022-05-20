// See https://aka.ms/new-console-template for more 
using System.Collections.ObjectModel;

using UNIQUMkidsCore;

Parent usr;
Teacher teach;
bool auth = false;
Console.ForegroundColor = ConsoleColor.Black;
Console.BackgroundColor = ConsoleColor.Yellow;
bool isParent = false;

Console.WriteLine("[+] Добро пожаловать в UNIQUMkids!");
while (!auth)
{
    Console.WriteLine("[+] Для авторизации введите /login, для регистрации /registration, для входа как сотрудник /loginEmp");
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
            isParent = true;
        }
        else
        {
            Console.WriteLine("[+] Логин или пароль не верный, попробуйте еще раз!");
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
                Console.WriteLine($"Приветсвуем Вас, {usr.Name}!");
                auth = true;
                break;
            }

        }
    }
    else if (answer == "/loginEmp")
    {
        Console.WriteLine("[+] Введите логин для авторизации: ");
        string loginUsr = Console.ReadLine();
        Console.WriteLine("[+] Введите пароль для авторизации: ");
        string passwUsr = Console.ReadLine();
        Console.WriteLine("[+] Загрузка...");
        teach = MainFunc.AuthorizationTeacher(loginUsr, passwUsr);
        if (teach != null)
        {
            Console.WriteLine($"Приветсвуем Вас, {teach.Name}");
            auth = true;
            MainMenu((int)teach.id_Role);
        }
        else
        {
            Console.WriteLine("[+] Логин или пароль не верный, попробуйте еще раз!");
        }
    }
    else
    {
        Console.WriteLine("Неизвестная команда!");
    }
}


void MainMenu(int idRole)
{
    bool exit = false;
    while (!exit)
    {
        Console.WriteLine("[+] Доступные команды: /addChild, /myChilds, /lessonInfo");
    }
}


