// See https://aka.ms/new-console-template for more 
using System.Collections.ObjectModel;
using System.Linq;
using UNIQUMkidsCore;

Parent usr;
Teacher teach;
bool auth = false;
Console.ForegroundColor = ConsoleColor.Black;
Console.BackgroundColor = ConsoleColor.Yellow;

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
            MainMenu((int)usr.id_Role, usr.id_Parent);
        }
        else
        {
            Console.WriteLine("[!] Логин или пароль не верный, попробуйте еще раз!");
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
            int id_Role = 2;
            if (usrLogin != null && usrName != null && usrSurname != null && usrPassword != null)
            {
                correcInput = true;
                Console.WriteLine("[+] Загрузка...");
                Parent par = new Parent();
                par.Login = usrLogin;
                par.Password = usrPassword;
                par.Name = usrName;
                par.Surname = usrSurname;
                par.Number = usrNumber;
                par.id_Role = id_Role;
                if (MainFunc.CheckRegistrationLogin(par.Login))
                {
                    AddToBD.AddParent(par);
                    Console.WriteLine($"Приветсвуем Вас, {par.Name}!");
                    auth = true;
                    MainMenu((int)par.id_Role, par.id_Parent);
                    break;
                }
                else
                {
                    Console.WriteLine("[!] Пользователь с таким логином уже существует");
                }
                
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
            Console.WriteLine($"[+] Приветсвуем Вас, {teach.Name}");
            auth = true;
            MainMenu((int)teach.id_Role, teach.id_Teacher);
        }
        else
        {
            Console.WriteLine("[!] Логин или пароль не верный, попробуйте еще раз!");
        }
    }
    else
    {
        Console.WriteLine("[!] Неизвестная команда!");
    }
}


void MainMenu(int idRole, int idUser)
{
    bool exit = false;
    while (!exit)
    {
        if(idRole == 2)
        {
            Console.WriteLine("[+] Доступные команды: /addChild, /myChilds, /lessonInfo /siqnUpLesson" );
            string command = Console.ReadLine();
            if (command == "/addChild")
            {
                Child newChild = new Child();
                Console.WriteLine("[+] Введите имя ребенка: ");
                newChild.Name = Console.ReadLine();
                Console.WriteLine("[+] Введите фамилию ребенка: ");
                newChild.Surname = Console.ReadLine();
                Console.WriteLine("[+] Введите возраст ребенка: ");
                newChild.Year = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("[+] Введите пол ребенка ребенка (м/ж): ");
                if (Console.ReadLine() == "ж")
                {
                    newChild.id_Gender = 2;
                }
                else
                {
                    newChild.id_Gender = 1;
                }
                newChild.id_Parent = idUser;
                newChild.IsDeleted = false;
                AddToBD.AddChild(newChild);
                Console.WriteLine("[+] Ребёнок успешно добавлен!");
            }
            else if (command == "/myChilds")
            {
                List<Child> childs = MainFunc.childsOnParent(idUser);
                foreach (Child child in childs)
                {
                    Console.WriteLine("----------------------------");
                    Console.WriteLine($"[+] Имя: {child.Name}");
                    Console.WriteLine($"[+] Фамилия: {child.Surname}");
                    Console.WriteLine($"[+] Возраст: {child.Year}");
                    if(child.id_Gender == 1)
                    {
                        Console.WriteLine($"[+] Пол: Мужской");
                    }
                    else
                    {
                        Console.WriteLine($"[+] Пол: Женский");
                    }
                    
                }
                Console.WriteLine("");
            }
            else if(command == "/lessonInfo")
            {
                List<Lesson> lessons = GetDataFromDB.GetLesson();
                foreach (Lesson lesson in lessons)
                {
                    Console.WriteLine("----------------------------");
                    Console.WriteLine($"[+] Название: {lesson.Name}");
                    Console.WriteLine($"[+] Минимальное количество лет: {lesson.MinYear}");
                    Console.WriteLine($"[+] Максимальное количество лет: {lesson.MaxYear}");
                    Console.WriteLine($"[+] Преподаватель {MainFunc.nameTeacherOnLesson(lesson)}");
                    Console.WriteLine($"[+] Описание: {lesson.Description}");
                    Console.WriteLine($"[+] Стоимость: {lesson.Price}");
                }
                Console.WriteLine();
            }
            else if(command == "/siqnUpLesson")
            {
                LessonChild choiseLesson = new LessonChild();
                Console.WriteLine("[+] Введите номер курса");
                List<Lesson> lessons = GetDataFromDB.GetLesson();
                int count = 1;
                foreach (Lesson lesson in lessons)
                {
                    Console.WriteLine("----------------------------");
                    Console.WriteLine($"[+] {count}. {lesson.Name}");
                    count++;
                }
                int choise = Convert.ToInt32(Console.ReadLine());
                count = 1;
                foreach (Lesson lesson in lessons)
                {
                    if(choise == count)
                    {
                        choiseLesson.id_Lesson = lesson.id_Lesson;
                        choiseLesson.id_Teacher = lesson.id_Teacher;
                        Console.WriteLine("[+] Введите имя ребенка для записи");
                        string name = Console.ReadLine();
                        List<Child> child = MainFunc.childsOnParent(idUser);
                        foreach (Child child2 in child)
                        {
                            if(child2.Name == name)
                            {
                                choiseLesson.id_Child = child2.id_Child;
                            }
                        }

                        if(choiseLesson.id_Child != null)
                        {
                            //Закончить добавление записаь на курс, добавить расписание и учителей
                            Console.WriteLine("[+] Выберите вариант расписания (1, 2 и тд.)" );
                            List<Raspisanie> rasp = GetDataFromDB.GetRaspisanie();
                            int count2 = 1;
                            foreach( Raspisanie rasp2 in rasp)
                            {
                                Console.WriteLine("----------------------------");
                                Console.WriteLine($"{count2}. {rasp2.Days} , Время: {rasp2.Time}");
                                count2++;
                            }
                            int numberChoise = Convert.ToInt32(Console.ReadLine());
                            count2 = 1;
                            foreach (Raspisanie rasp2 in rasp)
                            {
                                if(numberChoise == count2)
                                {
                                    choiseLesson.id_Raspisanie = rasp2.id_Raspisanie;
                                }
                                count2++;
                            }
                            choiseLesson.IsDeleted = false;
                            AddToBD.AddLessonChild(choiseLesson);
                            Console.WriteLine("[+] Заявка успешно создана в скором времени с вами свяжутся!");
                        }
                    }
                    count++;
                }
            }

        }else if(idRole == 1)
        {
            Console.WriteLine("[+] Доступные команды: /myLessonRequest");
            string answer = Console.ReadLine();
            if(answer == "/myLessonRequest")
            {
                List<LessonChild> lessonChildren = GetDataFromDB.GetLessonChild().Where(p => p.id_Teacher == idUser).ToList();
                foreach( LessonChild lessonChild in lessonChildren)
                {
                    Console.WriteLine("----------------------------");
                    Console.WriteLine($"[+] Название предмета: {MainFunc.nameLessoOnId((int)lessonChild.id_Lesson)}");
                    Console.WriteLine($"[+] Имя ребенка: {MainFunc.nameChildOnId((int)lessonChild.id_Child)}");
                    Console.WriteLine($"[+] Телефон родителя: {MainFunc.getParentNumberOnChildID((int)lessonChild.id_Child)}");
                    Console.WriteLine($"[+] Расписание: {MainFunc.nameRaspOnId((int)lessonChild.id_Raspisanie)}");
                }
            }
        }
    }
}


