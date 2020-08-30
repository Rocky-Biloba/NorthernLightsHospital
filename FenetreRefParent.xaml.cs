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
using System.Text.RegularExpressions;

namespace NorthernLightsHospital
{
    /// <summary>
    /// Interaction logic for FenetreRefParent.xaml
    /// </summary>
    public partial class FenetreRefParent : Window
    {
        public FenetreRefParent()
        {
            InitializeComponent();

        }

        // AJOUTER RÉF PARENT
        private void btn_ajouter_Click(object sender, RoutedEventArgs e)
        {
            if (ValidNoms(tbox_prenom.Text) && ValidNoms(tbox_nom.Text) && ValidPhone(tbox_tel.Text) && ValidPost(tbox_CP.Text)) 
            {
                tblParent parent = new tblParent();
                // refParent est le NAS du patient 
                parent.Nom = tbox_nom.Text;
                parent.Prenom = tbox_prenom.Text;
                parent.Adresse = tbox_adresse.Text;
                parent.Ville = tbox_ville.Text;
                parent.Province = tbox_prov.Text;
                parent.CP = tbox_CP.Text;
                parent.Tel = tbox_tel.Text;
                parent.RefParent = Global.NASactuel;

                Login.myBDD.tblParents.Add(parent);

                try
                {
                    Login.myBDD.SaveChanges();
                    MessageBox.Show("Réf. parent ajoutée avec succes!");
                    Global.referenceExiste = true;
                    Close();
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

        // VALIDATION 
        bool ValidNoms(String nom)
        {
            //Null case
            if (nom == null)
                return false;
            else
                return true;
        }

        bool ValidPhone(String Phone)
        {
            //Regex
            if (Regex.IsMatch(Phone, @"^\(?\d{3}\)?-? *\d{3}-? *-?\d{4}$"))
                return true;
            else
                return false;
        }

        bool ValidPost(String Post)
        {
            //Regex
            if (Regex.IsMatch(Post, @"^[ABCEGHJKLMNPRSTVXYabceghjklmnprstvxy]{1}\d{1}[A-Za-z]{1}\d{1}[A-Za-z]{1}\d{1}$"))
                return true;
            else
                return false;
        }

        private void btn_annuler_Click(object sender, RoutedEventArgs e)
        {
            ViderTout();
            this.Close();
        }

        public void ViderTout()
        {
            // vider les TextBox
            tbox_prenom.Text = String.Empty;
            tbox_nom.Text = String.Empty;
            tbox_adresse.Text = String.Empty;
            tbox_ville.Text = String.Empty;
            tbox_prov.Text = String.Empty;
            tbox_CP.Text = String.Empty;
            tbox_tel.Text = String.Empty;

        }
    }
}
