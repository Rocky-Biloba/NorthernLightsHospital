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

namespace NorthernLightsHospital
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string NAS, specMed;
        int idMed, typeLit;
        public MainWindow()
        {
            InitializeComponent();
            cb_IDmedecin.DataContext = MenuPrepose.myBDD.tblMedecins.ToList();
            cb_dept.DataContext = MenuPrepose.myBDD.tblDepts.ToList();
            dp_dateAdmis.SelectedDate = DateTime.Today;
        }

        private void btn_ajouter_Click(object sender, RoutedEventArgs e)
        {
            // AJOUT PATIENT
            tblPatient patient = new tblPatient();
            patient.NAS = int.Parse(tbox_NAS.Text);
            patient.DOB = (DateTime)dp_DOB.SelectedDate;
            patient.Nom = tbox_nom.Text;
            patient.Prenom = tbox_prenom.Text;
            patient.Adresse = tbox_adresse.Text;
            patient.Ville = tbox_ville.Text;
            patient.Province = tbox_prov.Text;
            patient.CP = tbox_CP.Text;
            patient.Tel = int.Parse(tbox_tel.Text);
            patient.IDassurance = int.Parse(tbox_IDassurance.Text);

            // CHOIX LIT,  DEPT
            //printout = cb_dept.SelectedItem;
            if (rb_standard.IsChecked == true || rb_semiprive.IsChecked == true || rb_prive.IsChecked == true) {
                if (rb_standard.IsChecked == true)
                    typeLit = 1;
                else if (rb_semiprive.IsChecked == true)
                    typeLit = 2;
                else (rb_prive.IsChecked == true)
                    typeLit = 3;
            }
            else
            {
                MessageBox.Show("Vous devez selectionner un type de lit.",
                "Attention", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            // AJOUT ADMISSION
            tblAdmission admis = new tblAdmission();
            //nouveauID =
            //tb_IDadmission.Text = NouveauID; use this in RecherchePatient
            admis.NAS = int.Parse(tbox_NAS.Text);
            admis.dateAdmis = (DateTime)dp_dateAdmis.SelectedDate;
            admis.IDmedecin = int.Parse(cb_IDmedecin.Text);
            //admis.Lit = int.Parse() auto incre
            admis.Chirugie = tbox_chirugie.Text;
            admis.dateChirugie = (DateTime)dp_dateChirugie.SelectedDate;
            admis.dateConge = (DateTime)dp_dateConge.SelectedDate;

            MenuPrepose.myBDD.tblAdmissions.Add(admis);

            try
            {
                MenuPrepose.myBDD.SaveChanges();
                MessageBox.Show("Personne admise avec succes!");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }



        private void btn_annuler_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cb_IDmedecin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //idMed = int.Parse(cb_IDmedecin.Text);
            //specMed = MenuPrepose.myBDD.tblMedecins.Specialite.ToString();
            //tb_nomSpecMedecin.DataContext = specMed;
        }

        private void btn_refParent_Click(object sender, RoutedEventArgs e)
        {
            // POP-UP WINDOW AJOUTER UNE RÉF PARENT
        }

        private void tbox_NAS_TextChanged(object sender, TextChangedEventArgs e)
        {
            NAS = tbox_NAS.Text;
            tb_NAS2.Text = NAS;
        }
    }
}
