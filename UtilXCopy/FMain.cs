using System.Diagnostics;
using System.Text;

namespace UtilXCopy
{
    public partial class FMain : Form
    {
        private Process? _xcopyProcess;

        public FMain()
        {
            InitializeComponent();
        }

        private void btnBrowseSource_Click(object sender, EventArgs e)
        {
            // Use FolderBrowserDialog to select the source directory
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select the source folder";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Controls["txtSource"]!.Text = dialog.SelectedPath;
                }
            }
        }

        private void btnBrowseDestination_Click(object sender, EventArgs e)
        {
            // Use FolderBrowserDialog to select the destination directory
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select the destination folder";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Controls["txtDestination"]!.Text = dialog.SelectedPath;
                }
            }
        }

        // --- Logic to ensure /E is only used with /S ---
        private void chkS_CheckedChanged(object? sender, EventArgs e)
        {
            var chkS = (CheckBox)sender!;
            var chkE = (CheckBox)Controls.Find("chkE", true)[0];
            chkE.Enabled = chkS.Checked;
            if (!chkS.Checked)
            {
                chkE.Checked = false;
            }
        }

        private async void btnCopy_Click(object? sender, EventArgs e)
        {
            // --- Get all controls ---
            var txtSource = (TextBox)Controls.Find("txtSource", true)[0];
            var txtDestination = (TextBox)Controls.Find("txtDestination", true)[0];
            var txtOutput = (TextBox)Controls.Find("txtOutput", true)[0];
            var btnCopy = (Button)Controls.Find("btnCopy", true)[0];
            var btnStop = (Button)Controls.Find("btnStop", true)[0];

            // --- Input Validation ---
            if (string.IsNullOrWhiteSpace(txtSource.Text) || string.IsNullOrWhiteSpace(txtDestination.Text))
            {
                MessageBox.Show("Please select both source and destination folders.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // --- UI State Management ---
            btnCopy.Enabled = false;
            btnStop.Enabled = true;
            txtOutput.Clear();
            txtOutput.AppendText("Starting copy process...\r\n");

            // --- Build xcopy arguments ---
            var argsBuilder = new StringBuilder();

            // --- CRITICAL FIX: Ensure source path targets the FOLDER'S CONTENTS ---
            // Append a backslash to the source path to ensure we copy its content.
            // xcopy treats "C:\Folder" and "C:\Folder\" differently.
            string sourcePath = txtSource.Text;
            if (!sourcePath.EndsWith("\\"))
            {
                sourcePath += "\\";
            }

            // Add source and destination paths with quotes
            argsBuilder.Append($"\"{sourcePath}\" \"{txtDestination.Text}\" ");

            // Use Controls.Find to be safe, even inside a groupbox
            if (((CheckBox)Controls.Find("chkS", true)[0])!.Checked) argsBuilder.Append("/S ");
            if (((CheckBox)Controls.Find("chkE", true)[0])!.Checked) argsBuilder.Append("/E ");
            if (((CheckBox)Controls.Find("chkY", true)[0])!.Checked) argsBuilder.Append("/Y ");
            if (((CheckBox)Controls.Find("chkH", true)[0])!.Checked) argsBuilder.Append("/H ");
            if (((CheckBox)Controls.Find("chkI", true)[0])!.Checked) argsBuilder.Append("/I "); // This one is also important!
            if (((CheckBox)Controls.Find("chkR", true)[0])!.Checked) argsBuilder.Append("/R ");
            if (((CheckBox)Controls.Find("chkK", true)[0])!.Checked) argsBuilder.Append("/K ");
            if (((CheckBox)Controls.Find("chkC", true)[0])!.Checked) argsBuilder.Append("/C ");
            if (((CheckBox)Controls.Find("chkF", true)[0])!.Checked) argsBuilder.Append("/F ");
            if (((CheckBox)Controls.Find("chkJ", true)[0])!.Checked) argsBuilder.Append("/J ");

            // Handle the date parameter
            var chkDate = (CheckBox)Controls.Find("chkDate", true)[0];
            if (chkDate.Checked)
            {
                var dtpDate = (DateTimePicker)Controls.Find("dtpDate", true)[0];
                argsBuilder.Append($"/D:{dtpDate.Value:MM-dd-yyyy} ");

            }

            // You can uncomment this line for debugging to see the final command
            // MessageBox.Show($"Executing: xcopy.exe {argsBuilder.ToString()}", "Final Command");

            // --- Run the process ---
            try
            {
                _xcopyProcess = new Process();
                _xcopyProcess.StartInfo.FileName = "xcopy.exe";
                _xcopyProcess.StartInfo.Arguments = argsBuilder.ToString();
                _xcopyProcess.StartInfo.UseShellExecute = false;
                _xcopyProcess.StartInfo.RedirectStandardOutput = true;
                _xcopyProcess.StartInfo.RedirectStandardError = true;
                _xcopyProcess.StartInfo.CreateNoWindow = true;
                _xcopyProcess.EnableRaisingEvents = true;

                _xcopyProcess.OutputDataReceived += (s, ev) => { if (ev.Data != null) { this.Invoke(() => txtOutput.AppendText(ev.Data + "\r\n")); } };
                _xcopyProcess.ErrorDataReceived += (s, ev) => { if (ev.Data != null) { this.Invoke(() => txtOutput.AppendText("ERROR: " + ev.Data + "\r\n")); } };

                _xcopyProcess.Start();
                _xcopyProcess.BeginOutputReadLine();
                _xcopyProcess.BeginErrorReadLine();

                await _xcopyProcess.WaitForExitAsync();
                txtOutput.AppendText("\r\nCopy process finished.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // --- Reset UI State ---
                btnCopy.Enabled = true;
                btnStop.Enabled = false;
                _xcopyProcess?.Dispose();
                _xcopyProcess = null;
            }
        }
        private void btnStop_Click(object? sender, EventArgs e)
        {
            if (_xcopyProcess != null && !_xcopyProcess.HasExited)
            {
                try
                {
                    _xcopyProcess.Kill();
                    ((TextBox)Controls.Find("txtOutput", true)[0])?.AppendText("\r\n--- PROCESS STOPPED BY USER ---");

                    btnCopy.Enabled = true;
                    btnStop.Enabled = false;
                    _xcopyProcess?.Dispose();
                    _xcopyProcess = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Could not stop the process: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            var chkDate = (CheckBox)Controls.Find("chkDate", true)[0];
            if (!chkDate.Checked)
            {
                dtpDate.Enabled = false;
            }
            else
            {
                dtpDate.Enabled = true;
            }
        }
    }
}