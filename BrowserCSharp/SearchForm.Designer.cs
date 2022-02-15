using System.Data.SqlClient;
using System.Collections;

namespace Athelas
{
    partial class SearchForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchForm));
            this.panelSearch = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.lbTimeProcessed = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Docname = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Dsize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TCY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GPR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ext = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Img = new System.Windows.Forms.DataGridViewImageColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbFilterSelectedCount = new System.Windows.Forms.Label();
            this.btFilter = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.chLBClusters = new System.Windows.Forms.CheckedListBox();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btSearch = new System.Windows.Forms.Button();
            this.lbSearchTime = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSearch
            // 
            this.panelSearch.Controls.Add(this.button3);
            this.panelSearch.Controls.Add(this.lbTimeProcessed);
            this.panelSearch.Controls.Add(this.radioButton2);
            this.panelSearch.Controls.Add(this.radioButton1);
            this.panelSearch.Controls.Add(this.checkBox1);
            this.panelSearch.Controls.Add(this.label2);
            this.panelSearch.Controls.Add(this.numericUpDown1);
            this.panelSearch.Controls.Add(this.button2);
            this.panelSearch.Controls.Add(this.button1);
            this.panelSearch.Controls.Add(this.dataGridView1);
            this.panelSearch.Controls.Add(this.lbFilterSelectedCount);
            this.panelSearch.Controls.Add(this.btFilter);
            this.panelSearch.Controls.Add(this.label4);
            this.panelSearch.Controls.Add(this.chLBClusters);
            this.panelSearch.Controls.Add(this.tbSearch);
            this.panelSearch.Controls.Add(this.btSearch);
            this.panelSearch.Controls.Add(this.lbSearchTime);
            this.panelSearch.Location = new System.Drawing.Point(2, 3);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(903, 591);
            this.panelSearch.TabIndex = 77;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(345, 49);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(67, 23);
            this.button3.TabIndex = 134;
            this.button3.Text = "Кластеры";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lbTimeProcessed
            // 
            this.lbTimeProcessed.AutoSize = true;
            this.lbTimeProcessed.ForeColor = System.Drawing.Color.Red;
            this.lbTimeProcessed.Location = new System.Drawing.Point(15, 66);
            this.lbTimeProcessed.Name = "lbTimeProcessed";
            this.lbTimeProcessed.Size = new System.Drawing.Size(35, 13);
            this.lbTimeProcessed.TabIndex = 133;
            this.lbTimeProcessed.Text = "label1";
            this.lbTimeProcessed.Visible = false;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(18, 113);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(89, 17);
            this.radioButton2.TabIndex = 132;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "В Интернете";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(18, 90);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(146, 17);
            this.radioButton1.TabIndex = 131;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "В локальной коллекции";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(18, 134);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(104, 17);
            this.checkBox1.TabIndex = 130;
            this.checkBox1.Text = "Только первые";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(203, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 129;
            this.label2.Text = "ссылок";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Enabled = false;
            this.numericUpDown1.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(130, 133);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(67, 20);
            this.numericUpDown1.TabIndex = 128;
            this.numericUpDown1.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(769, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 25);
            this.button2.TabIndex = 127;
            this.button2.Text = "Загрузить из файла...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(769, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 25);
            this.button1.TabIndex = 126;
            this.button1.Text = "Сохранить в файл...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Docname,
            this.Dsize,
            this.Url,
            this.TCY,
            this.GPR,
            this.ext,
            this.Img,
            this.Date});
            this.dataGridView1.Location = new System.Drawing.Point(18, 167);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(880, 420);
            this.dataGridView1.TabIndex = 125;
            this.dataGridView1.Enter += new System.EventHandler(this.dataGridView1_Enter);
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // id
            // 
            dataGridViewCellStyle1.Format = "N3";
            dataGridViewCellStyle1.NullValue = null;
            this.id.DefaultCellStyle = dataGridViewCellStyle1;
            this.id.HeaderText = "№";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 30;
            // 
            // Docname
            // 
            this.Docname.HeaderText = "Ссылка";
            this.Docname.Name = "Docname";
            this.Docname.ReadOnly = true;
            this.Docname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Docname.UseColumnTextForLinkValue = true;
            this.Docname.Width = 230;
            // 
            // Dsize
            // 
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.Dsize.DefaultCellStyle = dataGridViewCellStyle2;
            this.Dsize.HeaderText = "Размер";
            this.Dsize.Name = "Dsize";
            this.Dsize.ReadOnly = true;
            this.Dsize.Width = 60;
            // 
            // Url
            // 
            this.Url.HeaderText = "Адрес";
            this.Url.Name = "Url";
            this.Url.ReadOnly = true;
            // 
            // TCY
            // 
            this.TCY.HeaderText = "Яндекс ТИЦ";
            this.TCY.Name = "TCY";
            this.TCY.ReadOnly = true;
            // 
            // GPR
            // 
            this.GPR.HeaderText = "Google PR";
            this.GPR.Name = "GPR";
            this.GPR.ReadOnly = true;
            // 
            // ext
            // 
            this.ext.HeaderText = "Тип";
            this.ext.Name = "ext";
            this.ext.ReadOnly = true;
            this.ext.Width = 50;
            // 
            // Img
            // 
            this.Img.HeaderText = "";
            this.Img.Image = ((System.Drawing.Image)(resources.GetObject("Img.Image")));
            this.Img.Name = "Img";
            this.Img.ReadOnly = true;
            this.Img.Width = 50;
            // 
            // Date
            // 
            this.Date.HeaderText = "Дата";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // lbFilterSelectedCount
            // 
            this.lbFilterSelectedCount.AutoSize = true;
            this.lbFilterSelectedCount.Location = new System.Drawing.Point(477, 6);
            this.lbFilterSelectedCount.Name = "lbFilterSelectedCount";
            this.lbFilterSelectedCount.Size = new System.Drawing.Size(69, 13);
            this.lbFilterSelectedCount.TabIndex = 121;
            this.lbFilterSelectedCount.Text = "(выбрано: 0)";
            // 
            // btFilter
            // 
            this.btFilter.Enabled = false;
            this.btFilter.Location = new System.Drawing.Point(772, 85);
            this.btFilter.Name = "btFilter";
            this.btFilter.Size = new System.Drawing.Size(128, 76);
            this.btFilter.TabIndex = 120;
            this.btFilter.Text = "Применить";
            this.btFilter.UseVisualStyleBackColor = true;
            this.btFilter.Click += new System.EventHandler(this.btFilter_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(424, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 109;
            this.label4.Text = "Фильтр";
            // 
            // chLBClusters
            // 
            this.chLBClusters.CheckOnClick = true;
            this.chLBClusters.FormattingEnabled = true;
            this.chLBClusters.HorizontalScrollbar = true;
            this.chLBClusters.Location = new System.Drawing.Point(427, 22);
            this.chLBClusters.Name = "chLBClusters";
            this.chLBClusters.Size = new System.Drawing.Size(339, 139);
            this.chLBClusters.TabIndex = 108;
            // 
            // tbSearch
            // 
            this.tbSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbSearch.Location = new System.Drawing.Point(18, 22);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(321, 20);
            this.tbSearch.TabIndex = 51;
            this.tbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSearch_KeyPress);
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(345, 22);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(67, 23);
            this.btSearch.TabIndex = 52;
            this.btSearch.Text = "Найти";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // lbSearchTime
            // 
            this.lbSearchTime.AutoSize = true;
            this.lbSearchTime.Location = new System.Drawing.Point(15, 49);
            this.lbSearchTime.Name = "lbSearchTime";
            this.lbSearchTime.Size = new System.Drawing.Size(88, 13);
            this.lbSearchTime.TabIndex = 54;
            this.lbSearchTime.Text = "Задайте запрос";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Кластеры (*.cls)|*.cls";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Кластеры (*.cls)|*.cls";
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 602);
            this.Controls.Add(this.panelSearch);
            this.Name = "SearchForm";
            this.Text = "SearchForm";
            this.Activated += new System.EventHandler(this.SearchForm_Activated);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        Clusters cls;
        int NumSnippets = 0;
        Results results;
        public SqlConnection sc;
        public Settings AppSettings;
        SqlCommand myCommand;

        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Label lbFilterSelectedCount;
        private System.Windows.Forms.Button btFilter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox chLBClusters;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.Label lbSearchTime;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label lbTimeProcessed;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewLinkColumn Docname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dsize;
        private System.Windows.Forms.DataGridViewTextBoxColumn Url;
        private System.Windows.Forms.DataGridViewTextBoxColumn TCY;
        private System.Windows.Forms.DataGridViewTextBoxColumn GPR;
        private System.Windows.Forms.DataGridViewTextBoxColumn ext;
        private System.Windows.Forms.DataGridViewImageColumn Img;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        //        private System.Windows.Forms.DataGridViewTextBoxColumn Docsize;
    }
}