namespace TLENREADER_NET
{
    partial class TlenReaderNET
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
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otwórzArchiwumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usunięteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nieusunięteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otwórzArchiwumTlen7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otwórzArchSMSTlen6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zamknijArchiwumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportujArchiwumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eksportujCałeArchiwumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eksportujCałeArchSMSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.koniecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pomocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oProgramieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listView_ListaRozm = new System.Windows.Forms.ListView();
            this.Nr_rozm = new System.Windows.Forms.ColumnHeader();
            this.Login_rozmówcy = new System.Windows.Forms.ColumnHeader();
            this.Czas_rozp_rozmowy = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Exportuj_rozm = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox_Wypowiedź = new System.Windows.Forms.RichTextBox();
            this.radioButton_T7Rozm = new System.Windows.Forms.RadioButton();
            this.radioButton_T7SMS = new System.Windows.Forms.RadioButton();
            this.radioButton_T7Czaty = new System.Windows.Forms.RadioButton();
            this.radioButton_T7Konf = new System.Windows.Forms.RadioButton();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lista rozmów";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.pomocToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(718, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.otwórzArchiwumToolStripMenuItem,
            this.otwórzArchiwumTlen7ToolStripMenuItem,
            this.otwórzArchSMSTlen6ToolStripMenuItem,
            this.zamknijArchiwumToolStripMenuItem,
            this.exportujArchiwumToolStripMenuItem,
            this.eksportujCałeArchiwumToolStripMenuItem,
            this.eksportujCałeArchSMSToolStripMenuItem,
            this.koniecToolStripMenuItem});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // otwórzArchiwumToolStripMenuItem
            // 
            this.otwórzArchiwumToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usunięteToolStripMenuItem,
            this.nieusunięteToolStripMenuItem});
            this.otwórzArchiwumToolStripMenuItem.Name = "otwórzArchiwumToolStripMenuItem";
            this.otwórzArchiwumToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.otwórzArchiwumToolStripMenuItem.Text = "Otwórz archiwum Tlen 6";
            // 
            // usunięteToolStripMenuItem
            // 
            this.usunięteToolStripMenuItem.Name = "usunięteToolStripMenuItem";
            this.usunięteToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.usunięteToolStripMenuItem.Text = "Usunięte";
            this.usunięteToolStripMenuItem.Click += new System.EventHandler(this.usunięteToolStripMenuItem_Click);
            // 
            // nieusunięteToolStripMenuItem
            // 
            this.nieusunięteToolStripMenuItem.Name = "nieusunięteToolStripMenuItem";
            this.nieusunięteToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.nieusunięteToolStripMenuItem.Text = "Nieusunięte";
            this.nieusunięteToolStripMenuItem.Click += new System.EventHandler(this.nieusunięteToolStripMenuItem_Click);
            // 
            // otwórzArchiwumTlen7ToolStripMenuItem
            // 
            this.otwórzArchiwumTlen7ToolStripMenuItem.Name = "otwórzArchiwumTlen7ToolStripMenuItem";
            this.otwórzArchiwumTlen7ToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.otwórzArchiwumTlen7ToolStripMenuItem.Text = "Otwórz archiwum Tlen 7";
            this.otwórzArchiwumTlen7ToolStripMenuItem.Visible = false;
            // 
            // otwórzArchSMSTlen6ToolStripMenuItem
            // 
            this.otwórzArchSMSTlen6ToolStripMenuItem.Name = "otwórzArchSMSTlen6ToolStripMenuItem";
            this.otwórzArchSMSTlen6ToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.otwórzArchSMSTlen6ToolStripMenuItem.Text = "Otwórz arch. SMS Tlen 6";
            this.otwórzArchSMSTlen6ToolStripMenuItem.Click += new System.EventHandler(this.otwórzArchSMSTlen6ToolStripMenuItem_Click);
            // 
            // zamknijArchiwumToolStripMenuItem
            // 
            this.zamknijArchiwumToolStripMenuItem.Name = "zamknijArchiwumToolStripMenuItem";
            this.zamknijArchiwumToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.zamknijArchiwumToolStripMenuItem.Text = "Zamknij archiwum";
            this.zamknijArchiwumToolStripMenuItem.Click += new System.EventHandler(this.zamknijArchiwumToolStripMenuItem_Click);
            // 
            // exportujArchiwumToolStripMenuItem
            // 
            this.exportujArchiwumToolStripMenuItem.Enabled = false;
            this.exportujArchiwumToolStripMenuItem.Name = "exportujArchiwumToolStripMenuItem";
            this.exportujArchiwumToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.exportujArchiwumToolStripMenuItem.Text = "Eksportuj Rozmowę";
            this.exportujArchiwumToolStripMenuItem.Click += new System.EventHandler(this.exportujArchiwumToolStripMenuItem_Click);
            // 
            // eksportujCałeArchiwumToolStripMenuItem
            // 
            this.eksportujCałeArchiwumToolStripMenuItem.Enabled = false;
            this.eksportujCałeArchiwumToolStripMenuItem.Name = "eksportujCałeArchiwumToolStripMenuItem";
            this.eksportujCałeArchiwumToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.eksportujCałeArchiwumToolStripMenuItem.Text = "Eksportuj całe archiwum";
            this.eksportujCałeArchiwumToolStripMenuItem.Click += new System.EventHandler(this.eksportujCałeArchiwumToolStripMenuItem_Click);
            // 
            // eksportujCałeArchSMSToolStripMenuItem
            // 
            this.eksportujCałeArchSMSToolStripMenuItem.Enabled = false;
            this.eksportujCałeArchSMSToolStripMenuItem.Name = "eksportujCałeArchSMSToolStripMenuItem";
            this.eksportujCałeArchSMSToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.eksportujCałeArchSMSToolStripMenuItem.Text = "Eksportuj całe arch. SMS";
            this.eksportujCałeArchSMSToolStripMenuItem.Click += new System.EventHandler(this.eksportujCałeArchSMSToolStripMenuItem_Click);
            // 
            // koniecToolStripMenuItem
            // 
            this.koniecToolStripMenuItem.Name = "koniecToolStripMenuItem";
            this.koniecToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.koniecToolStripMenuItem.Text = "Koniec";
            this.koniecToolStripMenuItem.Click += new System.EventHandler(this.koniecToolStripMenuItem_Click);
            // 
            // pomocToolStripMenuItem
            // 
            this.pomocToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oProgramieToolStripMenuItem});
            this.pomocToolStripMenuItem.Name = "pomocToolStripMenuItem";
            this.pomocToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.pomocToolStripMenuItem.Text = "Pomoc";
            // 
            // oProgramieToolStripMenuItem
            // 
            this.oProgramieToolStripMenuItem.Name = "oProgramieToolStripMenuItem";
            this.oProgramieToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.oProgramieToolStripMenuItem.Text = "O programie";
            this.oProgramieToolStripMenuItem.Click += new System.EventHandler(this.oProgramieToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Treść rozmowy";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 677);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(205, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "(C) Copyright by Marcin Kałat 2010 - 2012";
            // 
            // listView_ListaRozm
            // 
            this.listView_ListaRozm.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Nr_rozm,
            this.Login_rozmówcy,
            this.Czas_rozp_rozmowy});
            this.listView_ListaRozm.FullRowSelect = true;
            this.listView_ListaRozm.GridLines = true;
            this.listView_ListaRozm.HideSelection = false;
            this.listView_ListaRozm.Location = new System.Drawing.Point(15, 71);
            this.listView_ListaRozm.MultiSelect = false;
            this.listView_ListaRozm.Name = "listView_ListaRozm";
            this.listView_ListaRozm.Size = new System.Drawing.Size(691, 134);
            this.listView_ListaRozm.TabIndex = 8;
            this.listView_ListaRozm.UseCompatibleStateImageBehavior = false;
            this.listView_ListaRozm.View = System.Windows.Forms.View.Details;
            this.listView_ListaRozm.SelectedIndexChanged += new System.EventHandler(this.listView_ListaRozm_SelectedIndexChanged);
            // 
            // Nr_rozm
            // 
            this.Nr_rozm.Text = "Nr Rozm";
            // 
            // Login_rozmówcy
            // 
            this.Login_rozmówcy.Text = "Nazwa rozmówcy";
            this.Login_rozmówcy.Width = 150;
            // 
            // Czas_rozp_rozmowy
            // 
            this.Czas_rozp_rozmowy.Text = "Czas rozp. rozmowy";
            this.Czas_rozp_rozmowy.Width = 115;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Exportuj_rozm});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(176, 26);
            // 
            // Exportuj_rozm
            // 
            this.Exportuj_rozm.Name = "Exportuj_rozm";
            this.Exportuj_rozm.Size = new System.Drawing.Size(175, 22);
            this.Exportuj_rozm.Text = "Eksportuj rozmowę";
            this.Exportuj_rozm.Click += new System.EventHandler(this.Exportuj_rozm_Click);
            // 
            // richTextBox_Wypowiedź
            // 
            this.richTextBox_Wypowiedź.AcceptsTab = true;
            this.richTextBox_Wypowiedź.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.richTextBox_Wypowiedź.ContextMenuStrip = this.contextMenuStrip1;
            this.richTextBox_Wypowiedź.Location = new System.Drawing.Point(15, 224);
            this.richTextBox_Wypowiedź.Name = "richTextBox_Wypowiedź";
            this.richTextBox_Wypowiedź.ReadOnly = true;
            this.richTextBox_Wypowiedź.Size = new System.Drawing.Size(691, 450);
            this.richTextBox_Wypowiedź.TabIndex = 9;
            this.richTextBox_Wypowiedź.Text = "";
            // 
            // radioButton_T7Rozm
            // 
            this.radioButton_T7Rozm.AutoSize = true;
            this.radioButton_T7Rozm.Location = new System.Drawing.Point(15, 27);
            this.radioButton_T7Rozm.Name = "radioButton_T7Rozm";
            this.radioButton_T7Rozm.Size = new System.Drawing.Size(71, 17);
            this.radioButton_T7Rozm.TabIndex = 10;
            this.radioButton_T7Rozm.TabStop = true;
            this.radioButton_T7Rozm.Text = "Rozmowy";
            this.radioButton_T7Rozm.UseVisualStyleBackColor = true;
            this.radioButton_T7Rozm.Visible = false;
            // 
            // radioButton_T7SMS
            // 
            this.radioButton_T7SMS.AutoSize = true;
            this.radioButton_T7SMS.Location = new System.Drawing.Point(92, 27);
            this.radioButton_T7SMS.Name = "radioButton_T7SMS";
            this.radioButton_T7SMS.Size = new System.Drawing.Size(48, 17);
            this.radioButton_T7SMS.TabIndex = 11;
            this.radioButton_T7SMS.TabStop = true;
            this.radioButton_T7SMS.Text = "SMS";
            this.radioButton_T7SMS.UseVisualStyleBackColor = true;
            this.radioButton_T7SMS.Visible = false;
            // 
            // radioButton_T7Czaty
            // 
            this.radioButton_T7Czaty.AutoSize = true;
            this.radioButton_T7Czaty.Location = new System.Drawing.Point(146, 27);
            this.radioButton_T7Czaty.Name = "radioButton_T7Czaty";
            this.radioButton_T7Czaty.Size = new System.Drawing.Size(51, 17);
            this.radioButton_T7Czaty.TabIndex = 12;
            this.radioButton_T7Czaty.TabStop = true;
            this.radioButton_T7Czaty.Text = "Czaty";
            this.radioButton_T7Czaty.UseVisualStyleBackColor = true;
            this.radioButton_T7Czaty.Visible = false;
            // 
            // radioButton_T7Konf
            // 
            this.radioButton_T7Konf.AutoSize = true;
            this.radioButton_T7Konf.Location = new System.Drawing.Point(203, 27);
            this.radioButton_T7Konf.Name = "radioButton_T7Konf";
            this.radioButton_T7Konf.Size = new System.Drawing.Size(82, 17);
            this.radioButton_T7Konf.TabIndex = 13;
            this.radioButton_T7Konf.TabStop = true;
            this.radioButton_T7Konf.Text = "Konferencje";
            this.radioButton_T7Konf.UseVisualStyleBackColor = true;
            this.radioButton_T7Konf.Visible = false;
            // 
            // TlenReaderNET
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 699);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.radioButton_T7Konf);
            this.Controls.Add(this.radioButton_T7Czaty);
            this.Controls.Add(this.radioButton_T7SMS);
            this.Controls.Add(this.radioButton_T7Rozm);
            this.Controls.Add(this.richTextBox_Wypowiedź);
            this.Controls.Add(this.listView_ListaRozm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TlenReaderNET";
            this.Text = "Tlen Reader Net";
            this.Load += new System.EventHandler(this.TlenReaderNET_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otwórzArchiwumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zamknijArchiwumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem koniecToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pomocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oProgramieToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listView_ListaRozm;
        private System.Windows.Forms.ColumnHeader Nr_rozm;
        private System.Windows.Forms.ColumnHeader Login_rozmówcy;
        private System.Windows.Forms.ColumnHeader Czas_rozp_rozmowy;
        private System.Windows.Forms.ToolStripMenuItem usunięteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nieusunięteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportujArchiwumToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Exportuj_rozm;
        private System.Windows.Forms.ToolStripMenuItem eksportujCałeArchiwumToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox_Wypowiedź;
        private System.Windows.Forms.ToolStripMenuItem otwórzArchSMSTlen6ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eksportujCałeArchSMSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otwórzArchiwumTlen7ToolStripMenuItem;
        private System.Windows.Forms.RadioButton radioButton_T7Rozm;
        private System.Windows.Forms.RadioButton radioButton_T7SMS;
        private System.Windows.Forms.RadioButton radioButton_T7Czaty;
        private System.Windows.Forms.RadioButton radioButton_T7Konf;
    }
}

