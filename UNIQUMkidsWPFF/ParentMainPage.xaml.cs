using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UNIQUMkidsWPF
{
    /// <summary>
    /// Логика взаимодействия для ParentMainPage.xaml
    /// </summary>
    public partial class ParentMainPage : Page
    {
        int idParent;
        public ParentMainPage(int idparent)
        {
            InitializeComponent();
            idParent = idparent;
            tb_Description.Text = "ЛУЧШАЯ ШКОЛА РАЗВИТИЯ В КАЗАНИ!!!!" 
                + Environment.NewLine + "Региональный представитель ВСЕМИРНОЙ Ассоциации ПРОФЕССИОНАЛОВ в сфере МЕНТАЛЬНОЙ АРИФМЕТИКИ UAMAP"
                + Environment.NewLine + "Обучение по всем международным стандартам. (Сертификаты SAMA и PAMA GLOBAL - Крупнейшие организации мира по ментальной арифметике)"
                 + Environment.NewLine + "МЕЖДУНАРОДНЫЙ ЭКЗАМЕН на уровни владения абакусом для детей и педагогов"
                  + Environment.NewLine + "Работаем с ментальной арифметикой с начала ее появления в РФ"
                   + Environment.NewLine + "2 объединенные методики СКОРОЧТЕНИЯ"
                    + Environment.NewLine + "ЛУЧШИЕ проработанные, красочные материалы"
                     + Environment.NewLine + "Сертифицированные педагоги"
                      + Environment.NewLine + "Более 50 ПОСОБИЙ для развития интеллекта"
                       + Environment.NewLine + "+ ОНЛАЙН ФОРМАТ"
                        + Environment.NewLine + "Ежегодные ОЛИМПИАДЫ, ПРАЗДНИКИ, ЯРМАРКИ"
                         + Environment.NewLine + "ПОБЕДИТЕЛИ региональных и всероссийских олимпиад"
                          + Environment.NewLine + "МОТИВАЦИОННАЯ СИСТЕМА"
                           + Environment.NewLine + "1300+ СЧАСТЛИВЫХ УЧЕНИКОВ И ДОВОЛЬНЫХ РОДИТЕЛЕЙ"
                            + Environment.NewLine + "И более тысячи детей начали читать и считать в Uniqum Kids с любовью к постоянному развитию"
                             + Environment.NewLine + "Если мы Вас еще не убедили, приходите на бесплатное пробное занятие и у Вас не останется сомнений!"
                              + Environment.NewLine + "Тел.: 89-503-203-555"
                               + Environment.NewLine + "Мы научим Ваших детей:"
                                + Environment.NewLine + "1. Концентрации;"
                                 + Environment.NewLine + "2. Усидчивости;"
                                  + Environment.NewLine + "3. Смелости перед сложной информацией и ее большим объемом;"
                                   + Environment.NewLine + "4. Быстрому принятию решений;"
                                    + Environment.NewLine + "5. Невероятному запоминанию;"
                                     + Environment.NewLine + "6. Уверенности в себе!"
                                      + Environment.NewLine + "и многому другому!"
                                       + Environment.NewLine + "UniqumKids - с заботой о будущем Ваших детей"
                                        + Environment.NewLine + "Тел.: 89-503-203-555";
            
        }

        public void press()
        {

        }

        private void HamburgerMenuItem_Child(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ParentChildPage(idParent));
        }

        private void HamburgerMenuItem_Main(object sender, RoutedEventArgs e)
        {

        }

        private void HamburgerMenuItem_SiqnUp(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ParentSiqnUpPage(idParent));
        }
    }
}
