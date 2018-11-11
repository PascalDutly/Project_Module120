using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Projekt_120
{
    
    /// <summary>
    /// Interaktionslogik für AddUser.xaml
    /// </summary>
    public partial class AddUser : UserControl
    {
        private List<Citizen> citizenList;

        public AddUser()
        {
            InitializeComponent();

            updateDataGrid();
        }
        

        static void CreateCitizen(int citizenID, string name, string firstName, string gender, DateTime birthday, int income, int building)
        {
            Citizen newCitizen = new Citizen();
            newCitizen.citizenID = citizenID;
            newCitizen.name = name;
            newCitizen.firstName = firstName;
            newCitizen.gender = gender;
            newCitizen.birthday = birthday;
            newCitizen.incomePerMonth = income;
            newCitizen.fk_buildingID = building;
            
            try
            {
                Console.WriteLine("Der neue Bewohner:" + AddUser.Create(newCitizen));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Speichern:" + ex.Message);
                Warning warning = new Warning();
                warning.Show();
            }
        }

        public static Int64 Create(Citizen citizen)
        {
                if (citizen.name == null) citizen.name = "";
                if (citizen.firstName == null) citizen.firstName = "";
                if (citizen.gender == null) citizen.gender = "";
                if (citizen.birthday == null) citizen.birthday = DateTime.Today;
                if (citizen.incomePerMonth == null) citizen.incomePerMonth = 0;
                if (citizen.fk_buildingID == null) citizen.fk_buildingID = 1;

            using (var db = new M120_ProjektEntities())
            {
                db.Citizens.Add(citizen);
                db.SaveChanges();
                db.Entry(citizen).Reload();
                return citizen.citizenID;
            }
            
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(Birthday.DisplayDate);
            using (var context = new M120_ProjektEntities())
            {
                context.Citizens.ToList();
            }

            string gender;
            if (Male.IsChecked == true)
                gender = "Herr";
            else
                gender = "Frau";
            

            try //Absturz bei falschem Datenformat wird verhindert
            {
                format.Opacity = 0;
                Console.WriteLine(Birthday.DisplayDate);
                CreateCitizen(Convert.ToInt32(CitizenID.Text), Name.Text, FirstName.Text, gender, Convert.ToDateTime(Birthday.Text), Convert.ToInt32(Income.Text), Convert.ToInt32(Building.Text));
            }
            catch
            {
                format.Opacity = 1;
            }
            addSuccessful();
        }

        public static List<Citizen> ReadAll()
        {
            using (var db = new M120_ProjektEntities())
            {
                return (from rec in db.Citizens select rec).ToList();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            updateDataGrid();
        }

        private void updateDataGrid()
        {
            try
            {
                citizenList = new List<Citizen>();

                foreach (Citizen citizen in AddUser.ReadAll())
                {
                    citizenList.Add(citizen);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Auslesen:" + ex.Message);
            }
            ReadAll();

            listAllCitizens.ItemsSource = citizenList;
        }

        private void addSuccessful()
        {
            CitizenID.Text = "";
            Name.Text = "";
            FirstName.Text = "";
            Income.Text = "";
            Building.Text = "";
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }




        private void updateStatistic()
        {
            int maleCount = 0;
            int femaleCount = 0;
            try
            {
                citizenList = new List<Citizen>();

                foreach (Citizen citizen in AddUser.ReadAll())
                {
                    Console.WriteLine("CitizenID:" + citizen.citizenID + " / Name:" + citizen.name + " / Vorname:" + citizen.firstName + citizen.gender);

                    if (citizen.gender == "Herr")
                        maleCount++;
                    else
                        femaleCount++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Auslesen:" + ex.Message);
            }
            
            genderStatistic.ColumnDefinitions[0].Width = new GridLength(maleCount, GridUnitType.Star);
            genderStatistic.ColumnDefinitions[1].Width = new GridLength(femaleCount, GridUnitType.Star);
            mencount.Content = "Männer: " + maleCount;
            womencount.Content = "Frauen: " + femaleCount;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            updateStatistic();
            genderStatistic.Opacity = 0;
            timer();
        }

        private void timer()
        {
                DispatcherTimer dispatcherTimer = new DispatcherTimer();
                dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
                dispatcherTimer.Start();

            if (genderStatistic.Opacity >= 1)
                dispatcherTimer.Stop();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            genderStatistic.Opacity += 0.01;
            
        }

        private void Birthday_CalendarClosed(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(Birthday.Text);
        }
    }
}
