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
        string NAS;
       
        public MainWindow()
        {
            InitializeComponent();
            cb_IDmedecin.DataContext = Login.myBDD.tblMedecins.ToList();
            dp_dateAdmis.SelectedDate = DateTime.Today;
            Global.referenceExiste = false;

            // récrupère les LITS disponibles (Occupé = 0 ou false) 
            var query = from temp in Login.myBDD.tblLits where temp.Occupe == false select temp;
            List<NorthernLightsHospital.tblLit> list_query = query.ToList();

            foreach (var i in list_query)
            {
                string NewLine = i.Lit.ToString();

                //Type
                if (i.Type == 1)
                    NewLine += " | Standard      ";
                else if (i.Type == 2)
                    NewLine += " | Semi privé";
                else 
                    NewLine += " | Privé         ";

                //Dept
                if (i.IDdept == 1)
                    NewLine += " | Urgence";
                else if (i.IDdept == 2)
                    NewLine += " | Réadaptation";
                else
                    NewLine += " | Chirugie";

                cb_choixLit.Items.Add(NewLine);
            }

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

        // RÉFÉRENCE PARENT
        private void btn_refParent_Click(object sender, RoutedEventArgs e)
        {
            Global.NASactuel = int.Parse(tbox_NAS.Text.Trim());
            FenetreRefParent main = new FenetreRefParent();
            main.ShowDialog();
            
        }

        // AJOUTER PATIENT
        private void btn_ajouter_Click(object sender, RoutedEventArgs e)
        {
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

            // pas d'assurance = 0
            if (cb_IDassurance.Text == "")
            {
                patient.IDassurance = 0;
            }
            else{
                patient.IDassurance = int.Parse(cb_IDassurance.Text);
            }
            

            if (Global.referenceExiste) {
                patient.RefParent = patient.NAS;
            }
            

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


        // ADMISSION PATIENT
        private void btn_Admis_Click(object sender, RoutedEventArgs e)
        {
            int nasPatient = int.Parse(tbox_NAS.Text.Trim());

            //Validation : que le patient n'est pas déjà admis
            tblAdmission adm = Login.myBDD.tblAdmissions.SingleOrDefault(x => x.NAS == nasPatient);
            if (adm != null) //// patient déjà admis
            {
                btn_admettre.IsEnabled = false; // Validation : usager ne peux pas admettre un patient déjà admis
                MessageBox.Show("Ce patient est déjà admis.",
            "Attention", MessageBoxButton.OK, MessageBoxImage.Information);
                // vider le textbox NAS et reactiver le bouton ajouter
                tbox_NAS.Text = String.Empty;

            }
            else {

                string LitNum = cb_choixLit.Text;
                int index = LitNum.IndexOf(" |");
                if (index > 0)
                {
                    LitNum = LitNum.Substring(0, index);
                }

                tblAdmission admis = new tblAdmission();

                

                //tb_IDadmission.Text = autogénéré
                admis.NAS = int.Parse(tbox_NAS.Text);
                admis.dateAdmis = (DateTime)dp_dateAdmis.SelectedDate;
                admis.IDmedecin = int.Parse(cb_IDmedecin.Text);

                admis.Lit = int.Parse(LitNum);
                admis.Chirugie = chbox_chirugie.IsChecked;
                //null date time fix + validation
                if (chbox_chirugie.IsChecked == true)
                {
                    // vérifie si l'usager as mis un date
                    if ((DateTime)dp_chirugie.SelectedDate == null)
                    {
                        // set to default date (today)
                        admis.dateChirugie = DateTime.Today;
                    }
                    else
                    {
                        admis.dateChirugie = (DateTime)dp_chirugie.SelectedDate;
                    }
                }
                // else set date to null
                else
                {
                    admis.dateChirugie = null;
                }
                admis.tv = Convert.ToBoolean(chbox_tv.IsChecked);
                admis.telephone = Convert.ToBoolean(chbox_telChambre.IsChecked);

                Login.myBDD.tblAdmissions.Add(admis);

                try
                {
                    Login.myBDD.SaveChanges();
                    MessageBox.Show("Personne admise avec succes!");
                    ViderTout();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            } 

        }

        //ANNULER
        private void btn_annuler_Click(object sender, RoutedEventArgs e)
        {
            ViderTout();
            btn_admettre.IsEnabled = true;
        }

        private void cb_IDmedecin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //idMed = int.Parse(cb_IDmedecin.Text);
            //specMed = MenuPrepose.myBDD.tblMedecins.Specialite.ToString();
            //tb_nomSpecMedecin.DataContext = specMed;
        }

        public void ViderTout() {
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

            // vider les combobox
            cb_IDmedecin.Text = String.Empty;
            cb_choixLit.Text = String.Empty;

            //// décocher les checkbox
            chbox_chirugie.IsChecked = false;
            chbox_tv.IsChecked = false;
            chbox_telChambre.IsChecked = false;

            // vider les datePicker
            dp_DOB.SelectedDate = null;
            dp_chirugie.SelectedDate = null;
        }

       
    }
}
