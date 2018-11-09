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
    /// Interaktionslogik für AddBuilding.xaml
    /// </summary>
    public partial class AddBuilding : UserControl
    {
        private List<Building> buildingList;
        public AddBuilding()
        {
            InitializeComponent();
        }

        static void CreateBuilding(int buildingID, string name, string street, string streetNr, short postcode, string place, string purpose)
        {
            Building newBuilding = new Building();
            newBuilding.BuildingID = buildingID;
            newBuilding.name = name;
            newBuilding.street = street;
            newBuilding.streetNr = streetNr;
            newBuilding.postcode = postcode;
            newBuilding.place = place;
            newBuilding.purpose = purpose;

            try
            {
                Console.WriteLine("Der neue Kunde hat die Nummer:" + AddBuilding.Create(newBuilding));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Speichern:" + ex.Message);
                Warning warning = new Warning();
                warning.Show();
            }
        }

        public static Int64 Create(Building building)
        {
            if (building.name == null) building.name = "";
            if (building.street == null) building.street = "";
            if (building.streetNr == null) building.streetNr = "0";
            if (building.place == null) building.place = "";
            if (building.purpose == null) building.purpose = "";
            using (var db = new M120_ProjektEntities())
            {
                db.Buildings.Add(building);
                db.SaveChanges();
                db.Entry(building).Reload();
                return building.BuildingID;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var context = new M120_ProjektEntities())
            {
                context.Users.ToList();
            }

            try
            {
                format.Opacity = 0;
                CreateBuilding(Convert.ToInt32(ID.Text), name.Text, street.Text, streetNr.Text, Convert.ToInt16(postcode.Text), place.Text, purpose.Text);
            }
            catch
            {
                format.Opacity = 100;
            }
        }

        public static List<Building> ReadAll()
        {
            using (var db = new M120_ProjektEntities())
            {
                return (from rec in db.Buildings select rec).ToList();
            }
        }
        
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                buildingList = new List<Building>();

                foreach (Building building in AddBuilding.ReadAll())
                {
                    //Console.WriteLine("CitizenID:" + building.citizenID + " / Name:" + building.name + " / Vorname:" + citizen.firstName);

                    buildingList.Add(building);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Auslesen:" + ex.Message);
            }

            ReadAll();

            listAllBuildings.ItemsSource = buildingList;
        }
    }
}
