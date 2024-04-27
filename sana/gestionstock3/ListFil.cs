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
    public partial class ListFil : Form
    {
        public ListFil()
        {
            InitializeComponent();
        }

        private void ListFil_Load(object sender, EventArgs e)
        {
            ConfigurerDataGridView();

            // Remplir le DataGridView avec les données des articles
            RemplirDataGridView();
        }
        private void ConfigurerDataGridView()
        {
            // Ajout des colonnes au DataGridView
            dataGridView1.Columns.Add("code", "code");
            dataGridView1.Columns.Add("composition", "composition");
            dataGridView1.Columns.Add("couleur", "couleur");
            dataGridView1.Columns.Add("codefournisseur", "codefournisseur");
            dataGridView1.Columns.Add("titre", "titre");
            dataGridView1.Columns.Add("resistance", "resistance");
            dataGridView1.Columns.Add("allongment", "allongment");
            dataGridView1.Columns.Add("enbivage", "enbivage");
    
            // Réglez les propriétés supplémentaires des colonnes si nécessaire
            // Exemple : dataGridView1.Columns["reference"].Width = 100;
        }
       
        private void RemplirDataGridView()
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";
            // Assurez-vous que cette requête correspond aux noms de colonnes dans votre base de données
            string query = "SELECT `code`, `composition`, `couleur`, `codefournisseur` , `titre`,`resistance`,`allongment`,`enbivage` FROM fils";

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
                                reader["composition"].ToString(),
                                reader["couleur"].ToString(),
                                reader["codefournisseur"].ToString(),
                                reader["titre"].ToString(),
                                reader["resistance"].ToString(),
                                reader["allongment"].ToString(),
                                reader["enbivage"].ToString()

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

