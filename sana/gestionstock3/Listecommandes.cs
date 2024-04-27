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
    public partial class Listecommandes : Form
    {
        public Listecommandes()
        {
            InitializeComponent();
        }

        private void Listecommandes_Load(object sender, EventArgs e)
        {
            // Configuration initiale du DataGridView
            ConfigurerDataGridView();

            // Remplir le DataGridView avec les données des articles
            RemplirDataGridView();
        }
        private void ConfigurerDataGridView()
        {
            // Ajout des colonnes au DataGridView
            dataGridView1.Columns.Add("OF", "OF");
            dataGridView1.Columns.Add("designation", "designation");
            dataGridView1.Columns.Add("Quantité à fabriquer", "Quantité à fabriquer");
            dataGridView1.Columns.Add("Nombre de bande", "Nombre de bande");
            dataGridView1.Columns.Add("Code machines", "Code machines");
             // Réglez les propriétés supplémentaires des colonnes si nécessaire
            // Exemple : dataGridView1.Columns["reference"].Width = 100;
        }
        private void RemplirDataGridView()
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";
            // Assurez-vous que cette requête correspond aux noms de colonnes dans votre base de données
            string query = "SELECT `OF`, `designation`, `quantite fabriquer` AS `Quantité à fabriquer`, `nombre de bande` AS `Nombre de bande`, `code machines` AS `Code machines` FROM commande";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        dataGridView1.Rows.Clear();

                        while (reader.Read())
                        {
                            dataGridView1.Rows.Add(
                                reader["OF"].ToString(),
                                reader["designation"].ToString(),
                                reader["Quantité à fabriquer"].ToString(),
                                reader["Nombre de bande"].ToString(),
                                reader["Code machines"].ToString()
                            );
                        }
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
