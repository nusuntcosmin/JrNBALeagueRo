namespace JrNBALeagueRo
{
    partial class AppGUI
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
            this.labelDisplayMeciuri = new System.Windows.Forms.Label();
            this.tabelMeciuri = new System.Windows.Forms.DataGridView();
            this.coloanaEchipaGazda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coloanaEchipaColoana = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coloanaDataMeci = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guidMeci = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.finalDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.labelFinalInterval = new System.Windows.Forms.Label();
            this.btnFilterMeciByDate = new System.Windows.Forms.Button();
            this.btnShowEchipaGazda = new System.Windows.Forms.Button();
            this.btnShowEchipaOaspete = new System.Windows.Forms.Button();
            this.btnShowMeciScor = new System.Windows.Forms.Button();
            this.listaJucatoriActiviMeci = new System.Windows.Forms.ListView();
            this.nume = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.displayJucatoriActiviMeci = new System.Windows.Forms.Label();
            this.comboBoxEchipe = new System.Windows.Forms.ComboBox();
            this.labelDisplayEchipe = new System.Windows.Forms.Label();
            this.listJucatoriEchipaAleasa = new System.Windows.Forms.ListView();
            this.NumeJucator = new System.Windows.Forms.ColumnHeader();
            this.Scoala = new System.Windows.Forms.ColumnHeader();
            this.labelDisplayJucatoriiEchipei = new System.Windows.Forms.Label();
            this.labelNumeEchipaGazda = new System.Windows.Forms.Label();
            this.labelNumeEchipaOaspete = new System.Windows.Forms.Label();
            this.scorEchipaGazda = new System.Windows.Forms.Label();
            this.scorEchipaOaspete = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tabelMeciuri)).BeginInit();
            this.SuspendLayout();
            // 
            // labelDisplayMeciuri
            // 
            this.labelDisplayMeciuri.AutoSize = true;
            this.labelDisplayMeciuri.Location = new System.Drawing.Point(8, 14);
            this.labelDisplayMeciuri.Name = "labelDisplayMeciuri";
            this.labelDisplayMeciuri.Size = new System.Drawing.Size(69, 25);
            this.labelDisplayMeciuri.TabIndex = 0;
            this.labelDisplayMeciuri.Text = "Meciuri";
            // 
            // tabelMeciuri
            // 
            this.tabelMeciuri.AllowUserToAddRows = false;
            this.tabelMeciuri.AllowUserToDeleteRows = false;
            this.tabelMeciuri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabelMeciuri.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.coloanaEchipaGazda,
            this.coloanaEchipaColoana,
            this.coloanaDataMeci,
            this.guidMeci});
            this.tabelMeciuri.Location = new System.Drawing.Point(8, 42);
            this.tabelMeciuri.Name = "tabelMeciuri";
            this.tabelMeciuri.ReadOnly = true;
            this.tabelMeciuri.RowHeadersWidth = 62;
            this.tabelMeciuri.RowTemplate.Height = 33;
            this.tabelMeciuri.Size = new System.Drawing.Size(509, 225);
            this.tabelMeciuri.TabIndex = 1;
            this.tabelMeciuri.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabelMeciuri_CellContentClick);
            // 
            // coloanaEchipaGazda
            // 
            this.coloanaEchipaGazda.HeaderText = "Echipa gazda";
            this.coloanaEchipaGazda.MinimumWidth = 8;
            this.coloanaEchipaGazda.Name = "coloanaEchipaGazda";
            this.coloanaEchipaGazda.ReadOnly = true;
            this.coloanaEchipaGazda.Width = 150;
            // 
            // coloanaEchipaColoana
            // 
            this.coloanaEchipaColoana.HeaderText = "Echipa coloana";
            this.coloanaEchipaColoana.MinimumWidth = 8;
            this.coloanaEchipaColoana.Name = "coloanaEchipaColoana";
            this.coloanaEchipaColoana.ReadOnly = true;
            this.coloanaEchipaColoana.Width = 150;
            // 
            // coloanaDataMeci
            // 
            this.coloanaDataMeci.HeaderText = "Data meci";
            this.coloanaDataMeci.MinimumWidth = 8;
            this.coloanaDataMeci.Name = "coloanaDataMeci";
            this.coloanaDataMeci.ReadOnly = true;
            this.coloanaDataMeci.Width = 150;
            // 
            // guidMeci
            // 
            this.guidMeci.HeaderText = "guidMeci";
            this.guidMeci.MinimumWidth = 8;
            this.guidMeci.Name = "guidMeci";
            this.guidMeci.ReadOnly = true;
            this.guidMeci.Visible = false;
            this.guidMeci.Width = 150;
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Location = new System.Drawing.Point(197, 300);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(300, 31);
            this.startDateTimePicker.TabIndex = 2;
            this.startDateTimePicker.ValueChanged += new System.EventHandler(this.startDateTimePicker_ValueChanged);
            // 
            // finalDateTimePicker
            // 
            this.finalDateTimePicker.Location = new System.Drawing.Point(197, 335);
            this.finalDateTimePicker.Name = "finalDateTimePicker";
            this.finalDateTimePicker.Size = new System.Drawing.Size(300, 31);
            this.finalDateTimePicker.TabIndex = 3;
            this.finalDateTimePicker.ValueChanged += new System.EventHandler(this.finalDateTimePicker_ValueChanged);
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(18, 305);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(173, 25);
            this.labelStartDate.TabIndex = 4;
            this.labelStartDate.Text = "Inceput interval data";
            // 
            // labelFinalInterval
            // 
            this.labelFinalInterval.AutoSize = true;
            this.labelFinalInterval.Location = new System.Drawing.Point(18, 341);
            this.labelFinalInterval.Name = "labelFinalInterval";
            this.labelFinalInterval.Size = new System.Drawing.Size(150, 25);
            this.labelFinalInterval.TabIndex = 5;
            this.labelFinalInterval.Text = "Final interval data";
            // 
            // btnFilterMeciByDate
            // 
            this.btnFilterMeciByDate.Location = new System.Drawing.Point(18, 388);
            this.btnFilterMeciByDate.Name = "btnFilterMeciByDate";
            this.btnFilterMeciByDate.Size = new System.Drawing.Size(256, 34);
            this.btnFilterMeciByDate.TabIndex = 6;
            this.btnFilterMeciByDate.Text = "Afiseaza meciuri din perioada aleasa";
            this.btnFilterMeciByDate.UseVisualStyleBackColor = true;
            this.btnFilterMeciByDate.Click += new System.EventHandler(this.btnFilterMeciByDate_Click);
            // 
            // btnShowEchipaGazda
            // 
            this.btnShowEchipaGazda.Location = new System.Drawing.Point(522, 14);
            this.btnShowEchipaGazda.Name = "btnShowEchipaGazda";
            this.btnShowEchipaGazda.Size = new System.Drawing.Size(268, 34);
            this.btnShowEchipaGazda.TabIndex = 7;
            this.btnShowEchipaGazda.Text = "Afiseaza line up echipa gazda";
            this.btnShowEchipaGazda.UseVisualStyleBackColor = true;
            this.btnShowEchipaGazda.Click += new System.EventHandler(this.btnShowEchipaGazda_Click);
            // 
            // btnShowEchipaOaspete
            // 
            this.btnShowEchipaOaspete.Location = new System.Drawing.Point(522, 54);
            this.btnShowEchipaOaspete.Name = "btnShowEchipaOaspete";
            this.btnShowEchipaOaspete.Size = new System.Drawing.Size(267, 34);
            this.btnShowEchipaOaspete.TabIndex = 8;
            this.btnShowEchipaOaspete.Text = "Afiseaza line up echipa oaspete";
            this.btnShowEchipaOaspete.UseVisualStyleBackColor = true;
            this.btnShowEchipaOaspete.Click += new System.EventHandler(this.btnShowEchipaOaspete_Click);
            // 
            // btnShowMeciScor
            // 
            this.btnShowMeciScor.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnShowMeciScor.Location = new System.Drawing.Point(525, 94);
            this.btnShowMeciScor.Name = "btnShowMeciScor";
            this.btnShowMeciScor.Size = new System.Drawing.Size(268, 34);
            this.btnShowMeciScor.TabIndex = 9;
            this.btnShowMeciScor.Text = "Afiseaza scor meci selectat";
            this.btnShowMeciScor.UseVisualStyleBackColor = true;
            this.btnShowMeciScor.Click += new System.EventHandler(this.btnMeciScor_Click);
            // 
            // listaJucatoriActiviMeci
            // 
            this.listaJucatoriActiviMeci.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nume,
            this.columnHeader1});
            this.listaJucatoriActiviMeci.Location = new System.Drawing.Point(799, 54);
            this.listaJucatoriActiviMeci.Name = "listaJucatoriActiviMeci";
            this.listaJucatoriActiviMeci.Size = new System.Drawing.Size(416, 225);
            this.listaJucatoriActiviMeci.TabIndex = 14;
            this.listaJucatoriActiviMeci.UseCompatibleStateImageBehavior = false;
            this.listaJucatoriActiviMeci.View = System.Windows.Forms.View.Details;
            // 
            // nume
            // 
            this.nume.Text = "Nume jucator";
            this.nume.Width = 150;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "scoala";
            this.columnHeader1.Width = 300;
            // 
            // displayJucatoriActiviMeci
            // 
            this.displayJucatoriActiviMeci.AutoSize = true;
            this.displayJucatoriActiviMeci.Location = new System.Drawing.Point(799, 14);
            this.displayJucatoriActiviMeci.Name = "displayJucatoriActiviMeci";
            this.displayJucatoriActiviMeci.Size = new System.Drawing.Size(276, 25);
            this.displayJucatoriActiviMeci.TabIndex = 15;
            this.displayJucatoriActiviMeci.Text = "Jucatori activi din echipa selectata";
            // 
            // comboBoxEchipe
            // 
            this.comboBoxEchipe.FormattingEnabled = true;
            this.comboBoxEchipe.Items.AddRange(new object[] {
            "Atlanta Hawks",
            "Boston Celtics",
            "Brooklyn Nets",
            "Charlotte Hornets",
            "Chicago Bulls",
            "Cleveland Cavaliers",
            "Dallas Mavericks",
            "Denver Nuggets",
            "Detroit Pistons",
            "Golden State Warriors",
            "Houston Rockets",
            "Indiana Pacers",
            "Los Angeles Clippers",
            "Los Angeles Lakers",
            "Memphis Grizzlies",
            "Miami Heat",
            "Milwaukee Bucks",
            "Minnesota Timberwolves",
            "New Orleans Pelicans",
            "New York Knicks",
            "Oklahoma City Thunder",
            "Orlando Magic",
            "Philadelphia 76ers",
            "Phoenix Suns",
            "Portland Trail Blazers",
            "Sacramento Kings",
            "San Antonio Spurs",
            "Toronto Raptors",
            "Utah Jazz",
            "Washington Wizards"});
            this.comboBoxEchipe.Location = new System.Drawing.Point(523, 333);
            this.comboBoxEchipe.Name = "comboBoxEchipe";
            this.comboBoxEchipe.Size = new System.Drawing.Size(182, 33);
            this.comboBoxEchipe.TabIndex = 16;
            this.comboBoxEchipe.SelectedIndexChanged += new System.EventHandler(this.comboBoxEchipe_SelectedIndexChanged);
            // 
            // labelDisplayEchipe
            // 
            this.labelDisplayEchipe.AutoSize = true;
            this.labelDisplayEchipe.Location = new System.Drawing.Point(553, 306);
            this.labelDisplayEchipe.Name = "labelDisplayEchipe";
            this.labelDisplayEchipe.Size = new System.Drawing.Size(63, 25);
            this.labelDisplayEchipe.TabIndex = 17;
            this.labelDisplayEchipe.Text = "Echipe";
            // 
            // listJucatoriEchipaAleasa
            // 
            this.listJucatoriEchipaAleasa.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NumeJucator,
            this.Scoala});
            this.listJucatoriEchipaAleasa.Location = new System.Drawing.Point(711, 333);
            this.listJucatoriEchipaAleasa.Name = "listJucatoriEchipaAleasa";
            this.listJucatoriEchipaAleasa.Size = new System.Drawing.Size(504, 146);
            this.listJucatoriEchipaAleasa.TabIndex = 18;
            this.listJucatoriEchipaAleasa.UseCompatibleStateImageBehavior = false;
            this.listJucatoriEchipaAleasa.View = System.Windows.Forms.View.Details;
            // 
            // NumeJucator
            // 
            this.NumeJucator.Text = "Nume Jucator";
            this.NumeJucator.Width = 150;
            // 
            // Scoala
            // 
            this.Scoala.Text = "Scoala";
            this.Scoala.Width = 350;
            // 
            // labelDisplayJucatoriiEchipei
            // 
            this.labelDisplayJucatoriiEchipei.AutoSize = true;
            this.labelDisplayJucatoriiEchipei.Location = new System.Drawing.Point(864, 298);
            this.labelDisplayJucatoriiEchipei.Name = "labelDisplayJucatoriiEchipei";
            this.labelDisplayJucatoriiEchipei.Size = new System.Drawing.Size(180, 25);
            this.labelDisplayJucatoriiEchipei.TabIndex = 19;
            this.labelDisplayJucatoriiEchipei.Text = "Jucatorii echipei alese";
            // 
            // labelNumeEchipaGazda
            // 
            this.labelNumeEchipaGazda.AutoSize = true;
            this.labelNumeEchipaGazda.Location = new System.Drawing.Point(525, 140);
            this.labelNumeEchipaGazda.Name = "labelNumeEchipaGazda";
            this.labelNumeEchipaGazda.Size = new System.Drawing.Size(59, 25);
            this.labelNumeEchipaGazda.TabIndex = 20;
            this.labelNumeEchipaGazda.Text = "label1";
            // 
            // labelNumeEchipaOaspete
            // 
            this.labelNumeEchipaOaspete.AutoSize = true;
            this.labelNumeEchipaOaspete.Location = new System.Drawing.Point(529, 217);
            this.labelNumeEchipaOaspete.Name = "labelNumeEchipaOaspete";
            this.labelNumeEchipaOaspete.Size = new System.Drawing.Size(59, 25);
            this.labelNumeEchipaOaspete.TabIndex = 21;
            this.labelNumeEchipaOaspete.Text = "label2";
            // 
            // scorEchipaGazda
            // 
            this.scorEchipaGazda.AutoSize = true;
            this.scorEchipaGazda.Location = new System.Drawing.Point(525, 174);
            this.scorEchipaGazda.Name = "scorEchipaGazda";
            this.scorEchipaGazda.Size = new System.Drawing.Size(59, 25);
            this.scorEchipaGazda.TabIndex = 22;
            this.scorEchipaGazda.Text = "label3";
            // 
            // scorEchipaOaspete
            // 
            this.scorEchipaOaspete.AutoSize = true;
            this.scorEchipaOaspete.Location = new System.Drawing.Point(529, 254);
            this.scorEchipaOaspete.Name = "scorEchipaOaspete";
            this.scorEchipaOaspete.Size = new System.Drawing.Size(59, 25);
            this.scorEchipaOaspete.TabIndex = 23;
            this.scorEchipaOaspete.Text = "label4";
            // 
            // AppGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 489);
            this.Controls.Add(this.scorEchipaOaspete);
            this.Controls.Add(this.scorEchipaGazda);
            this.Controls.Add(this.labelNumeEchipaOaspete);
            this.Controls.Add(this.labelNumeEchipaGazda);
            this.Controls.Add(this.labelDisplayJucatoriiEchipei);
            this.Controls.Add(this.listJucatoriEchipaAleasa);
            this.Controls.Add(this.labelDisplayEchipe);
            this.Controls.Add(this.comboBoxEchipe);
            this.Controls.Add(this.displayJucatoriActiviMeci);
            this.Controls.Add(this.listaJucatoriActiviMeci);
            this.Controls.Add(this.btnShowMeciScor);
            this.Controls.Add(this.btnShowEchipaOaspete);
            this.Controls.Add(this.btnShowEchipaGazda);
            this.Controls.Add(this.btnFilterMeciByDate);
            this.Controls.Add(this.labelFinalInterval);
            this.Controls.Add(this.labelStartDate);
            this.Controls.Add(this.finalDateTimePicker);
            this.Controls.Add(this.startDateTimePicker);
            this.Controls.Add(this.tabelMeciuri);
            this.Controls.Add(this.labelDisplayMeciuri);
            this.Name = "AppGUI";
            this.Text = "AppGUI";
            ((System.ComponentModel.ISupportInitialize)(this.tabelMeciuri)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelDisplayMeciuri;
        private DataGridView tabelMeciuri;
        private DateTimePicker startDateTimePicker;
        private DateTimePicker finalDateTimePicker;
        private Label labelStartDate;
        private Label labelFinalInterval;
        private Button btnFilterMeciByDate;
        private Button btnShowEchipaGazda;
        private Button btnShowEchipaOaspete;
        private Button btnShowMeciScor;
        //private Label labelNumeEchipaGazda;
        //private Label labelNumeEchipaOaspete;
        //private Label scorEchipaGazda;
        //private Label scorEchipaOaspete;
        private ListView listaJucatoriActiviMeci;
        private Label displayJucatoriActiviMeci;
        private ComboBox comboBoxEchipe;
        private Label labelDisplayEchipe;
        private ListView listJucatoriEchipaAleasa;
        private Label labelDisplayJucatoriiEchipei;
        private ColumnHeader NumeJucator;
        private ColumnHeader Scoala;
        private DataGridViewTextBoxColumn coloanaEchipaGazda;
        private DataGridViewTextBoxColumn coloanaEchipaColoana;
        private DataGridViewTextBoxColumn coloanaDataMeci;
        private DataGridViewTextBoxColumn guidMeci;
        private ColumnHeader nume;
        private ColumnHeader columnHeader1;
        private Label labelNumeEchipaGazda;
        private Label labelNumeEchipaOaspete;
        private Label scorEchipaGazda;
        private Label scorEchipaOaspete;
    }
}