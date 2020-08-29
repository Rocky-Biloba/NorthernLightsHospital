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
    /// Interaction logic for FenetreRefParent.xaml
    /// </summary>
    public partial class FenetreRefParent : Window
    {
        public FenetreRefParent(int value)
        {
            InitializeComponent();
            
            //this.NASpatient = value;
        }

        // AJOUTER RÉF PARENT
        private void btn_ajouter_Click(object sender, RoutedEventArgs e)
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

            Login.myBDD.tblParents.Add(parent);

            try
            {
                Login.myBDD.SaveChanges();
                MessageBox.Show("Réf. parent ajoutée avec succes!");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
