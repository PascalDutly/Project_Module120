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
    /// Interaktionslogik für DeleteBuilding.xaml
    /// </summary>
    public partial class DeleteBuilding : UserControl
    {
        public DeleteBuilding()
        {
            InitializeComponent();
        }

        public void DeleteBuild()
        {

            Int32 id = Convert.ToInt32(BuildingIDField.Text);
            try
            {
                Building building = Read_BuildingID(id);
                Console.WriteLine("Gebäude: " + building.name);

                name.Text = building.name;
                street.Text = building.street;
                streetNr.Text = building.streetNr;
                postcode.Text = Convert.ToString(building.postcode);
                place.Text = building.place;
                purpose.Text = building.purpose;

                Delete(building);
                // TEST
                if (DeleteBuilding.Read_BuildingID(id) == null)
                {
                    Console.WriteLine("Löschen erfolgreich");
                }
                else
                {
                    Console.WriteLine("Löschen NICHT erfolgreich");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Das Gebäude hat noch mindestens einen Bewohner");
            }
        }

        public static Building Read_BuildingID(int BuildingID)
        {
            using (var db = new M120_ProjektEntities())
            {
                return (from rec in db.Buildings where rec.BuildingID == BuildingID select rec).FirstOrDefault();
            }
        }

        public static void Delete(Building building)
        {
            using (var db = new M120_ProjektEntities())
            {
                db.Entry(building).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DeleteBuild();
        }
    }
}
