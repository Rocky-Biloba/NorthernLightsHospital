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
    /// Interaction logic for FenetreAdmin.xaml
    /// </summary>
    public partial class FenetreAdmin : Window
    {
        //public static int ID;
        public FenetreAdmin()
        {
            InitializeComponent();
            cb_IDmedecin.DataContext = Login.myBDD.tblMedecins.ToList();

            // liste de spécialités
            cb_specialite.Items.Add("Interniste");
            cb_specialite.Items.Add("Pédiatrie");
            cb_specialite.Items.Add("Anesthésiologie");

            cb_specialite.SelectedIndex = 1;

        }

        private void cb_IDmedecin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //// AFFICHER Prenom, Nom, Specialite du médecin
            //// récupère le int IDmedecin du combobox      
            //try 
            //{
            //    string cbChoice = cb_IDmedecin.Text;

            //    int IDmed = int.Parse(cbChoice);
            //    IDmed++;
            //    var query = from med in Login.myBDD.tblMedecins where med.IDmedecin == IDmed select med;
            //    List<NorthernLightsHospital.tblMedecin> list_query = query.ToList();
            //    tb_detailMedecin.Text = list_query[0].Prenom + " " + list_query[0].Nom + ", " + list_query[0].Specialite + ".";
            //}
            //catch { }
        }

        // SUPPRIMER
        private void btn_supprimer_Click(object sender, RoutedEventArgs e)
        {
            // récupère le int IDmedecin du combobox
            int IDmed = int.Parse(cb_IDmedecin.Text.Trim());

            // Query pour vérifier que le médecin n'as pas patients actuellement
            var query =
                from admis in Login.myBDD.tblAdmissions
                where admis.IDmedecin == IDmed
                select admis;

            List<NorthernLightsHospital.tblAdmission> list_query = query.ToList();

            if (list_query.Count > 0)
            {
                string erreur = "Docteur " + IDmed + " ne peux pas\nêtre congédié en raison d'avoir les patients\nactuellement admis.";
                tb_erreur.Text = erreur;
            }
            else
            {
                string erreur = "";
                tb_erreur.Text = erreur;
                // Query pour SUPPRIMER un médecin
                var query2 =
                    from dr in Login.myBDD.tblMedecins
                    where dr.IDmedecin == IDmed
                    select dr;

                foreach (var dr in query2)
                {
                    Login.myBDD.tblMedecins.Remove(dr);
                }

                try
                {
                    Login.myBDD.SaveChanges();
                    ViderTout();
                    cb_IDmedecin.DataContext = Login.myBDD.tblMedecins.ToList();
                    MessageBox.Show("Docteur " + IDmed + " congédié le : " + DateTime.Today.ToString("yyyy MM dd"),
                       "Attention", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception f)
                {
                    Console.WriteLine(f);
                    // Provide for exceptions.
                }
            }
        }

        private void btn_ajouter_Click(object sender, RoutedEventArgs e)
        {
            if (ValidNoms(tbox_prenom.Text) && ValidNoms(tbox_nom.Text))
            {
                tblMedecin medecin = new tblMedecin();

                medecin.Nom = tbox_nom.Text;
                medecin.Prenom = tbox_prenom.Text;
                medecin.Specialite = cb_specialite.Text;

                Login.myBDD.tblMedecins.Add(medecin);

                try
                {
                    Login.myBDD.SaveChanges();
                    ViderTout();
                    cb_IDmedecin.DataContext = Login.myBDD.tblMedecins.ToList();
                    MessageBox.Show("Médecin ajouté avec succes!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Veuillez assurer que tous les champs son bien remplis",
                       "Attention", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btn_annuler_Click(object sender, RoutedEventArgs e)
        {
            ViderTout();
        }

        public void ViderTout()
        {
            // vider les TextBox
            tbox_prenom.Text = String.Empty;
            tbox_nom.Text = String.Empty;
            tb_erreur.Text = String.Empty;

            // vider les combobox
            cb_IDmedecin.Text = String.Empty;
            cb_specialite.Text = String.Empty;

        }


        // VALIDATION 
        bool ValidNoms(String nom)
        {
            //Null case
            if (nom == "")
                return false;
            else
                return true;
        }

    }
}

