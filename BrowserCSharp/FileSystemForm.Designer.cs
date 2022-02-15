namespace Athelas
{
    partial class FileSystemForm
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tree = new Athelas.FileSystemTreeView();
            this.button3 = new System.Windows.Forms.Button();
            this.cbDoc = new System.Windows.Forms.CheckBox();
            this.cbTxt = new System.Windows.Forms.CheckBox();
            this.cbHtm = new System.Windows.Forms.CheckBox();
            this.cbXls = new System.Windows.Forms.CheckBox();
            this.cbPpt = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(107, 24);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(252, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Открыть";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выберите диск";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(403, 539);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "OK";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbDoc);
            this.groupBox1.Controls.Add(this.cbTxt);
            this.groupBox1.Controls.Add(this.cbHtm);
            this.groupBox1.Controls.Add(this.cbXls);
            this.groupBox1.Controls.Add(this.cbPpt);
            this.groupBox1.Controls.Add(this.tree);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(556, 510);
            this.groupBox1.TabIndex = 140;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Папки";
            // 
            // tree
            // 
            this.tree.CheckBoxes = true;
            this.tree.ImageIndex = 0;
            this.tree.Location = new System.Drawing.Point(20, 58);
            this.tree.Name = "tree";
            this.tree.SelectedImageIndex = 0;
            this.tree.ShowFiles = true;
            this.tree.Size = new System.Drawing.Size(517, 369);
            this.tree.TabIndex = 5;
            this.tree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tree_AfterCheck);
            this.tree.Click += new System.EventHandler(this.tree_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(493, 539);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 142;
            this.button3.Text = "Отмена";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // cbDoc
            // 
            this.cbDoc.AutoSize = true;
            this.cbDoc.Checked = true;
            this.cbDoc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDoc.Location = new System.Drawing.Point(20, 433);
            this.cbDoc.Name = "cbDoc";
            this.cbDoc.Size = new System.Drawing.Size(160, 17);
            this.cbDoc.TabIndex = 139;
            this.cbDoc.Text = "Документы Microsoft Word";
            this.cbDoc.UseVisualStyleBackColor = true;
            // 
            // cbTxt
            // 
            this.cbTxt.AutoSize = true;
            this.cbTxt.Checked = true;
            this.cbTxt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTxt.Location = new System.Drawing.Point(20, 456);
            this.cbTxt.Name = "cbTxt";
            this.cbTxt.Size = new System.Drawing.Size(141, 17);
            this.cbTxt.TabIndex = 140;
            this.cbTxt.Text = "Текстовые документы";
            this.cbTxt.UseVisualStyleBackColor = true;
            // 
            // cbHtm
            // 
            this.cbHtm.AutoSize = true;
            this.cbHtm.Checked = true;
            this.cbHtm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbHtm.Location = new System.Drawing.Point(20, 479);
            this.cbHtm.Name = "cbHtm";
            this.cbHtm.Size = new System.Drawing.Size(97, 17);
            this.cbHtm.TabIndex = 141;
            this.cbHtm.Text = "Веб-страницы";
            this.cbHtm.UseVisualStyleBackColor = true;
            // 
            // cbXls
            // 
            this.cbXls.AutoSize = true;
            this.cbXls.Checked = true;
            this.cbXls.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbXls.Location = new System.Drawing.Point(181, 456);
            this.cbXls.Name = "cbXls";
            this.cbXls.Size = new System.Drawing.Size(146, 17);
            this.cbXls.TabIndex = 143;
            this.cbXls.Text = "Таблицы Microsoft Excel";
            this.cbXls.UseVisualStyleBackColor = true;
            // 
            // cbPpt
            // 
            this.cbPpt.AutoSize = true;
            this.cbPpt.Checked = true;
            this.cbPpt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPpt.Location = new System.Drawing.Point(181, 433);
            this.cbPpt.Name = "cbPpt";
            this.cbPpt.Size = new System.Drawing.Size(150, 17);
            this.cbPpt.TabIndex = 142;
            this.cbPpt.Text = "Презентации PowerPoint";
            this.cbPpt.UseVisualStyleBackColor = true;
            // 
            // FileSystemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 574);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Name = "FileSystemForm";
            this.Text = "Область индексирования (логические диски)";
            this.Load += new System.EventHandler(this.FileSystemForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private FileSystemTreeView tree;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox cbDoc;
        private System.Windows.Forms.CheckBox cbTxt;
        private System.Windows.Forms.CheckBox cbHtm;
        private System.Windows.Forms.CheckBox cbXls;
        private System.Windows.Forms.CheckBox cbPpt;
    }
}