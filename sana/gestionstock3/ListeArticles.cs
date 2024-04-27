using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace gestionstock3
{
    public partial class ListeArticles : Form
    {
        public ListeArticles()
        {
            InitializeComponent();
        }

        private void ListeArticles_Load(object sender, EventArgs e)
        {
            // Configuration initiale du DataGridView
            ConfigurerDataGridView();

            // Remplir le DataGridView avec les données des articles
            RemplirDataGridView();
        }

        private void ConfigurerDataGridView()
        {
            // Ajout des colonnes au DataGridView
            dataGridView1.Columns.Add("reference", "Référence");
            dataGridView1.Columns.Add("designation", "Désignation");
            dataGridView1.Columns.Add("largeur", "Largeur");
            dataGridView1.Columns.Add("epaisseur", "Épaisseur");
            dataGridView1.Columns.Add("resistance", "Résistance");
            dataGridView1.Columns.Add("allongement", "Allongement");
            dataGridView1.Columns.Add("tirageFilChaine", "Tirage Fil Chaine");
            dataGridView1.Columns.Add("metrageFilChaine", "Métrage Fil Chaine");
            dataGridView1.Columns.Add("tirageFilTrame", "Tirage Fil Trame");
            dataGridView1.Columns.Add("metrageFilTrame", "Métrage Fil Trame");
            dataGridView1.Columns.Add("tirageFilRetenue", "Tirage Fil Retenue");
            dataGridView1.Columns.Add("metrageFilRetenue", "Métrage Fil Retenue");

            // Réglez les propriétés supplémentaires des colonnes si nécessaire
            // Exemple : dataGridView1.Columns["reference"].Width = 100;
        }

        private void RemplirDataGridView()
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";
            string query = "SELECT * FROM articles";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        // Vider les lignes existantes dans le DataGridView
                        dataGridView1.Rows.Clear();

                        // Parcourir chaque ligne de données récupérée
                        while (reader.Read())
                        {
                            // Ajouter une nouvelle ligne dans le DataGridView avec les données de l'article
                            dataGridView1.Rows.Add(
                                reader["reference"].ToString(),
                                reader["designation"].ToString(),
                                reader["largeur"].ToString(),
                                reader["epaisseur"].ToString(),
                                reader["resistance"].ToString(),
                                reader["allongement"].ToString(),
                                reader["tirage fil chaine"].ToString(),
                                reader["metrage fil chaine"].ToString(),
                                reader["tirage fil trame"].ToString(),
                                reader["metrage fil trame"].ToString(),
                                reader["tirage fil retenue"].ToString(),
                                reader["metrage fil retenue"].ToString()
                            );
                        }
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
