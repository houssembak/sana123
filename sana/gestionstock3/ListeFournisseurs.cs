using MySql.Data.MySqlClient;
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

namespace gestionstock3
{
    public partial class ListeFournisseurs : Form
    {
        public ListeFournisseurs()
        {
            InitializeComponent();
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
        }

        private void ListeFournisseurs_Load(object sender, EventArgs e)
        {
            // Configuration initiale du DataGridView
            ConfigurerDataGridView();

            // Remplir le DataGridView avec les données des fournisseurs
            RemplirDataGridView();
        }

        private void ConfigurerDataGridView()
        {
            // Ajout des colonnes au DataGridView
            dataGridView1.Columns.Add("Code", "Code");
            dataGridView1.Columns.Add("TVA", "TVA");
            dataGridView1.Columns.Add("Société", "Société");
            dataGridView1.Columns.Add("Pays", "Pays");
            dataGridView1.Columns.Add("Email", "Email");
            dataGridView1.Columns.Add("Téléphone", "Téléphone");
            dataGridView1.Columns.Add("Remarque", "Remarque");
        }

        private void RemplirDataGridView()
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";
            string query = "SELECT * FROM fournisseurs";

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
                            // Ajouter une nouvelle ligne dans le DataGridView avec les données du fournisseur
                            dataGridView1.Rows.Add(
                                reader["code"].ToString(),
                                reader["tva"].ToString(),
                                reader["societe"].ToString(),
                                reader["pays"].ToString(),
                                reader["email"].ToString(),
                                reader["tel"].ToString(),
                                reader["remarque"].ToString()
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
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Récupérer les données de la ligne sélectionnée
            DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
            string code = selectedRow.Cells["Code"].Value.ToString();
            string tva = selectedRow.Cells["TVA"].Value.ToString();
            string societe = selectedRow.Cells["Société"].Value.ToString();
            string pays = selectedRow.Cells["Pays"].Value.ToString();
            string email = selectedRow.Cells["Email"].Value.ToString();
            string tel = selectedRow.Cells["Téléphone"].Value.ToString();
            string remarque = selectedRow.Cells["Remarque"].Value.ToString();

            // Afficher les données dans un formulaire de modification
            // Par exemple, vous pouvez créer une nouvelle instance d'un formulaire de modification et lui transmettre ces données
            // ModifySupplierForm modifyForm = new ModifySupplierForm(code, tva, societe, pays, email, tel, remarque);
            // modifyForm.ShowDialog();
            // Dans le formulaire de modification, vous permettez à l'utilisateur de modifier les données et enregistrer les modifications

            // Après l'enregistrement des modifications dans le formulaire de modification, rafraîchir le DataGridView pour afficher les modifications
            RemplirDataGridView();
        }
        // Dans la méthode dataGridView1_CellDoubleClick, après l'affichage des données dans le formulaire de modification :
        // L'utilisateur a modifié les données et cliqué sur le bouton "Enregistrer"
       


    }
}
