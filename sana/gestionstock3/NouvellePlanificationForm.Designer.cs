namespace gestionstock3
{
    partial class NouvellePlanificationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtProductionJournaliere = new System.Windows.Forms.TextBox();
            this.txtQuantiteAProduire = new System.Windows.Forms.TextBox();
            this.txtProductionHoraire = new System.Windows.Forms.TextBox();
            this.cbNumeroDeBande = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNombreDeJoursEstimes = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtcodearticle = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label1.Location = new System.Drawing.Point(402, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "Code Article";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(351, 41);
            this.label3.TabIndex = 5;
            this.label3.Text = "Planification de production";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label2.Location = new System.Drawing.Point(39, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 27);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nombre de bande ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label4.Location = new System.Drawing.Point(39, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 27);
            this.label4.TabIndex = 7;
            this.label4.Text = "production horaire";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label5.Location = new System.Drawing.Point(39, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 27);
            this.label5.TabIndex = 8;
            this.label5.Text = "Qté à produire";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label6.Location = new System.Drawing.Point(393, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(189, 27);
            this.label6.TabIndex = 9;
            this.label6.Text = "Production jouranlier ";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtProductionJournaliere
            // 
            this.txtProductionJournaliere.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtProductionJournaliere.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductionJournaliere.Location = new System.Drawing.Point(617, 148);
            this.txtProductionJournaliere.Multiline = true;
            this.txtProductionJournaliere.Name = "txtProductionJournaliere";
            this.txtProductionJournaliere.Size = new System.Drawing.Size(95, 27);
            this.txtProductionJournaliere.TabIndex = 11;
            // 
            // txtQuantiteAProduire
            // 
            this.txtQuantiteAProduire.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtQuantiteAProduire.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQuantiteAProduire.Location = new System.Drawing.Point(202, 297);
            this.txtQuantiteAProduire.Multiline = true;
            this.txtQuantiteAProduire.Name = "txtQuantiteAProduire";
            this.txtQuantiteAProduire.Size = new System.Drawing.Size(151, 27);
            this.txtQuantiteAProduire.TabIndex = 12;
            // 
            // txtProductionHoraire
            // 
            this.txtProductionHoraire.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtProductionHoraire.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductionHoraire.Location = new System.Drawing.Point(202, 217);
            this.txtProductionHoraire.Multiline = true;
            this.txtProductionHoraire.Name = "txtProductionHoraire";
            this.txtProductionHoraire.Size = new System.Drawing.Size(151, 27);
            this.txtProductionHoraire.TabIndex = 13;
            // 
            // cbNumeroDeBande
            // 
            this.cbNumeroDeBande.FormattingEnabled = true;
            this.cbNumeroDeBande.Location = new System.Drawing.Point(202, 154);
            this.cbNumeroDeBande.Name = "cbNumeroDeBande";
            this.cbNumeroDeBande.Size = new System.Drawing.Size(93, 21);
            this.cbNumeroDeBande.TabIndex = 14;
            this.cbNumeroDeBande.SelectedIndexChanged += new System.EventHandler(this.cbNumeroDeBande_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label7.Location = new System.Drawing.Point(393, 243);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(232, 31);
            this.label7.TabIndex = 15;
            this.label7.Text = "Nombre de jours éstimés ";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // txtNombreDeJoursEstimes
            // 
            this.txtNombreDeJoursEstimes.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtNombreDeJoursEstimes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombreDeJoursEstimes.Location = new System.Drawing.Point(617, 241);
            this.txtNombreDeJoursEstimes.Multiline = true;
            this.txtNombreDeJoursEstimes.Name = "txtNombreDeJoursEstimes";
            this.txtNombreDeJoursEstimes.Size = new System.Drawing.Size(95, 27);
            this.txtNombreDeJoursEstimes.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Green;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(471, 363);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 43);
            this.button1.TabIndex = 17;
            this.button1.Text = "Ajouter";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtcodearticle
            // 
            this.txtcodearticle.FormattingEnabled = true;
            this.txtcodearticle.Location = new System.Drawing.Point(617, 94);
            this.txtcodearticle.Name = "txtcodearticle";
            this.txtcodearticle.Size = new System.Drawing.Size(151, 21);
            this.txtcodearticle.TabIndex = 19;
            this.txtcodearticle.SelectedIndexChanged += new System.EventHandler(this.txtcodearticle_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(718, 148);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(70, 26);
            this.button2.TabIndex = 20;
            this.button2.Text = "Calculer";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(718, 241);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(70, 26);
            this.button3.TabIndex = 21;
            this.button3.Text = "Calculer";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label8.Location = new System.Drawing.Point(393, 303);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 31);
            this.label8.TabIndex = 22;
            this.label8.Text = "Machine ";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(617, 304);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(151, 21);
            this.comboBox2.TabIndex = 23;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label9.Location = new System.Drawing.Point(39, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(189, 27);
            this.label9.TabIndex = 24;
            this.label9.Text = "Code Planification";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(202, 86);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(151, 27);
            this.textBox1.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label10.Location = new System.Drawing.Point(39, 363);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(189, 27);
            this.label10.TabIndex = 26;
            this.label10.Text = "Date  de  commence ";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Location = new System.Drawing.Point(212, 363);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(151, 27);
            this.textBox2.TabIndex = 27;
            // 
            // NouvellePlanificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtcodearticle);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtNombreDeJoursEstimes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbNumeroDeBande);
            this.Controls.Add(this.txtProductionHoraire);
            this.Controls.Add(this.txtQuantiteAProduire);
            this.Controls.Add(this.txtProductionJournaliere);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "NouvellePlanificationForm";
            this.Text = "NouvellePlanificationForm";
            this.Load += new System.EventHandler(this.NouvellePlanificationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtProductionJournaliere;
        private System.Windows.Forms.TextBox txtQuantiteAProduire;
        private System.Windows.Forms.TextBox txtProductionHoraire;
        private System.Windows.Forms.ComboBox cbNumeroDeBande;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNombreDeJoursEstimes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox txtcodearticle;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox2;
    }
}