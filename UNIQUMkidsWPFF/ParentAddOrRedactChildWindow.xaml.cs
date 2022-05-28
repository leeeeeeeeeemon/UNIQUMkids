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
using System.Windows.Shapes;
using UNIQUMkidsCore;

namespace UNIQUMkidsWPF
{
    /// <summary>
    /// Логика взаимодействия для ParentAddOrRedactChildWindow.xaml
    /// </summary>
    public partial class ParentAddOrRedactChildWindow : Window
    {
        Child child;
        bool createNew = false;
        int idParent;
        public ParentAddOrRedactChildWindow(Child child1)
        {
            InitializeComponent();
            this.child = child1;
            tb_Name.Text = child1.Name;
            tb_Surname.Text = child1.Surname;
            tb_year.Text = Convert.ToString(child1.Year);
        }
        public ParentAddOrRedactChildWindow(int parentId)
        {
            InitializeComponent();
            createNew = true;
            idParent = parentId;
        }

        private void addChild_btn_Click(object sender, RoutedEventArgs e)
        {
            if (createNew)
            {
                if(tb_Name.Text != "" && tb_Surname.Text != "" && tb_year.Text != "")
                {
                    Child newChild = new Child();
                    newChild.Name = tb_Name.Text;
                    newChild.Surname = tb_Surname.Text;
                    newChild.Year = Convert.ToInt32(tb_year.Text);
                    newChild.id_Parent = idParent;
                    newChild.IsDeleted = false;
                    AddToBD.AddChild(newChild);
                    Close();
                }
                else
                {
                    MessageBox.Show("Заполните все поля!");
                }
            }
            else
            {
                Child childToRedact = GetDataFromDB.GetChild().FirstOrDefault(p => p.id_Child == child.id_Child);
                    if (tb_Name.Text != "" && tb_Surname.Text != "" && tb_year.Text != "")
                    {
                        childToRedact.Name = tb_Name.Text;
                        childToRedact.Surname = tb_Surname.Text;
                        childToRedact.Year = Convert.ToInt32(tb_year.Text);
                        MainFunc.SaveChangeDB();
                        
                        Close();
                    }
                }
        }

        private void deleteChild_btn_Click(object sender, RoutedEventArgs e)
        {
            if (createNew)
            {
                Close();
            }
            else
            {
                child.IsDeleted = true;
                MainFunc.SaveChangeDB();
                Close();
            }
        }
    }
}
