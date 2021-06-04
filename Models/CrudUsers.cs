using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_emrac_connexion.Models
{
    class CrudUsers
    {
        public bool ajouterUser(Users userAAjouter)
        {
            bool EstOK = false;
            BddMysql Bdd = new BddMysql("localhost", 3306, "xamaringestioncourse", "root", "" );
            //BddMysql Bdd = new BddMysql("mysql-emrac-connexion.alwaysdata.net", 3306, "emrac-connexion_bdd", "236713", "1alwaysLAmouche");

            bool OuvertureOk = Bdd.OuvrirConnexion();

            if (OuvertureOk == true)
            {
                // préparation de la requête SQL
                string requete = "INSERT INTO users(pseudo, Prenom, Nom, password, email) VALUES('" + userAAjouter.Pseudo + "', '" + userAAjouter.Prenom +
                    "', '" + userAAjouter.Nom + "', '" + userAAjouter.Password + "' , '" + userAAjouter.Email + "')";


                int NbrLignes = Bdd.RequeteNoData(requete);

                if (NbrLignes == 0)
                {
                    MessageBox.Show("L'écriture n'a pas fonctionné");
                }
                else
                {
                    MessageBox.Show("L'écriture est bien effective");
                }
            }
            else
            {
                MessageBox.Show("La connexion à la base de données n'a pas fonctionnée");
            }
            return EstOK;
        }

        public bool supprimerUser(Users userASupprimer)
        {
            bool EstOK = false;
            BddMysql Bdd = new BddMysql("localhost", 3306, "gestioncourse", "root", "");
            bool OuvertureOk = Bdd.OuvrirConnexion();

            // préparation de la requête SQL
            string requete = "DELETE FROM users WHERE Nom ='" + userASupprimer.Nom + "' ";

            if (OuvertureOk == true)
            {
                int NbrLignes = Bdd.RequeteNoData(requete);
                EstOK = true;
            }
            return EstOK;
        }

        public void UpdateUser(Users userAUpdate)
        {
            bool EstOK = false;
            BddMysql Bdd = new BddMysql("localhost", 3306, "gestioncourse", "root", "");
            bool OuvertureOk = Bdd.OuvrirConnexion();

            // préparation de la requête SQL
            string requete = "UPDATE `users` SET `pseudo` = '" + userAUpdate.Pseudo + "', `Prenom` = '" + userAUpdate.Prenom + "', `password` = '" +
                userAUpdate.Password + "', `email` = '" + userAUpdate.Email + "' WHERE `users`.`idusers` = '" + userAUpdate.IdUsers + "' ";

            if (OuvertureOk == true)
            {
                int NbrLignes = Bdd.RequeteNoData(requete);
                if (NbrLignes == 0)
                {
                    MessageBox.Show("La mise à jour à échoué");
                }
                else
                {
                    MessageBox.Show("mise à jour effectué avec succè");
                }
            }
        }



        public List<string> lireUser(Users userALire)
        {
            List<string> resultat = new List<string>();
            String requete = string.Format("SELECT * FROM users WHERE idusers ={0}", userALire.IdUsers);
            BddMysql bdd = new BddMysql("localhost", 3306, "xamaringestioncourse", "root", "");
            MySqlDataReader reader = bdd.RequeteSql(requete);
            if (reader != null)
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int nbrColonnes = reader.FieldCount;
                        string valeur = "";
                        for (int i = 0; i < nbrColonnes; i++)
                        {
                            valeur += reader.GetString(i) + "/";
                        }
                        resultat.Add(valeur);
                    }
                }
            }
            reader.Close();
            return resultat;

        }
    }
}
