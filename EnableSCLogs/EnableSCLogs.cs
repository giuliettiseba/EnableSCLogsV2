using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using System.Xml;

namespace EnableSCLogs
{
    public partial class EnableSCLogs : Form
    {
        // Join the dark theme 
        readonly Color TEXTBACKCOLOR = System.Drawing.ColorTranslator.FromHtml("#252526");
        readonly Color BACKCOLOR = System.Drawing.ColorTranslator.FromHtml("#2D2D30");
        readonly Color INFOCOLOR = System.Drawing.ColorTranslator.FromHtml("#1E7AD4");
        readonly Color MESSAGECOLOR = System.Drawing.ColorTranslator.FromHtml("#86A95A");
        readonly Color DEBUGCOLOR = System.Drawing.ColorTranslator.FromHtml("#DCDCAA");
        readonly Color ERRORCOLOR = System.Drawing.ColorTranslator.FromHtml("#B0572C");


        private XmlNode nodeLoggingenabled;
        private XmlDocument doc;
        static readonly String appDataFile = (Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Milestone\Smart Client\ApplicationSettings.xml");
        static readonly String appConfigFile = (Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\Milestone\XProtect Smart Client\Client.exe.config");
        static readonly String pluginsDir = (Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\Milestone\MIPPlugins");
        private Configuration config;
        private KeyValueConfigurationCollection settings;

        public EnableSCLogs()
        {
            InitializeComponent();
            doc = new XmlDocument();
            ReadXML();
            ReadConfigFile();
        }

        private void ReadConfigFile()
        {
            try
            {
                System.Configuration.ExeConfigurationFileMap configFile = new System.Configuration.ExeConfigurationFileMap();
                configFile.ExeConfigFilename = appConfigFile;  //name of your config file, can be from your app or external
                config = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(configFile, System.Configuration.ConfigurationUserLevel.None);
                settings = config.AppSettings.Settings;

                KeyValueConfigurationElement k = settings["FallThroughPriority"];
                comboBoxHA.SelectedItem = k.Value;
            }

            catch (Exception me)
            {
                MessageBox.Show(me.Message);
            }
        }

        private void ReadXML()
        {
            try
            {
                doc.Load(appDataFile);
                nodeLoggingenabled = doc.DocumentElement.SelectSingleNode("/applicationsettings/loggingenabled");
                chechBoxLogEnabled.Checked = nodeLoggingenabled.InnerText.Equals("True");
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot find the configuration file, this version will only work with 2020r3 or newer");
                System.Environment.Exit(1);
            }
        }

        private void buttonCollectLogs_Click(object sender, EventArgs e)
        {
            int i = 0;
            while (!SaveXmlFile(i))
                i++;
        }

        private bool SaveXmlFile(int i)
        {

            string startPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Milestone\XProtect Smart Client";
            string zipPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\sc_logs_" + DateTime.Now.ToString("MMddyyyy_") + i + ".zip";

            try
            {
                ZipFile.CreateFromDirectory(startPath, zipPath);
                return true;
            }

            catch (System.IO.IOException)
            {
                return false;
            }

            catch (Exception em)
            {
                MessageBox.Show(em.Message);
                return true;
            }
        }

        private void buttonLauchSC_Click(object sender, EventArgs e)
        {
            try
            {

                Process[] processes = Process.GetProcessesByName("Client");

                foreach (Process process in processes)
                {
                    // Close process by sending a close message to its main window.
                    process.CloseMainWindow();
                    // Free resources associated with process.
                    process.Close();
                }

                Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\Milestone\XProtect Smart Client\Client.exe");

            }
            catch (Exception em)
            {
                MessageBox.Show(em.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string subPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Milestone\Smart Client";
            try
            {
                //  Directory.CreateDirectory(subPath);
                Directory.Delete(subPath, true);
            }
            catch (Exception e1)
            {
                Console.WriteLine("The process failed: {0}", e1.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormLogViewer f2 = new FormLogViewer(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Milestone\XProtect Smart Client\ClientLog.txt");
            f2.Show(); // Shows Form2
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                nodeLoggingenabled.InnerText = chechBoxLogEnabled.Checked.ToString();
                doc.Save(appDataFile);


                settings["FallThroughPriority"].Value = comboBoxHA.SelectedItem.ToString();

                int i = 0;
                while (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\Milestone\XProtect Smart Client\Client.exe_" + i + ".config"))
                {

                    i++;
                }

                File.Copy((Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\Milestone\XProtect Smart Client\Client.exe.config"),
                    (Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\Milestone\XProtect Smart Client\Client.exe_" + i + ".config"), true);
                config.Save();

            }
            catch (Exception em)
            {
                MessageBox.Show(em.Message);
            }
        }
    }

}














