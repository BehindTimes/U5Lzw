namespace U5Lzw
{
    partial class Form1
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
            tbTiles = new TextBox();
            lblTileName = new Label();
            lblOutput = new Label();
            tbOutput = new TextBox();
            btnExtract = new Button();
            btnBrowseTiles = new Button();
            btnBrowsePic = new Button();
            rbCompress = new RadioButton();
            rbExtract = new RadioButton();
            SuspendLayout();
            // 
            // tbTiles
            // 
            tbTiles.Location = new Point(128, 12);
            tbTiles.Name = "tbTiles";
            tbTiles.Size = new Size(293, 23);
            tbTiles.TabIndex = 0;
            // 
            // lblTileName
            // 
            lblTileName.AutoSize = true;
            lblTileName.Location = new Point(12, 15);
            lblTileName.Name = "lblTileName";
            lblTileName.Size = new Size(97, 15);
            lblTileName.TabIndex = 1;
            lblTileName.Text = "Tiles.16 Location:";
            // 
            // lblOutput
            // 
            lblOutput.AutoSize = true;
            lblOutput.Location = new Point(12, 45);
            lblOutput.Name = "lblOutput";
            lblOutput.Size = new Size(115, 15);
            lblOutput.TabIndex = 2;
            lblOutput.Text = "Output Tiles.lzw File:";
            // 
            // tbOutput
            // 
            tbOutput.Location = new Point(128, 42);
            tbOutput.Name = "tbOutput";
            tbOutput.Size = new Size(293, 23);
            tbOutput.TabIndex = 3;
            // 
            // btnExtract
            // 
            btnExtract.Location = new Point(427, 95);
            btnExtract.Name = "btnExtract";
            btnExtract.Size = new Size(75, 23);
            btnExtract.TabIndex = 4;
            btnExtract.Text = "Extract";
            btnExtract.UseVisualStyleBackColor = true;
            btnExtract.Click += btnExtract_Click;
            // 
            // btnBrowseTiles
            // 
            btnBrowseTiles.Location = new Point(427, 12);
            btnBrowseTiles.Name = "btnBrowseTiles";
            btnBrowseTiles.Size = new Size(75, 23);
            btnBrowseTiles.TabIndex = 6;
            btnBrowseTiles.Text = "Browse...";
            btnBrowseTiles.UseVisualStyleBackColor = true;
            btnBrowseTiles.Click += btnBrowseTiles_Click;
            // 
            // btnBrowsePic
            // 
            btnBrowsePic.Location = new Point(427, 41);
            btnBrowsePic.Name = "btnBrowsePic";
            btnBrowsePic.Size = new Size(75, 23);
            btnBrowsePic.TabIndex = 7;
            btnBrowsePic.Text = "Browse...";
            btnBrowsePic.UseVisualStyleBackColor = true;
            btnBrowsePic.Click += btnBrowsePic_Click;
            // 
            // rbCompress
            // 
            rbCompress.AutoSize = true;
            rbCompress.Location = new Point(128, 99);
            rbCompress.Name = "rbCompress";
            rbCompress.Size = new Size(78, 19);
            rbCompress.TabIndex = 9;
            rbCompress.Text = "Compress";
            rbCompress.UseVisualStyleBackColor = true;
            rbCompress.CheckedChanged += rbCompress_CheckedChanged;
            // 
            // rbExtract
            // 
            rbExtract.AutoSize = true;
            rbExtract.Checked = true;
            rbExtract.Location = new Point(12, 99);
            rbExtract.Name = "rbExtract";
            rbExtract.Size = new Size(61, 19);
            rbExtract.TabIndex = 8;
            rbExtract.TabStop = true;
            rbExtract.Text = "Extract";
            rbExtract.UseVisualStyleBackColor = true;
            rbExtract.CheckedChanged += rbExtract_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(518, 137);
            Controls.Add(rbCompress);
            Controls.Add(rbExtract);
            Controls.Add(btnBrowsePic);
            Controls.Add(btnBrowseTiles);
            Controls.Add(btnExtract);
            Controls.Add(tbOutput);
            Controls.Add(lblOutput);
            Controls.Add(lblTileName);
            Controls.Add(tbTiles);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbTiles;
        private Label lblTileName;
        private Label lblOutput;
        private TextBox tbOutput;
        private Button btnExtract;
        private Button btnBrowseTiles;
        private Button btnBrowsePic;
        private RadioButton rbCompress;
        private RadioButton rbExtract;
    }
}