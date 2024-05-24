namespace ProjektNr2_Piwowarski62024
{
    partial class KokpitProjektuNr2
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
            this.btnSzeregIndywidualny = new System.Windows.Forms.Button();
            this.btnSzeregLaboratoryjny = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSzeregIndywidualny
            // 
            this.btnSzeregIndywidualny.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSzeregIndywidualny.Location = new System.Drawing.Point(446, 179);
            this.btnSzeregIndywidualny.Name = "btnSzeregIndywidualny";
            this.btnSzeregIndywidualny.Size = new System.Drawing.Size(240, 175);
            this.btnSzeregIndywidualny.TabIndex = 5;
            this.btnSzeregIndywidualny.Text = "Projekt Nr 2\r\n(Analizator Szeregu Indywidualnego)";
            this.btnSzeregIndywidualny.UseVisualStyleBackColor = true;
            this.btnSzeregIndywidualny.Click += new System.EventHandler(this.btnSzeregIndywidualny_Click);
            // 
            // btnSzeregLaboratoryjny
            // 
            this.btnSzeregLaboratoryjny.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSzeregLaboratoryjny.Location = new System.Drawing.Point(115, 178);
            this.btnSzeregLaboratoryjny.Name = "btnSzeregLaboratoryjny";
            this.btnSzeregLaboratoryjny.Size = new System.Drawing.Size(240, 175);
            this.btnSzeregLaboratoryjny.TabIndex = 4;
            this.btnSzeregLaboratoryjny.Text = "Laboratorium Nr 2\r\n(Analizator Szeregu Laboratoryjnego)";
            this.btnSzeregLaboratoryjny.UseVisualStyleBackColor = true;
            this.btnSzeregLaboratoryjny.Click += new System.EventHandler(this.btnSzeregLaboratoryjny_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(275, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Analizator Szeregów";
            // 
            // KokpitProjektuNr2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSzeregIndywidualny);
            this.Controls.Add(this.btnSzeregLaboratoryjny);
            this.Controls.Add(this.label1);
            this.Name = "KokpitProjektuNr2";
            this.Text = "KokpitProjektuNr2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KokpitProjektuNr2_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSzeregIndywidualny;
        private System.Windows.Forms.Button btnSzeregLaboratoryjny;
        private System.Windows.Forms.Label label1;
    }
}

