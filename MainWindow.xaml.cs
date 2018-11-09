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

namespace Projekt_120
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private List<User> userList;
        private bool isLoggedIn = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void loadMenu()
        {
                MainMenu menu = new MainMenu();
                MainMenu AddTaskUserControl = new MainMenu();
                DockPanel.SetDock(AddTaskUserControl, Dock.Top);
                SwitchContainer.Children.Clear();
                SwitchContainer.Children.Add(AddTaskUserControl);
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                userList = new List<User>();

                foreach (User user in MainWindow.ReadAll())
                {
                    //Console.WriteLine("CitizenID:" + user.BenutzerID + " / Name:" + user.Benutzername + " / Vorname:" + user.Passwort);
                    userList.Add(user);

                    if (isLoggedIn == false)
                    {
                        if (Username.Text == user.Benutzername && Password.Password == user.Passwort)
                        {
                            isLoggedIn = true;
                            Username.IsReadOnly = true;
                            UsernameError.Opacity = 0;
                            LoginSuccessful.Opacity = 100;
                            LoginSuccessful.Content = "Sie sind eingeloggt als " + user.Benutzername;
                            loadMenu();
                        }
                        else
                        {
                            UsernameError.Opacity = 100;
                            LoginSuccessful.Opacity = 0;
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Auslesen:" + ex.Message);
            }

            ReadAll();
            Console.WriteLine(userList);
        }

        public static List<User> ReadAll()
        {
            using (var db = new M120_ProjektEntities())
            {
                return (from rec in db.Users select rec).ToList();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        public static void setAvatar()
        {
            /*User user = new User();
            user.Avatar = MainMenu.newAvatarPath;
            Console.WriteLine(user.Avatar);*/
        }

        private void login_MouseEnter(object sender, MouseEventArgs e)
        {
            
        }
    }
}