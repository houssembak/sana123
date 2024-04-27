using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestionstock3
{
    public partial class AjouterCommande : Form
    {
        public AjouterCommande()
        {
            InitializeComponent();
        }

        private void AjouterCommande_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtof.Text) ||
            string.IsNullOrEmpty(txtdesignation.Text) ||
            string.IsNullOrEmpty(txtqtefabriquer.Text) ||
            string.IsNullOrEmpty(txtnbbande.Text) ||
            string.IsNullOrEmpty(txtcodemachiines.Text))
    




            {
                // Afficher un message d'erreur si un champ est vide
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Arrêter l'exécution de la méthode
            }
            // Récupérer les valeurs des champs de texte
            string of = txtof.Text;
            string codearticle= txtcodearcticle.Text;
            string designation= txtdesignation.Text;
            string qtefabriquer= txtqtefabriquer.Text;
            string nombrebande =  txtnbbande.Text;
            string codemachines = txtcodemachiines.Text;

            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";

            // Requête d'insertion SQL
            string query = "INSERT INTO commande (`OF`, designation, `quantite fabriquer`, `nombre de bande`, `code machines`) " +
                     "VALUES (@of, @designation, @qtefabriquer, @nbbande, @codemachine)";

            // Création de la commande SQL avec paramètres
            using (MySqlConnection connection = new MySqlConnection(connectionString))

            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Ouvrir la connexion
                    connection.Open();
                    command.Parameters.AddWithValue("@of", of);
                    command.Parameters.AddWithValue("@designation", designation);
                    command.Parameters.AddWithValue("@qtefabriquer", qtefabriquer);
                    command.Parameters.AddWithValue("@nbbande", nombrebande);
                    command.Parameters.AddWithValue("@codemachine", codemachines);

                    // Exécuter la commande
                    command.ExecuteNonQuery();

                    // Fermer la connexion
                    connection.Close();
                    // Afficher un message ou effectuer une action après l'insertion des données
                    MessageBox.Show("Commande ajouté avec succès.");
                    txtof.Text = "";
                    txtdesignation.Text = "";
                    txtqtefabriquer.Text = "";
                    txtnbbande.Text = "";
                    txtcodemachiines.Text = "";
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
