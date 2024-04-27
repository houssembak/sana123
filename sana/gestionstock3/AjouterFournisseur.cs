using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // Assurez-vous d'importer le bon namespace pour les types MySQL


namespace gestionstock3
{
    public partial class AjouterFournisseur : Form
    {
        public AjouterFournisseur()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Vérifier si tous les champs sont remplis
            if (string.IsNullOrEmpty(txtCodeMatricule.Text) ||
                string.IsNullOrEmpty(txttva.Text) ||
                string.IsNullOrEmpty(txtsociete.Text) ||
                string.IsNullOrEmpty(txtpays.Text) ||
                string.IsNullOrEmpty(txtemail.Text) ||
                string.IsNullOrEmpty(txttelephone.Text) ||
                string.IsNullOrEmpty(txtremarque.Text))
            {
                // Afficher un message d'erreur si un champ est vide
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Arrêter l'exécution de la méthode
            }
            // Définir la chaîne de connexion à votre base de données
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";

            // Créer la requête SQL pour insérer les données
            string query = "INSERT INTO fournisseurs (code,tva, societe, Pays, email, tel, remarque) VALUES (@code,@tva , @societe, @Pays, @email, @tel, @remarque)";

            // Créer une connexion MySQL
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // Créer une commande MySQL
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Ouvrir la connexion
                    connection.Open();

                    // Associer les valeurs des contrôles de formulaire aux paramètres de la commande
                    command.Parameters.AddWithValue("@code", txtCodeMatricule.Text);
                    command.Parameters.AddWithValue("@tva", txttva.Text);
                    command.Parameters.AddWithValue("@societe", txtsociete.Text);
                    command.Parameters.AddWithValue("@Pays", txtpays.Text);
                    command.Parameters.AddWithValue("@email", txtemail.Text);
                    command.Parameters.AddWithValue("@tel", txttelephone.Text);
                    command.Parameters.AddWithValue("@remarque", txtremarque.Text);

                    // Exécuter la commande
                    command.ExecuteNonQuery();

                    // Fermer la connexion
                    connection.Close();
                }
            }

            // Afficher un message ou effectuer une action après l'insertion des données
            MessageBox.Show("Fournisseur ajouté avec succès.");
            txtCodeMatricule.Text = "";
            txttva.Text = "";
            txtsociete.Text = "";
            txtpays.Text = "";
            txtemail.Text = "";
            txttelephone.Text = "";
            txtremarque.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Afficher une boîte de dialogue de confirmation
            DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir quitter ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Vérifier la réponse de l'utilisateur
            if (result == DialogResult.Yes)
            {
                // Si l'utilisateur clique sur "Oui", fermer l'interface
                this.Close();
            }
            // Si l'utilisateur clique sur "Non", ne rien faire (rester sur l'interface)
        }

        private void AjouterFournisseur_Load(object sender, EventArgs e)
        {

        }
    }
}