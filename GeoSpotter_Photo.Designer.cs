
namespace Geocoding_App
{
    partial class GeoSpotter_Photo
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeoSpotter_Photo));
            this.checkBoxCountry = new System.Windows.Forms.CheckBox();
            this.checkBoxState = new System.Windows.Forms.CheckBox();
            this.checkBoxCity = new System.Windows.Forms.CheckBox();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonFolderBrowserTo = new System.Windows.Forms.Button();
            this.buttonFolderBrowserFrom = new System.Windows.Forms.Button();
            this.folderBrowserLabelOrigen = new System.Windows.Forms.TextBox();
            this.folderBrowserLabelDestino = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.richTextBoxLogs = new System.Windows.Forms.RichTextBox();
            this.backgroundWorkerThread = new System.ComponentModel.BackgroundWorker();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBoxCountry
            // 
            this.checkBoxCountry.AutoSize = true;
            this.checkBoxCountry.Location = new System.Drawing.Point(366, 66);
            this.checkBoxCountry.Name = "checkBoxCountry";
            this.checkBoxCountry.Size = new System.Drawing.Size(62, 17);
            this.checkBoxCountry.TabIndex = 1;
            this.checkBoxCountry.Text = "Country";
            this.checkBoxCountry.UseVisualStyleBackColor = true;
            this.checkBoxCountry.CheckedChanged += new System.EventHandler(this.checkBoxCountry_CheckedChanged);
            // 
            // checkBoxState
            // 
            this.checkBoxState.AutoSize = true;
            this.checkBoxState.Location = new System.Drawing.Point(366, 89);
            this.checkBoxState.Name = "checkBoxState";
            this.checkBoxState.Size = new System.Drawing.Size(51, 17);
            this.checkBoxState.TabIndex = 2;
            this.checkBoxState.Text = "State";
            this.checkBoxState.UseVisualStyleBackColor = true;
            this.checkBoxState.CheckedChanged += new System.EventHandler(this.checkBoxState_CheckedChanged);
            // 
            // checkBoxCity
            // 
            this.checkBoxCity.AutoSize = true;
            this.checkBoxCity.Location = new System.Drawing.Point(366, 112);
            this.checkBoxCity.Name = "checkBoxCity";
            this.checkBoxCity.Size = new System.Drawing.Size(43, 17);
            this.checkBoxCity.TabIndex = 3;
            this.checkBoxCity.Text = "City";
            this.checkBoxCity.UseVisualStyleBackColor = true;
            this.checkBoxCity.CheckedChanged += new System.EventHandler(this.checkBoxCity_CheckedChanged);
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Location = new System.Drawing.Point(337, 29);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(121, 21);
            this.comboBoxLanguage.TabIndex = 4;
            this.comboBoxLanguage.SelectedIndexChanged += new System.EventHandler(this.comboBoxLanguage_SelectedIndexChanged);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(30, 264);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(441, 15);
            this.progressBar.TabIndex = 5;
            // 
            // buttonFolderBrowserTo
            // 
            this.buttonFolderBrowserTo.Location = new System.Drawing.Point(30, 97);
            this.buttonFolderBrowserTo.Name = "buttonFolderBrowserTo";
            this.buttonFolderBrowserTo.Size = new System.Drawing.Size(77, 23);
            this.buttonFolderBrowserTo.TabIndex = 8;
            this.buttonFolderBrowserTo.Text = "Destination";
            this.buttonFolderBrowserTo.UseVisualStyleBackColor = true;
            this.buttonFolderBrowserTo.Click += new System.EventHandler(this.buttonFolderBrowserDestino_Click);
            // 
            // buttonFolderBrowserFrom
            // 
            this.buttonFolderBrowserFrom.Location = new System.Drawing.Point(30, 28);
            this.buttonFolderBrowserFrom.Name = "buttonFolderBrowserFrom";
            this.buttonFolderBrowserFrom.Size = new System.Drawing.Size(77, 23);
            this.buttonFolderBrowserFrom.TabIndex = 10;
            this.buttonFolderBrowserFrom.Text = "Source";
            this.buttonFolderBrowserFrom.UseVisualStyleBackColor = true;
            this.buttonFolderBrowserFrom.Click += new System.EventHandler(this.buttonFolderBrowserOrigen_Click);
            // 
            // folderBrowserLabelOrigen
            // 
            this.folderBrowserLabelOrigen.Location = new System.Drawing.Point(113, 30);
            this.folderBrowserLabelOrigen.Name = "folderBrowserLabelOrigen";
            this.folderBrowserLabelOrigen.Size = new System.Drawing.Size(200, 20);
            this.folderBrowserLabelOrigen.TabIndex = 11;
            // 
            // folderBrowserLabelDestino
            // 
            this.folderBrowserLabelDestino.Location = new System.Drawing.Point(113, 99);
            this.folderBrowserLabelDestino.Name = "folderBrowserLabelDestino";
            this.folderBrowserLabelDestino.Size = new System.Drawing.Size(200, 20);
            this.folderBrowserLabelDestino.TabIndex = 12;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(150, 156);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 14;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_ClickAsync);
            // 
            // richTextBoxLogs
            // 
            this.richTextBoxLogs.Location = new System.Drawing.Point(30, 185);
            this.richTextBoxLogs.Name = "richTextBoxLogs";
            this.richTextBoxLogs.Size = new System.Drawing.Size(441, 73);
            this.richTextBoxLogs.TabIndex = 15;
            this.richTextBoxLogs.Text = "";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(273, 156);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 17;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // GeoSpotter_Photo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 288);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.richTextBoxLogs);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.folderBrowserLabelDestino);
            this.Controls.Add(this.folderBrowserLabelOrigen);
            this.Controls.Add(this.buttonFolderBrowserFrom);
            this.Controls.Add(this.buttonFolderBrowserTo);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.comboBoxLanguage);
            this.Controls.Add(this.checkBoxCity);
            this.Controls.Add(this.checkBoxState);
            this.Controls.Add(this.checkBoxCountry);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GeoSpotter_Photo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GeoSpotter Photo";
            this.Load += new System.EventHandler(this.GeoSpotter_Photo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox checkBoxCountry;
        private System.Windows.Forms.CheckBox checkBoxState;
        private System.Windows.Forms.CheckBox checkBoxCity;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.Button buttonFolderBrowserTo;
        private System.Windows.Forms.Button buttonFolderBrowserFrom;
        private System.Windows.Forms.TextBox folderBrowserLabelOrigen;
        private System.Windows.Forms.TextBox folderBrowserLabelDestino;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.RichTextBox richTextBoxLogs;
        private System.ComponentModel.BackgroundWorker backgroundWorkerThread;
        private System.Windows.Forms.Button buttonCancel;
    }
}

