using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WPF_emrac_connexion
{
    class BddMysql
    {
        // connexion bdd sur always data
        //$servername = 'mysql-emrac-connexion.alwaysdata.net';
        //$table = 'emrac-connexion_bdd';
        //$user = '236713';
        //$pass = '1alwaysLAmouche';
        //$dsn="mysql:host=$servername;dbname=$table";


        // connexion bdd sur wampserver
        //$servername = 'localhost';
        //$table = 'xamaringestioncourse';
        //$user = 'root';
        //$pass = '';
        //$dsn="mysql:host=$servername;dbname=$table";

        private MySqlConnection Connexion;
        private String AdrServeur, NomBdd, Utilisateur, MotPasse;
        private int NumPort;
        private String ChaineConnexion;
        private string _Erreur;
        private bool EstConnecte;

        public BddMysql(string Serv, int Port, string Bdd, string User, string Pass)
        {
            AdrServeur = Serv;
            NomBdd = Bdd;
            Utilisateur = User;
            MotPasse = Pass;
            NumPort = Port;
            ChaineConnexion = "Server=" + AdrServeur +
                              ";Database=" + NomBdd +
                              ";port=" + NumPort +
                              ";User Id=" + Utilisateur +
                              ";password=" + MotPasse;

            Connexion = new MySqlConnection(ChaineConnexion); // Création de l'objet Connexion
            EstConnecte = false;                              // Connexion fermée par défaut


        }

        public BddMysql(string Serv, string Bdd, string User, string Pass)
        {
            AdrServeur = Serv;
            NomBdd = Bdd;
            Utilisateur = User;
            MotPasse = Pass;
            ChaineConnexion = "Server=" + AdrServeur +
                              ";Database=" + NomBdd +
                              ";User Id=" + Utilisateur +
                              ";password=" + MotPasse;

            Connexion = new MySqlConnection(ChaineConnexion); // Création de l'objet Connexion
            EstConnecte = false;                              // Connexion fermée par défaut


        }

        public bool OuvrirConnexion()
        {
            try
            {
                Connexion.Open();
                EstConnecte = true;
            }

            catch (Exception Er)
            {
                _Erreur = Er.Message;
            }

            return EstConnecte;
        }

        public bool FermerConnexion()
        {
            try
            {
                Connexion.Close();
                EstConnecte = false;
            }

            catch (Exception Er)
            {
                _Erreur = Er.Message;
            }

            return EstConnecte;
        }

        public string Erreur
        {
            get { return _Erreur; }
        }

        public MySqlDataReader RequeteSql(String Requete)
        {
            MySqlCommand CmdSql = new MySqlCommand(Requete, Connexion);
            MySqlDataReader Reader = null;

            if (EstConnecte == true)
            {
                try
                {
                    Reader = CmdSql.ExecuteReader();
                }
                catch (Exception Er)
                {
                    _Erreur = Er.Message;
                }
            }
            return Reader;
        }

        public int RequeteNoData(String Requete)
        {
            MySqlCommand CmdSqlNoData = new MySqlCommand(Requete, Connexion);
            int NbLignesModifiees = 0;

            if (EstConnecte == true)
            {
                try
                {
                    NbLignesModifiees = CmdSqlNoData.ExecuteNonQuery();
                }
                catch (MySqlException Er)
                {
                    _Erreur = Er.Message;
                }
            }
            return NbLignesModifiees;
        }

        public List<string> AvoirListe(string table)
        {
            List<string> resultat = new List<string>();

            String requete = string.Format("select * from {0}", table);
            MySqlDataReader reader = RequeteSql(requete);
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

        public List<string> AvoirListe(string table, int id)
        {
            List<string> resultat = new List<string>();

            String requete = string.Format("SELECT * from {0} WHERE idClub = {1} ", table, id);
            MySqlDataReader reader = RequeteSql(requete);
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

        public List<string> AvoirListe(string table, string email)
        {
            List<string> resultat = new List<string>();

            String requete = string.Format("select * from {0} WHERE email = {1} ", table, email);
            MySqlDataReader reader = RequeteSql(requete);
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
