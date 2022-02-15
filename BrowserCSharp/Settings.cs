using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.IO;

namespace Athelas
{
    public class Settings
    {
        public int maxDocSize = 100;
        public int maxTrafic = 1000;
        public int maxTime = 60;
        public int maxClusters = 5;
        public string connectionstring = "Initial Catalog=robot; Integrated Security=true; Data Source=localhost;";
        public string files = "(\\.doc)|(\\.txt)(\\.htm)|(\\.ppt)|(\\.xls)$";
        public bool isSearchSubFolders = true;
        public bool isSearchHyperLinks = true;

        public Settings()
        {
            Read();
        }

        public void Read()
        {
            string path = Application.StartupPath + "\\";
            if (!File.Exists(path + "config.ini"))
                return;
            StreamReader reader = new StreamReader(path+"config.ini");
            
            maxDocSize = int.Parse(reader.ReadLine());
            maxTrafic = int.Parse(reader.ReadLine());
            maxTime = int.Parse(reader.ReadLine());
            connectionstring = reader.ReadLine();
            maxClusters = int.Parse(reader.ReadLine());
            files = reader.ReadLine();
            if (files.StartsWith("|"))
                files=files.Remove(0,1);
            isSearchSubFolders = bool.Parse(reader.ReadLine());
            isSearchHyperLinks = bool.Parse(reader.ReadLine());
            reader.Close();
        }
        public void Write()
        {
            string path = Application.StartupPath + "\\";
            StreamWriter writer = new StreamWriter(path+"config.ini", false);
            writer.WriteLine(maxDocSize.ToString());
            writer.WriteLine(maxTrafic.ToString());
            writer.WriteLine(maxTime.ToString());
            writer.WriteLine(connectionstring);
            writer.WriteLine(maxClusters.ToString());
            writer.WriteLine(files);
            writer.WriteLine(isSearchSubFolders);
            writer.WriteLine(isSearchHyperLinks);
            writer.Close();            
        }
    }
}
