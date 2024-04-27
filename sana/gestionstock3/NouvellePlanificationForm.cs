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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace gestionstock3
{
    public partial class NouvellePlanificationForm : Form
    {
        /*ligne de configuration de la  base  de donnée 
        /*adiya  li  bech  t5alina  nodkhlou lel  base  de  donnée suivant  l xampp*/
        MySqlConnection connexion = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=devnet");
        public NouvellePlanificationForm()
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

        private void NouvellePlanificationForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cbNumeroDeBande_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) ||
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
            string query = @"INSERT INTO productionplanification (`code_planification`,`code_article`, `qte_produire`, `production_horaire`, `Nb_jour_estimé`, `Production_journalier`, `nombre_de_bande`,`machines`,`Date_commence`) 
                      VALUES (@CodePlanification, @CodeArticle, @QuantiteAProduire, @ProductionHoraire, @NombreDeJoursEstimes, @ProductionJournaliere, @NombreDeBandes,@machines,@Date_commence)";


            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
              
                {
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

                if (!string.IsNullOrEmpty(comboBox2.Text))
                {
                    string queryParcMachine = @"UPDATE parcmachine 
                                SET `Date_commence` = @Date_commence 
                                WHERE Utilisée = @Utilisee";

                    using (MySqlCommand commandParcMachine = new MySqlCommand(queryParcMachine, connection))
                    {
                        // Paramètres pour la table parcmachine
                        commandParcMachine.Parameters.AddWithValue("@Date_commence", textBox2.Text);
                        commandParcMachine.Parameters.AddWithValue("@Utilisee", comboBox2.Text);

                        try
                        {
                            commandParcMachine.ExecuteNonQuery(); // Exécuter la commande pour insérer la date dans la table parcmachine
                            MessageBox.Show("Date de début ajoutée avec succès dans la table parcmachine.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Une erreur est survenue : {ex.Message}");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez sélectionner une valeur pour comboBox2 avant d'ajouter la date de début dans la table parcmachine.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void txtCodeArticle_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtcodearticle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Récupérer la machine sélectionnée dans comboBox2
            string machineSelectionnee = comboBox2.SelectedItem.ToString();

            // Mettre à jour l'attribut "Utilisée" dans la base de données
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";
            string updateQuery = "UPDATE parcmachine SET Utilisée = true WHERE code = @MachineCode";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                {
                    // Ajouter le paramètre pour le code de la machine
                    command.Parameters.AddWithValue("@MachineCode", machineSelectionnee);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("L'attribut 'Utilisée' a été mis à jour pour la machine sélectionnée.");
                        }
                        else
                        {
                            MessageBox.Show("Aucune machine correspondant au code sélectionné n'a été trouvée.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Une erreur est survenue lors de la mise à jour de l'attribut 'Utilisée': {ex.Message}");
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Récupérer les valeurs des champs à mettre à jour
            string codePlanification = textBox1.Text;
            string dateCommence = textBox2.Text;
            string machineSelectionnee = comboBox2.SelectedItem.ToString();

            // Mettre à jour les données dans la base de données
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";
            string updateQuery = "UPDATE productionplanification SET Date_commence = @DateCommence, machines = @Machine WHERE code_planification = @CodePlanification";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                {
                    // Ajouter les paramètres pour la mise à jour
                    command.Parameters.AddWithValue("@DateCommence", dateCommence);
                    command.Parameters.AddWithValue("@Machine", machineSelectionnee);
                    command.Parameters.AddWithValue("@CodePlanification", codePlanification);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Les données ont été mises à jour avec succès.");
                        }
                        else
                        {
                            MessageBox.Show("Aucune entrée correspondant au code de planification spécifié n'a été trouvée.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Une erreur est survenue lors de la mise à jour des données : {ex.Message}");
                    }
                }
            }
        }
    }
}