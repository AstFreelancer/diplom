using System.Data.SqlClient;
using System.Collections;
namespace Athelas
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openCltDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveCltDialog = new System.Windows.Forms.SaveFileDialog();
            this.openDocDialog = new System.Windows.Forms.OpenFileDialog();
            this.openManyDocDialog = new System.Windows.Forms.OpenFileDialog();
            this.опцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelTrafic = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbTrafic = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelProcessed = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbProcessed = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.numTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьКоллекциюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьКоллекциюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.документыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьФайлыToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьПапкуToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.экспортИзбранногоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.экспортИзЯндексToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поискToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.базаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обновитьЯндексТИЦToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обновитьGooglePRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.очиститьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.стопсловаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.опцииToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.обходToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.начатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.остановитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.подключениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.проверитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbAddress = new System.Windows.Forms.Label();
            this.lbClt = new System.Windows.Forms.ListBox();
            this.tbAddress_Sp = new System.Windows.Forms.TextBox();
            this.lbDBCount = new System.Windows.Forms.Label();
            this.lbCltCount = new System.Windows.Forms.Label();
            this.lbReport = new System.Windows.Forms.ListBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lbDB = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton11 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton12 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton13 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton14 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton15 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton16 = new System.Windows.Forms.ToolStripButton();
            this.btStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openCltDialog
            // 
            this.openCltDialog.DefaultExt = "*.clt";
            this.openCltDialog.FileName = "*.clt";
            resources.ApplyResources(this.openCltDialog, "openCltDialog");
            // 
            // saveCltDialog
            // 
            resources.ApplyResources(this.saveCltDialog, "saveCltDialog");
            // 
            // openDocDialog
            // 
            resources.ApplyResources(this.openDocDialog, "openDocDialog");
            // 
            // openManyDocDialog
            // 
            resources.ApplyResources(this.openManyDocDialog, "openManyDocDialog");
            this.openManyDocDialog.Multiselect = true;
            // 
            // опцииToolStripMenuItem
            // 
            this.опцииToolStripMenuItem.Name = "опцииToolStripMenuItem";
            resources.ApplyResources(this.опцииToolStripMenuItem, "опцииToolStripMenuItem");
            this.опцииToolStripMenuItem.Click += new System.EventHandler(this.опцииToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabelTrafic,
            this.lbTrafic,
            this.toolStripStatusLabelProcessed,
            this.lbProcessed,
            this.toolStripStatusLabelTime,
            this.numTime});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            resources.ApplyResources(this.toolStripProgressBar1, "toolStripProgressBar1");
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            // 
            // toolStripStatusLabelTrafic
            // 
            this.toolStripStatusLabelTrafic.Name = "toolStripStatusLabelTrafic";
            resources.ApplyResources(this.toolStripStatusLabelTrafic, "toolStripStatusLabelTrafic");
            // 
            // lbTrafic
            // 
            this.lbTrafic.Name = "lbTrafic";
            resources.ApplyResources(this.lbTrafic, "lbTrafic");
            // 
            // toolStripStatusLabelProcessed
            // 
            this.toolStripStatusLabelProcessed.Name = "toolStripStatusLabelProcessed";
            resources.ApplyResources(this.toolStripStatusLabelProcessed, "toolStripStatusLabelProcessed");
            // 
            // lbProcessed
            // 
            this.lbProcessed.Name = "lbProcessed";
            resources.ApplyResources(this.lbProcessed, "lbProcessed");
            // 
            // toolStripStatusLabelTime
            // 
            this.toolStripStatusLabelTime.Name = "toolStripStatusLabelTime";
            resources.ApplyResources(this.toolStripStatusLabelTime, "toolStripStatusLabelTime");
            // 
            // numTime
            // 
            this.numTime.Name = "numTime";
            resources.ApplyResources(this.numTime, "numTime");
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьКоллекциюToolStripMenuItem,
            this.открытьКоллекциюToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.сохранитьКакToolStripMenuItem,
            this.документыToolStripMenuItem,
            this.поискToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            resources.ApplyResources(this.файлToolStripMenuItem, "файлToolStripMenuItem");
            // 
            // создатьКоллекциюToolStripMenuItem
            // 
            resources.ApplyResources(this.создатьКоллекциюToolStripMenuItem, "создатьКоллекциюToolStripMenuItem");
            this.создатьКоллекциюToolStripMenuItem.Name = "создатьКоллекциюToolStripMenuItem";
            this.создатьКоллекциюToolStripMenuItem.Click += new System.EventHandler(this.создатьКоллекциюToolStripMenuItem_Click);
            // 
            // открытьКоллекциюToolStripMenuItem
            // 
            resources.ApplyResources(this.открытьКоллекциюToolStripMenuItem, "открытьКоллекциюToolStripMenuItem");
            this.открытьКоллекциюToolStripMenuItem.Name = "открытьКоллекциюToolStripMenuItem";
            this.открытьКоллекциюToolStripMenuItem.Click += new System.EventHandler(this.открытьКоллекциюToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            resources.ApplyResources(this.сохранитьToolStripMenuItem, "сохранитьToolStripMenuItem");
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            resources.ApplyResources(this.сохранитьКакToolStripMenuItem, "сохранитьКакToolStripMenuItem");
            this.сохранитьКакToolStripMenuItem.Click += new System.EventHandler(this.сохранитьКакToolStripMenuItem_Click);
            // 
            // документыToolStripMenuItem
            // 
            this.документыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem1,
            this.удалитьToolStripMenuItem1,
            this.добавитьФайлыToolStripMenuItem1,
            this.добавитьПапкуToolStripMenuItem1,
            this.экспортИзбранногоToolStripMenuItem,
            this.экспортИзЯндексToolStripMenuItem});
            this.документыToolStripMenuItem.Name = "документыToolStripMenuItem";
            resources.ApplyResources(this.документыToolStripMenuItem, "документыToolStripMenuItem");
            // 
            // добавитьToolStripMenuItem1
            // 
            resources.ApplyResources(this.добавитьToolStripMenuItem1, "добавитьToolStripMenuItem1");
            this.добавитьToolStripMenuItem1.Name = "добавитьToolStripMenuItem1";
            this.добавитьToolStripMenuItem1.Click += new System.EventHandler(this.добавитьToolStripMenuItem1_Click);
            // 
            // удалитьToolStripMenuItem1
            // 
            resources.ApplyResources(this.удалитьToolStripMenuItem1, "удалитьToolStripMenuItem1");
            this.удалитьToolStripMenuItem1.Name = "удалитьToolStripMenuItem1";
            this.удалитьToolStripMenuItem1.Click += new System.EventHandler(this.удалитьToolStripMenuItem1_Click);
            // 
            // добавитьФайлыToolStripMenuItem1
            // 
            resources.ApplyResources(this.добавитьФайлыToolStripMenuItem1, "добавитьФайлыToolStripMenuItem1");
            this.добавитьФайлыToolStripMenuItem1.Name = "добавитьФайлыToolStripMenuItem1";
            this.добавитьФайлыToolStripMenuItem1.Click += new System.EventHandler(this.добавитьФайлыToolStripMenuItem1_Click);
            // 
            // добавитьПапкуToolStripMenuItem1
            // 
            resources.ApplyResources(this.добавитьПапкуToolStripMenuItem1, "добавитьПапкуToolStripMenuItem1");
            this.добавитьПапкуToolStripMenuItem1.Name = "добавитьПапкуToolStripMenuItem1";
            this.добавитьПапкуToolStripMenuItem1.Click += new System.EventHandler(this.добавитьПапкуToolStripMenuItem1_Click);
            // 
            // экспортИзбранногоToolStripMenuItem
            // 
            this.экспортИзбранногоToolStripMenuItem.Name = "экспортИзбранногоToolStripMenuItem";
            resources.ApplyResources(this.экспортИзбранногоToolStripMenuItem, "экспортИзбранногоToolStripMenuItem");
            this.экспортИзбранногоToolStripMenuItem.Click += new System.EventHandler(this.экспортИзбранногоToolStripMenuItem_Click);
            // 
            // экспортИзЯндексToolStripMenuItem
            // 
            this.экспортИзЯндексToolStripMenuItem.Name = "экспортИзЯндексToolStripMenuItem";
            resources.ApplyResources(this.экспортИзЯндексToolStripMenuItem, "экспортИзЯндексToolStripMenuItem");
            this.экспортИзЯндексToolStripMenuItem.Click += new System.EventHandler(this.экспортИзЯндексToolStripMenuItem_Click);
            // 
            // поискToolStripMenuItem
            // 
            resources.ApplyResources(this.поискToolStripMenuItem, "поискToolStripMenuItem");
            this.поискToolStripMenuItem.Name = "поискToolStripMenuItem";
            this.поискToolStripMenuItem.Click += new System.EventHandler(this.поискToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            resources.ApplyResources(this.выходToolStripMenuItem, "выходToolStripMenuItem");
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // базаToolStripMenuItem
            // 
            this.базаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.обновитьЯндексТИЦToolStripMenuItem,
            this.обновитьGooglePRToolStripMenuItem,
            this.очиститьToolStripMenuItem});
            this.базаToolStripMenuItem.Name = "базаToolStripMenuItem";
            resources.ApplyResources(this.базаToolStripMenuItem, "базаToolStripMenuItem");
            this.базаToolStripMenuItem.Click += new System.EventHandler(this.базаToolStripMenuItem_Click);
            // 
            // обновитьЯндексТИЦToolStripMenuItem
            // 
            this.обновитьЯндексТИЦToolStripMenuItem.Name = "обновитьЯндексТИЦToolStripMenuItem";
            resources.ApplyResources(this.обновитьЯндексТИЦToolStripMenuItem, "обновитьЯндексТИЦToolStripMenuItem");
            this.обновитьЯндексТИЦToolStripMenuItem.Click += new System.EventHandler(this.обновитьЯндексТИЦToolStripMenuItem_Click);
            // 
            // обновитьGooglePRToolStripMenuItem
            // 
            this.обновитьGooglePRToolStripMenuItem.Name = "обновитьGooglePRToolStripMenuItem";
            resources.ApplyResources(this.обновитьGooglePRToolStripMenuItem, "обновитьGooglePRToolStripMenuItem");
            this.обновитьGooglePRToolStripMenuItem.Click += new System.EventHandler(this.обновитьGooglePRToolStripMenuItem_Click);
            // 
            // очиститьToolStripMenuItem
            // 
            this.очиститьToolStripMenuItem.Name = "очиститьToolStripMenuItem";
            resources.ApplyResources(this.очиститьToolStripMenuItem, "очиститьToolStripMenuItem");
            this.очиститьToolStripMenuItem.Click += new System.EventHandler(this.очиститьToolStripMenuItem_Click);
            // 
            // настройкаToolStripMenuItem
            // 
            this.настройкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.стопсловаToolStripMenuItem,
            this.опцииToolStripMenuItem1});
            this.настройкаToolStripMenuItem.Name = "настройкаToolStripMenuItem";
            resources.ApplyResources(this.настройкаToolStripMenuItem, "настройкаToolStripMenuItem");
            // 
            // стопсловаToolStripMenuItem
            // 
            this.стопсловаToolStripMenuItem.Name = "стопсловаToolStripMenuItem";
            resources.ApplyResources(this.стопсловаToolStripMenuItem, "стопсловаToolStripMenuItem");
            this.стопсловаToolStripMenuItem.Click += new System.EventHandler(this.стопсловаToolStripMenuItem_Click);
            // 
            // опцииToolStripMenuItem1
            // 
            this.опцииToolStripMenuItem1.Name = "опцииToolStripMenuItem1";
            resources.ApplyResources(this.опцииToolStripMenuItem1, "опцииToolStripMenuItem1");
            this.опцииToolStripMenuItem1.Click += new System.EventHandler(this.опцииToolStripMenuItem1_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            resources.ApplyResources(this.справкаToolStripMenuItem, "справкаToolStripMenuItem");
            this.справкаToolStripMenuItem.Click += new System.EventHandler(this.справкаToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.обходToolStripMenuItem1,
            this.базаToolStripMenuItem,
            this.подключениеToolStripMenuItem,
            this.настройкаToolStripMenuItem,
            this.справкаToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // обходToolStripMenuItem1
            // 
            this.обходToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.начатьToolStripMenuItem,
            this.обходToolStripMenuItem,
            this.остановитьToolStripMenuItem});
            this.обходToolStripMenuItem1.Name = "обходToolStripMenuItem1";
            resources.ApplyResources(this.обходToolStripMenuItem1, "обходToolStripMenuItem1");
            // 
            // начатьToolStripMenuItem
            // 
            resources.ApplyResources(this.начатьToolStripMenuItem, "начатьToolStripMenuItem");
            this.начатьToolStripMenuItem.Name = "начатьToolStripMenuItem";
            this.начатьToolStripMenuItem.Click += new System.EventHandler(this.начатьToolStripMenuItem_Click);
            // 
            // обходToolStripMenuItem
            // 
            resources.ApplyResources(this.обходToolStripMenuItem, "обходToolStripMenuItem");
            this.обходToolStripMenuItem.Name = "обходToolStripMenuItem";
            this.обходToolStripMenuItem.Click += new System.EventHandler(this.индексироватьToolStripMenuItem_Click);
            // 
            // остановитьToolStripMenuItem
            // 
            resources.ApplyResources(this.остановитьToolStripMenuItem, "остановитьToolStripMenuItem");
            this.остановитьToolStripMenuItem.Name = "остановитьToolStripMenuItem";
            this.остановитьToolStripMenuItem.Click += new System.EventHandler(this.остановитьToolStripMenuItem_Click);
            // 
            // подключениеToolStripMenuItem
            // 
            this.подключениеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.проверитьToolStripMenuItem});
            this.подключениеToolStripMenuItem.Name = "подключениеToolStripMenuItem";
            resources.ApplyResources(this.подключениеToolStripMenuItem, "подключениеToolStripMenuItem");
            // 
            // проверитьToolStripMenuItem
            // 
            resources.ApplyResources(this.проверитьToolStripMenuItem, "проверитьToolStripMenuItem");
            this.проверитьToolStripMenuItem.Name = "проверитьToolStripMenuItem";
            this.проверитьToolStripMenuItem.Click += new System.EventHandler(this.проверитьToolStripMenuItem_Click);
            // 
            // lbAddress
            // 
            resources.ApplyResources(this.lbAddress, "lbAddress");
            this.lbAddress.Name = "lbAddress";
            // 
            // lbClt
            // 
            this.lbClt.FormattingEnabled = true;
            resources.ApplyResources(this.lbClt, "lbClt");
            this.lbClt.Name = "lbClt";
            this.lbClt.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbClt.SelectedIndexChanged += new System.EventHandler(this.lstAddress_Sp_SelectedIndexChanged);
            // 
            // tbAddress_Sp
            // 
            this.tbAddress_Sp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbAddress_Sp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllUrl;
            resources.ApplyResources(this.tbAddress_Sp, "tbAddress_Sp");
            this.tbAddress_Sp.Name = "tbAddress_Sp";
            // 
            // lbDBCount
            // 
            resources.ApplyResources(this.lbDBCount, "lbDBCount");
            this.lbDBCount.Name = "lbDBCount";
            // 
            // lbCltCount
            // 
            resources.ApplyResources(this.lbCltCount, "lbCltCount");
            this.lbCltCount.Name = "lbCltCount";
            // 
            // lbReport
            // 
            this.lbReport.FormattingEnabled = true;
            resources.ApplyResources(this.lbReport, "lbReport");
            this.lbReport.Name = "lbReport";
            // 
            // button4
            // 
            resources.ApplyResources(this.button4, "button4");
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbDB
            // 
            this.lbDB.FormattingEnabled = true;
            resources.ApplyResources(this.lbDB, "lbDB");
            this.lbDB.Name = "lbDB";
            this.lbDB.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbDB.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton11,
            this.toolStripButton8,
            this.toolStripButton5,
            this.toolStripSeparator1,
            this.toolStripButton12,
            this.toolStripButton13,
            this.toolStripButton14,
            this.toolStripButton15,
            this.toolStripSeparator3,
            this.toolStripButton9,
            this.toolStripButton16,
            this.btStop,
            this.toolStripSeparator4,
            this.toolStripButton3,
            this.toolStripButton7,
            this.toolStripButton1,
            this.toolStripSeparator2,
            this.toolStripButton2});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            // 
            // toolStripButton11
            // 
            this.toolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButton11, "toolStripButton11");
            this.toolStripButton11.Name = "toolStripButton11";
            this.toolStripButton11.Click += new System.EventHandler(this.toolStripButton11_Click);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButton8, "toolStripButton8");
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Click += new System.EventHandler(this.toolStripButton8_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButton5, "toolStripButton5");
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolStripButton12
            // 
            this.toolStripButton12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButton12, "toolStripButton12");
            this.toolStripButton12.Name = "toolStripButton12";
            this.toolStripButton12.Click += new System.EventHandler(this.toolStripButton12_Click);
            // 
            // toolStripButton13
            // 
            this.toolStripButton13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButton13, "toolStripButton13");
            this.toolStripButton13.Name = "toolStripButton13";
            this.toolStripButton13.Click += new System.EventHandler(this.toolStripButton13_Click);
            // 
            // toolStripButton14
            // 
            this.toolStripButton14.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButton14, "toolStripButton14");
            this.toolStripButton14.Name = "toolStripButton14";
            this.toolStripButton14.Click += new System.EventHandler(this.toolStripButton14_Click);
            // 
            // toolStripButton15
            // 
            this.toolStripButton15.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButton15, "toolStripButton15");
            this.toolStripButton15.Name = "toolStripButton15";
            this.toolStripButton15.Click += new System.EventHandler(this.toolStripButton15_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButton9, "toolStripButton9");
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Click += new System.EventHandler(this.toolStripButton9_Click);
            // 
            // toolStripButton16
            // 
            this.toolStripButton16.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButton16, "toolStripButton16");
            this.toolStripButton16.Name = "toolStripButton16";
            this.toolStripButton16.Click += new System.EventHandler(this.toolStripButton16_Click);
            // 
            // btStop
            // 
            this.btStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.btStop, "btStop");
            this.btStop.Name = "btStop";
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButton3, "toolStripButton3");
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButton7, "toolStripButton7");
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton7_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButton2, "toolStripButton2");
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbDB);
            this.Controls.Add(this.lbDBCount);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lbReport);
            this.Controls.Add(this.lbCltCount);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.lbAddress);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tbAddress_Sp);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lbClt);
            this.Controls.Add(this.button1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openCltDialog;
        private System.Windows.Forms.SaveFileDialog saveCltDialog;
        private System.Windows.Forms.OpenFileDialog openDocDialog;

        SqlConnection sc;
        SqlCommand myCommand;

        public Settings AppSettings;
        public string CurrentFileName;
        public bool isFileChanged;
        Indexer StemIndexer;

        public bool isStop;
        public int step;
        public int trafic;
        public int processed;
        public System.DateTime begintime;

        private System.Windows.Forms.OpenFileDialog openManyDocDialog;
        private System.Windows.Forms.ToolStripMenuItem опцииToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьКоллекциюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьКоллекциюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem базаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem очиститьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem опцииToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.Label lbAddress;
        private System.Windows.Forms.ListBox lbClt;
        private System.Windows.Forms.TextBox tbAddress_Sp;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem поискToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem стопсловаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обновитьЯндексТИЦToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обновитьGooglePRToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripButton toolStripButton11;
        private System.Windows.Forms.ToolStripMenuItem подключениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem проверитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton12;
        private System.Windows.Forms.ToolStripButton toolStripButton13;
        private System.Windows.Forms.ToolStripButton toolStripButton14;
        private System.Windows.Forms.ToolStripButton toolStripButton15;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton16;
        private System.Windows.Forms.ToolStripMenuItem документыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem добавитьФайлыToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem добавитьПапкуToolStripMenuItem1;
        private System.Windows.Forms.ListBox lbDB;
        private System.Windows.Forms.ToolStripMenuItem обходToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem начатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem остановитьToolStripMenuItem;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
        private System.Windows.Forms.ToolStripButton btStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ListBox lbReport;
        private System.Windows.Forms.Label lbCltCount;
        private System.Windows.Forms.Label lbDBCount;
        private System.Windows.Forms.ToolStripMenuItem экспортИзбранногоToolStripMenuItem;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTrafic;
        private System.Windows.Forms.ToolStripStatusLabel lbTrafic;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelProcessed;
        private System.Windows.Forms.ToolStripStatusLabel lbProcessed;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTime;
        private System.Windows.Forms.ToolStripStatusLabel numTime;
        private System.Windows.Forms.ToolStripMenuItem обходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem экспортИзЯндексToolStripMenuItem;

    }
}

