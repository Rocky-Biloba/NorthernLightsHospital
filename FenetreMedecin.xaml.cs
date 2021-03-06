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
    /// Interaction logic for FenetreMedecin.xaml
    /// </summary>
    public partial class FenetreMedecin : Window
    {
        string NAS;
        public FenetreMedecin()
        {
            InitializeComponent();
            //cb_IDmedecin.DataContext = Login.myBDD.tblMedecins.ToList();
            cb_choixLit.DataContext = Login.myBDD.tblLits.ToList();
            cb_choixLit.DataContext = Login.myBDD.tblLitTypes.ToList();
            cb_choixLit.DataContext = Login.myBDD.tblDepts.ToList();
            dp_dateAdmis.SelectedDate = DateTime.Today;
            dp_conge.SelectedDate = DateTime.Today;

            // all fields read-only, except NAS (recherche) + date congé 
            gbox_coordPatient.IsEnabled = false;
            gbox_admissionPatient.IsEnabled = false;
            btn_conge.IsEnabled = false;
            dp_conge.IsEnabled = false;

        }

        // RECHERHER PATIENT (NAS)
        private void btn_rechercher_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(tbox_NAS.Text))
            {
                // add the condition if dp_conge is !null here?
                btn_conge.IsEnabled = true;


                int nasPatient = int.Parse(tbox_NAS.Text.Trim());
                tblPatient pat = Login.myBDD.tblPatients.SingleOrDefault(x => x.NAS == nasPatient);
                if (pat != null) // vérifier que le champ NAS n'est pas vide
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

                    // AFFICHAGE des informations associé tblAdmission
                    tblAdmission adm = Login.myBDD.tblAdmissions.SingleOrDefault(x => x.NAS == nasPatient);
            
                    if (adm != null) // Si le patient est admis
                    {
                        if (adm.dateConge == null) // Si le patient n'as pas encore été congédié
                        {
                            string erreur = "";
                            tb_Erreur.Text = erreur;
                            dp_conge.IsEnabled = true;
                            btn_conge.IsEnabled = true;
                            dp_dateAdmis.SelectedDate = adm.dateAdmis;
                            // vider combobox, affiche le IDmedecin associé à l'admission du patient
                            cb_IDmedecin.ClearValue(ItemsControl.ItemsSourceProperty);
                            cb_IDmedecin.Items.Add(adm);
                            cb_IDmedecin.SelectedIndex = 0;

                            if (adm.Chirugie == true)
                            {
                                chbox_chirugie.IsChecked = adm.Chirugie;
                            }

                            dp_chirugie.SelectedDate = adm.dateChirugie;

                            // vider combobox, affiche les infos Lit (Lit, Descript, NomDept)
                            cb_choixLit.ClearValue(ItemsControl.ItemsSourceProperty);
                            cb_choixLit.Items.Add(adm);
                            cb_choixLit.SelectedIndex = 0;
                        }
                        else
                        {
                            btn_conge.IsEnabled = false;
                            dp_conge.IsEnabled = false;
                            string erreur = " Ce patient as été congédié.";
                            tb_Erreur.Text = erreur;
                        }
                    }
                    else
                    {
                        btn_conge.IsEnabled = false;
                        dp_conge.IsEnabled = false;
                        string erreur = " Ce patient n'est pas admis.";
                        tb_Erreur.Text = erreur;
                    }

                    }
                    else
                    {
                        MessageBox.Show("Ce NAS de patient n'existe pas.",
                        "Attention", MessageBoxButton.OK, MessageBoxImage.Information);
                        btn_conge.IsEnabled = false;
                    }

                }
                else
                {
                    MessageBox.Show("Le NAS est requis pour faire la recherche!",
                    "Attention", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }

            // DONNER CONGÉE
            private void btn_conge_Click(object sender, RoutedEventArgs e)
            {
                int nasPatient = int.Parse(tbox_NAS.Text.Trim());
                // set to default date (today)
                DateTime releaseDate = DateTime.Today;

                // vérifie si l'usager as mis un date
                if ((DateTime)dp_conge.SelectedDate != null)
                {
                    releaseDate = (DateTime)dp_conge.SelectedDate;
                }

                //Query db pour trouver le rang à updater
                var query =
                     from adm in Login.myBDD.tblAdmissions
                     where adm.NAS == nasPatient
                     select adm;

                // Execute query, changer les colonnes
                foreach (var adm in query)
                {
                    adm.dateConge = releaseDate;
                    // autre changements ici..
                }

                // Submit changements au db
                try
                {
                    Login.myBDD.SaveChanges();

                    MessageBox.Show("Patient " + nasPatient + " congédié le : " + releaseDate.ToString("yyyy MM dd"),
                    "Attention", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception f)
                {
                    Console.WriteLine(f);
                    //Provide for exceptions
                }

            }

            // AFFICHER NAS dans le section 'détails admission'
            private void tbox_NAS_TextChanged(object sender, TextChangedEventArgs e)
            {
                NAS = tbox_NAS.Text;
                tb_NAS2.Text = NAS;
            }

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

                // vider les combobox
                cb_IDmedecin.Text = String.Empty;
                cb_choixLit.Text = String.Empty;

                //// décocher les checkbox
                chbox_chirugie.IsChecked = false;

                // vider les datePicker
                dp_DOB.SelectedDate = null;
                dp_chirugie.SelectedDate = null;
                dp_conge.SelectedDate = null;

                // vider msg d'erreur
                string erreur = "";
                tb_Erreur.Text = erreur;
            }


        }
    }
