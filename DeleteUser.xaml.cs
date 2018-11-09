using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Projekt_120
{
    /// <summary>
    /// Interaktionslogik für DeleteUser.xaml
    /// </summary>
    public partial class DeleteUser : UserControl
    {
        public DeleteUser()
        {
            InitializeComponent();
        }

        public void DeleteCitizen(bool confirm)
        {
            try
            { 
            Int32 id = Convert.ToInt32(CitizenID.Text);
            
                Citizen citizen = DeleteUser.Read_CitizenID(id);
                Name.Text = citizen.name;
                FirstName.Text = citizen.firstName;

                if(confirm == true)
                Delete(citizen);

                // TEST
                if (DeleteUser.Read_CitizenID(id) == null)
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
                Console.WriteLine("Fehler beim Löschen:" + ex.Message);
                number.Opacity = 1;
            }
        }

        public static Citizen Read_CitizenID(int citizenID)
        {
            using (var db = new M120_ProjektEntities())
            {
                return (from rec in db.Citizens where rec.citizenID == citizenID select rec).FirstOrDefault();
            }
        }

        public static void Delete(Citizen citizen)
        {
            using (var db = new M120_ProjektEntities())
            {
                db.Entry(citizen).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DeleteCitizen(false);

            Warning.Opacity = 100;
            Warning1.Opacity = 100;
            Warning2.Opacity = 100;
        }

        private void Warning1_Click(object sender, RoutedEventArgs e)
        {
            DeleteCitizen(true);

            Warning.Opacity = 0;
            Warning1.Opacity = 0;
            Warning2.Opacity = 0;
        }

        private void Warning2_Click(object sender, RoutedEventArgs e)
        {
            Warning.Opacity = 0;
            Warning1.Opacity = 0;
            Warning2.Opacity = 0;
        }
    }
}
