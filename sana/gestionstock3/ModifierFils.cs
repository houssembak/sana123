using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace gestionstock3
{
    public partial class ModifierFils : Form
    {
        public ModifierFils()
        {
            InitializeComponent();
            // Vérifier si un gestionnaire d'événements est déjà attaché
           
            
                button1.Click += button1_Click;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string code = Microsoft.VisualBasic.Interaction.InputBox("Entrez le code de votre Fil :", "Code fil", "");

            // Vérifier si l'utilisateur a saisi une valeur
            if (!string.IsNullOrEmpty(code))
            {
                ChargerDonnees(code);
            }
            else
            {
                MessageBox.Show("Vous devez entrer un Code non disponible.");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Confirmez-vous la modification ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";
                    string updateQuery = "UPDATE fils SET id=id, code=@code, composition=@composition, couleur=@couleur, codefournisseur=@codefournisseur, titre=@titre, resistance=@resistance, allongment=@allongment, enbivage=@enbivage WHERE id = @id";

                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                        {
                            command.Parameters.AddWithValue("id", txtid.Text);
                            command.Parameters.AddWithValue("@code", txtCodeMatricule.Text);
                            command.Parameters.AddWithValue("@composition", txtcomposition.Text);
                            command.Parameters.AddWithValue("@couleur", txtcouleur.Text);
                            command.Parameters.AddWithValue("@codefournisseur", txtcodefournisseur.Text);
                            command.Parameters.AddWithValue("@titre", txttitre.Text);
                            command.Parameters.AddWithValue("@resistance", txtresistance.Text);
                            command.Parameters.AddWithValue("@allongment", txtallongment.Text);
                            command.Parameters.AddWithValue("@enbivage", txtenbivage.Text);
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Modification enregistrée avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Aucune modification n'a été enregistrée.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Une erreur est survenue lors de l'enregistrement de la modification : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Une erreur générale est survenue : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void ChargerDonnees(string code)
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id, code, composition, couleur, codefournisseur, titre, resistance, allongment, enbivage FROM fils WHERE code=@code";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@code", code);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtid.Text = reader["id"].ToString();
                                txtCodeMatricule.Text = reader["code"].ToString();
                                txtcomposition.Text = reader["composition"].ToString();
                                txtcouleur.Text = reader["couleur"].ToString();
                                txtcodefournisseur.Text = reader["codefournisseur"].ToString();
                                txttitre.Text = reader["titre"].ToString();
                                txtresistance.Text = reader["resistance"].ToString();
                                txtallongment.Text = reader["allongment"].ToString();
                                txtenbivage.Text = reader["enbivage"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Aucune donnée trouvée pour ce code.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Une erreur est survenue lors de la connexion à la base de données : {ex.Message}");
                }
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

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


