using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_emrac_connexion.Models
{
    class Users
    {
        private int idUsers;
        private string pseudo;
        private string prenom = "NULL";
        private string nom = "NULL";
        private string password;
        private string email;

        public int IdUsers { get => idUsers; set => idUsers = value; }
        public string Pseudo { get => pseudo; set => pseudo = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        

        public Users(int id, string _pseudo, string _prenom, string _nom, string pass, string mail )
        {
            IdUsers = id;
            Pseudo = _pseudo;
            Prenom = _prenom;
            Nom = _nom;
            Password = pass;
            Email = mail;
        }

        public Users(string _pseudo, string _prenom, string _nom, string pass, string mail)
        {
            Pseudo = _pseudo;
            Prenom = _prenom;
            Nom = _nom;
            Password = pass;
            Email = mail;
        }

        public Users(string pass, string mail)
        {
            Password = pass;
            Email = mail;
        }
    }
}
