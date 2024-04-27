namespace gestionstock3
{
    partial class CalculPlanification
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
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxNBdayREST = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxQTé = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(351, 41);
            this.label3.TabIndex = 6;
            this.label3.Text = "Calcul Planification";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label8.Location = new System.Drawing.Point(12, 272);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(280, 24);
            this.label8.TabIndex = 19;
            this.label8.Text = "Nombre de jours restant ";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // textBoxNBdayREST
            // 
            this.textBoxNBdayREST.Location = new System.Drawing.Point(271, 275);
            this.textBoxNBdayREST.Name = "textBoxNBdayREST";
            this.textBoxNBdayREST.Size = new System.Drawing.Size(142, 20);
            this.textBoxNBdayREST.TabIndex = 20;
            this.textBoxNBdayREST.TextChanged += new System.EventHandler(this.textBoxNBdayREST_TextChanged);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button2.Location = new System.Drawing.Point(16, 384);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(153, 50);
            this.button2.TabIndex = 22;
            this.button2.Text = "Calcul";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label9.Location = new System.Drawing.Point(12, 222);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(253, 27);
            this.label9.TabIndex = 23;
            this.label9.Text = "Qté de production Restante";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // textBoxQTé
            // 
            this.textBoxQTé.Location = new System.Drawing.Point(271, 222);
            this.textBoxQTé.Name = "textBoxQTé";
            this.textBoxQTé.Size = new System.Drawing.Size(142, 20);
            this.textBoxQTé.TabIndex = 24;
            this.textBoxQTé.TextChanged += new System.EventHandler(this.textBoxQTé_TextChanged);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.button3.Location = new System.Drawing.Point(341, 384);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(162, 50);
            this.button3.TabIndex = 25;
            this.button3.Text = "Enregistrer Votre calul";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label10.Location = new System.Drawing.Point(12, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(262, 27);
            this.label10.TabIndex = 26;
            this.label10.Text = "Quantité à produire ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(271, 97);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(142, 20);
            this.textBox1.TabIndex = 27;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(449, 95);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(63, 24);
            this.button4.TabIndex = 28;
            this.button4.Text = "Importer";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label6.Location = new System.Drawing.Point(12, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(253, 27);
            this.label6.TabIndex = 29;
            this.label6.Text = "Production jouranlière saisie";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(271, 184);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(142, 20);
            this.textBox2.TabIndex = 31;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label1.Location = new System.Drawing.Point(14, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 27);
            this.label1.TabIndex = 33;
            this.label1.Text = "Date de jour";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(271, 148);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(181, 20);
            this.dateTimePicker1.TabIndex = 34;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(439, 275);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 21);
            this.button1.TabIndex = 35;
            this.button1.Text = "Calculer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.button5.Location = new System.Drawing.Point(175, 384);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(160, 50);
            this.button5.TabIndex = 36;
            this.button5.Text = "Enregistrer Votre Date";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button6.Location = new System.Drawing.Point(521, 384);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(153, 50);
            this.button6.TabIndex = 37;
            this.button6.Text = "Annuler";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label2.Location = new System.Drawing.Point(14, 315);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 24);
            this.label2.TabIndex = 38;
            this.label2.Text = "Rendement ";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label4.Location = new System.Drawing.Point(14, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(214, 24);
            this.label4.TabIndex = 39;
            this.label4.Text = "Date  de  commence";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(271, 64);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(181, 20);
            this.dateTimePicker2.TabIndex = 41;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(271, 315);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(142, 20);
            this.textBox3.TabIndex = 42;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(439, 314);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(73, 21);
            this.button7.TabIndex = 43;
            this.button7.Text = "Calculer";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // CalculPlanification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 450);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBoxQTé);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBoxNBdayREST);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Name = "CalculPlanification";
            this.Text = "CalculPlanification";
            this.Load += new System.EventHandler(this.CalculPlanification_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxNBdayREST;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxQTé;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button7;
    }
}