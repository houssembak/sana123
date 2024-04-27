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
    public partial class HistoriquePlanification : Form
    {
        public HistoriquePlanification()
        {
            InitializeComponent();
        }

        private void HistoriquePlanification_Load(object sender, EventArgs e)
        {
            // Configuration initiale du DataGridView
            ConfigurerDataGridView();

            // Remplir le DataGridView avec les données des articles
            RemplirDataGridView();
        }
        private void ConfigurerDataGridView()
        {
            dataGridView1.Columns.Add("qte_Aproduire", "qte_Aproduire");
            dataGridView1.Columns.Add("date_jour", "date_jour");
            dataGridView1.Columns.Add("qte_produit", "qte_produit");
            dataGridView1.Columns.Add("qte_Restantes", "qte_Restantes");
            dataGridView1.Columns.Add("date_livraison", "date_livraison");

        }
        private void RemplirDataGridView()
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";
            string query = "SELECT qte_Aproduire, DATE_FORMAT(date_jour, '%Y-%m-%d') AS date_jour, qte_produit, qte_Restantes, DATE_FORMAT(date_livraison, '%Y-%m-%d') AS date_livraison FROM calculplanification";


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
                                reader["qte_Aproduire"].ToString(),
                                reader["date_jour"].ToString(),
                                reader["qte_produit"].ToString(),
                                reader["qte_Restantes"].ToString(),
                                reader["date_livraison"].ToString()
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
