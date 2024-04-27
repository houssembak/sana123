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
    public partial class AjouterMachine : Form
    {
        public AjouterMachine()
        {
            InitializeComponent();
            RemplirComboBox();
        }
        private void RemplirComboBox()
        {
            /*connexion ma3 l base de donnée */
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";
            string query = "SELECT code FROM tisserands";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader["code"].ToString());
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Une erreur est survenue: " + ex.Message);
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodeMatricule.Text) ||
                string.IsNullOrEmpty(txtmarque.Text) ||
                string.IsNullOrEmpty(comboBox1.Text) ||
                string.IsNullOrEmpty(txtensouple.Text))

            {
                // Afficher un message d'erreur si un champ est vide
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Arrêter l'exécution de la méthode
            }
            string code=txtCodeMatricule.Text;
            string marque=txtmarque.Text;
          
            string tisserand= comboBox1.Text;
            string ensouple=txtensouple.Text;
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";
            string query = "INSERT INTO parcmachine (code, marque, tisserand, nbreesouples) " +
                 "VALUES (@code, @marque,@tisserand, @nbesouples)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))

            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Ouvrir la connexion
                    connection.Open();
                    command.Parameters.AddWithValue("@code", code);
                    command.Parameters.AddWithValue("@marque", marque);
                    command.Parameters.AddWithValue("@tisserand", tisserand);
                    command.Parameters.AddWithValue("@nbesouples", ensouple);
                    
                    // Exécuter la commande
                    command.ExecuteNonQuery();

                    // Fermer la connexion
                    connection.Close();
                    // Afficher un message ou effectuer une action après l'insertion des données
                    MessageBox.Show("Machine ajouté avec succès.");
                    txtCodeMatricule.Text = "";
                    txtmarque.Text = "";
                    comboBox1.Text = "";
                    txtensouple.Text = "";
                }
            }

        }

        private void txtmarque_TextChanged(object sender, EventArgs e)
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

        private void AjouterMachine_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
