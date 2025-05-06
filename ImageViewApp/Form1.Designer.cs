namespace ImageViewApp
{
    partial class MainForm
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
            pictureBox = new PictureBox();
            btnPickFolder = new Button();
            btnPickDeliveryLocationYes = new Button();
            btnPickDeliveryLocationNo = new Button();
            btnYes = new Button();
            btnNo = new Button();
            btnReset = new Button();
            btnClose = new Button();
            btnTopMost = new Label();
            lblPictureName = new Label();
            menuStrip = new MenuStrip();
            saveLoadToolStripMenuItem = new ToolStripMenuItem();
            btnSave = new ToolStripMenuItem();
            btnLoad = new ToolStripMenuItem();
            btnClearSaveData = new ToolStripMenuItem();
            btnSaveAs = new ToolStripMenuItem();
            btnLoadAs = new ToolStripMenuItem();
            ExtraToolStripMenuItem = new ToolStripMenuItem();
            btnSearch = new ToolStripMenuItem();
            btnResetSearch = new ToolStripMenuItem();
            btnSkip = new ToolStripMenuItem();
            btnToggleKeyInput = new Button();
            btnSearchv2 = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(12, 65);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(1135, 638);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // btnPickFolder
            // 
            btnPickFolder.Location = new Point(1154, 165);
            btnPickFolder.Name = "btnPickFolder";
            btnPickFolder.Size = new Size(250, 100);
            btnPickFolder.TabIndex = 1;
            btnPickFolder.Text = "Image Location Setter";
            btnPickFolder.UseVisualStyleBackColor = true;
            btnPickFolder.Click += btnPickFolder_Click;
            // 
            // btnPickDeliveryLocationYes
            // 
            btnPickDeliveryLocationYes.Location = new Point(1154, 65);
            btnPickDeliveryLocationYes.Name = "btnPickDeliveryLocationYes";
            btnPickDeliveryLocationYes.Size = new Size(125, 100);
            btnPickDeliveryLocationYes.TabIndex = 2;
            btnPickDeliveryLocationYes.Text = "Pass File Location Setter";
            btnPickDeliveryLocationYes.UseVisualStyleBackColor = true;
            btnPickDeliveryLocationYes.Click += btnPickDeliveryLocationYes_Click;
            // 
            // btnPickDeliveryLocationNo
            // 
            btnPickDeliveryLocationNo.Location = new Point(1279, 65);
            btnPickDeliveryLocationNo.Name = "btnPickDeliveryLocationNo";
            btnPickDeliveryLocationNo.Size = new Size(125, 100);
            btnPickDeliveryLocationNo.TabIndex = 3;
            btnPickDeliveryLocationNo.Text = "Fail File Location Setter";
            btnPickDeliveryLocationNo.UseVisualStyleBackColor = true;
            btnPickDeliveryLocationNo.Click += btnPickDeliveryLocationNo_Click;
            // 
            // btnYes
            // 
            btnYes.Location = new Point(1154, 265);
            btnYes.Name = "btnYes";
            btnYes.Size = new Size(125, 350);
            btnYes.TabIndex = 4;
            btnYes.Text = "Pass";
            btnYes.UseVisualStyleBackColor = true;
            btnYes.Click += btnYes_Click;
            // 
            // btnNo
            // 
            btnNo.Location = new Point(1279, 265);
            btnNo.Name = "btnNo";
            btnNo.Size = new Size(125, 350);
            btnNo.TabIndex = 5;
            btnNo.Text = "Fail";
            btnNo.UseVisualStyleBackColor = true;
            btnNo.Click += btnNo_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(1154, 615);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(125, 88);
            btnReset.TabIndex = 6;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(1279, 615);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(125, 88);
            btnClose.TabIndex = 7;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnTopMost
            // 
            btnTopMost.AutoSize = true;
            btnTopMost.ForeColor = SystemColors.Highlight;
            btnTopMost.Location = new Point(1265, 706);
            btnTopMost.Name = "btnTopMost";
            btnTopMost.Size = new Size(139, 15);
            btnTopMost.TabIndex = 8;
            btnTopMost.Text = "Program created by Yutti";
            btnTopMost.Click += btnTopMost_Click;
            // 
            // lblPictureName
            // 
            lblPictureName.AutoSize = true;
            lblPictureName.Font = new Font("Segoe UI", 15F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblPictureName.ForeColor = Color.White;
            lblPictureName.Location = new Point(12, 31);
            lblPictureName.Name = "lblPictureName";
            lblPictureName.Size = new Size(0, 28);
            lblPictureName.TabIndex = 9;
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { saveLoadToolStripMenuItem, ExtraToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1416, 24);
            menuStrip.TabIndex = 10;
            menuStrip.Text = "menuStrip";
            // 
            // saveLoadToolStripMenuItem
            // 
            saveLoadToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { btnSave, btnLoad, btnClearSaveData, btnSaveAs, btnLoadAs });
            saveLoadToolStripMenuItem.Name = "saveLoadToolStripMenuItem";
            saveLoadToolStripMenuItem.Size = new Size(80, 20);
            saveLoadToolStripMenuItem.Text = "Save / Load";
            // 
            // btnSave
            // 
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(128, 22);
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            // 
            // btnLoad
            // 
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(128, 22);
            btnLoad.Text = "Load";
            btnLoad.Click += btnLoad_Click;
            // 
            // btnClearSaveData
            // 
            btnClearSaveData.Name = "btnClearSaveData";
            btnClearSaveData.Size = new Size(128, 22);
            btnClearSaveData.Text = "Clear Save";
            btnClearSaveData.Click += btnClearSaveData_Click;
            // 
            // btnSaveAs
            // 
            btnSaveAs.Name = "btnSaveAs";
            btnSaveAs.Size = new Size(128, 22);
            btnSaveAs.Text = "Save as";
            btnSaveAs.Click += btnSaveAs_Click;
            // 
            // btnLoadAs
            // 
            btnLoadAs.Name = "btnLoadAs";
            btnLoadAs.Size = new Size(128, 22);
            btnLoadAs.Text = "Load as";
            btnLoadAs.Click += btnLoadAs_Click;
            // 
            // ExtraToolStripMenuItem
            // 
            ExtraToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { btnSearch, btnSearchv2, btnResetSearch, btnSkip });
            ExtraToolStripMenuItem.Name = "ExtraToolStripMenuItem";
            ExtraToolStripMenuItem.Size = new Size(45, 20);
            ExtraToolStripMenuItem.Text = "Extra";
            // 
            // btnSearch
            // 
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(180, 22);
            btnSearch.Text = "Search";
            btnSearch.Click += btnSearch_Click;
            // 
            // btnResetSearch
            // 
            btnResetSearch.Name = "btnResetSearch";
            btnResetSearch.Size = new Size(180, 22);
            btnResetSearch.Text = "Reset Search";
            btnResetSearch.Click += btnResetSearch_Click;
            // 
            // btnSkip
            // 
            btnSkip.Name = "btnSkip";
            btnSkip.Size = new Size(180, 22);
            btnSkip.Text = "Skip";
            btnSkip.Click += btnSkip_Click;
            // 
            // btnToggleKeyInput
            // 
            btnToggleKeyInput.Location = new Point(1154, 38);
            btnToggleKeyInput.Name = "btnToggleKeyInput";
            btnToggleKeyInput.Size = new Size(250, 23);
            btnToggleKeyInput.TabIndex = 11;
            btnToggleKeyInput.Text = "Toggle Hot Keys";
            btnToggleKeyInput.UseVisualStyleBackColor = true;
            btnToggleKeyInput.Click += btnToggleKeyInput_Click;
            // 
            // btnSearchv2
            // 
            btnSearchv2.Name = "btnSearchv2";
            btnSearchv2.Size = new Size(180, 22);
            btnSearchv2.Text = "File Explorer Search";
            btnSearchv2.Click += btnSearchv2_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 18, 18);
            ClientSize = new Size(1416, 727);
            Controls.Add(btnToggleKeyInput);
            Controls.Add(lblPictureName);
            Controls.Add(btnTopMost);
            Controls.Add(btnClose);
            Controls.Add(btnReset);
            Controls.Add(btnNo);
            Controls.Add(btnYes);
            Controls.Add(btnPickDeliveryLocationNo);
            Controls.Add(btnPickDeliveryLocationYes);
            Controls.Add(btnPickFolder);
            Controls.Add(pictureBox);
            Controls.Add(menuStrip);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MainMenuStrip = menuStrip;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Yutti's Image Sorter";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox;
        private Button btnPickFolder;
        private Button btnPickDeliveryLocationYes;
        private Button btnPickDeliveryLocationNo;
        private Button btnYes;
        private Button btnNo;
        private Button btnReset;
        private Button btnClose;
        private Label btnTopMost;
        private Label lblPictureName;
        private MenuStrip menuStrip;
        private ToolStripMenuItem saveLoadToolStripMenuItem;
        private ToolStripMenuItem btnSaveAs;
        private ToolStripMenuItem btnLoadAs;
        private ToolStripMenuItem btnSave;
        private ToolStripMenuItem btnLoad;
        private ToolStripMenuItem btnClearSaveData;
        private ToolStripMenuItem ExtraToolStripMenuItem;
        private ToolStripMenuItem btnSearch;
        private ToolStripMenuItem btnResetSearch;
        private ToolStripMenuItem btnSkip;
        private Button btnToggleKeyInput;
        private ToolStripMenuItem btnSearchv2;
    }
}