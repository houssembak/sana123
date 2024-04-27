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
using MySql.Data.MySqlClient; // Assurez-vous d'importer le bon namespace pour les types MySQL

namespace gestionstock3
{
    public partial class AjoutArticle : Form

    {

        public AjoutArticle()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void AjoutArticle_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtreference.Text) ||
            string.IsNullOrEmpty(txtdesignation.Text) ||
    string.IsNullOrEmpty(txtlargeur.Text) ||
    string.IsNullOrEmpty(txtepaisseur.Text) ||
    string.IsNullOrEmpty(txtresistance.Text) ||
    string.IsNullOrEmpty(txtallongement.Text) ||
    string.IsNullOrEmpty(txttiragefilchaine.Text) ||
    string.IsNullOrEmpty(txtmetragefilchaine.Text) ||
    string.IsNullOrEmpty(txttiragefiltrame.Text) ||
    string.IsNullOrEmpty(txtmetragefiltrame.Text) ||
    string.IsNullOrEmpty(txttiragefilretenue.Text) ||
    string.IsNullOrEmpty(txtmetragefilretenue.Text))




            {
                // Afficher un message d'erreur si un champ est vide
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Arrêter l'exécution de la méthode
            }
            // Récupérer les valeurs des champs de texte
            string reference = txtreference.Text;
              string designation = txtdesignation.Text;
              string largeur = txtlargeur.Text;
              string epaisseur = txtepaisseur.Text;
              string resistance = txtresistance.Text;
              string allongement = txtallongement.Text;
              string tirageFilChaine = txttiragefilchaine.Text;
              string metrageFilChaine = txtmetragefilchaine.Text;
              string tirageFilTrame = txttiragefiltrame.Text;
              string metrageFilTrame = txtmetragefiltrame.Text;
              string tirageFilRetenue = txttiragefilretenue.Text;
              string metrageFilRetenue = txtmetragefilretenue.Text;

              string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";

            // Requête d'insertion SQL
            string query = "INSERT INTO articles (reference, designation, largeur, epaisseur, resistance, allongement, `tirage fil chaine`, `metrage fil chaine`, `tirage fil trame`, `metrage fil trame`, `tirage fil retenue`, `metrage fil retenue`) " +
             "VALUES (@reference, @designation, @largeur, @epaisseur, @resistance, @allongement, @tirageFilChaine, @metrageFilChaine, @tirageFilTrame, @metrageFilTrame, @tirageFilRetenue, @metrageFilRetenue)";

            // Création de la commande SQL avec paramètres
            using (MySqlConnection connection = new MySqlConnection(connectionString))

              {
                  using (MySqlCommand command = new MySqlCommand(query, connection))
                  {
                      // Ouvrir la connexion
                      connection.Open();
                      command.Parameters.AddWithValue("@reference", reference);
                      command.Parameters.AddWithValue("@designation", designation);
                      command.Parameters.AddWithValue("@largeur", largeur);
                      command.Parameters.AddWithValue("@epaisseur", epaisseur);
                      command.Parameters.AddWithValue("@resistance", resistance);
                      command.Parameters.AddWithValue("@allongement", allongement);
                      command.Parameters.AddWithValue("@tirageFilChaine", tirageFilChaine);
                      command.Parameters.AddWithValue("@metrageFilChaine", metrageFilChaine);
                      command.Parameters.AddWithValue("@tirageFilTrame", tirageFilTrame);
                      command.Parameters.AddWithValue("@metrageFilTrame", metrageFilTrame);
                      command.Parameters.AddWithValue("@tirageFilRetenue", tirageFilRetenue);
                      command.Parameters.AddWithValue("@metrageFilRetenue", metrageFilRetenue);
                      // Exécuter la commande
                      command.ExecuteNonQuery();

                      // Fermer la connexion
                      connection.Close();
                    // Afficher un message ou effectuer une action après l'insertion des données
                    MessageBox.Show("Article ajouté avec succès.");
                    txtreference.Text="";
                    txtdesignation.Text = "";
                    txtlargeur.Text = "";
                    txtepaisseur.Text = "";
                    txtresistance.Text = "";
                    txtallongement.Text = "";
                    txttiragefilchaine.Text = "";
                    txtmetragefilchaine.Text = "";
                    txttiragefiltrame.Text = "";
                    txtmetragefiltrame.Text = "";
                    txttiragefilretenue.Text = "";
                    txtmetragefilretenue.Text = "";


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
    

