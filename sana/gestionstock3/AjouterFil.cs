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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace gestionstock3
{
    public partial class AjouterFil : Form
    {
        public AjouterFil()
        {
            InitializeComponent();
            RemplirComboBox();
        }
        private void RemplirComboBox()
        {
            /*connexion ma3 l base de donnée */
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";
            string query = "SELECT code FROM fournisseurs";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        txtcodefournisseur.Items.Add(reader["code"].ToString());
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Une erreur est survenue: " + ex.Message);
                }
            }
        }

        private void AjouterFil_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodeMatricule.Text) ||
         string.IsNullOrEmpty(txtcomposition.Text) ||
         string.IsNullOrEmpty(txtcouleur.Text) ||
         string.IsNullOrEmpty(txtcodefournisseur.Text) ||
         string.IsNullOrEmpty(txttitre.Text) ||
         string.IsNullOrEmpty(txtresistance.Text) ||
         string.IsNullOrEmpty(txtallongment.Text) ||
         string.IsNullOrEmpty(txtenbivage.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";
            string query = @"INSERT INTO fils (`code`, `composition`,`couleur`, `codefournisseur`, `titre`, `resistance`, `allongment`,`enbivage`) 
              VALUES (@code,@composition, @couleur, @codefournisseur, @titre, @resistance, @allongment,@enbivage)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@code", txtCodeMatricule.Text);
                    command.Parameters.AddWithValue("@composition", txtcomposition.Text); // Convertir en int si c'est un nombre entier
                    command.Parameters.AddWithValue("@couleur", txtcouleur.Text);
                    command.Parameters.AddWithValue("@codefournisseur", txtcodefournisseur.Text);
                    command.Parameters.AddWithValue("@titre", txttitre.Text);
                    command.Parameters.AddWithValue("@resistance", txtresistance.Text);
                    command.Parameters.AddWithValue("@allongment", txtallongment.Text);
                    command.Parameters.AddWithValue("@enbivage", txtenbivage.Text);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Les données ont été enregistrées avec succès.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Une erreur est survenue : {ex.Message}");
                    }
                    finally
                    {
                        connection.Close();
                        // Fermer la connexion dans le bloc finally pour garantir qu'elle sera toujours fermée
                        MessageBox.Show("Fil ajouté avec succès.");
                        txtCodeMatricule.Text = "";
                        txtcomposition.Text = "";
                        txtcouleur.Text = "";
                        txtcodefournisseur.Text = "";
                        txttitre.Text = "";
                        txtresistance.Text = "";
                        txtallongment.Text = "";
                        txtenbivage.Text = "";
                    }
                }
            }
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
    }
}
