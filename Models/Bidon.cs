using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_emrac_connexion.Models
{
    class Bidon
    {


if (isset($_POST) && !empty($_POST)) {
    $email = $_POST['email'];
    $password = $_POST['password'];


    if (!empty($email)  && !empty($password) ) {

        //si login valide et email valide et mot de passe valide et mot mot de passe identique à sa confirmation,  on essaie de se connecter à la BDD

        require 'inc/config-bdd.php';

        //On essaie de se connecter à la BDD
        try {
            $conn = new PDO($dsn, $user, $pass);
            //On définit le mode d'erreur de PDO sur Exception
            $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

            //vérification en base de données
            $verifbdd=$conn->prepare("SELECT email, pseudo, password  FROM users WHERE email= ?");
            $verifbdd->execute(array("$email"));
            $resultat=$verifbdd->fetch();


            if (strlen($resultat['email']) != 0){
                // si le mail entré et le mail de la requête résultat sont identique et
                // si le password entré transformé en hash et le password de la requête résultat sont identique
                if (($email === $resultat['email']) && (password_verify($password,$resultat['password']))){

                    // enregistre le mail comme variable de session
                    $_SESSION['email']=$email;
                    // enregistre le mdp comme variable de session
                    $_SESSION['password']=$password;
                    // enregistre le pseudo comme variable de session
                    $_SESSION['pseudo']=$resultat['pseudo'];
                    header('location: appli.php');
                }else echo "le mot de passe associé à cet identifiant est incorrecte";
            }
            else{
                echo "identifiant et (ou) mot de passe incorrect";
            }


            /*$resultat = $verifbdd->rowCount();*/

            //si le login est déjà connu en base de données car la variable est pleine

            /*$requete=$conn->prepare("INSERT INTO user (login,password,email,date_inscription) VALUES (?,?,?,?)");
            $passwordmasque=password_hash("$password",PASSWORD_DEFAULT);
            $requete->execute(array("$login","$passwordmasque","$email",'2020-03-02 13:00:00'));*/


        }
        catch (PDOException $e) {
            echo "Erreur : " . $e->getMessage();
        }
        //ferme la connexion à la base de donnée
        $conn = null;

        // applique ci-dessous si au moins un des champs du formulaire est vide
    } else {
        if (empty($email)) {
            ?>
            <div style = "color: red;text-align: center" xmlns="http://www.w3.org/1999/html"><? php echo "veuillez compléter le champs Email <br/>"; ?></div><? php
        }

        if (empty($password)) {
            ?> <div style = "color: red;text-align: center" ><? php echo "veuillez compléter le champs password <br/>";?></div><? php
        }

    }
}
?>
    }
}
