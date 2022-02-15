namespace Athelas
{
    partial class OptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.tcProperties = new System.Windows.Forms.TabControl();
            this.tpGeneral = new System.Windows.Forms.TabPage();
            this.tpSpider = new System.Windows.Forms.TabPage();
            this.tpIndexer = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btConfigOK = new System.Windows.Forms.Button();
            this.btConfigCancel = new System.Windows.Forms.Button();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numClusters = new System.Windows.Forms.NumericUpDown();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.lbServer = new System.Windows.Forms.Label();
            this.numMaxTime = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numMaxTrafic = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numMaxSize = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbXls = new System.Windows.Forms.CheckBox();
            this.cbPpt = new System.Windows.Forms.CheckBox();
            this.cbHtm = new System.Windows.Forms.CheckBox();
            this.cbTxt = new System.Windows.Forms.CheckBox();
            this.cbDoc = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbIsSearchSubFolders = new System.Windows.Forms.CheckBox();
            this.cbIsSearchHyperLinks = new System.Windows.Forms.CheckBox();
            this.tcProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numClusters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxTrafic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxSize)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcProperties
            // 
            this.tcProperties.Controls.Add(this.tpGeneral);
            this.tcProperties.Controls.Add(this.tpSpider);
            this.tcProperties.Controls.Add(this.tpIndexer);
            this.tcProperties.Location = new System.Drawing.Point(12, 12);
            this.tcProperties.Name = "tcProperties";
            this.tcProperties.SelectedIndex = 0;
            this.tcProperties.Size = new System.Drawing.Size(717, 387);
            this.tcProperties.TabIndex = 0;
            // 
            // tpGeneral
            // 
            this.tpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Size = new System.Drawing.Size(709, 361);
            this.tpGeneral.TabIndex = 2;
            this.tpGeneral.Text = "Общие";
            this.tpGeneral.UseVisualStyleBackColor = true;
            // 
            // tpSpider
            // 
            this.tpSpider.Location = new System.Drawing.Point(4, 22);
            this.tpSpider.Name = "tpSpider";
            this.tpSpider.Padding = new System.Windows.Forms.Padding(3);
            this.tpSpider.Size = new System.Drawing.Size(709, 361);
            this.tpSpider.TabIndex = 0;
            this.tpSpider.Text = "Робот-паук";
            this.tpSpider.UseVisualStyleBackColor = true;
            // 
            // tpIndexer
            // 
            this.tpIndexer.Location = new System.Drawing.Point(4, 22);
            this.tpIndexer.Name = "tpIndexer";
            this.tpIndexer.Padding = new System.Windows.Forms.Padding(3);
            this.tpIndexer.Size = new System.Drawing.Size(709, 361);
            this.tpIndexer.TabIndex = 1;
            this.tpIndexer.Text = "Индексер";
            this.tpIndexer.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(455, 416);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(556, 416);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(73, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btConfigOK
            // 
            this.btConfigOK.Location = new System.Drawing.Point(428, 188);
            this.btConfigOK.Name = "btConfigOK";
            this.btConfigOK.Size = new System.Drawing.Size(75, 23);
            this.btConfigOK.TabIndex = 1;
            this.btConfigOK.Text = "OK";
            this.btConfigOK.UseVisualStyleBackColor = true;
            this.btConfigOK.Click += new System.EventHandler(this.btConfigOK_Click);
            // 
            // btConfigCancel
            // 
            this.btConfigCancel.Location = new System.Drawing.Point(525, 188);
            this.btConfigCancel.Name = "btConfigCancel";
            this.btConfigCancel.Size = new System.Drawing.Size(75, 23);
            this.btConfigCancel.TabIndex = 2;
            this.btConfigCancel.Text = "Отмена";
            this.btConfigCancel.UseVisualStyleBackColor = true;
            this.btConfigCancel.Click += new System.EventHandler(this.btConfigCancel_Click);
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown3.Location = new System.Drawing.Point(169, 43);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numericUpDown3.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(67, 20);
            this.numericUpDown3.TabIndex = 34;
            this.numericUpDown3.ThousandsSeparator = true;
            this.numericUpDown3.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Максимальный трафик (Кб)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Страницы не больше (Кб)";
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown4.Location = new System.Drawing.Point(169, 16);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown4.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(67, 20);
            this.numericUpDown4.TabIndex = 26;
            this.numericUpDown4.ThousandsSeparator = true;
            this.numericUpDown4.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 123;
            this.label4.Text = "Кластеров:";
            // 
            // numClusters
            // 
            this.numClusters.Location = new System.Drawing.Point(231, 120);
            this.numClusters.Name = "numClusters";
            this.numClusters.Size = new System.Drawing.Size(42, 20);
            this.numClusters.TabIndex = 122;
            this.numClusters.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // tbServer
            // 
            this.tbServer.Location = new System.Drawing.Point(113, 98);
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(160, 20);
            this.tbServer.TabIndex = 121;
            this.tbServer.Text = "localhost";
            // 
            // lbServer
            // 
            this.lbServer.AutoSize = true;
            this.lbServer.Location = new System.Drawing.Point(17, 101);
            this.lbServer.Name = "lbServer";
            this.lbServer.Size = new System.Drawing.Size(96, 13);
            this.lbServer.TabIndex = 120;
            this.lbServer.Text = "Соединение с БД";
            // 
            // numMaxTime
            // 
            this.numMaxTime.Location = new System.Drawing.Point(206, 75);
            this.numMaxTime.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.numMaxTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxTime.Name = "numMaxTime";
            this.numMaxTime.Size = new System.Drawing.Size(67, 20);
            this.numMaxTime.TabIndex = 119;
            this.numMaxTime.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(188, 13);
            this.label6.TabIndex = 118;
            this.label6.Text = "Максимальное время работы (мин)";
            // 
            // numMaxTrafic
            // 
            this.numMaxTrafic.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numMaxTrafic.Location = new System.Drawing.Point(206, 52);
            this.numMaxTrafic.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numMaxTrafic.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numMaxTrafic.Name = "numMaxTrafic";
            this.numMaxTrafic.Size = new System.Drawing.Size(67, 20);
            this.numMaxTrafic.TabIndex = 117;
            this.numMaxTrafic.ThousandsSeparator = true;
            this.numMaxTrafic.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 13);
            this.label5.TabIndex = 116;
            this.label5.Text = "Максимальный трафик (Кб)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 115;
            this.label1.Text = "Страницы не больше (Кб)";
            // 
            // numMaxSize
            // 
            this.numMaxSize.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numMaxSize.Location = new System.Drawing.Point(206, 27);
            this.numMaxSize.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numMaxSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxSize.Name = "numMaxSize";
            this.numMaxSize.Size = new System.Drawing.Size(67, 20);
            this.numMaxSize.TabIndex = 114;
            this.numMaxSize.ThousandsSeparator = true;
            this.numMaxSize.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbXls);
            this.groupBox1.Controls.Add(this.cbPpt);
            this.groupBox1.Controls.Add(this.cbHtm);
            this.groupBox1.Controls.Add(this.cbTxt);
            this.groupBox1.Controls.Add(this.cbDoc);
            this.groupBox1.Location = new System.Drawing.Point(354, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 151);
            this.groupBox1.TabIndex = 129;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Объекты индексации";
            // 
            // cbXls
            // 
            this.cbXls.AutoSize = true;
            this.cbXls.Location = new System.Drawing.Point(19, 118);
            this.cbXls.Name = "cbXls";
            this.cbXls.Size = new System.Drawing.Size(174, 17);
            this.cbXls.TabIndex = 133;
            this.cbXls.Text = "Таблицы Microsoft Excel (*.xls)";
            this.cbXls.UseVisualStyleBackColor = true;
            // 
            // cbPpt
            // 
            this.cbPpt.AutoSize = true;
            this.cbPpt.Checked = true;
            this.cbPpt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPpt.Location = new System.Drawing.Point(19, 95);
            this.cbPpt.Name = "cbPpt";
            this.cbPpt.Size = new System.Drawing.Size(181, 17);
            this.cbPpt.TabIndex = 132;
            this.cbPpt.Text = "Презентация PowerPoint (*.ppt)";
            this.cbPpt.UseVisualStyleBackColor = true;
            // 
            // cbHtm
            // 
            this.cbHtm.AutoSize = true;
            this.cbHtm.Checked = true;
            this.cbHtm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbHtm.Location = new System.Drawing.Point(19, 72);
            this.cbHtm.Name = "cbHtm";
            this.cbHtm.Size = new System.Drawing.Size(130, 17);
            this.cbHtm.TabIndex = 131;
            this.cbHtm.Text = "Веб-страницы (*.htm)";
            this.cbHtm.UseVisualStyleBackColor = true;
            // 
            // cbTxt
            // 
            this.cbTxt.AutoSize = true;
            this.cbTxt.Checked = true;
            this.cbTxt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTxt.Location = new System.Drawing.Point(19, 49);
            this.cbTxt.Name = "cbTxt";
            this.cbTxt.Size = new System.Drawing.Size(168, 17);
            this.cbTxt.TabIndex = 130;
            this.cbTxt.Text = "Текстовые документы (*.txt)";
            this.cbTxt.UseVisualStyleBackColor = true;
            // 
            // cbDoc
            // 
            this.cbDoc.AutoSize = true;
            this.cbDoc.Checked = true;
            this.cbDoc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDoc.Location = new System.Drawing.Point(19, 26);
            this.cbDoc.Name = "cbDoc";
            this.cbDoc.Size = new System.Drawing.Size(194, 17);
            this.cbDoc.TabIndex = 129;
            this.cbDoc.Text = "Документы Microsoft Word (*.doc)";
            this.cbDoc.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.numMaxSize);
            this.groupBox2.Controls.Add(this.numClusters);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.numMaxTrafic);
            this.groupBox2.Controls.Add(this.tbServer);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lbServer);
            this.groupBox2.Controls.Add(this.numMaxTime);
            this.groupBox2.Location = new System.Drawing.Point(24, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(297, 151);
            this.groupBox2.TabIndex = 130;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Параметры индексации";
            // 
            // cbIsSearchSubFolders
            // 
            this.cbIsSearchSubFolders.AutoSize = true;
            this.cbIsSearchSubFolders.Location = new System.Drawing.Point(44, 199);
            this.cbIsSearchSubFolders.Name = "cbIsSearchSubFolders";
            this.cbIsSearchSubFolders.Size = new System.Drawing.Size(176, 17);
            this.cbIsSearchSubFolders.TabIndex = 131;
            this.cbIsSearchSubFolders.Text = "Добавлять вложенные папки";
            this.cbIsSearchSubFolders.UseVisualStyleBackColor = true;
            // 
            // cbIsSearchHyperLinks
            // 
            this.cbIsSearchHyperLinks.AutoSize = true;
            this.cbIsSearchHyperLinks.Location = new System.Drawing.Point(44, 176);
            this.cbIsSearchHyperLinks.Name = "cbIsSearchHyperLinks";
            this.cbIsSearchHyperLinks.Size = new System.Drawing.Size(286, 17);
            this.cbIsSearchHyperLinks.TabIndex = 132;
            this.cbIsSearchHyperLinks.Text = "Рекурсивно переходить по гиперссылкам в тексте";
            this.cbIsSearchHyperLinks.UseVisualStyleBackColor = true;
            // 
            // OptionsForm
            // 
            this.ClientSize = new System.Drawing.Size(623, 312);
            this.Controls.Add(this.cbIsSearchHyperLinks);
            this.Controls.Add(this.cbIsSearchSubFolders);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btConfigCancel);
            this.Controls.Add(this.btConfigOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OptionsForm";
            this.Text = "Настройки";
            this.tcProperties.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numClusters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxTrafic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxSize)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcProperties;
        private System.Windows.Forms.TabPage tpSpider;
        private System.Windows.Forms.TabPage tpIndexer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage tpGeneral;
        private System.Windows.Forms.Button btConfigOK;
        private System.Windows.Forms.Button btConfigCancel;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numClusters;
        private System.Windows.Forms.TextBox tbServer;
        private System.Windows.Forms.Label lbServer;
        private System.Windows.Forms.NumericUpDown numMaxTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numMaxTrafic;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numMaxSize;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbXls;
        private System.Windows.Forms.CheckBox cbPpt;
        private System.Windows.Forms.CheckBox cbHtm;
        private System.Windows.Forms.CheckBox cbTxt;
        private System.Windows.Forms.CheckBox cbDoc;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbIsSearchSubFolders;
        private System.Windows.Forms.CheckBox cbIsSearchHyperLinks;
    }
}