using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Athelas
{
    public partial class OptionsForm : Form
    {
        public Settings s = new Settings();
        public OptionsForm()
        {
            InitializeComponent();
            s.Read();
            //настройки
            numMaxSize.Value = s.maxDocSize;
            numMaxTrafic.Value = s.maxTrafic;
            numMaxTime.Value = s.maxTime;
            numClusters.Value = s.maxClusters;
            tbServer.Text = s.connectionstring;
            if (s.files.Contains(".doc"))
                cbDoc.Checked=true;
            else
                cbDoc.Checked=false;

            if (s.files.Contains(".txt"))
                cbTxt.Checked=true;
            else
                cbTxt.Checked=false;

            if (s.files.Contains(".htm"))
                cbHtm.Checked=true;
            else
                cbHtm.Checked=false;

            if (s.files.Contains(".ppt"))
                cbPpt.Checked=true;
            else
                cbPpt.Checked=false;

            if (s.files.Contains(".xls"))
                cbXls.Checked=true;
            else
                cbXls.Checked=false;

            if (s.isSearchHyperLinks)
                cbIsSearchHyperLinks.Checked = true;
            else
                cbIsSearchHyperLinks.Checked = false;

            if (s.isSearchSubFolders)
                cbIsSearchSubFolders.Checked = true;
            else
                cbIsSearchSubFolders.Checked = false;
        }

        private void btConfigOK_Click(object sender, EventArgs e)
        {
            if (!cbDoc.Checked && !cbTxt.Checked && !cbHtm.Checked && !cbPpt.Checked && !cbXls.Checked)
            {
                MessageBox.Show("Необходимо указать хотя бы один\nтип индексируемых файлов!", "Ошибка",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            s.maxDocSize=(int)numMaxSize.Value;
            s.maxTrafic=(int)numMaxTrafic.Value;
            s.maxTime = (int)numMaxTime.Value;
            s.maxClusters = (int)numClusters.Value;
            s.connectionstring = tbServer.Text;
            s.files = "";
            if (cbDoc.Checked)
                s.files += "(\\.doc)";

            if (cbTxt.Checked)
                s.files += "|(\\.txt)";

            if (cbHtm.Checked)
                s.files += "|(\\.htm)";

            if (cbPpt.Checked)
                s.files += "|(\\.ppt)";
            
            if (cbXls.Checked)
                s.files += "|(\\.xls)";
            s.files += "$";
            if (s.files.StartsWith("|"))
                s.files=s.files.Remove(0,1);
            s.isSearchHyperLinks = cbIsSearchHyperLinks.Checked;
            s.isSearchSubFolders = cbIsSearchSubFolders.Checked;

            s.Write();
            Close();
        }

        private void btConfigCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}