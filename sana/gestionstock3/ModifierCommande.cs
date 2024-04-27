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
    public partial class ModifierCommande : Form
    {
        public ModifierCommande()
        {
            InitializeComponent();
            
                }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string numeroOF = Microsoft.VisualBasic.Interaction.InputBox("Entrez Votre OF  :", "OF commande", "");

            // Vérifier si l'utilisateur a saisi une valeur
            if (!string.IsNullOrEmpty(numeroOF))
            {

                ChargerDonnees(numeroOF);
            }
            else
            {
                MessageBox.Show("Vous devez entrer un OF disponible.");
            }
        }
        public void ChargerDonnees(string numeroOF)
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id, `OF`, `code article`, `designation`, `quantite fabriquer` AS `Quantité à fabriquer`, `nombre de bande` AS `Nombre de bande`, `code machines` AS `Code machines` FROM commande WHERE `OF` = @numeroOF";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@numeroOF", numeroOF);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtid.Text = reader["id"].ToString();
                                txtof.Text = reader["OF"].ToString();
                                txtcodearcticle.Text = reader["code article"].ToString();
                                txtdesignation.Text = reader["designation"].ToString();
                                txtqtefabriquer.Text = reader["Quantité à fabriquer"].ToString();
                                txtnbbande.Text = reader["Nombre de bande"].ToString();
                                txtcodemachiines.Text = reader["Code machines"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Aucune donnée trouvée pour cet OF.");
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
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Confirmez-vous la modification ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";
                    string updateQuery = "UPDATE commande SET OF=@of, designation=@designation, `quantite fabriquer`=@quantitefabriquer, `nombre de bande`=@nombrebande, `code machines`=@codemachines WHERE id=@id";

                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                        {
                            command.Parameters.AddWithValue("@id", txtid.Text);
                            command.Parameters.AddWithValue("@of", txtof.Text);
                            command.Parameters.AddWithValue("@designation", txtdesignation.Text);
                            command.Parameters.AddWithValue("@quantitefabriquer", txtqtefabriquer.Text);
                            command.Parameters.AddWithValue("@nombrebande", txtnbbande.Text);
                            command.Parameters.AddWithValue("@codemachines", txtcodemachiines.Text);

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
