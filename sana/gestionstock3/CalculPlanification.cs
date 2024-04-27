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
using Microsoft.VisualBasic;

namespace gestionstock3
{
    public partial class CalculPlanification : Form
    {
        private MySqlConnection connection;
        private string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";
        public CalculPlanification()
        {
            InitializeComponent();
        }
        public void ChargerDonnees(string idPlanification)
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT Production_journalier, nombre_de_bande,qte_produire,Nb_jour_estimé,machines FROM productionplanification WHERE id_planification=@idPlanification"; // Remplacez 'votreCondition' par une condition réelle si nécessaire

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idPlanification", idPlanification);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Une erreur est survenue lors de la connexion à la base de données : {ex.Message}");
                }
            }
        }
        private string idPlanificationGlobal;
        private void button1_Click(object sender, EventArgs e)
        {
            string idPlanification = Microsoft.VisualBasic.Interaction.InputBox("Entrez l'ID de planification :", "ID de Planification", "");

            // Vérifier si l'utilisateur a saisi une valeur
            if (!string.IsNullOrEmpty(idPlanification))
            {
                idPlanificationGlobal = idPlanification;
                ChargerDonnees(idPlanification);
            }
            else
            {
                MessageBox.Show("Vous devez entrer un ID de planification.");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                MessageBox.Show("Votre produit est terminé.");
                button2.Enabled = false; // Désactiver le bouton de calcul
                return; // Sortir de la méthode
            }
            // Vérifier si les champs textBox1 et textBox2 ne sont pas vides
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                // Convertir les valeurs des champs textBox1 et textBox2 en nombres décimaux
                if (decimal.TryParse(textBox1.Text, out decimal valeurTextBox1) && decimal.TryParse(textBox2.Text, out decimal valeurTextBox2))
                {
                    // Effectuer le calcul
                    decimal resultatCalcul = valeurTextBox1 - valeurTextBox2;

                    // Mettre à jour la valeur de textBoxQTé avec le résultat du calcul
                    textBoxQTé.Text = resultatCalcul.ToString();
                    // Récupérer la valeur de qte_produire à partir de la base de données ou d'où vous stockez ces données
                    decimal produceQuantity = GetProductionQuantityFromDatabase(); // Assurez-vous d'implémenter cette méthode
                    decimal nombrejour = GetNBjourFromDatabase();

                    // Calculer le nombre de jours de production nécessaire
                    decimal joursRestants = resultatCalcul / produceQuantity;

                    // Arrondir le résultat à l'entier supérieur
                    int joursArrondis = (int)Math.Ceiling(joursRestants);

                    // Ajouter le nombre de jours supplémentaires
                    joursArrondis += (int)nombrejour;

                    // Mettre à jour le textBoxNBdayREST avec le nombre de jours arrondis
                    textBoxNBdayREST.Text = joursArrondis.ToString();
                }
                else
                {
                    MessageBox.Show("Les valeurs entrées dans textBox1 et textBox2 doivent être des nombres décimaux valides.");
                }
            }
            else
            {
                MessageBox.Show("Veuillez remplir les champs textBox1 et textBox2 avant de calculer.");
            }
        }




        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void CalculPlanification_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }


        private void label8_Click(object sender, EventArgs e)
        {

        }
        private int nombreAjoutsEffectues = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            string qteproduction = textBoxQTé.Text;
            string datejour = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string productionjournalier = textBox2.Text;
            string dayrestant = textBoxNBdayREST.Text;
            string productionrestante = textBoxQTé.Text;
            String Datejour2 = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            string rendement = textBox3.Text;


            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";

            // Requête d'insertion SQL
            string query = "INSERT INTO calculplanification (qte_Aproduire, date_jour, qte_produit, qte_Restantes, date_livraison,Rendement) " +
                           "VALUES (@qte_Aproduire, @datejour, @qteproduit, @qterestantes, @datelivraison,@Rendement)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Insertion dans la table calculplanification
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@qte_Aproduire", qteproduction);
                    command.Parameters.AddWithValue("@datejour", datejour);
                    command.Parameters.AddWithValue("@qteproduit", productionjournalier);
                    command.Parameters.AddWithValue("@qterestantes", productionrestante);
                    command.Parameters.AddWithValue("@datelivraison", dayrestant);
                    command.Parameters.AddWithValue("@Rendement", rendement);

                    command.ExecuteNonQuery();
                }
                // Requête d'insertion SQL pour la table parcmachine
                string queryParcMachine = "UPDATE parcmachine SET date_disponibilite = @dateDisponibilite, Date_commence = @Date_commence WHERE Utilisée = @Utilisee";
                using (MySqlCommand commandParcMachine = new MySqlCommand(queryParcMachine, connection))
                {
                    commandParcMachine.Parameters.AddWithValue("@dateDisponibilite", dayrestant);
                    commandParcMachine.Parameters.AddWithValue("@Date_commence", Datejour2); // Utiliser la date actuelle
                    commandParcMachine.Parameters.AddWithValue("@Utilisee", "machine encore utilisée");
                    commandParcMachine.ExecuteNonQuery();
                }

                // Vérification si la machine est utilisée dans la table productionplanification
                string queryVerification = "SELECT COUNT(*) FROM productionplanification WHERE machines = @Utilisee "; // Ajoutez ici d'autres conditions nécessaires
                using (MySqlCommand commandVerification = new MySqlCommand(queryVerification, connection))
                {
                    commandVerification.Parameters.AddWithValue("@Utilisee", "valeur_de_la_machine_utilisée");
                    int count = Convert.ToInt32(commandVerification.ExecuteScalar());

                    if (count > 0)
                    {
                        // Mise à jour de la table parcmachine si la machine est utilisée
                        using (MySqlCommand commandParcMachine = new MySqlCommand(queryParcMachine, connection))
                        {
                            commandParcMachine.Parameters.AddWithValue("@dateDisponibilite", dayrestant);
                            commandParcMachine.Parameters.AddWithValue("@Utilisee", "machine encore utilisée");
                            commandParcMachine.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        MessageBox.Show("La machine n'est pas utilisée dans la productionplanification.");
                    }
                }

                connection.Close();
            }

            // Réinitialisation des champs après l'insertion
            textBoxQTé.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBoxNBdayREST.Text = "";
            textBox3.Text = "";

            MessageBox.Show("Calcul planification ajouté avec succès.");
        }

        private bool premiereImportation = true;
        private void button4_Click(object sender, EventArgs e)
        {

            if (premiereImportation)
            {
                // Afficher un MessageBox pour demander si c'est la première planification
                DialogResult result = MessageBox.Show("Voulez-vous effectuer la première planification ?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // Afficher la fenêtre de saisie de la quantité à produire du tableau productionplanification
                    SaisirQuantiteAProduire();
                }
                else
                {
                    // Vérifier si la quantité à produire est nulle dans la base de données
                    if (QuantiteAProduireEstNulle())
                    {
                        MessageBox.Show("Vous avez déjà produit toute la quantité.", "Information");
                    }
                    else
                    {
                        // Afficher la fenêtre pour saisir la quantité produite du dernier enregistrement dans calculplanification
                        SaisirDerniereQuantiteProduite();
                    }
                }
                premiereImportation = true;

            }
            else
            {
                if (!string.IsNullOrEmpty(idPlanificationGlobal))
                {
                    ChargerDonnees2(idPlanificationGlobal);
                }
            }
        }
        private bool QuantiteAProduireEstNulle()
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";
            string query = "SELECT qte_Aproduire FROM calculplanification WHERE qte_Aproduire = 0";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        int qteAProduire;
                        if (int.TryParse(result.ToString(), out qteAProduire))
                        {
                            // Vérifie si la quantité à produire est nulle
                            return qteAProduire == 0;
                        }
                    }
                }
            }
            return false;
        }
        private void SaisirQuantiteAProduire()
        {
            // Afficher une boîte de dialogue pour saisir la quantité à produire
            string quantiteAProduire = Microsoft.VisualBasic.Interaction.InputBox("Entrez la quantité à produire :", "Quantité à produire", "");

            // Vérifier si l'utilisateur a saisi une valeur
            if (!string.IsNullOrEmpty(quantiteAProduire))
            {
                // Mettre à jour le textBox1 avec la quantité à produire saisie
                textBox1.Text = quantiteAProduire;
            }
            else
            {
                MessageBox.Show("Vous devez entrer une quantité à produire.");
            }
        }

        private void SaisirDerniereQuantiteProduite()
        {
            // Récupérer la dernière quantité produite depuis le tableau calculplanification
            string derniereQuantiteProduite = GetDerniereQuantiteProduiteFromCalculPlanification();

            // Afficher une boîte de dialogue pour saisir la dernière quantité produite
            string quantiteProduite = Microsoft.VisualBasic.Interaction.InputBox("Entrez la dernière quantité produite :", "Dernière quantité produite", derniereQuantiteProduite);

            // Vérifier si l'utilisateur a saisi une valeur
            if (!string.IsNullOrEmpty(quantiteProduite))
            {
                // Mettre à jour le textBox1 avec la dernière quantité produite saisie
                textBox1.Text = quantiteProduite;
            }
            else
            {
                MessageBox.Show("Vous devez entrer une dernière quantité produite.");
            }
        }

        private string GetDerniereQuantiteProduiteFromCalculPlanification()
        {
            string derniereQuantiteProduite = string.Empty;

            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT qte_Aproduire FROM calculplanification ORDER BY id DESC LIMIT 1";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            derniereQuantiteProduite = result.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Aucune donnée trouvée dans la table calculplanification.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Une erreur est survenue lors de la connexion à la base de données : {ex.Message}");
                }
            }

            return derniereQuantiteProduite;
        }




        public void ChargerDonnees2(string idPlanificationGlobal)
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT qte_Restantes FROM calculplanification ORDER BY id DESC LIMIT 1";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBox1.Text = reader["qte_Restantes"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Aucune donnée trouvée pour l'id_planification sélectionné.");
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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBoxNBdayREST_TextChanged(object sender, EventArgs e)
        {

        }
        private int nombreCalculsEffectues = 0;
        private decimal sommeResultats = 0;


        private void button1_Click_2(object sender, EventArgs e)
        {
            // Appeler la méthode textBoxQTé_TextChanged pour effectuer les calculs nécessaires
            textBoxQTé_TextChanged(sender, e);

            // Appeler la méthode AfficherDateLivraison pour afficher la date de livraison
            AfficherDateLivraison();
        }

        private void textBoxQTé_TextChanged(object sender, EventArgs e)
        {
            // Récupérer la valeur de qte_produire à partir de la base de données ou d'où vous stockez ces données
            decimal produceQuantity = GetProductionQuantityFromDatabase(); // Assurez-vous d'implémenter cette méthode
            decimal nombrejour = GetNBjourFromDatabase();

            // Vérifier si la TextBox textBoxQTé contient une valeur valide
            if (decimal.TryParse(textBoxQTé.Text, out decimal totalQTé))
            {
                // Calculer le nombre de jours de production nécessaire
                decimal joursRestants = totalQTé / produceQuantity;

                // Arrondir le résultat à l'entier supérieur
                int joursArrondis = (int)Math.Ceiling(joursRestants);

                // Ajouter le nombre de jours supplémentaires
                joursArrondis += (int)nombrejour;
            }

        }
        private decimal GetProductionJournalierFromDatabase()
        {
            // Chaîne de connexion à votre base de données MySQL
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";

            // Variable pour stocker la valeur de qte_produire
            decimal productionnjournalier = 0;

            // Requête SQL pour récupérer la valeur de qte_produire depuis la table productionplanification
            string query = "SELECT Production_journalier  FROM productionplanification";

            // Création de la connexion à la base de données et exécution de la requête
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        // Exécutez la commande et récupérez la valeur de qte_produire
                        object result = command.ExecuteScalar();

                        // Vérifiez si le résultat n'est pas nul et peut être converti en décimal
                        if (result != null && decimal.TryParse(result.ToString(), out productionnjournalier))
                        {
                            // Vous pouvez également ajouter d'autres logiques de traitement ici si nécessaire
                        }
                        else
                        {
                            // Gérez le cas où la valeur de qte_produire n'a pas pu être récupérée
                            Console.WriteLine("La valeur de qte_produire n'a pas pu être récupérée.");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Gérez les exceptions qui pourraient survenir lors de la récupération des données depuis la base de données
                        Console.WriteLine("Une erreur est survenue lors de la récupération de la valeur de qte_produire : " + ex.Message);
                    }
                }
            }

            // Retourne la valeur de qte_produire récupérée depuis la base de données
            return productionnjournalier;
        }
        private decimal GetProductionQuantityFromDatabase()
        {
            // Chaîne de connexion à votre base de données MySQL
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";

            // Variable pour stocker la valeur de qte_produire
            decimal produceQuantity = 0;

            // Requête SQL pour récupérer la valeur de qte_produire depuis la table productionplanification
            string query = "SELECT qte_produire  FROM productionplanification";

            // Création de la connexion à la base de données et exécution de la requête
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        // Exécutez la commande et récupérez la valeur de qte_produire
                        object result = command.ExecuteScalar();

                        // Vérifiez si le résultat n'est pas nul et peut être converti en décimal
                        if (result != null && decimal.TryParse(result.ToString(), out produceQuantity))
                        {
                            // Vous pouvez également ajouter d'autres logiques de traitement ici si nécessaire
                        }
                        else
                        {
                            // Gérez le cas où la valeur de qte_produire n'a pas pu être récupérée
                            Console.WriteLine("La valeur de qte_produire n'a pas pu être récupérée.");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Gérez les exceptions qui pourraient survenir lors de la récupération des données depuis la base de données
                        Console.WriteLine("Une erreur est survenue lors de la récupération de la valeur de qte_produire : " + ex.Message);
                    }
                }
            }

            // Retourne la valeur de qte_produire récupérée depuis la base de données
            return produceQuantity;
        }
        private decimal GetNBjourFromDatabase()
        {
            // Chaîne de connexion à votre base de données MySQL
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";

            // Variable pour stocker la valeur de qte_produire
            decimal nombrejour = 0;

            // Requête SQL pour récupérer la valeur de nombre de jour depuis la table productionplanification
            string query = "SELECT Nb_jour_estimé  FROM productionplanification";

            // Création de la connexion à la base de données et exécution de la requête
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        // Exécutez la commande et récupérez la valeur de qte_produire
                        object result = command.ExecuteScalar();

                        // Vérifiez si le résultat n'est pas nul et peut être converti en décimal
                        if (result != null && decimal.TryParse(result.ToString(), out nombrejour))
                        {
                            // Vous pouvez également ajouter d'autres logiques de traitement ici si nécessaire
                        }
                        else
                        {
                            // Gérez le cas où la valeur de qte_produire n'a pas pu être récupérée
                            Console.WriteLine("La valeur de date de jour n'a pas pu être récupérée.");
                        }
                    }

                    catch (Exception ex)
                    {
                        // Gérez les exceptions qui pourraient survenir lors de la récupération des données depuis la base de données
                        Console.WriteLine("Une erreur est survenue lors de la récupération de la valeur de qte_produire : " + ex.Message);
                    }
                }
            }

            // Retourne la valeur de qte_produire récupérée depuis la base de données
            return nombrejour;
        }
        private void AfficherDateLivraison()
        {
            // Récupérer le nombre de jours depuis textBoxNBdayREST
            if (int.TryParse(textBoxNBdayREST.Text, out int jours))
            {
                // Obtenir la date de référence
                DateTime dateReference = DateTime.Now; // Vous pouvez utiliser une autre date de référence si nécessaire

                // Ajouter le nombre de jours à la date de référence pour obtenir la date de livraison
                DateTime dateLivraison = dateReference.AddDays(jours);

                // Afficher la date de livraison dans textBoxNBdayREST sous forme de chaîne formatée
                textBoxNBdayREST.Text = dateLivraison.ToString("yyyy-MM-dd");
            }
            else
            {
                MessageBox.Show("Veuillez entrer un nombre valide de jours.");
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            string dayrestant = textBoxNBdayREST.Text;
            string machineUtilisee = "valeur_de_la_machine_utilisée"; // Remplacez cela par la valeur appropriée de la machine utilisée

            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";
            string query = "UPDATE parcmachine SET date_disponibilite = @dateDisponibilite WHERE Utilisée = @machineUtilisee";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@dateDisponibilite", dayrestant);
                    command.Parameters.AddWithValue("@machineUtilisee", machineUtilisee);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            MessageBox.Show("La date de disponibilité a été mise à jour avec succès dans la table parcmachine.");
        }
        private void button6_Click(object sender, EventArgs e)
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Afficher une boîte de dialogue pour saisir la Production_journalier
            string productionJournalierInput = Microsoft.VisualBasic.Interaction.InputBox("Entrez la valeur de Production_journalier :", "Production_journalier", "");

            // Vérifier si l'utilisateur a saisi une valeur
            if (!string.IsNullOrEmpty(productionJournalierInput))
            {
                double productionJournalier;
                // Vérifier si la valeur saisie peut être convertie en double
                if (double.TryParse(productionJournalierInput, out productionJournalier))
                {
                    // Connexion à la base de données
                    string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();

                            // Requête SQL pour vérifier si la Production_journalier est présente dans la table
                            string query = "SELECT COUNT(*) FROM productionplanification WHERE Production_journalier = @productionJournalier";
                            using (MySqlCommand command = new MySqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@productionJournalier", productionJournalier);
                                int count = Convert.ToInt32(command.ExecuteScalar());

                                if (count > 0)
                                {
                                    // Calcul du rendement en utilisant la valeur saisie
                                    double rendement = Convert.ToDouble(textBox2.Text) / productionJournalier;
                                    textBox3.Text = rendement.ToString();
                                }
                                else
                                {
                                    MessageBox.Show("La valeur de Production_journalier n'est pas présente dans la table productionplanification.");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erreur lors de la vérification de la présence de Production_journalier dans la base de données : " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("La valeur saisie n'est pas valide. Veuillez entrer un nombre valide.");
                }
            }
            else
            {
                MessageBox.Show("Vous devez entrer une valeur de Production_journalier.");
            }
        }

    }
    }
    
    
   
