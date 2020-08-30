﻿using System;
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

            // liste de spécilaités
            //List<string> listSpecialites = new List<string>();
            //listSpecialites.Add("");
            //cb_specialite.DataSource = listSpecialites;
            cb_specialite.Items.Add("Interniste");
            cb_specialite.Items.Add("Pédiatrie");
            cb_specialite.Items.Add("Anesthésiologie");
            
        }

        private void cb_IDmedecin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // affiche Prenom, Nom, Specialite du médecin

        }

        private void btn_supprimer_Click(object sender, RoutedEventArgs e)
        {
            // récupère le int IDmedecin du combobox
            int IDmed = int.Parse(cb_IDmedecin.Text.Trim());

            // Query pour vérifier que le médecin n'as pas patients actuellement
            var query =
                from admis in Login.myBDD.tblAdmissions
                where admis.IDmedecin == IDmed
                select admis;

            if (query != null)
            {
                string erreur = "Docteur " + IDmed + " ne peux pas\nêtre congédié en raison d'avoir les patients\nactuellement admis.";
                tb_erreur.Text = erreur;  
            }
            else {
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

                    MessageBox.Show("Docteur " + IDmed + " congédié le : " + DateTime.Today.ToString("YYYY MM DD"),
                       "Attention", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception f)
                {
                    Console.WriteLine(f);
                    // Provide for exceptions.
                }
            }
        }

      
    }
}
