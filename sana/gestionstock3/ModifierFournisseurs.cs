using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace gestionstock3
{
    public partial class ModifierFournisseurs : Form
    {
        public ModifierFournisseurs()
        {
            InitializeComponent();
            button1.Click += button1_Click;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string code = Microsoft.VisualBasic.Interaction.InputBox("Entrez le code de votre Fournisseur  :", "Code fournisseur", "");

            // Vérifier si l'utilisateur a saisi une valeur
            if (!string.IsNullOrEmpty(code))
            {

                ChargerDonnees(code);
            }
            else
            {
                MessageBox.Show("Vous devez entrer un Code de planification.");
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
                    string query = "SELECT id, code, tva, societe, Pays, email, tel, remarque FROM fournisseurs WHERE code = @code";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@code", code);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtid.Text = reader["id"].ToString();
                                txtCodeMatricule.Text = reader["code"].ToString();
                                txttva.Text = reader["tva"].ToString();
                                txtsociete.Text = reader["societe"].ToString();
                                txtpays.Text = reader["Pays"].ToString();
                                txtemail.Text = reader["email"].ToString();
                                txttelephone.Text = reader["tel"].ToString();
                                txtremarque.Text = reader["remarque"].ToString();
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


        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Confirmez-vous la modification ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";
                    string updateQuery = "UPDATE fournisseurs SET id=@id, code = @code, tva = @tva, societe = @societe, Pays = @pays, email = @email, tel = @tel, remarque = @remarque WHERE id = @id";

                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                        {
                            command.Parameters.AddWithValue("id",txtid.Text);
                            command.Parameters.AddWithValue("@code", txtCodeMatricule.Text);
                            command.Parameters.AddWithValue("@tva", txttva.Text);
                            command.Parameters.AddWithValue("@societe", txtsociete.Text);
                            command.Parameters.AddWithValue("@pays", txtpays.Text);
                         /*   command.Parameters.AddWithValue("@id", id);*/
                            command.Parameters.AddWithValue("@email", txtemail.Text);
                            command.Parameters.AddWithValue("@tel", txttelephone.Text);
                            command.Parameters.AddWithValue("@remarque", txtremarque.Text);

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

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }



}
    
   

