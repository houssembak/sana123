using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestionstock3
{
    public partial class NouvelleTisserand : Form
    {
        public NouvelleTisserand()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void NouvelleTisserand_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodeMatricule.Text) ||
               string.IsNullOrEmpty(txtnom.Text) ||
               string.IsNullOrEmpty(txtprenom.Text) ||
               string.IsNullOrEmpty(txtprenom.Text) ||
               string.IsNullOrEmpty(txtsexe.Text)||
               string.IsNullOrEmpty(txtetatcivil.Text) ||
               string.IsNullOrEmpty(txtadresse.Text) ||
               string.IsNullOrEmpty(txttelephone.Text) ||
               string.IsNullOrEmpty(txtequipe.Text) ||
               string.IsNullOrEmpty(txtpresence.Text) )

            {
                // Afficher un message d'erreur si un champ est vide
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Arrêter l'exécution de la méthode
            }
            string code = txtCodeMatricule.Text;
            string nom = txtnom.Text;
            string prenom = txtprenom.Text;
            string sexe = txtsexe.Text;
            string etatcivile = txtetatcivil.Text;
            string adresse=txtadresse.Text;
            string tel=txttelephone.Text;
            string equipe=txtequipe.Text;
            string presence=txtpresence.Text;
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";
            string query = "INSERT INTO tisserands (code, nom, prenom, sexe, etatcivile,adresse,tel,equipe,presence) " +
                 "VALUES (@code, @nom, @prenom, @sexe, @etatcivile,@adresse,@tel,@equipe,@presence)";
            using (MySqlConnection connection = new MySqlConnection(connectionString))

            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Ouvrir la connexion
                    connection.Open();
                    command.Parameters.AddWithValue("@code", code);
                    command.Parameters.AddWithValue("@nom", nom);
                    command.Parameters.AddWithValue("@prenom", prenom);
                    command.Parameters.AddWithValue("@sexe", sexe);
                    command.Parameters.AddWithValue("@etatcivile", etatcivile);
                    command.Parameters.AddWithValue("@adresse", adresse);
                    command.Parameters.AddWithValue("@tel", tel);
                    command.Parameters.AddWithValue("@equipe", equipe);
                    command.Parameters.AddWithValue("@presence", presence);
                    // Exécuter la commande
                    command.ExecuteNonQuery();
                    // Fermer la connexion
                    connection.Close();
                    // Afficher un message ou effectuer une action après l'insertion des données
                    MessageBox.Show("Machine ajouté avec succès.");
                    txtCodeMatricule.Text = "";
                    txtnom.Text = "";
                    txtprenom.Text = "";
                    txtsexe.Text = "";
                    txtetatcivil.Text = "";
                    txtadresse.Text = "";
                    txttelephone.Text = "";
                    txtequipe.Text = "";
                    txtpresence.Text = "";
                                    }
            }
        }
    }
}
