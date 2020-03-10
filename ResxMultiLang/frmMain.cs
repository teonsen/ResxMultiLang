using System;
using System.Collections.Generic;
using System.IO;
using System.Resources;
using System.Windows.Forms;
using unvell.ReoGrid;

namespace ResxMultiLang
{
    public partial class frmMain : Form
    {
        readonly static string _recent = Application.StartupPath + "\\Recent.txt";
        string CurrentResxFile { get; set; } = "";
        Dictionary<Col, string> _Locales = new Dictionary<Col, string>();

        enum Col : int
        {
            Key,
            zh_CN,
            ja_JP,
            en_US,
            zh_TW,
        }

        public frmMain()
        {
            InitializeComponent();
            _Locales.Add(Col.Key, "Key");
            _Locales.Add(Col.zh_CN, "zh-CN");
            _Locales.Add(Col.ja_JP, "ja-JP");
            _Locales.Add(Col.en_US, "en-US");
            _Locales.Add(Col.zh_TW, "zh-TW");
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            SetRecentOpenFileMenues();
        }


        #region Recent file
        // Add menu to Open Recent menu.
        private void SetRecentOpenFileMenues()
        {
            tsmiFile_OpenRecent.DropDownItems.Clear();
            tsmiFile_OpenRecent.Enabled = false;
            int count = 0;
            if (File.Exists(_recent))
            {
                foreach (string line in File.ReadAllLines(_recent))
                {
                    ToolStripMenuItem recentMenuItem = new ToolStripMenuItem();
                    recentMenuItem.Text = line;
                    recentMenuItem.Click += new EventHandler(OpenRecent_Click);
                    tsmiFile_OpenRecent.DropDownItems.Add(recentMenuItem);
                    count++;
                    if (count >= 20)
                    {
                        break;
                    }
                }
            }
            if (count > 0)
            {
                tsmiFile_OpenRecent.Enabled = true;
            }
        }

        private void OpenRecent_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem t = (ToolStripMenuItem)sender;
            if (File.Exists(t.Text))
            {
                MakeRecentMenu(t.Text);
                if (t.Text.EndsWith(".resx"))
                {
                    OpenTheResourceFile(t.Text);
                }
                else if (t.Text.EndsWith(".xlsx"))
                {
                    OpenExcelFile(t.Text);
                }
            }
            else
            {
                var dr = MessageBox.Show("\"" + t.Text + "\" is not found.\nDelete from menu?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dr == DialogResult.Yes)
                {
                    var lines = new List<string>();
                    foreach (string line in File.ReadAllLines(_recent))
                    {
                        if (line != t.Text)
                        {
                            lines.Add(line);
                        }
                    }
                    File.WriteAllLines(_recent, lines.ToArray());
                    SetRecentOpenFileMenues();
                }
            }
        }

        private void MakeRecentMenu(string fileToOpen)
        {
            if (File.Exists(_recent))
            {
                var lines = new List<string>();
                lines.Add(fileToOpen);
                int count = 1;
                foreach (string line in File.ReadAllLines(_recent))
                {
                    if (line != fileToOpen)
                    {
                        lines.Add(line);
                        count++;
                    }
                    if (count >= 20)
                        break;
                }
                File.WriteAllLines(_recent, lines.ToArray());
            }
            else
            {
                File.WriteAllText(_recent, fileToOpen);
            }
            SetRecentOpenFileMenues();
        }
        #endregion

        private void tsmiFile_OpenResx_Click(object sender, EventArgs e)
        {
            string file = SelectResxFileDialog();
            if (file.Length > 0)
            {
                OpenTheResourceFile(file);
            }
        }

        private void OpenTheResourceFile(string resxFile)
        {
            MakeRecentMenu(resxFile);
            CurrentResxFile = resxFile;
            this.Text = "ResxMultiLang : " + resxFile;
            tsmiFile_Save.Enabled = true;
            tsmiFile_Export.Enabled = true;
            grpTranslate.Enabled = true;
            reoGrid.Enabled = true;
            btnSave.Enabled = true;

            var enUS = GetKeyValue(resxFile);
            var jaJP = GetKeyValue(resxFile.Replace(".resx", $".{_Locales[Col.ja_JP]}.resx"));
            var zhCN = GetKeyValue(resxFile.Replace(".resx", $".{_Locales[Col.zh_CN]}.resx"));
            var zhTW = GetKeyValue(resxFile.Replace(".resx", $".{_Locales[Col.zh_TW]}.resx"));

            var sht = reoGrid.Worksheets[0];
            sht.ClearRangeContent("A1:Z9999", CellElementFlag.All);
            sht[0, (int)Col.Key] = _Locales[Col.Key];
            sht[0, (int)Col.zh_CN] = _Locales[Col.zh_CN];
            sht[0, (int)Col.ja_JP] = _Locales[Col.ja_JP];
            sht[0, (int)Col.en_US] = _Locales[Col.en_US];
            sht[0, (int)Col.zh_TW] = _Locales[Col.zh_TW];

            sht.SetColumnsWidth(0, 10, 250);
            // https://reogrid.net/jp/document/worksheet/
            sht.SetRangeStyles("A1:E1", new WorksheetRangeStyle
            {
                Flag = PlainStyleFlag.FontStyleBold,
                Bold = true
            });
            sht.FreezeToCell("B2");
            int i = 1;
            foreach (var item in enUS)
            {
                sht[i, (int)Col.Key] = item.Key;
                sht[i, (int)Col.zh_CN] = zhCN[item.Key];
                sht[i, (int)Col.ja_JP] = jaJP[item.Key];
                sht[i, (int)Col.en_US] = item.Value;
                sht[i, (int)Col.zh_TW] = zhTW[item.Key];
                AppendRow(i);
                i++;
            }
        }

        private void AppendRow(int currentRow)
        {
            if (currentRow >= 199)
            {
                reoGrid.Worksheets[0].AppendRows(1);
            }
        }

        Dictionary<string, string> GetKeyValue(string targetResx)
        {
            if (!File.Exists(targetResx)) return null;
            var dic = new Dictionary<string, string>();
            var reader = new ResXResourceReader(targetResx);
            var node = reader.GetEnumerator();

            using (var w = new ResXResourceWriter(targetResx))
            {
                while (node.MoveNext())
                {
                    w.AddResource(node.Key.ToString(), node.Value.ToString());
                    dic.Add(node.Key.ToString(), node.Value.ToString());
                }
                w.Generate();
                w.Close();
            }
            return dic;
        }

        void DeleteItems(string targetResx)
        {
            var reader = new ResXResourceReader(targetResx);
            var writer = new ResXResourceWriter(targetResx);
            writer.Close();
        }

        void AddResxItem(string targetResx, string key, string val)
        {
            var reader = new ResXResourceReader(targetResx);
            //reader.UseResXDataNodes = true;
            var node = reader.GetEnumerator();

            using (var w = new ResXResourceWriter(targetResx))
            {
                while (node.MoveNext())
                {
                    w.AddResource(node.Key.ToString(), node.Value.ToString());
                }
                var newNode = new ResXDataNode(key, val);
                w.AddResource(newNode);
                w.Generate();
                w.Close();
            }
        }

        private string SelectResxFileDialog()
        {
            var ofd = new OpenFileDialog();
            ofd.FileName = "";
            ofd.Filter = "Resource File(*.resx)|*.resx";
            string title = "Select the base resource .resx file.";
            ofd.Title = title;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                return ofd.FileName;
            }
            return "";
        }

        private void tsmiFile_OpenXlsx_Click(object sender, EventArgs e)
        {
            string xls = SelectExcelFile();
            if (xls.Length > 0)
            {
                OpenExcelFile(xls);
            }
        }

        private void OpenExcelFile(string xlsFile)
        {
            reoGrid.Load(xlsFile);
        }

        private void tsmiFile_Save_Click(object sender, EventArgs e)
        {
            SaveToResx();
        }

        private void SaveToResx()
        {
            Cursor = Cursors.WaitCursor;

            var sht = reoGrid.Worksheets[0];
            var zhCN = new Dictionary<string, string>();
            var jaJP = new Dictionary<string, string>();
            var enUS = new Dictionary<string, string>();
            var zhTW = new Dictionary<string, string>();

            for (int i = 1; i < sht.MaxContentRow + 1; i++)
            {
                if (sht[i, (int)Col.Key] == null || sht[i, (int)Col.Key].ToString().Length == 0)
                {
                    break;
                }
                zhCN.Add(sht[i, (int)Col.Key].ToString(), sht[i, (int)Col.zh_CN].ToString());
                jaJP.Add(sht[i, (int)Col.Key].ToString(), sht[i, (int)Col.ja_JP].ToString());
                enUS.Add(sht[i, (int)Col.Key].ToString(), sht[i, (int)Col.en_US].ToString());
                zhTW.Add(sht[i, (int)Col.Key].ToString(), sht[i, (int)Col.zh_TW].ToString());
            }
            DeleteItems(CurrentResxFile);
            DeleteItems(CurrentResxFile.Replace(".resx", $".{_Locales[Col.ja_JP]}.resx"));
            DeleteItems(CurrentResxFile.Replace(".resx", $".{_Locales[Col.zh_CN]}.resx"));
            DeleteItems(CurrentResxFile.Replace(".resx", $".{_Locales[Col.zh_TW]}.resx"));

            WriteResx(CurrentResxFile, enUS);
            WriteResx(CurrentResxFile.Replace(".resx", $".{_Locales[Col.ja_JP]}.resx"), jaJP);
            WriteResx(CurrentResxFile.Replace(".resx", $".{_Locales[Col.zh_CN]}.resx"), zhCN);
            WriteResx(CurrentResxFile.Replace(".resx", $".{_Locales[Col.zh_TW]}.resx"), zhTW);
            Cursor = Cursors.Default;
            MessageBox.Show("Save to .resx successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void WriteResx(string targetResx, Dictionary<string, string> dic)
        {
            foreach (var item in dic)
            {
                AddResxItem(targetResx, item.Key, dic[item.Key]);
            }
        }

        private void tsmiFile_Export_Click(object sender, EventArgs e)
        {
            string xls = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + Path.GetFileNameWithoutExtension(CurrentResxFile) + ".xlsx";
            File.Delete(xls);
            reoGrid.Save(xls);
            MessageBox.Show("Exported to" + Environment.NewLine + xls);
        }

        private void tsmiFile_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private string SelectExcelFile()
        {
            var ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ofd.Filter = "xlsx file(*.xlsx;*.xls)|*.xlsx;*.xls";
            ofd.Title = "Select exported resource Excel file";
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                return ofd.FileName;
            }
            return "";
        }

        private void btnTranslate_Click(object sender, EventArgs e)
        {
            var sht = reoGrid.Worksheets[0];
            int lastRow = sht.MaxContentRow + 1;
            AppendRow(lastRow);

            sht[lastRow, (int)Col.Key] = "key" + (lastRow + 1);
            if (radioFromChinese.Checked)
            {
                string ja = GoogleAPI.Translate(txtToTranslate.Text, "zh", "ja");
                string en = GoogleAPI.Translate(txtToTranslate.Text, "zh", "en");
                string tw = GoogleAPI.Translate(txtToTranslate.Text, "zh", "zh-TW");
                sht[lastRow, (int)Col.zh_CN] = txtToTranslate.Text;
                sht[lastRow, (int)Col.ja_JP] = ja;
                sht[lastRow, (int)Col.en_US] = en;
                sht[lastRow, (int)Col.zh_TW] = tw;
            }
            else if (radioFromJapanese.Checked)
            {
                string zh = GoogleAPI.Translate(txtToTranslate.Text, "ja", "zh");
                string en = GoogleAPI.Translate(txtToTranslate.Text, "ja", "en");
                string tw = GoogleAPI.Translate(txtToTranslate.Text, "ja", "zh-TW");
                sht[lastRow, (int)Col.zh_CN] = zh;
                sht[lastRow, (int)Col.ja_JP] = txtToTranslate.Text;
                sht[lastRow, (int)Col.en_US] = en;
                sht[lastRow, (int)Col.zh_TW] = tw;
            }
            else if (radioFromEnglish.Checked)
            {
                string zh = GoogleAPI.Translate(txtToTranslate.Text, "en", "zh");
                string ja = GoogleAPI.Translate(txtToTranslate.Text, "en", "ja");
                string tw = GoogleAPI.Translate(txtToTranslate.Text, "en", "zh-TW");
                sht[lastRow, (int)Col.zh_CN] = zh;
                sht[lastRow, (int)Col.ja_JP] = ja;
                sht[lastRow, (int)Col.en_US] = txtToTranslate.Text;
                sht[lastRow, (int)Col.zh_TW] = tw;
            }
            sht.SelectionRange = new RangePosition($"A{lastRow + 1}:E{lastRow + 1}");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveToResx();
        }
    }
}
