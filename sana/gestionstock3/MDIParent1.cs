using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestionstock3
{
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;

        public MDIParent1()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(MDIParent1_FormClosed);

        }
        void MDIParent1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
           AjouterFournisseur ajouterFournisseur=new AjouterFournisseur();
          ajouterFournisseur.ShowDialog();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            // n7ellou l lnouvelle  fenetre nouvelle  planification 
            ListeFournisseurs liste_Fournisseurs = new ListeFournisseurs();

            // Affichez le formulaire de planification
            liste_Fournisseurs.ShowDialog();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Fichiers texte (*.txt)|*.txt|Tous les fichiers (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModifierFils modifierFils = new ModifierFils();
            modifierFils.ShowDialog();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Demander à l'utilisateur de saisir le code du fil à supprimer
            string codeFil = Microsoft.VisualBasic.Interaction.InputBox("Entrez le code du fil à supprimer :", "Supprimer un fil", "");

            // Vérifier si l'utilisateur a saisi une valeur
            if (!string.IsNullOrEmpty(codeFil))
            {
                // Charger les données du fil en fonction de son code
                ChargerDonneesFil(codeFil);
            }
            else
            {
                MessageBox.Show("Vous devez entrer un code de fil.");
            }
        }
        public void ChargerDonneesFil(string codeFil)
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT code, composition, couleur, codefournisseur, titre, resistance, allongment, enbivage FROM fils WHERE code=@codeFil";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@codeFil", codeFil);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Afficher les informations du fil dans une boîte de dialogue de confirmation
                                string filInfo = $"Code: {reader["code"]}\nComposition: {reader["composition"]}\nCouleur: {reader["couleur"]}\nCode fournisseur: {reader["codefournisseur"]}\nTitre: {reader["titre"]}\nRésistance: {reader["resistance"]}\nAllongement: {reader["allongment"]}\nEnbivage: {reader["enbivage"]}";

                                // Demander confirmation de suppression
                                DialogResult result = MessageBox.Show($"Êtes-vous sûr de vouloir supprimer ce fil ?\n\n{filInfo}", "Confirmation de suppression", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                                if (result == DialogResult.OK)
                                {
                                    // Supprimer le fil
                                    SupprimerFil(codeFil);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Aucun fil trouvé avec ce code.");
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

        public void SupprimerFil(string codeFil)
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string deleteQuery = "DELETE FROM fils WHERE code=@codeFil";

                    using (MySqlCommand command = new MySqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@codeFil", codeFil);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Fil supprimé avec succès.", "Suppression réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Aucun fil n'a été supprimé.", "Suppression échouée", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue lors de la suppression du fil : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            // n7ellou l lnouvelle  fenetre nouvelle  planification 
            AjoutArticle ajoutArticle = new AjoutArticle();

            // Affichez le formulaire de planification
            ajoutArticle.ShowDialog();
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
            ListeArticles listeArticles = new ListeArticles();
            listeArticles.ShowDialog();
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
            ListesTisserand listesTisserand = new ListesTisserand();
            listesTisserand.ShowDialog();
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
            modifierTisserand modifierTisserand = new modifierTisserand();
            modifierTisserand.ShowDialog();
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
            // Demander à l'utilisateur de saisir le code du tisserand à supprimer
            string codeTisserand = Microsoft.VisualBasic.Interaction.InputBox("Entrez le code du tisserand à supprimer :", "Supprimer un tisserand", "");

            // Vérifier si l'utilisateur a saisi une valeur
            if (!string.IsNullOrEmpty(codeTisserand))
            {
                // Charger les données du tisserand en fonction de son code
                ChargerDonneesTisserand(codeTisserand);
            }
            else
            {
                MessageBox.Show("Vous devez entrer un code de tisserand.");
            }

        }
        public void ChargerDonneesTisserand(string codeTisserand)
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id, `code`, nom, prenom, sexe, etatcivile, adresse, tel, equipe, presence FROM tisserands WHERE `code`=@codeTisserand";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@codeTisserand", codeTisserand);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Afficher les informations du tisserand dans une boîte de dialogue de confirmation
                                string tisserandInfo = $"ID: {reader["id"]}\nCode: {reader["code"]}\nNom: {reader["nom"]}\nPrénom: {reader["prenom"]}\nSexe: {reader["sexe"]}\nÉtat civil: {reader["etatcivile"]}\nAdresse: {reader["adresse"]}\nTéléphone: {reader["tel"]}\nÉquipe: {reader["equipe"]}\nPrésence: {reader["presence"]}";

                                // Demander confirmation de suppression
                                DialogResult result = MessageBox.Show($"Êtes-vous sûr de vouloir supprimer ce tisserand ?\n\n{tisserandInfo}", "Confirmation de suppression", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                                if (result == DialogResult.OK)
                                {
                                    // Supprimer le tisserand
                                    SupprimerTisserand(codeTisserand);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Aucun tisserand trouvé avec ce code.");
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

        public void SupprimerTisserand(string codeTisserand)
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string deleteQuery = "DELETE FROM tisserands WHERE `code`=@codeTisserand";

                    using (MySqlCommand command = new MySqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@codeTisserand", codeTisserand);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Tisserand supprimé avec succès.", "Suppression réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Aucun tisserand n'a été supprimé.", "Suppression échouée", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue lors de la suppression du tisserand : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AjouterFil ajouterFil=new AjouterFil();
            ajouterFil.ShowDialog();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListFil listFil = new ListFil();
            listFil.ShowDialog();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AjouterCommande ajouterCommande=new AjouterCommande();
               ajouterCommande.ShowDialog();
        }

        private void listesCommandesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listecommandes listecommandes=new Listecommandes();
            listecommandes.ShowDialog();
        }

        private void windowsMenu_Click(object sender, EventArgs e)
        {

        }

        private void nouvelleMachineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AjouterMachine ajouterMachine=new AjouterMachine();
                ajouterMachine.ShowDialog();
        }

        private void listesMachinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListesMachines listesMachines=new ListesMachines();
            listesMachines.ShowDialog();
        }

        private void nouvellePlanificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NouvellePlanificationForm nouvellePlanificationForm =new NouvellePlanificationForm();
                nouvellePlanificationForm.ShowDialog();
        }

        private void calulPlanificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CalculPlanification calculPlanification=new CalculPlanification();
            calculPlanification.ShowDialog();
        }

        private void nouveleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NouvelleTisserand nouvelleTisserand=new NouvelleTisserand();
                nouvelleTisserand.ShowDialog();
        }

        private void historiquePlanificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistoriquePlanification historiquePlanification = new HistoriquePlanification();
            historiquePlanification.ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModifierFournisseurs modifierFournisseurs = new ModifierFournisseurs();
            modifierFournisseurs.ShowDialog();  
        }

        private void modifierArticleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModifierArticles modifierArticles = new ModifierArticles(); 
            modifierArticles.ShowDialog();  
        }

        private void modifierMachinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModifierParcMachine modifierParcMachine = new ModifierParcMachine();
            modifierParcMachine.ShowDialog();
        }

        private void modifierCommandeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModifierCommande modifierCommande = new ModifierCommande();
            modifierCommande.ShowDialog();
        }

        private void supprimerFournisseurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Demander à l'utilisateur de saisir le code du fournisseur à supprimer
            string code = Microsoft.VisualBasic.Interaction.InputBox("Entrez le code du fournisseur à supprimer :", "Supprimer un fournisseur", "");

            // Vérifier si l'utilisateur a saisi une valeur
            if (!string.IsNullOrEmpty(code))
            {
                // Charger les données du fournisseur en fonction du code
                ChargerDonneesFournisseur(code);
            }
            else
            {
                MessageBox.Show("Vous devez entrer un code de fournisseur.");
            }
        }
        public void ChargerDonneesFournisseur(string code)
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id, code, tva, societe, Pays, email, tel, remarque FROM fournisseurs WHERE code=@code";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@code", code);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Afficher les informations du fournisseur dans un message box
                                string fournisseurInfo = $"ID: {reader["id"]}\nCode: {reader["code"]}\nTVA: {reader["tva"]}\nSociété: {reader["societe"]}\nPays: {reader["Pays"]}\nEmail: {reader["email"]}\nTéléphone: {reader["tel"]}\nRemarque: {reader["remarque"]}";

                                // Demander confirmation de suppression
                                DialogResult result = MessageBox.Show($"Êtes-vous sûr de vouloir supprimer ce fournisseur ?\n\n{fournisseurInfo}", "Confirmation de suppression", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                                if (result == DialogResult.OK)
                                {
                                    // Supprimer le fournisseur
                                    SupprimerFournisseur(code);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Aucun fournisseur trouvé avec ce code.");
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

        public void SupprimerFournisseur(string code)
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string deleteQuery = "DELETE FROM fournisseurs WHERE code=@code";

                    using (MySqlCommand command = new MySqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@code", code);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Fournisseur supprimé avec succès.", "Suppression réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Aucun fournisseur n'a été supprimé.", "Suppression échouée", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue lors de la suppression du fournisseur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void supprimerArticleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Demander à l'utilisateur de saisir la référence de l'article à supprimer
            string reference = Microsoft.VisualBasic.Interaction.InputBox("Entrez la référence de l'article à supprimer :", "Supprimer un article", "");

            // Vérifier si l'utilisateur a saisi une valeur
            if (!string.IsNullOrEmpty(reference))
            {
                // Charger les données de l'article en fonction de la référence
                ChargerDonneesArticle(reference);
            }
            else
            {
                MessageBox.Show("Vous devez entrer une référence d'article.");
            }
        }
        public void ChargerDonneesArticle(string reference)
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id, reference, designation, largeur, epaisseur, resistance, allongement, `tirage fil chaine`, `metrage fil chaine`, `tirage fil trame`, `metrage fil trame`, `tirage fil retenue`, `metrage fil retenue` FROM articles WHERE reference=@reference";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@reference", reference);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Afficher les informations de l'article dans une boîte de dialogue de confirmation
                                string articleInfo = $"ID: {reader["id"]}\nRéférence: {reader["reference"]}\nDésignation: {reader["designation"]}\nLargeur: {reader["largeur"]}\nÉpaisseur: {reader["epaisseur"]}\nRésistance: {reader["resistance"]}\nAllongement: {reader["allongement"]}\nTirage fil chaine: {reader["tirage fil chaine"]}\nMétrage fil chaine: {reader["metrage fil chaine"]}\nTirage fil trame: {reader["tirage fil trame"]}\nMétrage fil trame: {reader["metrage fil trame"]}\nTirage fil retenue: {reader["tirage fil retenue"]}\nMétrage fil retenue: {reader["metrage fil retenue"]}";

                                // Demander confirmation de suppression
                                DialogResult result = MessageBox.Show($"Êtes-vous sûr de vouloir supprimer cet article ?\n\n{articleInfo}", "Confirmation de suppression", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                                if (result == DialogResult.OK)
                                {
                                    // Supprimer l'article
                                    SupprimerArticle(reference);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Aucun article trouvé avec cette référence.");
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

        public void SupprimerArticle(string reference)
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string deleteQuery = "DELETE FROM articles WHERE reference=@reference";

                    using (MySqlCommand command = new MySqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@reference", reference);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Article supprimé avec succès.", "Suppression réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Aucun article n'a été supprimé.", "Suppression échouée", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue lors de la suppression de l'article : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void supprimerCommandeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Demander à l'utilisateur de saisir le code de l'article de la commande à supprimer
            string codeArticle = Microsoft.VisualBasic.Interaction.InputBox("Entrez le code de l'article de la commande à supprimer :", "Supprimer une commande", "");

            // Vérifier si l'utilisateur a saisi une valeur
            if (!string.IsNullOrEmpty(codeArticle))
            {
                // Charger les données de la commande en fonction du code de l'article
                ChargerDonneesCommande(codeArticle);
            }
            else
            {
                MessageBox.Show("Vous devez entrer un code d'article.");
            }
        }
        public void ChargerDonneesCommande(string codeArticle)
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id, `OF`, `code article`, designation, `quantite fabriquer` AS `Quantité à fabriquer`, `nombre de bande` AS `Nombre de bande`, `code machines` AS `Code machines` FROM commande WHERE `code article`=@codeArticle";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@codeArticle", codeArticle);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Afficher les informations de la commande dans une boîte de dialogue de confirmation
                                string commandeInfo = $"ID: {reader["id"]}\nOF: {reader["OF"]}\nCode d'article: {reader["code article"]}\nDésignation: {reader["designation"]}\nQuantité à fabriquer: {reader["Quantité à fabriquer"]}\nNombre de bande: {reader["Nombre de bande"]}\nCode machines: {reader["Code machines"]}";

                                // Demander confirmation de suppression
                                DialogResult result = MessageBox.Show($"Êtes-vous sûr de vouloir supprimer cette commande ?\n\n{commandeInfo}", "Confirmation de suppression", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                                if (result == DialogResult.OK)
                                {
                                    // Supprimer la commande
                                    SupprimerCommande(codeArticle);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Aucune commande trouvée avec ce code d'article.");
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

        public void SupprimerCommande(string codeArticle)
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string deleteQuery = "DELETE FROM commande WHERE `code article`=@codeArticle";

                    using (MySqlCommand command = new MySqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@codeArticle", codeArticle);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Commande supprimée avec succès.", "Suppression réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Aucune commande n'a été supprimée.", "Suppression échouée", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue lors de la suppression de la commande : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void supprimerMachineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Demander à l'utilisateur de saisir le code de la machine à supprimer
            string codeMachine = Microsoft.VisualBasic.Interaction.InputBox("Entrez le code de la machine à supprimer :", "Supprimer une machine", "");

            // Vérifier si l'utilisateur a saisi une valeur
            if (!string.IsNullOrEmpty(codeMachine))
            {
                // Charger les données de la machine en fonction de son code
                ChargerDonneesMachine(codeMachine);
            }
            else
            {
                MessageBox.Show("Vous devez entrer un code de machine.");
            }
        }
        public void ChargerDonneesMachine(string codeMachine)
{
    string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";

    using (MySqlConnection connection = new MySqlConnection(connectionString))
    {
        try
        {
            connection.Open();
            string query = "SELECT id, code, marque, disponiblite, tisserand, nbreesouples FROM parcmachine WHERE code=@codeMachine";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@codeMachine", codeMachine);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Afficher les informations de la machine dans une boîte de dialogue de confirmation
                        string machineInfo = $"ID: {reader["id"]}\nCode: {reader["code"]}\nMarque: {reader["marque"]}\nDisponibilité: {reader["disponiblite"]}\nTisserand: {reader["tisserand"]}\nNombre de souples: {reader["nbreesouples"]}";

                        // Demander confirmation de suppression
                        DialogResult result = MessageBox.Show($"Êtes-vous sûr de vouloir supprimer cette machine ?\n\n{machineInfo}", "Confirmation de suppression", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (result == DialogResult.OK)
                        {
                            // Supprimer la machine
                            SupprimerMachine(codeMachine);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Aucune machine trouvée avec ce code.");
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

public void SupprimerMachine(string codeMachine)
{
    string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";

    try
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string deleteQuery = "DELETE FROM parcmachine WHERE code=@codeMachine";

            using (MySqlCommand command = new MySqlCommand(deleteQuery, connection))
            {
                command.Parameters.AddWithValue("@codeMachine", codeMachine);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Machine supprimée avec succès.", "Suppression réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Aucune machine n'a été supprimée.", "Suppression échouée", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Une erreur est survenue lors de la suppression de la machine : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}

        private void editMenu_Click(object sender, EventArgs e)
        {

        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
                    }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void fileMenu_Click(object sender, EventArgs e)
        {

        }

        private void imprimerArtilceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FicheTechnique ficheTechnique = new FicheTechnique();
            ficheTechnique.ShowDialog();
        
        }

        private void fichePlanificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FichePlanification fichePlanification= new FichePlanification();
            fichePlanification.ShowDialog();
        }

        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModifierPlanification modifierPlanification = new ModifierPlanification();
            modifierPlanification.ShowDialog();
        }
    }
    }

