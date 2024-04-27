using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;/* utiliser la  bibliothèque du Mysql*/
using System.Security.Cryptography;/*faire le  cryptage  du  mot de passe */


namespace gestionstock3
{
    
    public partial class Form1 : Form
    {

        /*ligne de configuration de la  base  de donnée 
        /*adiya  li  bech  t5alina  nodkhlou lel  base  de  donnée suivant  l xampp*/
        MySqlConnection connexion = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=devnet");

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
/* bech  naamlou  connexion ma3 l  uytlisateur  wel  mdp  mta3ou*/
        private void button1_Click(object sender, EventArgs e)
        {
            connexion.Open();/*bech  nhelou  l  base de  donnée*/
            /*behc naaml séléction lel  users l kol wel  mot de passe  mta3hom  bech  kif  ndkhel  ay  wahed  mawjoud  fel base  de  donnée yet3ada  l  authentificatioon */
            MySqlDataAdapter adap = new MySqlDataAdapter("SELECT COUNT(*) FROM login WHERE user='" + textuser.Text + "'AND password='" + temotdepasse.Text + "'", connexion);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            connexion.Close();

            if (dt.Rows[0][0].ToString() == "1")
            {/*kana  l  user wel  mdp  s7a7 bech ykhrjli  l  message */
                MessageBox.Show("Vous faites partie du système", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Ouvrir l'interface MDIParent
                MDIParent1 mdiParent = new MDIParent1();
                
                this.Hide(); // Cache la fenêtre de connexion
                mdiParent.Show(); // Affiche la fenêtre MDIParent
            }
            else
            {
                /*kan  l  user 8alet wellla  el mdp  8alta bech  yo5rej  l  message  hada */
                MessageBox.Show("Mot de passe ou nom d'utilisateur incorrect", "Erreur", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
