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

namespace NorthernLightsHospital
{
    /// <summary>
    /// Interaction logic for RecherchePatient.xaml
    /// </summary>
    public partial class RecherchePatient : Window
    {
        public RecherchePatient()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //var query =
    

           // //dg_listePatients -> pour tester la connexion à myBDD
           //from c in MenuPrepose.myBDD.tblPatients
           //select new {c.Prenom, c.Nom, c.Tel, c.Adresse, c.Ville, c.Province, c.CP, c.RefParent, c.IDassurance};
           // dg_listePatients.DataContext = query.ToList();
        }

        private void btn_rechercher_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
