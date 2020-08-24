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
    /// Interaction logic for FenetreMedecin.xaml
    /// </summary>
    public partial class FenetreMedecin : Window
    {
        string NAS;
        public FenetreMedecin()
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

    }
}
