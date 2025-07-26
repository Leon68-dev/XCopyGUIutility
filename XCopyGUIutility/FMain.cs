using System.Diagnostics;
using System.Text;

namespace XCopyGUIutility
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
                    txtSource.Text = dialog.SelectedPath;
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
                    txtDestination.Text = dialog.SelectedPath;
                }
            }
        }

        // --- Logic to ensure /E is only used with /S ---
        private void chkS_CheckedChanged(object? sender, EventArgs e)
        {
            var chkS = (CheckBox)sender!;
            chkE.Enabled = chkS.Checked;
            if (!chkS.Checked)
            {
                chkE.Checked = false;
            }
        }

        private async void btnCopy_Click(object? sender, EventArgs e)
        {
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

            string sourcePath = txtSource.Text;
            if (!sourcePath.EndsWith("\\"))
            {
                sourcePath += "\\";
            }

            // Add source and destination paths with quotes
            argsBuilder.Append($"\"{sourcePath}\" \"{txtDestination.Text}\" ");
            
            if (chkS.Checked) 
                argsBuilder.Append("/S ");

            if (chkE.Checked) 
                argsBuilder.Append("/E ");
            
            if (chkY.Checked) 
                argsBuilder.Append("/Y ");
            
            if (chkH.Checked) 
                argsBuilder.Append("/H ");
            
            if (chkI.Checked) 
                argsBuilder.Append("/I "); // This one is also important!
            
            if (chkR.Checked) 
                argsBuilder.Append("/R ");
            
            if (chkK.Checked) 
                argsBuilder.Append("/K ");
            
            if (chkC.Checked) 
                argsBuilder.Append("/C ");
            
            if (chkF.Checked) 
                argsBuilder.Append("/F ");
            
            if (chkJ.Checked) 
                argsBuilder.Append("/J ");

            
            if (chkDate.Checked)
                //argsBuilder.Append($"/D:{dtpDate.Value:MM-dd-yyyy} ");
                argsBuilder.Append($"/D ");


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

                _xcopyProcess.OutputDataReceived += (s, ev) => 
                { 
                    if (ev.Data != null) 
                        this.Invoke(() => txtOutput.AppendText(ev.Data + "\r\n")); 
                };
                
                _xcopyProcess.ErrorDataReceived += (s, ev) => 
                { 
                    if (ev.Data != null) 
                        this.Invoke(() => txtOutput.AppendText("ERROR: " + ev.Data + "\r\n")); 
                };

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
                resetUIstate();
            }
        }
        private void btnStop_Click(object? sender, EventArgs e)
        {
            if (_xcopyProcess != null && !_xcopyProcess.HasExited)
            {
                try
                {
                    _xcopyProcess.Kill();
                    txtOutput.AppendText("\r\n--- PROCESS STOPPED BY USER ---");

                    resetUIstate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Could not stop the process: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void resetUIstate() 
        {
            btnCopy.Enabled = true;
            btnStop.Enabled = false;
            _xcopyProcess?.Dispose();
            _xcopyProcess = null;
        }

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkDate.Checked)
                dtpDate.Enabled = false;
            else
                dtpDate.Enabled = true;
        }
    }
}