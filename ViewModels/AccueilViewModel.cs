using WPF_emrac_connexion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using System.Windows.Input;
using WPF_emrac_connexion.Views;

namespace WPF_emrac_connexion.ViewModels
{
    class AccueilViewModel : INotifyPropertyChanged
    {
        private string password;
        private string email;
        private List<string> resultat;
        private Window _window;
        public string Email { get { return email; } set { email = value; OnPropertyChanged("Email"); } }
        public string Password { get { return password; } set { password = value; OnPropertyChanged("Password"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string nomPropriete)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(nomPropriete));
            }
        }

        public AccueilViewModel(Window window)
        {
            // Créer d'un contact à ajouter
            //InitialisationBdd();//a enlever a la fin
            CommandeConnexion = new Command(ActionConnexion);
            CommandeNonInscrit = new Command(ActionNonInscrit);
            _window = window;
        }

        public ICommand CommandeConnexion { get; set; }
        public ICommand CommandeNonInscrit { get; set; }

        private void ActionConnexion(object obj)
        {
            Users users = new Users(Password, Email);
            CrudUsers verificationUser = new CrudUsers();
            resultat = verificationUser.LireUser(users);
        
            foreach(string verif in resultat)
            {
                MessageBox.Show(verif);
            }

        }

        private void ActionNonInscrit(object obj)
        {
            Inscription inscription = new Inscription();
            inscription.Show();
            _window.Close();
        }

    }
}
