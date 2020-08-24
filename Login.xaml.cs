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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public static NorthernLightsHospitalEntities myBDD;
        int essai = 0;
        public Login()
        {
            InitializeComponent();
            myBDD = new NorthernLightsHospitalEntities();
        }

        private void btn_OK_Click(object sender, RoutedEventArgs e)
        {
            string user = tbox_username.Text;
            string pass = pbox_mdp.Password;
            if (!String.IsNullOrEmpty(user) && !String.IsNullOrEmpty(pass))
            {
                if (user == "prepose" && pass == "prepose")
                {
                    MainWindow main = new MainWindow();
                    main.ShowDialog();
                }
                if (user == "admin" && pass == "admin")
                {
                        //changer MenuPrepose à MenuAdmin
                    MenuPrepose main = new MenuPrepose();
                    main.ShowDialog();
                }
                if (user == "medecin" && pass == "medecin")
                {
                    FenetreMedecin main = new FenetreMedecin();
                    main.ShowDialog();
                }
                else if (essai == 2)
                {
                    MessageBox.Show("Nombre maximal de tentatives atteint, veuillez réessayer plus tard! ",
                         "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                    Application.Current.Shutdown();
                }
                else
                {
                    MessageBox.Show("Vous devez saisir des informations valides!",
                       "Attention", MessageBoxButton.OK, MessageBoxImage.Information);
                    essai++;
                }

            }
            else
            {
                MessageBox.Show("Le nom d'utilisateur et le mot de passe sont requis!",
               "Attention", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void btn_Annuler_Click(object sender, RoutedEventArgs e)
        {
            // On s'assure que c'est bien l'intention de l'utilisateur de quitter l'application
            MessageBoxResult reponse = MessageBox.Show("Désirez-vous réellement quitter cette application ? ", "Attention!",
            MessageBoxButton.YesNo, MessageBoxImage.Question);
            // Si tel est le cas, on met fin à l'application.
            if (reponse == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
