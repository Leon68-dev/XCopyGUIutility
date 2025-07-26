namespace XCopyGUIutility
{
    partial class FMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMain));
            label1 = new Label();
            txtSource = new TextBox();
            txtDestination = new TextBox();
            label2 = new Label();
            btnBrowseSource = new Button();
            btnBrowseDestination = new Button();
            btnCopy = new Button();
            txtOutput = new TextBox();
            btnStop = new Button();
            groupBox2 = new GroupBox();
            chkI = new CheckBox();
            chkH = new CheckBox();
            chkDate = new CheckBox();
            chkY = new CheckBox();
            chkE = new CheckBox();
            chkS = new CheckBox();
            groupBox3 = new GroupBox();
            dtpDate = new DateTimePicker();
            chkJ = new CheckBox();
            chkF = new CheckBox();
            chkC = new CheckBox();
            chkK = new CheckBox();
            chkR = new CheckBox();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 12);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 0;
            label1.Text = "Source";
            // 
            // txtSource
            // 
            txtSource.Location = new Point(96, 9);
            txtSource.Name = "txtSource";
            txtSource.Size = new Size(576, 27);
            txtSource.TabIndex = 1;
            // 
            // txtDestination
            // 
            txtDestination.Location = new Point(96, 42);
            txtDestination.Name = "txtDestination";
            txtDestination.Size = new Size(577, 27);
            txtDestination.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 45);
            label2.Name = "label2";
            label2.Size = new Size(85, 20);
            label2.TabIndex = 2;
            label2.Text = "Destination";
            // 
            // btnBrowseSource
            // 
            btnBrowseSource.Location = new Point(678, 8);
            btnBrowseSource.Name = "btnBrowseSource";
            btnBrowseSource.Size = new Size(97, 29);
            btnBrowseSource.TabIndex = 4;
            btnBrowseSource.Text = "Browse";
            btnBrowseSource.UseVisualStyleBackColor = true;
            btnBrowseSource.Click += btnBrowseSource_Click;
            // 
            // btnBrowseDestination
            // 
            btnBrowseDestination.Location = new Point(678, 41);
            btnBrowseDestination.Name = "btnBrowseDestination";
            btnBrowseDestination.Size = new Size(97, 29);
            btnBrowseDestination.TabIndex = 5;
            btnBrowseDestination.Text = "Browse";
            btnBrowseDestination.UseVisualStyleBackColor = true;
            btnBrowseDestination.Click += btnBrowseDestination_Click;
            // 
            // btnCopy
            // 
            btnCopy.BackColor = SystemColors.ActiveCaption;
            btnCopy.Location = new Point(581, 255);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(94, 29);
            btnCopy.TabIndex = 7;
            btnCopy.Text = "Start Copy";
            btnCopy.UseVisualStyleBackColor = false;
            btnCopy.Click += btnCopy_Click;
            // 
            // txtOutput
            // 
            txtOutput.BackColor = SystemColors.ActiveCaption;
            txtOutput.ForeColor = SystemColors.WindowText;
            txtOutput.Location = new Point(6, 286);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.Size = new Size(769, 260);
            txtOutput.TabIndex = 8;
            // 
            // btnStop
            // 
            btnStop.BackColor = SystemColors.ActiveCaption;
            btnStop.Enabled = false;
            btnStop.Location = new Point(681, 255);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(94, 29);
            btnStop.TabIndex = 9;
            btnStop.Text = "Stop Copy";
            btnStop.UseVisualStyleBackColor = false;
            btnStop.Click += btnStop_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(chkI);
            groupBox2.Controls.Add(chkH);
            groupBox2.Controls.Add(chkDate);
            groupBox2.Controls.Add(chkY);
            groupBox2.Controls.Add(chkE);
            groupBox2.Controls.Add(chkS);
            groupBox2.Location = new Point(8, 75);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(401, 205);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "Main Options";
            // 
            // chkI
            // 
            chkI.AutoSize = true;
            chkI.Checked = true;
            chkI.CheckState = CheckState.Checked;
            chkI.Location = new Point(13, 144);
            chkI.Name = "chkI";
            chkI.Size = new Size(254, 24);
            chkI.TabIndex = 4;
            chkI.Text = "Assume destination is a folder (/i)";
            chkI.UseVisualStyleBackColor = true;
            // 
            // chkH
            // 
            chkH.AutoSize = true;
            chkH.Checked = true;
            chkH.CheckState = CheckState.Checked;
            chkH.Location = new Point(12, 115);
            chkH.Name = "chkH";
            chkH.Size = new Size(252, 24);
            chkH.TabIndex = 3;
            chkH.Text = "Copy hidden and system files (/h)";
            chkH.UseVisualStyleBackColor = true;
            // 
            // chkDate
            // 
            chkDate.AutoSize = true;
            chkDate.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            chkDate.Location = new Point(13, 174);
            chkDate.Name = "chkDate";
            chkDate.Size = new Size(194, 24);
            chkDate.TabIndex = 0;
            chkDate.Text = "Copy only newer files (/d)";
            chkDate.UseVisualStyleBackColor = true;
            chkDate.CheckedChanged += chkDate_CheckedChanged;
            // 
            // chkY
            // 
            chkY.AutoSize = true;
            chkY.Checked = true;
            chkY.CheckState = CheckState.Checked;
            chkY.Enabled = false;
            chkY.Location = new Point(12, 87);
            chkY.Name = "chkY";
            chkY.Size = new Size(255, 24);
            chkY.TabIndex = 2;
            chkY.Text = "Suppress prompt to overwrite (/y)";
            chkY.UseVisualStyleBackColor = true;
            // 
            // chkE
            // 
            chkE.AutoSize = true;
            chkE.Checked = true;
            chkE.CheckState = CheckState.Checked;
            chkE.Location = new Point(12, 57);
            chkE.Name = "chkE";
            chkE.Size = new Size(365, 24);
            chkE.TabIndex = 1;
            chkE.Text = "Copy empty subdirectories (will depend on /s) (/e)";
            chkE.UseVisualStyleBackColor = true;
            // 
            // chkS
            // 
            chkS.AutoSize = true;
            chkS.Checked = true;
            chkS.CheckState = CheckState.Checked;
            chkS.Location = new Point(12, 28);
            chkS.Name = "chkS";
            chkS.Size = new Size(188, 24);
            chkS.TabIndex = 0;
            chkS.Text = "Copy subdirectories (/s)";
            chkS.UseVisualStyleBackColor = true;
            chkS.CheckedChanged += chkS_CheckedChanged;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dtpDate);
            groupBox3.Controls.Add(chkJ);
            groupBox3.Controls.Add(chkF);
            groupBox3.Controls.Add(chkC);
            groupBox3.Controls.Add(chkK);
            groupBox3.Controls.Add(chkR);
            groupBox3.Location = new Point(415, 75);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(360, 174);
            groupBox3.TabIndex = 11;
            groupBox3.TabStop = false;
            groupBox3.Text = "Additional Options";
            // 
            // dtpDate
            // 
            dtpDate.Enabled = false;
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(499, 28);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(115, 27);
            dtpDate.TabIndex = 1;
            dtpDate.Visible = false;
            // 
            // chkJ
            // 
            chkJ.AutoSize = true;
            chkJ.Location = new Point(12, 147);
            chkJ.Name = "chkJ";
            chkJ.Size = new Size(310, 24);
            chkJ.TabIndex = 4;
            chkJ.Text = "Copy without buffering (for large files) (/j)";
            chkJ.UseVisualStyleBackColor = true;
            // 
            // chkF
            // 
            chkF.AutoSize = true;
            chkF.Location = new Point(12, 117);
            chkF.Name = "chkF";
            chkF.Size = new Size(221, 24);
            chkF.TabIndex = 3;
            chkF.Text = "Show full paths in output (/f)";
            chkF.UseVisualStyleBackColor = true;
            // 
            // chkC
            // 
            chkC.AutoSize = true;
            chkC.Checked = true;
            chkC.CheckState = CheckState.Checked;
            chkC.Location = new Point(12, 87);
            chkC.Name = "chkC";
            chkC.Size = new Size(180, 24);
            chkC.TabIndex = 2;
            chkC.Text = "Continue on errors (/c)";
            chkC.UseVisualStyleBackColor = true;
            // 
            // chkK
            // 
            chkK.AutoSize = true;
            chkK.Checked = true;
            chkK.CheckState = CheckState.Checked;
            chkK.Location = new Point(12, 57);
            chkK.Name = "chkK";
            chkK.Size = new Size(184, 24);
            chkK.TabIndex = 1;
            chkK.Text = "Copy file attributes (/k)";
            chkK.UseVisualStyleBackColor = true;
            // 
            // chkR
            // 
            chkR.AutoSize = true;
            chkR.Checked = true;
            chkR.CheckState = CheckState.Checked;
            chkR.Location = new Point(12, 28);
            chkR.Name = "chkR";
            chkR.Size = new Size(219, 24);
            chkR.TabIndex = 0;
            chkR.Text = "Overwrite read-only files (/r)";
            chkR.UseVisualStyleBackColor = true;
            // 
            // FMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 553);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(btnStop);
            Controls.Add(txtOutput);
            Controls.Add(btnBrowseDestination);
            Controls.Add(btnCopy);
            Controls.Add(btnBrowseSource);
            Controls.Add(txtDestination);
            Controls.Add(label2);
            Controls.Add(txtSource);
            Controls.Add(label1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FMain";
            Opacity = 0.8D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "XCopy GUI Utility";
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtSource;
        private TextBox txtDestination;
        private Label label2;
        private Button btnBrowseSource;
        private Button btnBrowseDestination;
        private Button btnCopy;
        private TextBox txtOutput;
        private Button btnStop;
        private GroupBox groupBox2;
        private CheckBox chkS;
        private CheckBox chkI;
        private CheckBox chkH;
        private CheckBox chkY;
        private CheckBox chkE;
        private GroupBox groupBox3;
        private CheckBox chkJ;
        private CheckBox chkF;
        private CheckBox chkC;
        private CheckBox chkK;
        private CheckBox chkR;
        private GroupBox groupBox4;
        private DateTimePicker dtpDate;
        private CheckBox chkDate;
    }
}
