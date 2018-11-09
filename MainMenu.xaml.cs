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
    /// Interaktionslogik für MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        public static string newAvatarPath;
        public MainMenu()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddUser user = new AddUser();
            AddUser AddTaskUserControl = new AddUser();
            DockPanel.SetDock(AddTaskUserControl, Dock.Top);
            SwitchContainer.Children.Clear();
            SwitchContainer.Children.Add(AddTaskUserControl);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DeleteUser del = new DeleteUser();
            DeleteUser AddTaskUserControl = new DeleteUser();
            DockPanel.SetDock(AddTaskUserControl, Dock.Top);
            SwitchContainer.Children.Clear();
            SwitchContainer.Children.Add(AddTaskUserControl);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AddBuilding building = new AddBuilding();
            AddBuilding AddTaskUserControl = new AddBuilding();
            DockPanel.SetDock(AddTaskUserControl, Dock.Top);
            SwitchContainer.Children.Clear();
            SwitchContainer.Children.Add(AddTaskUserControl);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            DeleteBuilding delBuilding = new DeleteBuilding();
            DeleteBuilding AddTaskUserControl = new DeleteBuilding();
            DockPanel.SetDock(AddTaskUserControl, Dock.Top);
            SwitchContainer.Children.Clear();
            SwitchContainer.Children.Add(AddTaskUserControl);
        }

        private void TabItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void TabItem_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void TabItem_MouseUp(object sender, MouseButtonEventArgs e)
        {
            AddUser user = new AddUser();
            AddUser AddTaskUserControl = new AddUser();
            DockPanel.SetDock(AddTaskUserControl, Dock.Top);
            SwitchContainer.Children.Clear();
            SwitchContainer.Children.Add(AddTaskUserControl);
        }

        private void TabItem_MouseUp_1(object sender, MouseButtonEventArgs e)
        {
            DeleteUser del = new DeleteUser();
            DeleteUser AddTaskUserControl = new DeleteUser();
            DockPanel.SetDock(AddTaskUserControl, Dock.Top);
            SwitchContainer.Children.Clear();
            SwitchContainer.Children.Add(AddTaskUserControl);
        }

        private void TabItem_MouseUp_2(object sender, MouseButtonEventArgs e)
        {
            AddBuilding building = new AddBuilding();
            AddBuilding AddTaskUserControl = new AddBuilding();
            DockPanel.SetDock(AddTaskUserControl, Dock.Top);
            SwitchContainer.Children.Clear();
            SwitchContainer.Children.Add(AddTaskUserControl);
        }

        private void TabItem_MouseUp_3(object sender, MouseButtonEventArgs e)
        {
            DeleteBuilding delBuilding = new DeleteBuilding();
            DeleteBuilding AddTaskUserControl = new DeleteBuilding();
            DockPanel.SetDock(AddTaskUserControl, Dock.Top);
            SwitchContainer.Children.Clear();
            SwitchContainer.Children.Add(AddTaskUserControl);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            newAvatarPath = Avatar.Text;
            MainWindow.setAvatar();
        }
    }
}
