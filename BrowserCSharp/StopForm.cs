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
    public partial class StopForm : Form
    {
        public StopForm()
        {
            InitializeComponent();

            StreamReader reader;
            string path = Application.StartupPath + "\\";

            if (!File.Exists(path+"stop_ru.dat"))
                MessageBox.Show("Не найден файл stop_ru.dat", "Ошибка",MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                reader = new StreamReader(path+"stop_ru.dat");
                while (!reader.EndOfStream)
                {
                    string stopword = reader.ReadLine();
                    lbListStopRus.Items.Add(stopword);
                }
                reader.Close();
            }

            if (!File.Exists(path+"stop_en.dat"))
                MessageBox.Show("Не найден файл stop_en.dat","Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
            else
            {
                reader = new StreamReader(path+"stop_en.dat");
                while (!reader.EndOfStream)
                {
                    string stopword = reader.ReadLine();
                    lbListStopEn.Items.Add(stopword);
                }
                reader.Close();
            }

            if (!File.Exists(path+"stop_ru_stem.dat"))
                MessageBox.Show("Не найден файл stop_ru_stem.dat","Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
            else
            {
                reader = new StreamReader(path + "stop_ru_stem.dat");
                while (!reader.EndOfStream)
                {
                    string stopword = reader.ReadLine();
                    lbListStopStem.Items.Add(stopword);
                }
                reader.Close();
            }
            lbListStopRus.Refresh();
            lbListStopEn.Refresh();
            lbListStopStem.Refresh();
        }

        private void btConfigOK_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\";

            StreamWriter writer = new StreamWriter(path+"stop_ru.dat");
            foreach (string stopword in lbListStopRus.Items)
                writer.WriteLine(stopword);
            writer.Close();

            writer = new StreamWriter(path+"stop_en.dat");
            foreach (string stopword in lbListStopEn.Items)
                writer.WriteLine(stopword);
            writer.Close();

            writer = new StreamWriter(path+"stop_ru_stem.dat");
            foreach (string stopword in lbListStopStem.Items)
                writer.WriteLine(stopword);
            writer.Close();

            Close();
        }

        private void lbListStopRus_Click(object sender, EventArgs e)
        {

        }

        private void lbListStopRus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbListStopRus.SelectedIndex!=-1)
                tbNewStopRus.Text = lbListStopRus.SelectedItem.ToString();
        }

        private void btAddStopRus_Click(object sender, EventArgs e)
        {
            if (tbNewStopRus.Text == "")
                return;

            tbNewStopRus.Text = tbNewStopRus.Text.ToLower();

            if (lbListStopRus.SelectedIndex != -1)
                lbListStopRus.Items[lbListStopRus.SelectedIndex] = tbNewStopRus.Text;
            else
            {
                if (lbListStopRus.Items.Contains(tbNewStopRus.Text))
                {
                    MessageBox.Show("Такое слово уже содержится в списке","Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                lbListStopRus.Items.Add(tbNewStopRus.Text);
                lbListStopRus.Sorted = true;
                lbListStopRus.Refresh();
            }
        }

        private void btDelStopRus_Click(object sender, EventArgs e)
        {
            if (lbListStopRus.SelectedIndex != -1)
            {
                lbListStopRus.Items.RemoveAt(lbListStopRus.SelectedIndex);
                lbListStopRus.Refresh();
            }
            tbNewStopRus.Text = "";
        }

        private void lbListStopEn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbListStopEn.SelectedIndex != -1)
                tbNewStopEn.Text = lbListStopEn.SelectedItem.ToString();
        }

        private void btAddStopEn_Click(object sender, EventArgs e)
        {
            if (tbNewStopEn.Text == "")
                return;

            tbNewStopEn.Text = tbNewStopEn.Text.ToLower();

            if (lbListStopEn.SelectedIndex != -1)
                lbListStopEn.Items[lbListStopEn.SelectedIndex] = tbNewStopEn.Text;
            else
            {
                if (lbListStopEn.Items.Contains(tbNewStopEn.Text))
                {
                    MessageBox.Show("Такое слово уже содержится в списке", "Ошибка",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                lbListStopEn.Items.Add(tbNewStopEn.Text);
                lbListStopEn.Sorted = true;
                lbListStopEn.Refresh();
            }
        }

        private void btDelStopEn_Click(object sender, EventArgs e)
        {
            if (lbListStopEn.SelectedIndex != -1)
            {
                lbListStopEn.Items.RemoveAt(lbListStopEn.SelectedIndex);
                lbListStopEn.Refresh();
            }
            tbNewStopRus.Text = "";
        }

        private void btConfigCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lbListStopStem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbListStopStem.SelectedIndex != -1)
                tbNewStopStem.Text = lbListStopStem.SelectedItem.ToString();
        }

        private void btAddStopStem_Click(object sender, EventArgs e)
        {
            if (tbNewStopStem.Text == "")
                return;

            tbNewStopStem.Text = tbNewStopStem.Text.ToLower();

            if (lbListStopStem.SelectedIndex != -1)
                lbListStopStem.Items[lbListStopStem.SelectedIndex] = tbNewStopStem.Text;
            else
            {
                if (lbListStopStem.Items.Contains(tbNewStopStem.Text))
                {
                    MessageBox.Show("Такое слово уже содержится в списке", "Ошибка",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                lbListStopStem.Items.Add(tbNewStopStem.Text);
                lbListStopStem.Sorted = true;
                lbListStopStem.Refresh();
            }
        }

        private void btDelStopStem_Click(object sender, EventArgs e)
        {
            if (lbListStopStem.SelectedIndex != -1)
            {
                lbListStopStem.Items.RemoveAt(lbListStopStem.SelectedIndex);
                lbListStopStem.Refresh();
            }
            tbNewStopStem.Text = "";
        }

        private void btNewStopRu_Click(object sender, EventArgs e)
        {
            tbNewStopRus.Text = "";
            lbListStopRus.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbNewStopEn.Text = "";
            lbListStopEn.SelectedIndex = -1;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tbNewStopStem.Text = "";
            lbListStopStem.SelectedIndex = -1;

        }
    }
}