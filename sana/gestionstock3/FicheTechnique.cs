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
    public partial class FicheTechnique : Form
    {
        public FicheTechnique()
        {
            InitializeComponent();
        }

        private void FicheTechnique_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string reference = Microsoft.VisualBasic.Interaction.InputBox("Entrez la  référence de votre Article  :", "Référence Article", "");

            // Vérifier si l'utilisateur a saisi une valeur
            if (!string.IsNullOrEmpty(reference))
            {

                ChargerDonnees(reference);
            }
            else
            {
                MessageBox.Show("Vous devez entrer un ID de planification.");
            }
        }
        public void ChargerDonnees(string reference)
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=devnet";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT  reference, designation, largeur, epaisseur, resistance, allongement, `tirage fil chaine`, `metrage fil chaine`, `tirage fil trame`, `metrage fil trame`, `tirage fil retenue`, `metrage fil retenue` FROM articles WHERE reference = @reference";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@reference", reference);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                txtreference.Text = reader["reference"].ToString();
                                txtdesignation.Text = reader["designation"].ToString();
                                txtlargeur.Text = reader["largeur"].ToString();
                                txtepaisseur.Text = reader["epaisseur"].ToString();
                                txtresistance.Text = reader["resistance"].ToString();
                                txtallongement.Text = reader["allongement"].ToString();
                                txttiragefilchaine.Text = reader["tirage fil chaine"].ToString();
                                txtmetragefilchaine.Text = reader["metrage fil chaine"].ToString();
                                txttiragefiltrame.Text = reader["tirage fil trame"].ToString();
                                txtmetragefiltrame.Text = reader["metrage fil trame"].ToString();
                                txttiragefilretenue.Text = reader["tirage fil retenue"].ToString();
                                txtmetragefilretenue.Text = reader["metrage fil retenue"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Aucune donnée trouvée pour la référence spécifiée.");
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

        private void button1_Click(object sender, EventArgs e)
        {
            // Créez une instance de PrintDocument
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

            // Affichez la boîte de dialogue d'impression
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Définissez le rectangle d'impression pour correspondre à la taille de la page
            Rectangle rect = e.MarginBounds;

            // Définissez les polices à utiliser
            using (Font titleFont = new Font("Arial", 16, FontStyle.Bold))
            using (Font normalFont = new Font("Arial", 12))
            {
                // Définissez les coordonnées pour le début de l'impression
                float y = rect.Top;

                // Dessinez le titre "Fiche Technique" au centre de la page
                string title = "Fiche Technique";
                SizeF titleSize = e.Graphics.MeasureString(title, titleFont);
                e.Graphics.DrawString(title, titleFont, Brushes.Black, new PointF((rect.Width - titleSize.Width) / 2, y));
                y += titleSize.Height + 20; // Espacement après le titre

                // Dessinez chaque ligne de données avec leur libellé
                DrawLine("Référence:", txtreference.Text, e, normalFont, ref y);
                DrawLine("Désignation:", txtdesignation.Text, e, normalFont, ref y);
                DrawLine("Épaisseur:", txtepaisseur.Text, e, normalFont, ref y);
                DrawLine("Résistance:", txtresistance.Text, e, normalFont, ref y);
                DrawLine("Allongement:", txtallongement.Text, e, normalFont, ref y);
                DrawLine("Fil Chaine - Tirage:", txttiragefilchaine.Text, e, normalFont, ref y);
                DrawLine("Fil Chaine - Métrage:", txtmetragefilchaine.Text, e, normalFont, ref y);
                DrawLine("Fil Trame - Tirage:", txttiragefiltrame.Text, e, normalFont, ref y);
                DrawLine("Fil Trame - Métrage:", txtmetragefiltrame.Text, e, normalFont, ref y);
                DrawLine("Fil Retenue - Tirage:", txttiragefilretenue.Text, e, normalFont, ref y);
                DrawLine("Fil Retenue - Métrage:", txtmetragefilretenue.Text, e, normalFont, ref y);
            }
        }

        private void DrawLine(string label, string value, PrintPageEventArgs e, Font font, ref float y)
        {
            // Définissez la position x pour le libellé
            float xLabel = e.MarginBounds.Left;

            // Dessinez le libellé
            e.Graphics.DrawString(label, font, Brushes.Black, new PointF(xLabel, y));

            // Définissez la position x pour la valeur
            float xValue = e.MarginBounds.Left + 200; // Espacement entre le libellé et la valeur

            // Dessinez la valeur
            e.Graphics.DrawString(value, font, Brushes.Black, new PointF(xValue, y));

            // Mettez à jour la position y pour la prochaine ligne
            y += font.GetHeight();
        }
    }
}
