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
    public partial class FichePlanification : Form
    {
        private string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";

        public FichePlanification()
        {
            InitializeComponent();
       
        }



        private void FichePlanification_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
         
    
            // Connexion à la base de données
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";
                // Requête pour vérifier si le code article existe dans la table productionplanification
                string query = "SELECT code_article, qte_produire, Date_commence FROM productionplanification";

                // Création d'une commande avec des paramètres
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {                   
                    try
                    {
                        // Ouverture de la connexion
                        connection.Open();

                        // Exécution de la commande
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            // Vérification s'il y a des résultats
                            if (reader.Read())
                            {
                                // Affichage des données dans les TextBox
                                textBox2.Text = reader["code_article"].ToString();
                                txtQuantiteAProduire.Text = reader["qte_produire"].ToString();
                                textBox3.Text = reader["Date_commence"].ToString();
                             

                           
                            }
                            else
                            {
                                MessageBox.Show("Code article non trouvé dans la base de données.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur lors de la récupération des données : " + ex.Message);
                    }
                }
            }
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";
                // Requête pour vérifier si le code article existe dans la table productionplanification
                string query = "SELECT OF FROM commande";

                // Création d'une commande avec des paramètres
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        // Ouverture de la connexion
                        connection.Open();

                        // Exécution de la commande
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            // Vérification s'il y a des résultats
                            if (reader.Read())
                            {
                                // Affichage des données dans les TextBox
                                textBox1.Text = reader["OF"].ToString();
                          


                                // Vous pouvez continuer à récupérer d'autres données si nécessaire

                            }
                            else
                            {
                                MessageBox.Show("Code article non trouvé dans la base de données.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur lors de la récupération des données : " + ex.Message);
                    }
                }
            }
            
            // Configuration initiale du DataGridView
            ConfigurerDataGridView();
            RemplirDataGridView();
        }
        private void ConfigurerDataGridView()
        {
     
            dataGridView1.Columns.Add("Date", "Date");
            dataGridView1.Columns.Add("Production Journalier", "Production Journalier");
            dataGridView1.Columns.Add("qte_Restantes", "qte_Restantes");
            dataGridView1.Columns.Add("date_livraison", "date_livraison");
        }
        private void RemplirDataGridView()
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";
            string query = "SELECT  DATE_FORMAT(date_jour, '%Y-%m-%d') AS date_jour, qte_produit, qte_Restantes, DATE_FORMAT(date_livraison, '%Y-%m-%d') AS date_livraison FROM calculplanification";


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


        private void txtProductionHoraire_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
