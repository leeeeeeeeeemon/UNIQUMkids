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
using UNIQUMkidsCore;
namespace UNIQUMkidsWPF
{
    /// <summary>
    /// Логика взаимодействия для ParentChildPage.xaml
    /// </summary>
    public partial class ParentChildPage : Page
    {
        int idParent;
        public ParentChildPage(int parentId)
        {
            idParent = parentId;
            InitializeComponent();
            this.DataContext = this;
            childList.ItemsSource = GetDataFromDB.GetChild().Where(p=> p.id_Parent == parentId);
        }
    }
}
