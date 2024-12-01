
namespace C64CartridgeDumper
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.bDisconnetti = new System.Windows.Forms.Button();
            this.bConnetti = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cBSerialPorts = new System.Windows.Forms.ComboBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tBInfo = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.bDump = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.bGetInfo = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bDisconnetti
            // 
            this.bDisconnetti.Enabled = false;
            this.bDisconnetti.Location = new System.Drawing.Point(433, 63);
            this.bDisconnetti.Name = "bDisconnetti";
            this.bDisconnetti.Size = new System.Drawing.Size(91, 23);
            this.bDisconnetti.TabIndex = 9;
            this.bDisconnetti.Text = "Disconnetti";
            this.bDisconnetti.UseVisualStyleBackColor = true;
            this.bDisconnetti.Click += new System.EventHandler(this.bDisconnetti_Click);
            // 
            // bConnetti
            // 
            this.bConnetti.Enabled = false;
            this.bConnetti.Location = new System.Drawing.Point(333, 63);
            this.bConnetti.Name = "bConnetti";
            this.bConnetti.Size = new System.Drawing.Size(91, 23);
            this.bConnetti.TabIndex = 10;
            this.bConnetti.Text = "Connetti";
            this.bConnetti.UseVisualStyleBackColor = true;
            this.bConnetti.Click += new System.EventHandler(this.bConnetti_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(330, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Porta seriale";
            // 
            // cBSerialPorts
            // 
            this.cBSerialPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBSerialPorts.FormattingEnabled = true;
            this.cBSerialPorts.Location = new System.Drawing.Point(333, 36);
            this.cBSerialPorts.Name = "cBSerialPorts";
            this.cBSerialPorts.Size = new System.Drawing.Size(191, 21);
            this.cBSerialPorts.TabIndex = 7;
            this.cBSerialPorts.SelectedIndexChanged += new System.EventHandler(this.cBSerialPorts_SelectedIndexChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 323);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(539, 16);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 13;
            // 
            // tBInfo
            // 
            this.tBInfo.BackColor = System.Drawing.SystemColors.Info;
            this.tBInfo.Location = new System.Drawing.Point(12, 12);
            this.tBInfo.Multiline = true;
            this.tBInfo.Name = "tBInfo";
            this.tBInfo.ReadOnly = true;
            this.tBInfo.Size = new System.Drawing.Size(280, 302);
            this.tBInfo.TabIndex = 12;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 342);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(563, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(142, 17);
            this.toolStripStatusLabel1.Text = "Dispositivo non connesso";
            // 
            // bDump
            // 
            this.bDump.Enabled = false;
            this.bDump.Location = new System.Drawing.Point(433, 274);
            this.bDump.Name = "bDump";
            this.bDump.Size = new System.Drawing.Size(91, 23);
            this.bDump.TabIndex = 14;
            this.bDump.Text = "Salva ROM";
            this.bDump.UseVisualStyleBackColor = true;
            this.bDump.Click += new System.EventHandler(this.bDump_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "File gb|*.gb|Tutti i file|*.*";
            this.saveFileDialog1.Title = "Salva ROM";
            // 
            // bGetInfo
            // 
            this.bGetInfo.Enabled = false;
            this.bGetInfo.Location = new System.Drawing.Point(433, 169);
            this.bGetInfo.Name = "bGetInfo";
            this.bGetInfo.Size = new System.Drawing.Size(91, 23);
            this.bGetInfo.TabIndex = 15;
            this.bGetInfo.Text = "Get Info";
            this.bGetInfo.UseVisualStyleBackColor = true;
            this.bGetInfo.Click += new System.EventHandler(this.bGetInfo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 364);
            this.Controls.Add(this.bGetInfo);
            this.Controls.Add(this.bDump);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.tBInfo);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.bDisconnetti);
            this.Controls.Add(this.bConnetti);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cBSerialPorts);
            this.Name = "Form1";
            this.Text = "Form1";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bDisconnetti;
        private System.Windows.Forms.Button bConnetti;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cBSerialPorts;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox tBInfo;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button bDump;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button bGetInfo;
    }
}

