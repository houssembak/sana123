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
    public partial class ListesTisserand : Form
    {
        public ListesTisserand()
        {
            InitializeComponent();
        }

        private void ListesTisserand_Load(object sender, EventArgs e)
        {
            // Configuration initiale du DataGridView
            ConfigurerDataGridView();

            // Remplir le DataGridView avec les données des articles
            RemplirDataGridView();
        }
        private void ConfigurerDataGridView()
        {
            // Ajout des colonnes au DataGridView
            dataGridView1.Columns.Add("code", "code");
            dataGridView1.Columns.Add("nom", "nom");
            dataGridView1.Columns.Add("prenom", "prenom");
            dataGridView1.Columns.Add("sexe", "sexe");
            dataGridView1.Columns.Add("etatcivile", "etatcivile");
            dataGridView1.Columns.Add("adresse", "adresse");
            dataGridView1.Columns.Add("tel", "tel");
            dataGridView1.Columns.Add("equipe", "equipe");
            dataGridView1.Columns.Add("presence", "presence");
            // Réglez les propriétés supplémentaires des colonnes si nécessaire
            // Exemple : dataGridView1.Columns["reference"].Width = 100;
        }
        private void RemplirDataGridView()
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";
            // Assurez-vous que cette requête correspond aux noms de colonnes dans votre base de données
            string query = "SELECT `code`, `nom`, `prenom`, `sexe` , `etatcivile`,`adresse`,`tel`,`equipe`,`presence`  FROM tisserands";

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
                                reader["code"].ToString(),
                                reader["nom"].ToString(),
                                reader["prenom"].ToString(),
                                reader["sexe"].ToString(),
                                reader["etatcivile"].ToString(),
                                reader["adresse"].ToString(),
                                reader["tel"].ToString(),
                                reader["equipe"].ToString(),
                                reader["presence"].ToString()

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
    }
}
