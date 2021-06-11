using WPF_emrac_connexion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using System.Windows.Input;

namespace WPF_emrac_connexion.ViewModels
{
    class InscriptionViewModel : INotifyPropertyChanged
    {
        private string pseudo;
        private string prenom = "NULL";
        private string nom = "NULL";
        private string password;
        private string passwordConfirme;
        private string email;

        public string Pseudo { get { return pseudo; } set { pseudo = value; OnPropertyChanged("Pseudo"); } }
        public string Prenom { get { return prenom; } set { prenom = value; OnPropertyChanged("Prenom"); } }
        public string Nom { get { return nom; } set { nom = value; OnPropertyChanged("Nom"); } }
        public string Password { get { return password; } set { password = value; OnPropertyChanged("Nom"); } }
        public string PasswordConfirme { get { return passwordConfirme; } set { passwordConfirme = value; OnPropertyChanged("PasswordConfirme"); } }
        public string Email { get { return email; } set { email = value; OnPropertyChanged("Email"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string nomPropriete)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(nomPropriete));
            }
        }

        public InscriptionViewModel()
        {
            // Créer d'un contact à ajouter
            //InitialisationBdd();//a enlever a la fin
            CommandeInscription = new Command(ActionInscription);

        }
        public ICommand CommandeInscription { get; set; }

        private void ActionInscription(object obj)
        {
            if(Password == PasswordConfirme)
            {
                Users users = new Users(Pseudo, Prenom, Nom, Password, Email);

                // Création de l'objet Bdd pour l'intéraction avec la base de donnée MySQL
                CrudUsers insererUser = new CrudUsers();
                insererUser.ajouterUser(users);
            }
            else
            {
                MessageBox.Show("votre mot de passe et sa confirmation doivent être idendtiques !");
            } 
        }
    }
}
