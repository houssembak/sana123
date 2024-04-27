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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace gestionstock3
{
    public partial class ModifierPlanification : Form
    {
        public ModifierPlanification()
        {
            InitializeComponent();
            RemplirComboBox();
            RemplirComboBox2();
            // Remplir la ComboBox avec des numéros de 1 à 6
            for (int numero = 1; numero <= 6; numero++)
            {
                cbNumeroDeBande.Items.Add(numero);
            }
            // Optionnel: Sélectionnez un élément par défaut
            cbNumeroDeBande.SelectedIndex = 0;
        }
        private void RemplirComboBox()
        {
            /*connexion ma3 l base de donnée */
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";
            string query = "SELECT reference FROM articles";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        txtcodearticle.Items.Add(reader["reference"].ToString());
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Une erreur est survenue: " + ex.Message);
                }
            }
        }
        private void RemplirComboBox2()
        {
            /*connexion ma3 l base de donnée */
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";
            string query = "SELECT code FROM parcmachine";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        comboBox2.Items.Add(reader["code"].ToString());
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Une erreur est survenue: " + ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string code = Microsoft.VisualBasic.Interaction.InputBox("Entrez le code de votre Code planification  :", "Code Planification", "");

            // Vérifier si l'utilisateur a saisi une valeur
            if (!string.IsNullOrEmpty(code))
            {

                ChargerDonnees(code);
            }
            else
            {
                MessageBox.Show("Vous devez entrer un Code  machine.");
            }
        }
        public void ChargerDonnees(string code)
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id_planification, code_planification, code_article, qte_produire, production_horaire, Nb_jour_estimé,Production_journalier,nombre_de_bande,machines,\tDate_commence FROM productionplanification WHERE code_planification = @code";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@code", code);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBox3.Text = reader["id_planification"].ToString();
                                textBox1.Text = reader["code_planification"].ToString();
                                txtcodearticle.Text = reader["code_article"].ToString();
                                txtQuantiteAProduire.Text = reader["qte_produire"].ToString();
                                txtProductionHoraire.Text = reader["production_horaire"].ToString();
                                txtNombreDeJoursEstimes.Text = reader["Nb_jour_estimé"].ToString();
                                txtProductionJournaliere.Text = reader["Production_journalier"].ToString();
                               cbNumeroDeBande.Text = reader["nombre_de_bande"].ToString();
                                comboBox2.Text = reader["machines"].ToString();
                                textBox2.Text = reader["Date_commence"].ToString();
                             
                            }
                            else
                            {
                                MessageBox.Show("Aucune donnée trouvée pour ce code.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Une erreur est survenue lors de la connexion à la base de données : {ex.Message}");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Étape 1 : Récupérer les valeurs
            string productionHoraireStr = txtProductionHoraire.Text;
            string numeroDeBandeStr = cbNumeroDeBande.SelectedItem.ToString();

            // Étape 2 : Convertir en nombres
            bool isProductionHoraireNumeric = double.TryParse(productionHoraireStr, out double productionHoraire);
            bool isNumeroDeBandeNumeric = int.TryParse(numeroDeBandeStr, out int numeroDeBande);

            // Vérifiez si les conversions sont réussies
            if (isProductionHoraireNumeric && isNumeroDeBandeNumeric)
            {
                // Étape 3 : Effectuer le calcul
                double resultat = productionHoraire * numeroDeBande * 23.25;

                // Étape 4 : Afficher le résultat
                txtProductionJournaliere.Text = resultat.ToString();
            }
            else
            {
                MessageBox.Show("Veuillez entrer des valeurs numériques valides pour la production horaire et le numéro de bande.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Étape 1 : Récupérer les valeurs
            string quantiteAProduireStr = txtQuantiteAProduire.Text;
            string productionJournaliereStr = txtProductionJournaliere.Text;

            // Étape 2 : Convertir en nombres
            bool isQuantiteAProduireNumeric = double.TryParse(quantiteAProduireStr, out double quantiteAProduire);
            bool isProductionJournaliereNumeric = double.TryParse(productionJournaliereStr, out double productionJournaliere);

            // Vérifiez si les conversions sont réussies
            if (isQuantiteAProduireNumeric && isProductionJournaliereNumeric && productionJournaliere != 0)
            {
                // Étape 3 : Effectuer le calcul
                double resultat = quantiteAProduire / productionJournaliere;

                // Vérifier si le résultat a une partie décimale
                if (resultat % 1 != 0)
                {
                    // Si le résultat a une partie décimale, ajouter 1
                    resultat = Math.Floor(resultat) + 1;
                }

                // Étape 4 : Afficher le résultat
                txtNombreDeJoursEstimes.Text = resultat.ToString();
            }
            else
            {
                MessageBox.Show("Veuillez entrer des valeurs numériques valides pour la quantité à produire et la production journalière.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ( string.IsNullOrEmpty(textBox3.Text)||
               string.IsNullOrEmpty(textBox1.Text) ||
               string.IsNullOrEmpty(txtcodearticle.Text) ||
               string.IsNullOrEmpty(txtProductionHoraire.Text) ||
               string.IsNullOrEmpty(txtProductionJournaliere.Text) ||
               string.IsNullOrEmpty(txtQuantiteAProduire.Text) ||
               string.IsNullOrEmpty(txtNombreDeJoursEstimes.Text) ||
               string.IsNullOrEmpty(cbNumeroDeBande.Text) ||
               string.IsNullOrEmpty(comboBox2.Text) ||
               string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";
            string query = @"UPDATE productionplanification SET 
                 `code_article` = @CodeArticle, 
                 `qte_produire` = @QuantiteAProduire, 
                 `production_horaire` = @ProductionHoraire, 
                 `Nb_jour_estimé` = @NombreDeJoursEstimes, 
                 `Production_journalier` = @ProductionJournaliere, 
                 `nombre_de_bande` = @NombreDeBandes, 
                 `machines` = @machines, 
                 `Date_commence` = @Date_commence 
                 WHERE `id_planification` = @idplanification";
            // Requête d'insertion pour la table parcmachine
            string queryParcMachine = @"UPDATE parcmachine SET `Date_commence` = @Date_commence WHERE Utilisée = @Utilisee";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))

                {
                    command.Parameters.AddWithValue("@idplanification", textBox3.Text);
                    command.Parameters.AddWithValue("@CodePlanification", textBox1.Text);
                    command.Parameters.AddWithValue("@CodeArticle", txtcodearticle.Text);
                    command.Parameters.AddWithValue("@QuantiteAProduire", txtQuantiteAProduire.Text);
                    command.Parameters.AddWithValue("@ProductionHoraire", txtProductionHoraire.Text);
                    command.Parameters.AddWithValue("@NombreDeJoursEstimes", txtNombreDeJoursEstimes.Text);
                    command.Parameters.AddWithValue("@ProductionJournaliere", txtProductionJournaliere.Text);
                    command.Parameters.AddWithValue("@NombreDeBandes", cbNumeroDeBande.Text);
                    command.Parameters.AddWithValue("@machines", comboBox2.Text);
                    command.Parameters.AddWithValue("@Date_commence", textBox2.Text);


                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Les données ont été enregistrées avec succès.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Une erreur est survenue : {ex.Message}");
                    }
                }
                using (MySqlCommand commandParcMachine = new MySqlCommand(queryParcMachine, connection))

                {


                    // Paramètres pour la table parcmachine
                    commandParcMachine.Parameters.AddWithValue("@Date_commence", textBox2.Text);
                    commandParcMachine.Parameters.AddWithValue("@Utilisee", comboBox2.Text);

                    try
                    {

                        commandParcMachine.ExecuteNonQuery(); // Exécuter la commande pour mettre à jour la table parcmachine

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Une erreur est survenue : {ex.Message}");
                    }
                }
                connection.Close();
            }
        }
    }
}
