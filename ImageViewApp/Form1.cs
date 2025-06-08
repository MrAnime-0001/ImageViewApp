using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
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
        private string savedFilePath;
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
                    case Keys.NumPad3:
                        btnHidePictureBox.PerformClick();
                        return true;
                    case Keys.NumPad4:
                        btnSkipSimilar.PerformClick();
                        return true;
                    case Keys.NumPad5:
                        btnResetSearch.PerformClick();
                        return true;
                    case Keys.NumPad6:
                        btnSearch.PerformClick();
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

        public static void ShowToast(string message, int duration = 2000, bool playSound = true)
        {
            Form toast = new Form
            {
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.Manual,
                ShowInTaskbar = false,
                TopMost = true,
                BackColor = Color.FromArgb(45, 45, 48),
                Size = new Size(250, 60),
                Opacity = 0.9
            };

            toast.Controls.Add(new Label
            {
                Text = message,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White
            });

            var screen = Screen.PrimaryScreen.WorkingArea;
            toast.Location = new Point(screen.Right - toast.Width - 10, screen.Bottom - toast.Height - 10);

            toast.Shown += async (s, e) =>
            {
                if (playSound)
                {
                    SystemSounds.Exclamation.Play(); // Default Windows notification sound
                }

                await Task.Delay(duration);
                toast.Close();
            };

            toast.Show();
        }

        public MainForm()
        {
            InitializeComponent();
            SetHighPerformanceMode();
            btnPickFolder.Enabled = false;
            btnYes.Enabled = false;
            btnNo.Enabled = false;
            btnSaveAs.Enabled = false;
            btnSearch.Enabled = false;
            btnSearchv2.Enabled = false;
            btnSkip.Enabled = false;
            btnSkipSimilar.Enabled = false;
            btnResetSearch.Enabled = false;
            btnHidePictureBox.Enabled = false;
            btnrestartAnimatedImage.Enabled = false;

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

        private void SetHighPerformanceMode()
        {
            try
            {
                Process currentProcess = Process.GetCurrentProcess();
                currentProcess.PriorityClass = ProcessPriorityClass.High; // Options: Idle, BelowNormal, Normal, AboveNormal, High, RealTime
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error setting high-performance mode: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPickDeliveryLocationYes_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                deliveryLocationYes = folderBrowserDialog.SelectedPath;
                CheckEnablePickFolderButton();
                ShowToast("Location set for 'Pass' selection:\n" + deliveryLocationYes, 3000, true);
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
                ShowToast("Location set for 'Fail' selection:\n" + deliveryLocationNo, 3000, true);
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

                ShowToast("Image folder selected:\n" + imageFolderPath, 3000, true);
                btnPickFolder.Enabled = false;
                btnSaveAs.Enabled = true;
                btnSearch.Enabled = true;
                btnSearchv2.Enabled = true;
                btnSkip.Enabled = true;
                btnSkipSimilar.Enabled = true;
                btnResetSearch.Enabled = true;
                btnHidePictureBox.Enabled = true;
                btnrestartAnimatedImage.Enabled = true;
            }
        }

        const string PASSED_MESSAGE = "✅ Image successfully passed!\nSent to: {0}";
        const string FAILED_MESSAGE = "❌ Image marked as failed.\nSent to: {0}";

        private async void btnYes_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(deliveryLocationYes))
            {
                btnYes.Enabled = false;
                try
                {
                    MoveCurrentImage(deliveryLocationYes);
                    string passMessage = string.Format(PASSED_MESSAGE, deliveryLocationYes);
                    ShowToast(passMessage, 2500, true);
                }
                catch (Exception ex)
                {
                    ShowToast("⚠️ Failed to move image: " + ex.Message, 3000, true);
                }

                await Task.Delay(1500);
                btnYes.Enabled = true;
            }

            this.ActiveControl = null;
        }

        private async void btnNo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(deliveryLocationNo))
            {
                btnNo.Enabled = false;
                try
                {
                    MoveCurrentImage(deliveryLocationNo);
                    string failMessage = string.Format(FAILED_MESSAGE, deliveryLocationNo);
                    ShowToast(failMessage, 2500, true);
                }
                catch (Exception ex)
                {
                    ShowToast("⚠️ Failed to move image: " + ex.Message, 3000, true);
                }

                await Task.Delay(1500);
                btnNo.Enabled = true;
            }

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
            btnSearchv2.Enabled = false;
            btnSkip.Enabled = false;
            btnSkipSimilar.Enabled = false;
            btnResetSearch.Enabled = false;
            btnHidePictureBox.Enabled = false;
            btnrestartAnimatedImage.Enabled = false;

            // Deselect the button
            this.ActiveControl = null;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTopMost_Click(object sender, EventArgs e)
        {
            // Toggle the TopMost property
            TopMost = !TopMost;

            if (TopMost)
            {
                this.TopMost = true;
                ShowToast("TopMost enabled.", 2000, true);
            }
            else
            {
                this.TopMost = false;
                ShowToast("TopMost disabled.", 2000, true);
            }

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
            ShowToast("Locations saved successfully.", 2500, true);

            this.ActiveControl = null;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string defaultLoadFilePath = Path.Combine(Application.StartupPath, "SaveData.txt");

            if (File.Exists(defaultLoadFilePath))
            {
                string[] locations = File.ReadAllLines(defaultLoadFilePath);

                deliveryLocationYes = locations[0];
                deliveryLocationNo = locations[1];
                imageFolderPath = locations[2];

                btnPickDeliveryLocationYes.Enabled = false;
                btnPickDeliveryLocationNo.Enabled = false;
                btnPickFolder.Enabled = false;
                btnSaveAs.Enabled = true;
                btnYes.Enabled = true;
                btnNo.Enabled = true;
                btnSearch.Enabled = true;
                btnSearchv2.Enabled = true;
                btnSkip.Enabled = true;
                btnSkipSimilar.Enabled = true;
                btnResetSearch.Enabled = true;
                btnHidePictureBox.Enabled = true;
                btnrestartAnimatedImage.Enabled = true;

                LoadImages();

                ShowToast("Locations and images loaded successfully.", 2500, true);
            }
            else
            {
                ShowToast("No saved data found.", 2500, true);
            }

            this.ActiveControl = null;
        }

        private void btnClearSaveData_Click(object sender, EventArgs e)
        {
            string defaultSaveFilePath = Path.Combine(Application.StartupPath, "SaveData.txt");

            if (File.Exists(defaultSaveFilePath))
            {
                File.Delete(defaultSaveFilePath);
                ShowToast("SaveData cleared successfully.", 2500, true);
            }
            else
            {
                ShowToast("SaveData file not found.", 2500, true);
            }

            this.ActiveControl = null;
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                savedFilePath = saveFileDialog.FileName;

                string[] locations = new string[3];
                locations[0] = deliveryLocationYes;
                locations[1] = deliveryLocationNo;
                locations[2] = imageFolderPath;

                File.WriteAllLines(savedFilePath, locations);
                ShowToast("Locations saved successfully.", 2500, true);
            }

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

                deliveryLocationYes = locations[0];
                deliveryLocationNo = locations[1];
                imageFolderPath = locations[2];

                btnPickDeliveryLocationYes.Enabled = false;
                btnPickDeliveryLocationNo.Enabled = false;
                btnPickFolder.Enabled = false;
                btnSaveAs.Enabled = true;
                btnYes.Enabled = true;
                btnNo.Enabled = true;
                btnSearch.Enabled = true;
                btnSearchv2.Enabled = true;
                btnSkip.Enabled = true;
                btnSkipSimilar.Enabled = true;
                btnResetSearch.Enabled = true;
                btnHidePictureBox.Enabled = true;
                btnrestartAnimatedImage.Enabled = true;

                LoadImages();

                ShowToast("Locations and images loaded successfully.", 2500, true);
            }

            this.ActiveControl = null;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchName = GetSearchNameFromUser();

            if (!string.IsNullOrEmpty(searchName))
            {
                // Find the first image file that contains the search name
                string matchingFile = imageFiles.FirstOrDefault(file =>
                    Path.GetFileNameWithoutExtension(file).IndexOf(searchName, StringComparison.OrdinalIgnoreCase) >= 0);

                if (matchingFile != null)
                {
                    // Display the matching image
                    currentImageIndex = Array.IndexOf(imageFiles, matchingFile);
                    DisplayCurrentImage();
                }
                else
                {
                    ShowToast("No matching image found.", 2500, true);
                }
            }

            this.ActiveControl = null;
        }

        private string GetSearchNameFromUser()
        {
            using (var inputForm = new Form())
            {
                inputForm.Text = "Search Image";
                inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                inputForm.StartPosition = FormStartPosition.CenterScreen;
                inputForm.MinimizeBox = false;
                inputForm.MaximizeBox = false;
                inputForm.ClientSize = new Size(300, 150);
                inputForm.BackColor = Color.FromArgb(30, 30, 30);

                var label = new Label
                {
                    Text = "🔍 Enter image name to search:",
                    AutoSize = true,
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 10, FontStyle.Regular),
                    Location = new Point(20, 20)
                };

                var textBox = new TextBox
                {
                    Location = new Point(20, 50),
                    Width = 250,
                    Font = new Font("Segoe UI", 10),
                    BackColor = Color.FromArgb(45, 45, 48),
                    ForeColor = Color.White,
                    BorderStyle = BorderStyle.FixedSingle
                };

                var okButton = new Button
                {
                    Text = "OK",
                    DialogResult = DialogResult.OK,
                    Width = 100,
                    Height = 30,
                    Font = new Font("Segoe UI", 9),
                    Location = new Point(40, 95),
                    BackColor = Color.FromArgb(70, 130, 180),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };
                okButton.FlatAppearance.BorderSize = 0;

                var cancelButton = new Button
                {
                    Text = "Cancel",
                    DialogResult = DialogResult.Cancel,
                    Width = 100,
                    Height = 30,
                    Font = new Font("Segoe UI", 9),
                    Location = new Point(160, 95),
                    BackColor = Color.FromArgb(100, 100, 100),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };
                cancelButton.FlatAppearance.BorderSize = 0;

                inputForm.Controls.Add(label);
                inputForm.Controls.Add(textBox);
                inputForm.Controls.Add(okButton);
                inputForm.Controls.Add(cancelButton);

                inputForm.AcceptButton = okButton;
                inputForm.CancelButton = cancelButton;

                return inputForm.ShowDialog() == DialogResult.OK
                    ? textBox.Text.Trim()
                    : null;
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

                ShowToast("Image folder selected:\n" + imageFolderPath, 3000, true);
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

        private void btnSearchv2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = imageFolderPath;
                openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.gif, *.bmp)|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

                DialogResult result = openFileDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string selectedImagePath = openFileDialog.FileName;

                    int selectedImageIndex = Array.FindIndex(imageFiles, image =>
                        image.Equals(selectedImagePath, StringComparison.OrdinalIgnoreCase));

                    if (selectedImageIndex != -1)
                    {
                        currentImageIndex = selectedImageIndex;
                        DisplayCurrentImage();
                    }
                    else
                    {
                        ShowToast("Selected image not found in current image folder.", 3000, true);
                    }
                }
            }
        }

        private void btnrestartAnimatedImage_Click(object sender, EventArgs e)
        {
            pictureBox.ImageLocation = imageFiles[currentImageIndex];
        }

        private void btnHidePictureBox_Click(object sender, EventArgs e)
        {
            // Toggle visibility of pictureBox
            pictureBox.Visible = !pictureBox.Visible;

            // Enable/Disable buttons based on pictureBox visibility
            bool isVisible = pictureBox.Visible;
            btnPickFolder.Enabled = isVisible;
            btnYes.Enabled = isVisible;
            btnNo.Enabled = isVisible;
            btnReset.Enabled = isVisible;
            btnSave.Enabled = isVisible;
            btnLoad.Enabled = isVisible;
            btnClearSaveData.Enabled = isVisible;
            btnSaveAs.Enabled = isVisible;
            btnLoadAs.Enabled = isVisible;
            btnSearch.Enabled = isVisible;
            btnSearchv2.Enabled = isVisible;
            btnSkip.Enabled = isVisible;
            btnSkipSimilar.Enabled = isVisible;
            btnResetSearch.Enabled = isVisible;
            btnrestartAnimatedImage.Enabled = isVisible;

            // Change button text based on visibility
            btnHidePictureBox.Text = isVisible ? "Hide Image" : "Show Image";
        }

        private void btnSkipSimilar_Click(object sender, EventArgs e)
        {
            if (imageFiles.Length > 0)
            {
                // Extract the first word from the current image filename
                string firstWord = GetFirstWord(Path.GetFileNameWithoutExtension(imageFiles[currentImageIndex]));

                // Move to the next image that has a different first word
                do
                {
                    currentImageIndex++;
                    if (currentImageIndex >= imageFiles.Length)
                    {
                        currentImageIndex = 0; // Wrap around if reaching the end
                    }
                }
                while (GetFirstWord(Path.GetFileNameWithoutExtension(imageFiles[currentImageIndex])) == firstWord);

                DisplayCurrentImage();
            }

            // Deselect the button
            this.ActiveControl = null;
        }

        // Helper function to extract the first word from a filename
        private string GetFirstWord(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
                return string.Empty;

            string[] words = filename.Split(new[] { ' ', '_', '-' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length > 0 ? words[0] : filename; // Return first word or filename if no spaces
        }
    }
}