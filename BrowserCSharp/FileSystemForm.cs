using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Athelas
{
    public partial class FileSystemForm : Form
    {
        public FileSystemForm()
        {
            InitializeComponent();
//            tree.ShowFiles = false;
        }
        private void getDrives()
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                    comboBox1.Items.Add(drive.RootDirectory);
            }
        }

        private void FileSystemForm_Load(object sender, EventArgs e)
        {
            getDrives();
            if (comboBox1.Items.Count != 0)
            {
                comboBox1.Text = comboBox1.Items[0].ToString();
                SetExtensions();
                tree.Load(comboBox1.Text);
            }
            else
            {
                comboBox1.Text = "(нет дисков)";
                comboBox1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetExtensions();
            tree.Load(comboBox1.Text);
        }

        private void SetExtensions()
        {
            string extensions = "";
            if (cbDoc.Checked) extensions += "1"; else extensions += "0";
            if (cbXls.Checked) extensions += "1"; else extensions += "0";
            if (cbPpt.Checked) extensions += "1"; else extensions += "0";
            if (cbHtm.Checked) extensions += "1"; else extensions += "0";
            if (cbTxt.Checked) extensions += "1"; else extensions += "0";
            tree.extensions = extensions;
        }

        private void tree_Click(object sender, EventArgs e)
        {
            //listBox1.Items.Add(tree.SelectedNode.FullPath);
        }

        private void tree_AfterCheck(object sender, TreeViewEventArgs e)
        {
        }
    }
}