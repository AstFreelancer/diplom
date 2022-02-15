namespace Athelas
{
    partial class StopForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btDelStopRus = new System.Windows.Forms.Button();
            this.btAddStopRus = new System.Windows.Forms.Button();
            this.lbListStopRus = new System.Windows.Forms.ListBox();
            this.tbNewStopRus = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btDelStopEn = new System.Windows.Forms.Button();
            this.btAddStopEn = new System.Windows.Forms.Button();
            this.lbListStopEn = new System.Windows.Forms.ListBox();
            this.tbNewStopEn = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btDelStopStem = new System.Windows.Forms.Button();
            this.btAddStopStem = new System.Windows.Forms.Button();
            this.lbListStopStem = new System.Windows.Forms.ListBox();
            this.tbNewStopStem = new System.Windows.Forms.TextBox();
            this.btConfigCancel = new System.Windows.Forms.Button();
            this.btConfigOK = new System.Windows.Forms.Button();
            this.btNewStopRu = new System.Windows.Forms.Button();
            this.btNewStopEn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(285, 464);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btNewStopRu);
            this.tabPage1.Controls.Add(this.btDelStopRus);
            this.tabPage1.Controls.Add(this.btAddStopRus);
            this.tabPage1.Controls.Add(this.lbListStopRus);
            this.tabPage1.Controls.Add(this.tbNewStopRus);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(277, 438);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Русский язык";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btDelStopRus
            // 
            this.btDelStopRus.Location = new System.Drawing.Point(181, 408);
            this.btDelStopRus.Name = "btDelStopRus";
            this.btDelStopRus.Size = new System.Drawing.Size(75, 23);
            this.btDelStopRus.TabIndex = 3;
            this.btDelStopRus.Text = "Удалить";
            this.btDelStopRus.UseVisualStyleBackColor = true;
            this.btDelStopRus.Click += new System.EventHandler(this.btDelStopRus_Click);
            // 
            // btAddStopRus
            // 
            this.btAddStopRus.Location = new System.Drawing.Point(100, 408);
            this.btAddStopRus.Name = "btAddStopRus";
            this.btAddStopRus.Size = new System.Drawing.Size(75, 23);
            this.btAddStopRus.TabIndex = 2;
            this.btAddStopRus.Text = "Добавить";
            this.btAddStopRus.UseVisualStyleBackColor = true;
            this.btAddStopRus.Click += new System.EventHandler(this.btAddStopRus_Click);
            // 
            // lbListStopRus
            // 
            this.lbListStopRus.FormattingEnabled = true;
            this.lbListStopRus.Location = new System.Drawing.Point(21, 47);
            this.lbListStopRus.Name = "lbListStopRus";
            this.lbListStopRus.Size = new System.Drawing.Size(235, 355);
            this.lbListStopRus.TabIndex = 1;
            this.lbListStopRus.SelectedIndexChanged += new System.EventHandler(this.lbListStopRus_SelectedIndexChanged);
            this.lbListStopRus.Click += new System.EventHandler(this.lbListStopRus_Click);
            // 
            // tbNewStopRus
            // 
            this.tbNewStopRus.Location = new System.Drawing.Point(21, 21);
            this.tbNewStopRus.Name = "tbNewStopRus";
            this.tbNewStopRus.Size = new System.Drawing.Size(235, 20);
            this.tbNewStopRus.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btNewStopEn);
            this.tabPage2.Controls.Add(this.btDelStopEn);
            this.tabPage2.Controls.Add(this.btAddStopEn);
            this.tabPage2.Controls.Add(this.lbListStopEn);
            this.tabPage2.Controls.Add(this.tbNewStopEn);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(277, 438);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Английский язык";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btDelStopEn
            // 
            this.btDelStopEn.Location = new System.Drawing.Point(181, 401);
            this.btDelStopEn.Name = "btDelStopEn";
            this.btDelStopEn.Size = new System.Drawing.Size(75, 23);
            this.btDelStopEn.TabIndex = 7;
            this.btDelStopEn.Text = "Удалить";
            this.btDelStopEn.UseVisualStyleBackColor = true;
            this.btDelStopEn.Click += new System.EventHandler(this.btDelStopEn_Click);
            // 
            // btAddStopEn
            // 
            this.btAddStopEn.Location = new System.Drawing.Point(100, 401);
            this.btAddStopEn.Name = "btAddStopEn";
            this.btAddStopEn.Size = new System.Drawing.Size(75, 23);
            this.btAddStopEn.TabIndex = 6;
            this.btAddStopEn.Text = "Добавить";
            this.btAddStopEn.UseVisualStyleBackColor = true;
            this.btAddStopEn.Click += new System.EventHandler(this.btAddStopEn_Click);
            // 
            // lbListStopEn
            // 
            this.lbListStopEn.FormattingEnabled = true;
            this.lbListStopEn.Location = new System.Drawing.Point(21, 40);
            this.lbListStopEn.Name = "lbListStopEn";
            this.lbListStopEn.Size = new System.Drawing.Size(235, 355);
            this.lbListStopEn.TabIndex = 5;
            this.lbListStopEn.SelectedIndexChanged += new System.EventHandler(this.lbListStopEn_SelectedIndexChanged);
            // 
            // tbNewStopEn
            // 
            this.tbNewStopEn.Location = new System.Drawing.Point(21, 14);
            this.tbNewStopEn.Name = "tbNewStopEn";
            this.tbNewStopEn.Size = new System.Drawing.Size(235, 20);
            this.tbNewStopEn.TabIndex = 4;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.btDelStopStem);
            this.tabPage3.Controls.Add(this.btAddStopStem);
            this.tabPage3.Controls.Add(this.lbListStopStem);
            this.tabPage3.Controls.Add(this.tbNewStopStem);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(277, 438);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Стоп-основы";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btDelStopStem
            // 
            this.btDelStopStem.Location = new System.Drawing.Point(181, 401);
            this.btDelStopStem.Name = "btDelStopStem";
            this.btDelStopStem.Size = new System.Drawing.Size(75, 23);
            this.btDelStopStem.TabIndex = 7;
            this.btDelStopStem.Text = "Удалить";
            this.btDelStopStem.UseVisualStyleBackColor = true;
            this.btDelStopStem.Click += new System.EventHandler(this.btDelStopStem_Click);
            // 
            // btAddStopStem
            // 
            this.btAddStopStem.Location = new System.Drawing.Point(100, 401);
            this.btAddStopStem.Name = "btAddStopStem";
            this.btAddStopStem.Size = new System.Drawing.Size(75, 23);
            this.btAddStopStem.TabIndex = 6;
            this.btAddStopStem.Text = "Добавить";
            this.btAddStopStem.UseVisualStyleBackColor = true;
            this.btAddStopStem.Click += new System.EventHandler(this.btAddStopStem_Click);
            // 
            // lbListStopStem
            // 
            this.lbListStopStem.FormattingEnabled = true;
            this.lbListStopStem.Location = new System.Drawing.Point(21, 40);
            this.lbListStopStem.Name = "lbListStopStem";
            this.lbListStopStem.Size = new System.Drawing.Size(235, 355);
            this.lbListStopStem.TabIndex = 5;
            this.lbListStopStem.SelectedIndexChanged += new System.EventHandler(this.lbListStopStem_SelectedIndexChanged);
            // 
            // tbNewStopStem
            // 
            this.tbNewStopStem.Location = new System.Drawing.Point(21, 14);
            this.tbNewStopStem.Name = "tbNewStopStem";
            this.tbNewStopStem.Size = new System.Drawing.Size(235, 20);
            this.tbNewStopStem.TabIndex = 4;
            // 
            // btConfigCancel
            // 
            this.btConfigCancel.Location = new System.Drawing.Point(222, 492);
            this.btConfigCancel.Name = "btConfigCancel";
            this.btConfigCancel.Size = new System.Drawing.Size(75, 23);
            this.btConfigCancel.TabIndex = 4;
            this.btConfigCancel.Text = "Отмена";
            this.btConfigCancel.UseVisualStyleBackColor = true;
            this.btConfigCancel.Click += new System.EventHandler(this.btConfigCancel_Click);
            // 
            // btConfigOK
            // 
            this.btConfigOK.Location = new System.Drawing.Point(141, 492);
            this.btConfigOK.Name = "btConfigOK";
            this.btConfigOK.Size = new System.Drawing.Size(75, 23);
            this.btConfigOK.TabIndex = 3;
            this.btConfigOK.Text = "OK";
            this.btConfigOK.UseVisualStyleBackColor = true;
            this.btConfigOK.Click += new System.EventHandler(this.btConfigOK_Click);
            // 
            // btNewStopRu
            // 
            this.btNewStopRu.Location = new System.Drawing.Point(21, 408);
            this.btNewStopRu.Name = "btNewStopRu";
            this.btNewStopRu.Size = new System.Drawing.Size(75, 23);
            this.btNewStopRu.TabIndex = 4;
            this.btNewStopRu.Text = "Новое";
            this.btNewStopRu.UseVisualStyleBackColor = true;
            this.btNewStopRu.Click += new System.EventHandler(this.btNewStopRu_Click);
            // 
            // btNewStopEn
            // 
            this.btNewStopEn.Location = new System.Drawing.Point(21, 401);
            this.btNewStopEn.Name = "btNewStopEn";
            this.btNewStopEn.Size = new System.Drawing.Size(75, 23);
            this.btNewStopEn.TabIndex = 8;
            this.btNewStopEn.Text = "Новое";
            this.btNewStopEn.UseVisualStyleBackColor = true;
            this.btNewStopEn.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(21, 401);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Новое";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // StopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 527);
            this.Controls.Add(this.btConfigCancel);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btConfigOK);
            this.Name = "StopForm";
            this.Text = "Стоп-слова";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox lbListStopRus;
        private System.Windows.Forms.TextBox tbNewStopRus;
        private System.Windows.Forms.Button btDelStopRus;
        private System.Windows.Forms.Button btAddStopRus;
        private System.Windows.Forms.Button btConfigCancel;
        private System.Windows.Forms.Button btConfigOK;
        private System.Windows.Forms.Button btDelStopEn;
        private System.Windows.Forms.Button btAddStopEn;
        private System.Windows.Forms.ListBox lbListStopEn;
        private System.Windows.Forms.TextBox tbNewStopEn;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btDelStopStem;
        private System.Windows.Forms.Button btAddStopStem;
        private System.Windows.Forms.ListBox lbListStopStem;
        private System.Windows.Forms.TextBox tbNewStopStem;
        private System.Windows.Forms.Button btNewStopRu;
        private System.Windows.Forms.Button btNewStopEn;
        private System.Windows.Forms.Button button2;
    }
}