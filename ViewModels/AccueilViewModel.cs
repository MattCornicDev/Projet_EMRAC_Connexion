using WPF_emrac_connexion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_emrac_connexion.ViewModels
{
    class AccueilViewModel
    {
        public AccueilViewModel()
        {
            // Créer d'un contact à ajouter
            InitialisationBdd();
        }

        private void InitialisationBdd()
        {
            Users users = new Users("moumoule", "NC", "NC", "test", "blabla@hotmail.fr");
           
            // Création de l'objet Bdd pour l'intéraction avec la base de donnée MySQL
            CrudUsers insererUser = new CrudUsers();
            insererUser.ajouterUser(users);
        }

    }
}
