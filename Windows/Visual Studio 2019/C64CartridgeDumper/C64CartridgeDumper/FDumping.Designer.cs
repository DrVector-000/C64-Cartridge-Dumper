
namespace C64CartridgeDumper
{
    partial class FDumping
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tBCRTName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tBCRTPath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.nUDBanks = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nUDBanks)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome cartuccia";
            // 
            // tBCRTName
            // 
            this.tBCRTName.Location = new System.Drawing.Point(28, 35);
            this.tBCRTName.Name = "tBCRTName";
            this.tBCRTName.Size = new System.Drawing.Size(381, 20);
            this.tBCRTName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Percorso di salvataggio";
            // 
            // tBCRTPath
            // 
            this.tBCRTPath.Location = new System.Drawing.Point(28, 74);
            this.tBCRTPath.Name = "tBCRTPath";
            this.tBCRTPath.Size = new System.Drawing.Size(346, 20);
            this.tBCRTPath.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(380, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 20);
            this.button1.TabIndex = 2;
            this.button1.Text = "..";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.Location = new System.Drawing.Point(344, 161);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "OK";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.Location = new System.Drawing.Point(263, 161);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Annulla";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // nUDBanks
            // 
            this.nUDBanks.Location = new System.Drawing.Point(28, 113);
            this.nUDBanks.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.nUDBanks.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDBanks.Name = "nUDBanks";
            this.nUDBanks.Size = new System.Drawing.Size(70, 20);
            this.nUDBanks.TabIndex = 5;
            this.nUDBanks.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Numero di banchi";
            // 
            // FDumping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 198);
            this.Controls.Add(this.nUDBanks);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tBCRTPath);
            this.Controls.Add(this.tBCRTName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FDumping";
            this.Text = "Dumping ROM";
            ((System.ComponentModel.ISupportInitialize)(this.nUDBanks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBCRTName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBCRTPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.NumericUpDown nUDBanks;
        private System.Windows.Forms.Label label3;
    }
}