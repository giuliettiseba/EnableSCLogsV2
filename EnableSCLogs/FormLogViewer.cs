using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnableSCLogs
{
    public partial class FormLogViewer : Form
    {

        private string logFile;

        // Join the dark theme 
        readonly Color TEXTBACKCOLOR = System.Drawing.ColorTranslator.FromHtml("#252526");
        readonly Color BACKCOLOR = System.Drawing.ColorTranslator.FromHtml("#2D2D30");
        readonly Color INFOCOLOR = System.Drawing.ColorTranslator.FromHtml("#1E7AD4");
        readonly Color MESSAGECOLOR = System.Drawing.ColorTranslator.FromHtml("#86A95A");
        readonly Color DEBUGCOLOR = System.Drawing.ColorTranslator.FromHtml("#DCDCAA");
        readonly Color ERRORCOLOR = System.Drawing.ColorTranslator.FromHtml("#B0572C");

        public FormLogViewer(string logFile)
        {
            this.logFile = logFile;
            InitializeComponent();
            BackColor = BACKCOLOR;
            Task bg = Task.Run(BackgroundWorker1_DoWork);
        }

        private void BackgroundWorker1_DoWork()
        {
            var wh = new AutoResetEvent(false);
            var fsw = new FileSystemWatcher(".");
            fsw.Filter = logFile;
            fsw.EnableRaisingEvents = true;
            fsw.Changed += (s, e) => wh.Set();

            var fs = new FileStream(logFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            List<Entry> entries = new List<Entry>();

            using (var sr = new StreamReader(fs))
            {
                var s = "";
                while (true) /// Infinite loop (exit??)
                {
                    s = sr.ReadLine();
                    if (s != null)
                    {
                        try
                        {
                            WriteInConsole(s);

                            progressBar1.Invoke((MethodInvoker)delegate
                            {
                                progressBar1.Value = (Convert.ToInt32(Convert.ToDouble(fs.Position) / Convert.ToDouble(fs.Length) * 100));
                            });
                        }
                        catch (Exception e1)
                        {
                            Console.WriteLine(e1);
                        }
                    }
                    else
                        wh.WaitOne(1000);
                }
                wh.Close();
            }
        }

        private LogType lastLogType = LogType.info;
        private void WriteInConsole(string text)
        {
            // debug / info / warning => message / error

            LogType type = lastLogType;
            if (text.Contains("INFO")) type = LogType.info;
            else if (text.Contains("DEBUG")) type = LogType.debug;
            else if (text.Contains("ERROR")) type = LogType.error;
            else if (text.Contains("WARNING")) type = LogType.message;
            lastLogType = type;

            textBox_Console.Invoke((MethodInvoker)delegate
            {
                Color _color;
                switch (type)
                {
                    case LogType.debug:
                        _color = DEBUGCOLOR;
                        break;
                    case LogType.message:
                        _color = MESSAGECOLOR;
                        break;
                    case LogType.info:
                        _color = INFOCOLOR;
                        break;
                    case LogType.error:
                        _color = ERRORCOLOR;
                        break;
                    default:
                        _color = Color.White;
                        break;
                }

                textBox_Console.SelectionStart = textBox_Console.TextLength;
                textBox_Console.SelectionLength = 0;

                textBox_Console.SelectionColor = _color;
                textBox_Console.AppendText(text + Environment.NewLine);
                textBox_Console.SelectionColor = textBox_Console.ForeColor;

                textBox_Console.SelectionStart = textBox_Console.TextLength;
                textBox_Console.ScrollToCaret();

            });
        }

        enum LogType
        {
            debug,
            message,
            info,
            error,
        }

        private class Entry
        {
            public string entryDate { get; internal set; }
            public string entryTypeCode { get; internal set; }
            public string entryType { get; internal set; }
            public string entryMessage { get; internal set; }
        }

        private void ClearLogs_Click(object sender, EventArgs e)
        {
            try
            {
                System.IO.File.WriteAllText(logFile, string.Empty);
                textBox_Console.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            saveFileDialog1.FileName = Path.GetFileName(logFile);

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    StreamWriter sw = new StreamWriter(myStream);
                    sw.Write(textBox_Console.Text);
                    sw.Close();
                    myStream.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox_Console.Clear();
        }
    }
}
