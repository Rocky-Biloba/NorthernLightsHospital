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
    /// Interaction logic for  MenuPrepose.xaml
    /// </summary>
    public partial class MenuPrepose : Window
    {
        public static NorthernLightsHospitalEntities myBDD;

        public MenuPrepose()
        {
            InitializeComponent();
            myBDD = new NorthernLightsHospitalEntities();
        }

        //AJOUTER
        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ajout = new MainWindow();
            ajout.ShowDialog();
        }

        //RECHERCHER
        private void Rechercher_Click(object sender, RoutedEventArgs e)
        {
            RecherchePatient recherche = new RecherchePatient();
            recherche.ShowDialog();
        }

    }
}
