namespace ProjektNr2_Piwowarski62024
{
    partial class SzeregLaboratoryjny
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.txtH = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtXg = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtXd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEps = new System.Windows.Forms.TextBox();
            this.txtX = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnResetuj = new System.Windows.Forms.Button();
            this.btnWizualizacjaGraficzna = new System.Windows.Forms.Button();
            this.btnWizualizacjaTabelaryczna = new System.Windows.Forms.Button();
            this.btnObliczWartoscSzeregu = new System.Windows.Forms.Button();
            this.txtSumaSzeregu = new System.Windows.Forms.TextBox();
            this.txtLicznikWyrazow = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvTWS = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zapisanieTablicyTWSWPlikuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitZamknięcieFormularzaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atrybutyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zmianaKoloruTłaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zmianaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zmianaKoloruCzcionkiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atrybutyKonotrlkiDataGridViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zmianaCzcionkiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zmianaKoloruCzcionkiToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.atrybutyKontrolkiChartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zmianaTypuWykresuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zmianaKoloruToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zmianaStyluLiniiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chtWykresSzeregu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.LicznikWyrazow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WartoscSzeregu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WartoscX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTWS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtWykresSzeregu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtH
            // 
            this.txtH.Location = new System.Drawing.Point(81, 544);
            this.txtH.Name = "txtH";
            this.txtH.Size = new System.Drawing.Size(100, 20);
            this.txtH.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(54, 483);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(160, 42);
            this.label8.TabIndex = 25;
            this.label8.Text = "Przyrost h zmian\r\nwartości zmiennej X";
            // 
            // txtXg
            // 
            this.txtXg.Location = new System.Drawing.Point(81, 439);
            this.txtXg.Name = "txtXg";
            this.txtXg.Size = new System.Drawing.Size(100, 20);
            this.txtXg.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(63, 401);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 21);
            this.label7.TabIndex = 23;
            this.label7.Text = "Górna granica Xg";
            // 
            // txtXd
            // 
            this.txtXd.Location = new System.Drawing.Point(81, 348);
            this.txtXd.Name = "txtXd";
            this.txtXd.Size = new System.Drawing.Size(100, 20);
            this.txtXd.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(65, 316);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 21);
            this.label6.TabIndex = 21;
            this.label6.Text = "Dolna granica Xd";
            // 
            // txtEps
            // 
            this.txtEps.Location = new System.Drawing.Point(81, 266);
            this.txtEps.Name = "txtEps";
            this.txtEps.Size = new System.Drawing.Size(100, 20);
            this.txtEps.TabIndex = 20;
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(84, 179);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(100, 20);
            this.txtX.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(36, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 21);
            this.label3.TabIndex = 18;
            this.label3.Text = "Dokładność obliczeń Eps";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(25, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 21);
            this.label2.TabIndex = 17;
            this.label2.Text = "Wartość zmiennej niezależnej X";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(241, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(663, 36);
            this.label1.TabIndex = 16;
            this.label1.Text = "Analizator laboratoryjnego szeregu potęgowego";
            // 
            // btnResetuj
            // 
            this.btnResetuj.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnResetuj.Location = new System.Drawing.Point(897, 526);
            this.btnResetuj.Name = "btnResetuj";
            this.btnResetuj.Size = new System.Drawing.Size(210, 75);
            this.btnResetuj.TabIndex = 34;
            this.btnResetuj.Text = "RESETUJ\r\n(ustaw stan początkowy)";
            this.btnResetuj.UseVisualStyleBackColor = true;
            this.btnResetuj.Click += new System.EventHandler(this.btnResetuj_Click);
            // 
            // btnWizualizacjaGraficzna
            // 
            this.btnWizualizacjaGraficzna.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnWizualizacjaGraficzna.Location = new System.Drawing.Point(897, 449);
            this.btnWizualizacjaGraficzna.Name = "btnWizualizacjaGraficzna";
            this.btnWizualizacjaGraficzna.Size = new System.Drawing.Size(210, 71);
            this.btnWizualizacjaGraficzna.TabIndex = 33;
            this.btnWizualizacjaGraficzna.Text = "Wizualizacja graficzna zmian wartości";
            this.btnWizualizacjaGraficzna.UseVisualStyleBackColor = true;
            this.btnWizualizacjaGraficzna.Click += new System.EventHandler(this.btnWizualizacjaGraficzna_Click);
            // 
            // btnWizualizacjaTabelaryczna
            // 
            this.btnWizualizacjaTabelaryczna.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnWizualizacjaTabelaryczna.Location = new System.Drawing.Point(897, 357);
            this.btnWizualizacjaTabelaryczna.Name = "btnWizualizacjaTabelaryczna";
            this.btnWizualizacjaTabelaryczna.Size = new System.Drawing.Size(210, 82);
            this.btnWizualizacjaTabelaryczna.TabIndex = 32;
            this.btnWizualizacjaTabelaryczna.Text = "Wizualizacja zmian \r\nwartosci szeregu \r\npotęgowego";
            this.btnWizualizacjaTabelaryczna.UseVisualStyleBackColor = true;
            this.btnWizualizacjaTabelaryczna.Click += new System.EventHandler(this.btnWizualizacjaTabelaryczna_Click);
            // 
            // btnObliczWartoscSzeregu
            // 
            this.btnObliczWartoscSzeregu.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnObliczWartoscSzeregu.Location = new System.Drawing.Point(897, 290);
            this.btnObliczWartoscSzeregu.Name = "btnObliczWartoscSzeregu";
            this.btnObliczWartoscSzeregu.Size = new System.Drawing.Size(210, 49);
            this.btnObliczWartoscSzeregu.TabIndex = 31;
            this.btnObliczWartoscSzeregu.Text = "Oblicz wartość szeregu";
            this.btnObliczWartoscSzeregu.UseVisualStyleBackColor = true;
            this.btnObliczWartoscSzeregu.Click += new System.EventHandler(this.btnObliczWartoscSzeregu_Click);
            // 
            // txtSumaSzeregu
            // 
            this.txtSumaSzeregu.Location = new System.Drawing.Point(947, 181);
            this.txtSumaSzeregu.Name = "txtSumaSzeregu";
            this.txtSumaSzeregu.ReadOnly = true;
            this.txtSumaSzeregu.Size = new System.Drawing.Size(100, 20);
            this.txtSumaSzeregu.TabIndex = 30;
            // 
            // txtLicznikWyrazow
            // 
            this.txtLicznikWyrazow.Location = new System.Drawing.Point(947, 254);
            this.txtLicznikWyrazow.Name = "txtLicznikWyrazow";
            this.txtLicznikWyrazow.ReadOnly = true;
            this.txtLicznikWyrazow.Size = new System.Drawing.Size(100, 20);
            this.txtLicznikWyrazow.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(850, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(308, 21);
            this.label5.TabIndex = 28;
            this.label5.Text = "Licznik zsumowanych wyrazów szeregu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(893, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(211, 21);
            this.label4.TabIndex = 27;
            this.label4.Text = "Obliczona wartość szeregu";
            // 
            // dgvTWS
            // 
            this.dgvTWS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTWS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WartoscX,
            this.WartoscSzeregu,
            this.LicznikWyrazow});
            this.dgvTWS.Location = new System.Drawing.Point(357, 139);
            this.dgvTWS.Name = "dgvTWS";
            this.dgvTWS.Size = new System.Drawing.Size(449, 445);
            this.dgvTWS.TabIndex = 35;
            this.dgvTWS.Visible = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dToolStripMenuItem,
            this.atrybutyToolStripMenuItem,
            this.atrybutyKonotrlkiDataGridViewToolStripMenuItem,
            this.atrybutyKontrolkiChartToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1180, 24);
            this.menuStrip1.TabIndex = 36;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dToolStripMenuItem
            // 
            this.dToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zapisanieTablicyTWSWPlikuToolStripMenuItem,
            this.dToolStripMenuItem1,
            this.restartToolStripMenuItem,
            this.exitZamknięcieFormularzaToolStripMenuItem});
            this.dToolStripMenuItem.Name = "dToolStripMenuItem";
            this.dToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.dToolStripMenuItem.Text = "Plik";
            // 
            // zapisanieTablicyTWSWPlikuToolStripMenuItem
            // 
            this.zapisanieTablicyTWSWPlikuToolStripMenuItem.Name = "zapisanieTablicyTWSWPlikuToolStripMenuItem";
            this.zapisanieTablicyTWSWPlikuToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.zapisanieTablicyTWSWPlikuToolStripMenuItem.Text = "Zapisanie tablicy TWS w pliku";
            this.zapisanieTablicyTWSWPlikuToolStripMenuItem.Click += new System.EventHandler(this.zapisanieTablicyTWSWPlikuToolStripMenuItem_Click);
            // 
            // dToolStripMenuItem1
            // 
            this.dToolStripMenuItem1.Name = "dToolStripMenuItem1";
            this.dToolStripMenuItem1.Size = new System.Drawing.Size(234, 22);
            this.dToolStripMenuItem1.Text = "Odczytanie tablicy TWS z pliku";
            this.dToolStripMenuItem1.Click += new System.EventHandler(this.dToolStripMenuItem1_Click);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.restartToolStripMenuItem.Text = "Restart programu";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // exitZamknięcieFormularzaToolStripMenuItem
            // 
            this.exitZamknięcieFormularzaToolStripMenuItem.Name = "exitZamknięcieFormularzaToolStripMenuItem";
            this.exitZamknięcieFormularzaToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.exitZamknięcieFormularzaToolStripMenuItem.Text = "Exit zamknięcie formularza";
            this.exitZamknięcieFormularzaToolStripMenuItem.Click += new System.EventHandler(this.exitZamknięcieFormularzaToolStripMenuItem_Click);
            // 
            // atrybutyToolStripMenuItem
            // 
            this.atrybutyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zmianaKoloruTłaToolStripMenuItem,
            this.zmianaToolStripMenuItem,
            this.zmianaKoloruCzcionkiToolStripMenuItem});
            this.atrybutyToolStripMenuItem.Name = "atrybutyToolStripMenuItem";
            this.atrybutyToolStripMenuItem.Size = new System.Drawing.Size(125, 20);
            this.atrybutyToolStripMenuItem.Text = "Atrybuty formularza";
            // 
            // zmianaKoloruTłaToolStripMenuItem
            // 
            this.zmianaKoloruTłaToolStripMenuItem.Name = "zmianaKoloruTłaToolStripMenuItem";
            this.zmianaKoloruTłaToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.zmianaKoloruTłaToolStripMenuItem.Text = "Zmiana koloru tła";
            this.zmianaKoloruTłaToolStripMenuItem.Click += new System.EventHandler(this.zmianaKoloruTłaToolStripMenuItem_Click);
            // 
            // zmianaToolStripMenuItem
            // 
            this.zmianaToolStripMenuItem.Name = "zmianaToolStripMenuItem";
            this.zmianaToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.zmianaToolStripMenuItem.Text = "Zmiana czcionki";
            this.zmianaToolStripMenuItem.Click += new System.EventHandler(this.zmianaToolStripMenuItem_Click);
            // 
            // zmianaKoloruCzcionkiToolStripMenuItem
            // 
            this.zmianaKoloruCzcionkiToolStripMenuItem.Name = "zmianaKoloruCzcionkiToolStripMenuItem";
            this.zmianaKoloruCzcionkiToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.zmianaKoloruCzcionkiToolStripMenuItem.Text = "Zmiana koloru czcionki";
            // 
            // atrybutyKonotrlkiDataGridViewToolStripMenuItem
            // 
            this.atrybutyKonotrlkiDataGridViewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zmianaCzcionkiToolStripMenuItem,
            this.zmianaKoloruCzcionkiToolStripMenuItem1});
            this.atrybutyKonotrlkiDataGridViewToolStripMenuItem.Name = "atrybutyKonotrlkiDataGridViewToolStripMenuItem";
            this.atrybutyKonotrlkiDataGridViewToolStripMenuItem.Size = new System.Drawing.Size(189, 20);
            this.atrybutyKonotrlkiDataGridViewToolStripMenuItem.Text = "Atrybuty konotrlki DataGridView";
            // 
            // zmianaCzcionkiToolStripMenuItem
            // 
            this.zmianaCzcionkiToolStripMenuItem.Name = "zmianaCzcionkiToolStripMenuItem";
            this.zmianaCzcionkiToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.zmianaCzcionkiToolStripMenuItem.Text = "Zmiana czcionki";
            // 
            // zmianaKoloruCzcionkiToolStripMenuItem1
            // 
            this.zmianaKoloruCzcionkiToolStripMenuItem1.Name = "zmianaKoloruCzcionkiToolStripMenuItem1";
            this.zmianaKoloruCzcionkiToolStripMenuItem1.Size = new System.Drawing.Size(197, 22);
            this.zmianaKoloruCzcionkiToolStripMenuItem1.Text = "Zmiana koloru czcionki";
            // 
            // atrybutyKontrolkiChartToolStripMenuItem
            // 
            this.atrybutyKontrolkiChartToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zmianaTypuWykresuToolStripMenuItem,
            this.zmianaKoloruToolStripMenuItem,
            this.zmianaStyluLiniiToolStripMenuItem});
            this.atrybutyKontrolkiChartToolStripMenuItem.Name = "atrybutyKontrolkiChartToolStripMenuItem";
            this.atrybutyKontrolkiChartToolStripMenuItem.Size = new System.Drawing.Size(147, 20);
            this.atrybutyKontrolkiChartToolStripMenuItem.Text = "Atrybuty kontrolki Chart";
            // 
            // zmianaTypuWykresuToolStripMenuItem
            // 
            this.zmianaTypuWykresuToolStripMenuItem.Name = "zmianaTypuWykresuToolStripMenuItem";
            this.zmianaTypuWykresuToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.zmianaTypuWykresuToolStripMenuItem.Text = "Zmiana typu wykresu";
            // 
            // zmianaKoloruToolStripMenuItem
            // 
            this.zmianaKoloruToolStripMenuItem.Name = "zmianaKoloruToolStripMenuItem";
            this.zmianaKoloruToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.zmianaKoloruToolStripMenuItem.Text = "Zmiana koloru wykresu";
            // 
            // zmianaStyluLiniiToolStripMenuItem
            // 
            this.zmianaStyluLiniiToolStripMenuItem.Name = "zmianaStyluLiniiToolStripMenuItem";
            this.zmianaStyluLiniiToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.zmianaStyluLiniiToolStripMenuItem.Text = "Zmiana stylu linii";
            // 
            // chtWykresSzeregu
            // 
            chartArea1.Name = "ChartArea1";
            this.chtWykresSzeregu.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chtWykresSzeregu.Legends.Add(legend1);
            this.chtWykresSzeregu.Location = new System.Drawing.Point(357, 139);
            this.chtWykresSzeregu.Name = "chtWykresSzeregu";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chtWykresSzeregu.Series.Add(series1);
            this.chtWykresSzeregu.Size = new System.Drawing.Size(452, 445);
            this.chtWykresSzeregu.TabIndex = 37;
            this.chtWykresSzeregu.Text = "chart1";
            this.chtWykresSzeregu.Visible = false;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // LicznikWyrazow
            // 
            this.LicznikWyrazow.HeaderText = "Liczba zsumowanych wyrazów szeregu: S(X)";
            this.LicznikWyrazow.Name = "LicznikWyrazow";
            this.LicznikWyrazow.Width = 135;
            // 
            // WartoscSzeregu
            // 
            this.WartoscSzeregu.HeaderText = "Obliczona wartość szeregu: S(X)";
            this.WartoscSzeregu.Name = "WartoscSzeregu";
            this.WartoscSzeregu.Width = 135;
            // 
            // WartoscX
            // 
            this.WartoscX.HeaderText = "Wartość zmiennej niezależnej X";
            this.WartoscX.Name = "WartoscX";
            this.WartoscX.Width = 135;
            // 
            // SzeregLaboratoryjny
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 688);
            this.Controls.Add(this.chtWykresSzeregu);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dgvTWS);
            this.Controls.Add(this.btnResetuj);
            this.Controls.Add(this.btnWizualizacjaGraficzna);
            this.Controls.Add(this.btnWizualizacjaTabelaryczna);
            this.Controls.Add(this.btnObliczWartoscSzeregu);
            this.Controls.Add(this.txtSumaSzeregu);
            this.Controls.Add(this.txtLicznikWyrazow);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtH);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtXg);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtXd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtEps);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SzeregLaboratoryjny";
            this.Text = "SzeregLaboratoryjny";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SzeregLaboratoryjny_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTWS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtWykresSzeregu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtH;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtXg;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtXd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEps;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnResetuj;
        private System.Windows.Forms.Button btnWizualizacjaGraficzna;
        private System.Windows.Forms.Button btnWizualizacjaTabelaryczna;
        private System.Windows.Forms.Button btnObliczWartoscSzeregu;
        private System.Windows.Forms.TextBox txtSumaSzeregu;
        private System.Windows.Forms.TextBox txtLicznikWyrazow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvTWS;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zapisanieTablicyTWSWPlikuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitZamknięcieFormularzaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atrybutyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zmianaKoloruTłaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zmianaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zmianaKoloruCzcionkiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atrybutyKonotrlkiDataGridViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zmianaCzcionkiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zmianaKoloruCzcionkiToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem atrybutyKontrolkiChartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zmianaTypuWykresuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zmianaKoloruToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zmianaStyluLiniiToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtWykresSzeregu;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.DataGridViewTextBoxColumn WartoscX;
        private System.Windows.Forms.DataGridViewTextBoxColumn WartoscSzeregu;
        private System.Windows.Forms.DataGridViewTextBoxColumn LicznikWyrazow;
    }
}