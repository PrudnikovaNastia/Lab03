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



namespace WpfApp1
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new UserViewModel(ShowResultView);
        }
       
        private void ShowResultView()
        {
            if (!(DataContext is UserViewModel data)) return;

            try { 
                 var user = new Person(data.name, data.surname, data.email, data.dateOfBirth);
                 string birth = user.IsBirthday ? "З днем народження))))" : "";


                if (user.dateOfBirth > DateTime.Now)
                {
                    MessageBox.Show("((Error((");
                }
                else
                {
                    MessageBox.Show(
                         $"{birth}\n" +
                         $"~~~~~~\n" +
                         $"Ім'я: {user.name}\n" +
                         $"~~~~~~\n" +
                         $"Прізвище: {user.surname}\n" +
                         $"~~~~~~\n" +
                         $"Email: {user.email}\n" +
                         $"~~~~~~\n" +
                         $"Дата дня народження: {user.dateOfBirth}\n" +
                         $"~~~~~~\n" +
                         $"Вік: {user.IsAdult}\n" +
                         $"~~~~~~\n" +
                         $"Знак зодіаку: {user.SunSign}\n" +
                         $"~~~~~~\n" +
                         $"Знак зодіаку за китайським календарем: {user.ChineseSign}\n" +
                         $"~~~~~~\n"
                         );
                }

                
           
           }
             catch (EmailError email)
            {
                MessageBox.Show(email.Message);
            }
            catch (DateError date)
            {
                MessageBox.Show(date.Message);
            }
        }
    }
}