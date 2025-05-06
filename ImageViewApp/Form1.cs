using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ImageViewApp
{
    public partial class MainForm : Form
    {
        private string imageFolderPath;
        private string deliveryLocationYes;
        private string deliveryLocationNo;
        private string[] imageFiles;
        private int currentImageIndex;
        private string savedFilePath; // Added field to store the saved file path
        private bool keyInputEnabled = false;

        private void EnableKeyInput()
        {
            keyInputEnabled = true;
            btnYes.Text = "Yes (NumPad 1)";
            btnNo.Text = "No (NumPad 2)";
        }

        private void DisableKeyInput()
        {
            keyInputEnabled = false;
            btnYes.Text = "Yes";
            btnNo.Text = "No";
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyInputEnabled)
            {
                switch (keyData)
                {
                    case Keys.NumPad1:
                        btnYes.PerformClick();
                        return true;
                    case Keys.NumPad2:
                        btnNo.PerformClick();
                        return true;
                    default:
                        return base.ProcessCmdKey(ref msg, keyData);
                }
            }
            else
            {
                // Key input is disabled, handle other keys as needed
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void btnToggleKeyInput_Click(object sender, EventArgs e)
        {
            // Toggle key input
            if (keyInputEnabled)
            {
                DisableKeyInput();
            }
            else
            {
                EnableKeyInput();
            }
        }

        public MainForm()
        {
            InitializeComponent();
            btnPickFolder.Enabled = false;
            btnYes.Enabled = false;
            btnNo.Enabled = false;
            btnSaveAs.Enabled = false;
            btnSearch.Enabled = false;
            btnResetSearch.Enabled = false;
            btnSkip.Enabled = false;

            // Add these lines to disable key input initially
            DisableKeyInput();

            try
            {
                Icon = new Icon("Img.ico");
            }
            catch (FileNotFoundException)
            {
                // Handle the missing file scenario
                Icon = SystemIcons.Error;
            }

            // Add this code in the MainForm constructor or in the designer
            btnClearSaveData.Click += btnClearSaveData_Click;
        }

        private void btnPickDeliveryLocationYes_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                deliveryLocationYes = folderBrowserDialog.SelectedPath;
                CheckEnablePickFolderButton();
                MessageBox.Show("Location set for 'Pass' selection: " + deliveryLocationYes, "Location Set", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnPickDeliveryLocationYes.Enabled = false;
            }
        }

        private void btnPickDeliveryLocationNo_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                deliveryLocationNo = folderBrowserDialog.SelectedPath;
                CheckEnablePickFolderButton();
                MessageBox.Show("Location set for 'Fail' selection: " + deliveryLocationNo, "Location Set", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnPickDeliveryLocationNo.Enabled = false;
            }
        }

        private void btnPickFolder_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                imageFolderPath = folderBrowserDialog.SelectedPath;
                imageFiles = Directory.GetFiles(imageFolderPath)
                                      .Where(IsImageFile)
                                      .OrderBy(f => f)
                                      .ToArray();
                currentImageIndex = 0;
                DisplayCurrentImage();

                btnYes.Enabled = true;
                btnNo.Enabled = true;

                MessageBox.Show("Image folder selected: " + imageFolderPath, "Folder Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnPickFolder.Enabled = false;
                btnSaveAs.Enabled = true;
                btnSearch.Enabled = true;
                btnResetSearch.Enabled = true;
                btnSkip.Enabled = true;
            }
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(deliveryLocationYes))
            {
                try
                {
                    MoveCurrentImage(deliveryLocationYes);
                    MessageBox.Show("File has passed and been sent to: " + deliveryLocationYes, "File Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("File has failed to move: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Deselect the button
            this.ActiveControl = null;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(deliveryLocationNo))
            {
                try
                {
                    MoveCurrentImage(deliveryLocationNo);
                    MessageBox.Show("File has failed and been sent to: " + deliveryLocationNo, "File Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("File has failed to move: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Deselect the button
            this.ActiveControl = null;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            imageFolderPath = null;
            deliveryLocationYes = null;
            deliveryLocationNo = null;
            imageFiles = null;
            currentImageIndex = 0;
            pictureBox.Image = null;
            lblPictureName.Text = null;

            btnPickDeliveryLocationYes.Enabled = true;
            btnPickDeliveryLocationNo.Enabled = true;
            btnPickFolder.Enabled = false;
            btnYes.Enabled = false;
            btnNo.Enabled = false;
            btnSaveAs.Enabled = false;
            btnSearch.Enabled = false;
            btnResetSearch.Enabled = false;
            btnSkip.Enabled = false;

            // Deselect the button
            this.ActiveControl = null;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTopMost_Click(object sender, EventArgs e)
        {
            // Toggle the TopMost property of the form
            TopMost = !TopMost;

            // Update the form's TopMost state
            if (TopMost)
            {
                // Set the form to be topmost
                this.TopMost = true;
                // Display a message to indicate that TopMost is enabled
                MessageBox.Show("TopMost enabled.", "TopMost", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Set the form to not be topmost
                this.TopMost = false;
                // Display a message to indicate that TopMost is disabled
                MessageBox.Show("TopMost disabled.", "TopMost", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // Deselect the button
            this.ActiveControl = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string defaultSaveFilePath = Path.Combine(Application.StartupPath, "SaveData.txt");

            // Create a string array to store the locations
            string[] locations = new string[3];
            locations[0] = deliveryLocationYes;
            locations[1] = deliveryLocationNo;
            locations[2] = imageFolderPath;

            File.WriteAllLines(defaultSaveFilePath, locations);
            MessageBox.Show("Locations saved successfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Deselect the button
            this.ActiveControl = null;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string defaultLoadFilePath = Path.Combine(Application.StartupPath, "SaveData.txt");

            if (File.Exists(defaultLoadFilePath))
            {
                string[] locations = File.ReadAllLines(defaultLoadFilePath);

                // Assign the loaded locations to the respective variables
                deliveryLocationYes = locations[0];
                deliveryLocationNo = locations[1];
                imageFolderPath = locations[2];

                // Update the UI accordingly
                btnPickDeliveryLocationYes.Enabled = false;
                btnPickDeliveryLocationNo.Enabled = false;
                btnPickFolder.Enabled = false;
                btnSaveAs.Enabled = true;
                btnYes.Enabled = true;
                btnNo.Enabled = true;
                btnSearch.Enabled = true;
                btnResetSearch.Enabled = true;
                btnSkip.Enabled = true;

                // Load the images
                LoadImages();

                MessageBox.Show("Locations and images loaded successfully.", "Load", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No saved data found.", "Load", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // Deselect the button
            this.ActiveControl = null;
        }

        // Add this event handler to the MainForm class
        private void btnClearSaveData_Click(object sender, EventArgs e)
        {
            string defaultSaveFilePath = Path.Combine(Application.StartupPath, "SaveData.txt");

            if (File.Exists(defaultSaveFilePath))
            {
                File.Delete(defaultSaveFilePath);
                MessageBox.Show("SaveData cleared successfully.", "Clear SaveData", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("SaveData file not found.", "Clear SaveData", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // Deselect the button
            this.ActiveControl = null;
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                savedFilePath = saveFileDialog.FileName;

                // Create a string array to store the locations
                string[] locations = new string[3];
                locations[0] = deliveryLocationYes;
                locations[1] = deliveryLocationNo;
                locations[2] = imageFolderPath;

                File.WriteAllLines(savedFilePath, locations);
                MessageBox.Show("Locations saved successfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // Deselect the button
            this.ActiveControl = null;
        }

        private void btnLoadAs_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                savedFilePath = openFileDialog.FileName;
                string[] locations = File.ReadAllLines(savedFilePath);

                // Assign the loaded locations to the respective variables
                deliveryLocationYes = locations[0];
                deliveryLocationNo = locations[1];
                imageFolderPath = locations[2];

                // Update the UI accordingly
                btnPickDeliveryLocationYes.Enabled = false;
                btnPickDeliveryLocationNo.Enabled = false;
                btnPickFolder.Enabled = false;
                btnSaveAs.Enabled = true;
                btnYes.Enabled = true;
                btnNo.Enabled = true;
                btnSearch.Enabled = true;
                btnResetSearch.Enabled = true;
                btnSkip.Enabled = true;

                // Load the images
                LoadImages();

                MessageBox.Show("Locations and images loaded successfully.", "Load", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // Deselect the button
            this.ActiveControl = null;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchName = GetSearchNameFromUser();

            if (!string.IsNullOrEmpty(searchName))
            {
                // Find the first image file that contains the search name
                string matchingFile = imageFiles.FirstOrDefault(file => Path.GetFileNameWithoutExtension(file).IndexOf(searchName, StringComparison.OrdinalIgnoreCase) >= 0);

                if (matchingFile != null)
                {
                    // Display the matching image
                    currentImageIndex = Array.IndexOf(imageFiles, matchingFile);
                    DisplayCurrentImage();
                }
                else
                {
                    MessageBox.Show("No matching image found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            // Deselect the button
            this.ActiveControl = null;
        }

        private string GetSearchNameFromUser()
        {
            using (var inputForm = new Form())
            {
                inputForm.Text = "Search";
                inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                inputForm.StartPosition = FormStartPosition.CenterScreen;
                inputForm.MinimizeBox = false;
                inputForm.MaximizeBox = false;

                var label = new Label();
                label.Text = "Enter the name to search:";
                label.AutoSize = true;
                label.Location = new Point(10, 10);

                var textBox = new TextBox();
                textBox.Location = new Point(10, 40);
                textBox.Width = 200;

                var okButton = new Button();
                okButton.Text = "OK";
                okButton.DialogResult = DialogResult.OK;
                okButton.Location = new Point(10, 80);

                var cancelButton = new Button();
                cancelButton.Text = "Cancel";
                cancelButton.DialogResult = DialogResult.Cancel;
                cancelButton.Location = new Point(90, 80);

                inputForm.Controls.Add(label);
                inputForm.Controls.Add(textBox);
                inputForm.Controls.Add(okButton);
                inputForm.Controls.Add(cancelButton);

                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    return textBox.Text.Trim();
                }

                return null;
            }
        }

        private void btnResetSearch_Click(object sender, EventArgs e)
        {
            // Reset the image files to the original files in the image folder
            imageFiles = Directory.GetFiles(imageFolderPath)
                                  .Where(IsImageFile)
                                  .OrderBy(f => f)
                                  .ToArray();
            currentImageIndex = 0;
            DisplayCurrentImage();

            // Deselect the button
            this.ActiveControl = null;
        }

        private void LoadImages()
        {
            if (!string.IsNullOrEmpty(imageFolderPath))
            {
                imageFiles = Directory.GetFiles(imageFolderPath)
                                      .Where(IsImageFile)
                                      .OrderBy(f => f)
                                      .ToArray();
                currentImageIndex = 0;
                DisplayCurrentImage();

                MessageBox.Show("Image folder selected: " + imageFolderPath, "Folder Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnPickFolder.Enabled = false;
            }
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            if (imageFiles.Length > 0)
            {
                // Move to the next image
                currentImageIndex++;
                if (currentImageIndex >= imageFiles.Length)
                {
                    currentImageIndex = 0;
                }

                DisplayCurrentImage();
            }
            // Deselect the button
            this.ActiveControl = null;
        }

        private void DisplayCurrentImage()
        {
            if (imageFiles.Length > 0)
            {
                pictureBox.ImageLocation = imageFiles[currentImageIndex];
                lblPictureName.Text = Path.GetFileNameWithoutExtension(imageFiles[currentImageIndex]);
            }
        }

        private void MoveCurrentImage(string destinationFolder)
        {
            if (imageFiles.Length > 0)
            {
                string currentImageFile = imageFiles[currentImageIndex];
                string fileName = Path.GetFileName(currentImageFile);
                string destinationPath = Path.Combine(destinationFolder, fileName);
                File.Move(currentImageFile, destinationPath);

                // Move to the next image
                currentImageIndex++;
                if (currentImageIndex >= imageFiles.Length)
                {
                    currentImageIndex = 0;
                }

                DisplayCurrentImage();
            }
        }

        private bool IsImageFile(string filePath)
        {
            string extension = Path.GetExtension(filePath);
            string[] validExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" }; // Add more valid extensions if needed
            return validExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase);
        }

        private void CheckEnablePickFolderButton()
        {
            if (!string.IsNullOrEmpty(deliveryLocationYes) && !string.IsNullOrEmpty(deliveryLocationNo))
            {
                btnPickFolder.Enabled = true;
            }
        }
    }
}