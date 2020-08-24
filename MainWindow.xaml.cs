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
        string NAS; /*specMed;*/
        //int idMed, typeLit;
        public MainWindow()
        {
            InitializeComponent();
            cb_IDmedecin.DataContext = Login.myBDD.tblMedecins.ToList();
            cb_choixLit.DataContext = Login.myBDD.tblLits.ToList();
            cb_choixLit.DataContext = Login.myBDD.tblLitTypes.ToList();
            cb_choixLit.DataContext = Login.myBDD.tblDepts.ToList();
            dp_dateAdmis.SelectedDate = DateTime.Today;
        }

        // RECHERHER PATIENT (NAS)
        private void btn_rechercher_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(tbox_NAS.Text))
            {
                btn_ajouter.IsEnabled = false;
                btn_admettre.IsEnabled = true;

                int nasPatient = int.Parse(tbox_NAS.Text.Trim());
                tblPatient pat = Login.myBDD.tblPatients.SingleOrDefault(x => x.NAS == nasPatient);
                if (pat != null)
                {
                    string IDass = pat.IDassurance.ToString();
                    string tel = pat.Tel.ToString();

                    tbox_prenom.Text = pat.Prenom;
                    tbox_nom.Text = pat.Nom;
                    dp_DOB.SelectedDate = pat.DOB;
                    cb_IDassurance.Text = IDass;
                    tbox_adresse.Text = pat.Adresse;
                    tbox_ville.Text = pat.Ville;
                    tbox_prov.Text = pat.Province;
                    tbox_CP.Text = pat.CP;
                    tbox_tel.Text = tel;
                }
                else
                {
                    MessageBox.Show("Ce NAS de patient n'existe pas encore.\n Veuillez entrer leur info",
                    "Attention", MessageBoxButton.OK, MessageBoxImage.Information);
                    btn_ajouter.IsEnabled = true;
                }

            }
            else
            {
                MessageBox.Show("Le NAS est requis pour faire la recherche!",
                "Attention", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        // AFFICHER NAS dans le section 'détails admission'
        private void tbox_NAS_TextChanged(object sender, TextChangedEventArgs e)
        {
            NAS = tbox_NAS.Text;
            tb_NAS2.Text = NAS;
        }

        // RÉF PARENT
        private void btn_refParent_Click(object sender, RoutedEventArgs e)
        {
            // POP-UP WINDOW AJOUTER UNE RÉF PARENT
        }

     
        private void btn_ajouter_Click(object sender, RoutedEventArgs e)
        {
        //    btn_ajouter.IsEnabled = true;
        //    btn_Admis.IsEnabled = true;

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
            patient.Tel = tbox_tel.Text;
            patient.IDassurance = int.Parse(cb_IDassurance.Text);

            Login.myBDD.tblPatients.Add(patient);

          

            try
            {
                Login.myBDD.SaveChanges();
                MessageBox.Show("Personne ajoutée avec succes!");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btn_Admis_Click(object sender, RoutedEventArgs e)
        {
            //// AJOUT ADMISSION
            tblAdmission admis = new tblAdmission();
           
            //tb_IDadmission.Text = autogénéré;
            admis.NAS = int.Parse(tbox_NAS.Text);
            admis.dateAdmis = (DateTime)dp_dateAdmis.SelectedDate;
            admis.IDmedecin = int.Parse(cb_IDmedecin.Text);
            admis.Lit = int.Parse(cb_choixLit.Text);
            admis.Chirugie = chbox_chirugie.IsChecked;
            admis.dateChirugie = (DateTime)dp_chirugie.SelectedDate;
            admis.tv = Convert.ToBoolean(chbox_tv.IsChecked);
            admis.telephone = Convert.ToBoolean(chbox_telChambre.IsChecked);
            //admis.dateConge = (DateTime)dp_conge.Select

           Login.myBDD.tblAdmissions.Add(admis);


            try
            {
                Login.myBDD.SaveChanges();
                MessageBox.Show("Personne admise avec succes!");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        //ANNULER
        private void btn_annuler_Click(object sender, RoutedEventArgs e)
        {
            // vider les TextBox
            tbox_NAS.Text = String.Empty;
            tbox_prenom.Text = String.Empty;
            tbox_nom.Text = String.Empty;
            cb_IDassurance.Text = String.Empty;
            tbox_adresse.Text = String.Empty;
            tbox_ville.Text = String.Empty;
            tbox_prov.Text = String.Empty;
            tbox_CP.Text = String.Empty;
            tbox_tel.Text = String.Empty;

            //// déselectionner les boutons radio
            //rb_chirugie.IsChecked = false;
            //rb_standard.IsChecked = false;
            //rb_semiprive.IsChecked = false;
            //rb_prive.IsChecked = false;
            //rb_tv.IsChecked = false;
            //rb_telChambre.IsChecked = false;
            
            //// vider les datePicker
            //dp_DOB.SelectedDate = null;
            //dp_chirugie.SelectedDate = null;
            //dp_conge.SelectedDate = null;
        }

        private void cb_IDmedecin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //idMed = int.Parse(cb_IDmedecin.Text);
            //specMed = MenuPrepose.myBDD.tblMedecins.Specialite.ToString();
            //tb_nomSpecMedecin.DataContext = specMed;
        }

       
    }
}
