using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnableSCLogs
{
    public partial class FormLogViewer : Form
    {

        string logFile = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Milestone\XProtect Smart Client\ClientLog.txt";
        private BackgroundWorker backgroundWorker1;

        public FormLogViewer()
        {
            InitializeComponent();

            backgroundWorker1 = new BackgroundWorker();
            backgroundWorker1.DoWork += new DoWorkEventHandler(BackgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerAsync();


            ContextMenuStrip mnu = new ContextMenuStrip();
            ToolStripMenuItem mnuCopy = new ToolStripMenuItem("Copy");

            ToolStripMenuItem mnuAnalyze = new ToolStripMenuItem("Analyze");

            //Assign event handlers
            mnuCopy.Click += new EventHandler(mnuCopy_Click);

            mnuAnalyze.Click += new EventHandler(mnuAnalyze_Click);

            //Add to main context menu
            mnu.Items.AddRange(new ToolStripItem[] { mnuCopy , mnuAnalyze });
            //Assign to datagridview
            dataGridView1.ContextMenuStrip = mnu;

        }

        private void mnuAnalyze_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void mnuCopy_Click(object sender, EventArgs e)
        {
          var newline = System.Environment.NewLine;
    var tab = "\t";
    var clipboard_string = "";

            DataGridViewRow row = dataGridView1.SelectedRows[0];
    {
         for (int i=0; i < row.Cells.Count; i++)
         {
              if(i == (row.Cells.Count - 1))
                   clipboard_string += row.Cells[i].Value + newline;
              else
                   clipboard_string += row.Cells[i].Value + tab;
         }
    }

    Clipboard.SetText(clipboard_string);    }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e4)
        {
            var wh = new AutoResetEvent(false);
            var fsw = new FileSystemWatcher(".");
            fsw.Filter = logFile;
            fsw.EnableRaisingEvents = true;
            fsw.Changed += (s, e) => wh.Set();

            var fs = new FileStream(logFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            using (var sr = new StreamReader(fs))
            {
                var s = "";
                while (true)
                {
                    s = sr.ReadLine();
                    if (s != null)
                    {
                        try
                        {
                            Entry entry = new Entry();
                            entry.entryDate = s.Substring(0, 29);
                            entry.entryTypeCode = s.Substring(30, 8);
                            entry.entryType = s.Substring(39, 11);
                            entry.entryMessage = s.Substring(52);
                            this.Invoke(new Action<Entry>(AppendTextBox), new object[] { entry });

                        }
                        catch (Exception e1)
                        {

                            Console.WriteLine(e1);
                        }
                    }


                    else
                        wh.WaitOne(1000);
                }
            }
            wh.Close();

        }

        



        private void AppendTextBox(Entry value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<Entry>(AppendTextBox), new object[] { value });
                return;
            }



//   
            int rowId = dataGridView1.Rows.Add();

            // Grab the new row!
            DataGridViewRow row = dataGridView1.Rows[rowId];

            row.Cells[0].Value = value.entryDate;
            row.Cells[1].Value = value.entryTypeCode;

            row.Cells[2].Value = value.entryType;

            switch (value.entryType)
            {       

                case "INFO       ":
                    row.Cells[2].Style.BackColor = Color.Green; break;
                case "DEBUG      ":
                    row.Cells[2].Style.BackColor = Color.Yellow; break;
                case "ERROR      ":
                    row.Cells[2].Style.BackColor = Color.Red; break;

                default:
                    break;
            }

            row.Cells[3].Value = value.entryMessage;


            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
        }


        private class Entry
        {
            public string entryDate { get; internal set; }
            public string entryTypeCode { get; internal set; }
            public string entryType { get; internal set; }
            public string entryMessage { get; internal set; }
        }

      
    }
}
