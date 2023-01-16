using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geocoding_App
{
    public partial class GeoSpotter_Photo : Form
    {
        public GeoSpotter_Photo()
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.ShowIcon = false;
            InitializeComponent();
        }

        private void GeoSpotter_Photo_Load(object sender, EventArgs e)
        {
            InitializarBackgroundWorker();

            foreach (var i in Config.languages)
            {
                comboBoxLanguage.Items.Add(i);
            }
            comboBoxLanguage.SelectedIndex = 0;
            comboBoxLanguage.DropDownStyle = ComboBoxStyle.DropDownList;

            richTextBoxLogs.ReadOnly = true;

            buttonCancel.Enabled = false;

            Config.languageSelected = 0;

            RefreshLanguage();
        }

        private void InitializarBackgroundWorker()
        {
            backgroundWorkerThread.WorkerReportsProgress = true;
            backgroundWorkerThread.WorkerSupportsCancellation = true;
            backgroundWorkerThread.DoWork += new DoWorkEventHandler(backgroundWorkerThread_DoWork);
            backgroundWorkerThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorkerThread_RunWorkerCompleted);
            backgroundWorkerThread.ProgressChanged += new ProgressChangedEventHandler(backgroundWorkerThread_ProgressChanged);
        }

        private void buttonStart_ClickAsync(object sender, EventArgs e)
        {
            Config.pathFrom = folderBrowserLabelOrigen.Text;
            Config.pathTo = folderBrowserLabelDestino.Text;

            if (Config.pathFrom != null && Config.pathTo != null && Config.pathFrom != Config.pathTo)
            {
                if (!Config.country && !Config.state && !Config.city)
                {
                    MessageBox.Show(Config.languagesPhrases[13, Config.languageSelected],
                    Config.languagesPhrases[6, Config.languageSelected], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    if (Directory.Exists(Config.pathFrom))
                    {

                        Config.lista = Functions.LoadImages();

                        if (Config.lista.Length == 0)
                        {
                            MessageBox.Show(Config.languagesPhrases[12, Config.languageSelected],
                            Config.languagesPhrases[6, Config.languageSelected], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            if (Directory.Exists(Config.pathFrom))
                            {

                                var resultBox = MessageBox.Show(Config.languagesPhrases[10, Config.languageSelected] + Config.lista.Length,
                                    Config.languagesPhrases[11, Config.languageSelected], MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                if (resultBox == DialogResult.OK)
                                {
                                    progressBar.Maximum = Config.lista.Length;
                                    progressBar.Value = 0;
                                    richTextBoxLogs.Text = "";

                                    if (!backgroundWorkerThread.IsBusy)
                                        backgroundWorkerThread.RunWorkerAsync();

                                    changeStatusEnabledButtons(false);
                                }
                            }
                            else
                            {
                                MessageBox.Show(Config.languagesPhrases[21, Config.languageSelected],
                                Config.languagesPhrases[6, Config.languageSelected], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                Config.pathTo = null;
                                folderBrowserLabelDestino.Text = "";
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(Config.languagesPhrases[20, Config.languageSelected],
                        Config.languagesPhrases[6, Config.languageSelected], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Config.pathFrom = null;
                        folderBrowserLabelOrigen.Text = "";
                    }
                }
            }
            else
            {
                MessageBox.Show(Config.languagesPhrases[5, Config.languageSelected], 
                    Config.languagesPhrases[6, Config.languageSelected], MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonFolderBrowserOrigen_Click(object sender, EventArgs e)
        {
            if (!backgroundWorkerThread.IsBusy)
            {
                folderBrowser.Description = Config.languagesPhrases[7, Config.languageSelected];
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    folderBrowserLabelOrigen.Text = folderBrowser.SelectedPath;
                }
            }
        }

        private void buttonFolderBrowserDestino_Click(object sender, EventArgs e)
        {
            if (!backgroundWorkerThread.IsBusy)
            {
                folderBrowser.Description = Config.languagesPhrases[8, Config.languageSelected];
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    folderBrowserLabelDestino.Text = folderBrowser.SelectedPath;
                }
            }
        }

        private void comboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!backgroundWorkerThread.IsBusy)
            {
                Config.languageSelected = comboBoxLanguage.SelectedIndex;

                RefreshLanguage();
            }
        }

        private void RefreshLanguage()
        {
            buttonFolderBrowserFrom.Text = Config.languagesPhrases[0,Config.languageSelected];
            buttonFolderBrowserTo.Text = Config.languagesPhrases[1,Config.languageSelected];
            checkBoxCountry.Text = Config.languagesPhrases[2,Config.languageSelected];
            checkBoxState.Text = Config.languagesPhrases[3,Config.languageSelected];
            checkBoxCity.Text = Config.languagesPhrases[4,Config.languageSelected];
            buttonStart.Text = Config.languagesPhrases[9,Config.languageSelected];
            buttonCancel.Text = Config.languagesPhrases[23,Config.languageSelected];
        }

        private void checkBoxCountry_CheckedChanged(object sender, EventArgs e)
        {
            if (!backgroundWorkerThread.IsBusy)
                Config.country = checkBoxCountry.Checked;
        }

        private void checkBoxState_CheckedChanged(object sender, EventArgs e)
        {
            if (!backgroundWorkerThread.IsBusy)
                Config.state = checkBoxState.Checked;
        }

        private void checkBoxCity_CheckedChanged(object sender, EventArgs e)
        {
            if (!backgroundWorkerThread.IsBusy)
                Config.city = checkBoxCity.Checked;
        }

        #region BackgroundWorkerThread

        private void backgroundWorkerThread_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            e.Cancel = Functions.StartProcess(Config.lista, worker);
        }

        private void backgroundWorkerThread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage != 0)
            {
                progressBar.Value += e.ProgressPercentage;

                var textToAppend = (e.UserState as string).Split('|');

                if (textToAppend[0].Equals(Config.languagesPhrases[14, Config.languageSelected]))
                {
                    appendText(Config.languagesPhrases[14, Config.languageSelected], Color.Red);
                }
                else if (textToAppend[0].Equals(Config.languagesPhrases[15, Config.languageSelected]))
                {
                    appendText(Config.languagesPhrases[15, Config.languageSelected], Color.Green);
                }

                richTextBoxLogs.AppendText(textToAppend[1]);
            }
            else
                richTextBoxLogs.AppendText(e.UserState as string);

            richTextBoxLogs.SelectionStart = richTextBoxLogs.Text.Length;
            richTextBoxLogs.ScrollToCaret();
        }

        private void appendText(string text, Color color)
        {
            richTextBoxLogs.SelectionStart = richTextBoxLogs.TextLength;
            richTextBoxLogs.SelectionLength = 0;

            richTextBoxLogs.SelectionColor = color;
            richTextBoxLogs.AppendText(text);
            richTextBoxLogs.SelectionColor = richTextBoxLogs.ForeColor;
        }

        private void backgroundWorkerThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (e.Cancelled == true)
            {
                MessageBox.Show(Config.languagesPhrases[25, Config.languageSelected], 
                    Config.languagesPhrases[24, Config.languageSelected], MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (e.Error != null)
            {
                var error = Config.languagesPhrases[25, Config.languageSelected];
                MessageBox.Show(error + ": " + e.Error.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(Config.languagesPhrases[18, Config.languageSelected],
                Config.languagesPhrases[19, Config.languageSelected], MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            changeStatusEnabledButtons(true);
        }
        #endregion

        private void changeStatusEnabledButtons(bool status)
        {
            buttonStart.Enabled = status;
            buttonCancel.Enabled = !status;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (backgroundWorkerThread.WorkerSupportsCancellation && backgroundWorkerThread.IsBusy)
            {
                backgroundWorkerThread.CancelAsync();
                changeStatusEnabledButtons(true);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if(backgroundWorkerThread.IsBusy)
            {
                backgroundWorkerThread.CancelAsync();
                this.Enabled = false;
                return;
            }
            else
            {
                base.OnFormClosing(e);
            }
        }
    }
}
