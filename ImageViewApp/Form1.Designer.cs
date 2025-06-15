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
            panelControls = new Panel();
            btnPickFolder = new Button();
            btnPickDeliveryLocationYes = new Button();
            btnPickDeliveryLocationNo = new Button();
            btnYes = new Button();
            btnNo = new Button();
            btnReset = new Button();
            btnClose = new Button();
            btnToggleKeyInput = new Button();
            panelHeader = new Panel();
            lblPictureName = new Label();
            lblAppTitle = new Label();
            menuStrip = new MenuStrip();
            saveLoadToolStripMenuItem = new ToolStripMenuItem();
            btnSave = new ToolStripMenuItem();
            btnLoad = new ToolStripMenuItem();
            btnClearSaveData = new ToolStripMenuItem();
            btnSaveAs = new ToolStripMenuItem();
            btnLoadAs = new ToolStripMenuItem();
            btnSkip = new ToolStripMenuItem();
            btnSkipSimilar = new ToolStripMenuItem();
            btnSkipLayout = new ToolStripMenuItem();
            btnResetSearch = new ToolStripMenuItem();
            btnHidePictureBox = new ToolStripMenuItem();
            ExtraToolStripMenuItem = new ToolStripMenuItem();
            btnSearch = new ToolStripMenuItem();
            btnSearchv2 = new ToolStripMenuItem();
            panelFooter = new Panel();
            btnTopMost = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            panelControls.SuspendLayout();
            panelHeader.SuspendLayout();
            menuStrip.SuspendLayout();
            panelFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox.BackColor = Color.FromArgb(40, 40, 40);
            pictureBox.BorderStyle = BorderStyle.FixedSingle;
            pictureBox.Location = new Point(20, 80);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(1136, 640);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // panelControls
            // 
            panelControls.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panelControls.BackColor = Color.FromArgb(32, 32, 32);
            panelControls.BorderStyle = BorderStyle.FixedSingle;
            panelControls.Controls.Add(btnPickFolder);
            panelControls.Controls.Add(btnPickDeliveryLocationYes);
            panelControls.Controls.Add(btnPickDeliveryLocationNo);
            panelControls.Controls.Add(btnYes);
            panelControls.Controls.Add(btnNo);
            panelControls.Controls.Add(btnReset);
            panelControls.Controls.Add(btnClose);
            panelControls.Controls.Add(btnToggleKeyInput);
            panelControls.Location = new Point(1176, 80);
            panelControls.Name = "panelControls";
            panelControls.Padding = new Padding(15);
            panelControls.Size = new Size(270, 640);
            panelControls.TabIndex = 1;
            // 
            // btnPickFolder
            // 
            btnPickFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnPickFolder.BackColor = Color.FromArgb(0, 122, 204);
            btnPickFolder.FlatAppearance.BorderSize = 0;
            btnPickFolder.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 100, 170);
            btnPickFolder.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 140, 230);
            btnPickFolder.FlatStyle = FlatStyle.Flat;
            btnPickFolder.ForeColor = Color.White;
            btnPickFolder.Location = new Point(18, 115);
            btnPickFolder.Name = "btnPickFolder";
            btnPickFolder.Size = new Size(230, 45);
            btnPickFolder.TabIndex = 3;
            btnPickFolder.Text = "📁 Set Image Location";
            btnPickFolder.UseVisualStyleBackColor = false;
            btnPickFolder.Click += btnPickFolder_Click;
            // 
            // btnPickDeliveryLocationYes
            // 
            btnPickDeliveryLocationYes.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnPickDeliveryLocationYes.BackColor = Color.FromArgb(46, 204, 113);
            btnPickDeliveryLocationYes.FlatAppearance.BorderSize = 0;
            btnPickDeliveryLocationYes.FlatAppearance.MouseDownBackColor = Color.FromArgb(39, 174, 96);
            btnPickDeliveryLocationYes.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 232, 128);
            btnPickDeliveryLocationYes.FlatStyle = FlatStyle.Flat;
            btnPickDeliveryLocationYes.ForeColor = Color.White;
            btnPickDeliveryLocationYes.Location = new Point(18, 175);
            btnPickDeliveryLocationYes.Name = "btnPickDeliveryLocationYes";
            btnPickDeliveryLocationYes.Size = new Size(112, 45);
            btnPickDeliveryLocationYes.TabIndex = 4;
            btnPickDeliveryLocationYes.Text = "✓ Pass Folder";
            btnPickDeliveryLocationYes.UseVisualStyleBackColor = false;
            btnPickDeliveryLocationYes.Click += btnPickDeliveryLocationYes_Click;
            // 
            // btnPickDeliveryLocationNo
            // 
            btnPickDeliveryLocationNo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPickDeliveryLocationNo.BackColor = Color.FromArgb(231, 76, 60);
            btnPickDeliveryLocationNo.FlatAppearance.BorderSize = 0;
            btnPickDeliveryLocationNo.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 57, 43);
            btnPickDeliveryLocationNo.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 87, 68);
            btnPickDeliveryLocationNo.FlatStyle = FlatStyle.Flat;
            btnPickDeliveryLocationNo.ForeColor = Color.White;
            btnPickDeliveryLocationNo.Location = new Point(136, 175);
            btnPickDeliveryLocationNo.Name = "btnPickDeliveryLocationNo";
            btnPickDeliveryLocationNo.Size = new Size(112, 45);
            btnPickDeliveryLocationNo.TabIndex = 5;
            btnPickDeliveryLocationNo.Text = "✗ Fail Folder";
            btnPickDeliveryLocationNo.UseVisualStyleBackColor = false;
            btnPickDeliveryLocationNo.Click += btnPickDeliveryLocationNo_Click;
            // 
            // btnYes
            // 
            btnYes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btnYes.BackColor = Color.FromArgb(46, 204, 113);
            btnYes.FlatAppearance.BorderSize = 0;
            btnYes.FlatAppearance.MouseDownBackColor = Color.FromArgb(39, 174, 96);
            btnYes.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 232, 128);
            btnYes.FlatStyle = FlatStyle.Flat;
            btnYes.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnYes.ForeColor = Color.White;
            btnYes.Location = new Point(18, 240);
            btnYes.Name = "btnYes";
            btnYes.Size = new Size(112, 280);
            btnYes.TabIndex = 6;
            btnYes.Text = "✓\r\nPASS";
            btnYes.UseVisualStyleBackColor = false;
            btnYes.Click += btnYes_Click;
            // 
            // btnNo
            // 
            btnNo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnNo.BackColor = Color.FromArgb(231, 76, 60);
            btnNo.FlatAppearance.BorderSize = 0;
            btnNo.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 57, 43);
            btnNo.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 87, 68);
            btnNo.FlatStyle = FlatStyle.Flat;
            btnNo.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnNo.ForeColor = Color.White;
            btnNo.Location = new Point(136, 240);
            btnNo.Name = "btnNo";
            btnNo.Size = new Size(112, 280);
            btnNo.TabIndex = 7;
            btnNo.Text = "✗\r\nFAIL";
            btnNo.UseVisualStyleBackColor = false;
            btnNo.Click += btnNo_Click;
            // 
            // btnReset
            // 
            btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnReset.BackColor = Color.FromArgb(155, 89, 182);
            btnReset.FlatAppearance.BorderSize = 0;
            btnReset.FlatAppearance.MouseDownBackColor = Color.FromArgb(125, 60, 152);
            btnReset.FlatAppearance.MouseOverBackColor = Color.FromArgb(175, 122, 197);
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.ForeColor = Color.White;
            btnReset.Location = new Point(18, 540);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(112, 45);
            btnReset.TabIndex = 8;
            btnReset.Text = "🔄 Reset";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.BackColor = Color.FromArgb(52, 73, 94);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(44, 62, 80);
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(69, 90, 120);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(136, 540);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(112, 45);
            btnClose.TabIndex = 9;
            btnClose.Text = "🚪 Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnToggleKeyInput
            // 
            btnToggleKeyInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnToggleKeyInput.BackColor = Color.FromArgb(241, 196, 15);
            btnToggleKeyInput.FlatAppearance.BorderSize = 0;
            btnToggleKeyInput.FlatAppearance.MouseDownBackColor = Color.FromArgb(212, 172, 13);
            btnToggleKeyInput.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 211, 42);
            btnToggleKeyInput.FlatStyle = FlatStyle.Flat;
            btnToggleKeyInput.ForeColor = Color.Black;
            btnToggleKeyInput.Location = new Point(18, 55);
            btnToggleKeyInput.Name = "btnToggleKeyInput";
            btnToggleKeyInput.Size = new Size(230, 45);
            btnToggleKeyInput.TabIndex = 2;
            btnToggleKeyInput.Text = "⌨ Toggle Hot Keys";
            btnToggleKeyInput.UseVisualStyleBackColor = false;
            btnToggleKeyInput.Click += btnToggleKeyInput_Click;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(32, 32, 32);
            panelHeader.BorderStyle = BorderStyle.FixedSingle;
            panelHeader.Controls.Add(lblPictureName);
            panelHeader.Controls.Add(lblAppTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 24);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1466, 50);
            panelHeader.TabIndex = 2;
            // 
            // lblPictureName
            // 
            lblPictureName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblPictureName.AutoEllipsis = true;
            lblPictureName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblPictureName.ForeColor = Color.FromArgb(189, 195, 199);
            lblPictureName.Location = new Point(280, 15);
            lblPictureName.Name = "lblPictureName";
            lblPictureName.Size = new Size(870, 21);
            lblPictureName.TabIndex = 1;
            lblPictureName.Text = "No image selected";
            lblPictureName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAppTitle
            // 
            lblAppTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            lblAppTitle.AutoSize = true;
            lblAppTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblAppTitle.ForeColor = Color.FromArgb(52, 152, 219);
            lblAppTitle.Location = new Point(20, 13);
            lblAppTitle.Name = "lblAppTitle";
            lblAppTitle.Size = new Size(189, 25);
            lblAppTitle.TabIndex = 0;
            lblAppTitle.Text = "Yutti's Image Sorter";
            // 
            // menuStrip
            // 
            menuStrip.BackColor = Color.FromArgb(45, 45, 48);
            menuStrip.ForeColor = Color.White;
            menuStrip.Items.AddRange(new ToolStripItem[] { saveLoadToolStripMenuItem, btnSkip, btnSkipSimilar, btnSkipLayout, btnResetSearch, btnHidePictureBox, ExtraToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.RenderMode = ToolStripRenderMode.Professional;
            menuStrip.Size = new Size(1466, 24);
            menuStrip.TabIndex = 3;
            menuStrip.Text = "menuStrip";
            // 
            // saveLoadToolStripMenuItem
            // 
            saveLoadToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { btnSave, btnLoad, btnClearSaveData, btnSaveAs, btnLoadAs });
            saveLoadToolStripMenuItem.ForeColor = Color.White;
            saveLoadToolStripMenuItem.Name = "saveLoadToolStripMenuItem";
            saveLoadToolStripMenuItem.Size = new Size(80, 20);
            saveLoadToolStripMenuItem.Text = "Save / Load";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(60, 60, 60);
            btnSave.ForeColor = Color.White;
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(128, 22);
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            // 
            // btnLoad
            // 
            btnLoad.BackColor = Color.FromArgb(60, 60, 60);
            btnLoad.ForeColor = Color.White;
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(128, 22);
            btnLoad.Text = "Load";
            btnLoad.Click += btnLoad_Click;
            // 
            // btnClearSaveData
            // 
            btnClearSaveData.BackColor = Color.FromArgb(60, 60, 60);
            btnClearSaveData.ForeColor = Color.White;
            btnClearSaveData.Name = "btnClearSaveData";
            btnClearSaveData.Size = new Size(128, 22);
            btnClearSaveData.Text = "Clear Save";
            btnClearSaveData.Click += btnClearSaveData_Click;
            // 
            // btnSaveAs
            // 
            btnSaveAs.BackColor = Color.FromArgb(60, 60, 60);
            btnSaveAs.ForeColor = Color.White;
            btnSaveAs.Name = "btnSaveAs";
            btnSaveAs.Size = new Size(128, 22);
            btnSaveAs.Text = "Save as";
            btnSaveAs.Click += btnSaveAs_Click;
            // 
            // btnLoadAs
            // 
            btnLoadAs.BackColor = Color.FromArgb(60, 60, 60);
            btnLoadAs.ForeColor = Color.White;
            btnLoadAs.Name = "btnLoadAs";
            btnLoadAs.Size = new Size(128, 22);
            btnLoadAs.Text = "Load as";
            btnLoadAs.Click += btnLoadAs_Click;
            // 
            // btnSkip
            // 
            btnSkip.ForeColor = Color.White;
            btnSkip.Name = "btnSkip";
            btnSkip.Size = new Size(41, 20);
            btnSkip.Text = "Skip";
            btnSkip.Click += btnSkip_Click;
            // 
            // btnSkipSimilar
            // 
            btnSkipSimilar.ForeColor = Color.White;
            btnSkipSimilar.Name = "btnSkipSimilar";
            btnSkipSimilar.Size = new Size(80, 20);
            btnSkipSimilar.Text = "Skip Similar";
            btnSkipSimilar.Click += btnSkipSimilar_Click;
            // 
            // btnSkipLayout
            // 
            btnSkipLayout.Name = "btnSkipLayout";
            btnSkipLayout.Size = new Size(80, 20);
            btnSkipLayout.Text = "Skip Layout";
            btnSkipLayout.Click += btnSkipLayout_Click;
            // 
            // btnResetSearch
            // 
            btnResetSearch.ForeColor = Color.White;
            btnResetSearch.Name = "btnResetSearch";
            btnResetSearch.Size = new Size(85, 20);
            btnResetSearch.Text = "Reset Search";
            btnResetSearch.Click += btnResetSearch_Click;
            // 
            // btnHidePictureBox
            // 
            btnHidePictureBox.ForeColor = Color.White;
            btnHidePictureBox.Name = "btnHidePictureBox";
            btnHidePictureBox.Size = new Size(106, 20);
            btnHidePictureBox.Text = "Hide Picture Box";
            btnHidePictureBox.Click += btnHidePictureBox_Click;
            // 
            // ExtraToolStripMenuItem
            // 
            ExtraToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { btnSearch, btnSearchv2 });
            ExtraToolStripMenuItem.ForeColor = Color.White;
            ExtraToolStripMenuItem.Name = "ExtraToolStripMenuItem";
            ExtraToolStripMenuItem.Size = new Size(44, 20);
            ExtraToolStripMenuItem.Text = "Extra";
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(60, 60, 60);
            btnSearch.ForeColor = Color.White;
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(175, 22);
            btnSearch.Text = "Search";
            btnSearch.Click += btnSearch_Click;
            // 
            // btnSearchv2
            // 
            btnSearchv2.BackColor = Color.FromArgb(60, 60, 60);
            btnSearchv2.ForeColor = Color.White;
            btnSearchv2.Name = "btnSearchv2";
            btnSearchv2.Size = new Size(175, 22);
            btnSearchv2.Text = "File Explorer Search";
            btnSearchv2.Click += btnSearchv2_Click;
            // 
            // panelFooter
            // 
            panelFooter.BackColor = Color.FromArgb(32, 32, 32);
            panelFooter.BorderStyle = BorderStyle.FixedSingle;
            panelFooter.Controls.Add(btnTopMost);
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Location = new Point(0, 730);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new Size(1466, 30);
            panelFooter.TabIndex = 4;
            // 
            // btnTopMost
            // 
            btnTopMost.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnTopMost.AutoSize = true;
            btnTopMost.Cursor = Cursors.Hand;
            btnTopMost.ForeColor = Color.FromArgb(52, 152, 219);
            btnTopMost.Location = new Point(1324, 7);
            btnTopMost.Name = "btnTopMost";
            btnTopMost.Size = new Size(139, 15);
            btnTopMost.TabIndex = 0;
            btnTopMost.Text = "Program created by Yutti";
            btnTopMost.Click += btnTopMost_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 26);
            ClientSize = new Size(1466, 760);
            Controls.Add(panelFooter);
            Controls.Add(panelControls);
            Controls.Add(pictureBox);
            Controls.Add(panelHeader);
            Controls.Add(menuStrip);
            FormBorderStyle = FormBorderStyle.Sizable;
            MainMenuStrip = menuStrip;
            MinimumSize = new Size(1200, 600);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Yutti's Image Sorter";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            panelControls.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            panelFooter.ResumeLayout(false);
            panelFooter.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox;
        private Panel panelControls;
        private Button btnPickFolder;
        private Button btnPickDeliveryLocationYes;
        private Button btnPickDeliveryLocationNo;
        private Button btnYes;
        private Button btnNo;
        private Button btnReset;
        private Button btnClose;
        private Button btnToggleKeyInput;
        private Panel panelHeader;
        private Label lblPictureName;
        private Label lblAppTitle;
        private MenuStrip menuStrip;
        private ToolStripMenuItem saveLoadToolStripMenuItem;
        private ToolStripMenuItem btnSaveAs;
        private ToolStripMenuItem btnLoadAs;
        private ToolStripMenuItem btnSave;
        private ToolStripMenuItem btnLoad;
        private ToolStripMenuItem btnClearSaveData;
        private ToolStripMenuItem ExtraToolStripMenuItem;
        private ToolStripMenuItem btnSearch;
        private ToolStripMenuItem btnSearchv2;
        private ToolStripMenuItem btnSkipSimilar;
        private ToolStripMenuItem btnSkip;
        private ToolStripMenuItem btnResetSearch;
        private ToolStripMenuItem btnHidePictureBox;
        private Panel panelFooter;
        private Label btnTopMost;
        private ToolStripMenuItem btnSkipLayout;
    }
}