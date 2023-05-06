namespace U5Apple2TileEditor
{
    partial class Form1
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
            this.lblTileFile = new System.Windows.Forms.Label();
            this.tbTileFile = new System.Windows.Forms.TextBox();
            this.btnTFBrowse = new System.Windows.Forms.Button();
            this.lbTileSelect = new System.Windows.Forms.ListBox();
            this.gbTileByteState = new System.Windows.Forms.GroupBox();
            this.pbTile = new System.Windows.Forms.PictureBox();
            this.gbAltPalette = new System.Windows.Forms.GroupBox();
            this.gbImage = new System.Windows.Forms.GroupBox();
            this.btnSaveTile = new System.Windows.Forms.Button();
            this.btnSaveShapes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbTile)).BeginInit();
            this.gbImage.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTileFile
            // 
            this.lblTileFile.AutoSize = true;
            this.lblTileFile.Location = new System.Drawing.Point(12, 13);
            this.lblTileFile.Name = "lblTileFile";
            this.lblTileFile.Size = new System.Drawing.Size(72, 13);
            this.lblTileFile.TabIndex = 0;
            this.lblTileFile.Text = "SHAPES File:";
            // 
            // tbTileFile
            // 
            this.tbTileFile.Location = new System.Drawing.Point(87, 10);
            this.tbTileFile.Name = "tbTileFile";
            this.tbTileFile.ReadOnly = true;
            this.tbTileFile.Size = new System.Drawing.Size(341, 20);
            this.tbTileFile.TabIndex = 1;
            // 
            // btnTFBrowse
            // 
            this.btnTFBrowse.Location = new System.Drawing.Point(434, 8);
            this.btnTFBrowse.Name = "btnTFBrowse";
            this.btnTFBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnTFBrowse.TabIndex = 2;
            this.btnTFBrowse.Text = "Browse...";
            this.btnTFBrowse.UseVisualStyleBackColor = true;
            this.btnTFBrowse.Click += new System.EventHandler(this.btnTFBrowse_Click);
            // 
            // lbTileSelect
            // 
            this.lbTileSelect.FormattingEnabled = true;
            this.lbTileSelect.Location = new System.Drawing.Point(15, 46);
            this.lbTileSelect.Name = "lbTileSelect";
            this.lbTileSelect.Size = new System.Drawing.Size(174, 342);
            this.lbTileSelect.TabIndex = 3;
            this.lbTileSelect.SelectedIndexChanged += new System.EventHandler(this.lbTileSelect_SelectedIndexChanged);
            // 
            // gbTileByteState
            // 
            this.gbTileByteState.Location = new System.Drawing.Point(284, 46);
            this.gbTileByteState.Name = "gbTileByteState";
            this.gbTileByteState.Size = new System.Drawing.Size(268, 312);
            this.gbTileByteState.TabIndex = 6;
            this.gbTileByteState.TabStop = false;
            this.gbTileByteState.Text = "Tile Byte State";
            // 
            // pbTile
            // 
            this.pbTile.Location = new System.Drawing.Point(21, 34);
            this.pbTile.Name = "pbTile";
            this.pbTile.Size = new System.Drawing.Size(224, 256);
            this.pbTile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTile.TabIndex = 7;
            this.pbTile.TabStop = false;
            this.pbTile.Paint += new System.Windows.Forms.PaintEventHandler(this.pbTile_Paint);
            // 
            // gbAltPalette
            // 
            this.gbAltPalette.Location = new System.Drawing.Point(208, 46);
            this.gbAltPalette.Name = "gbAltPalette";
            this.gbAltPalette.Size = new System.Drawing.Size(70, 312);
            this.gbAltPalette.TabIndex = 7;
            this.gbAltPalette.TabStop = false;
            this.gbAltPalette.Text = "Alt Palette";
            // 
            // gbImage
            // 
            this.gbImage.Controls.Add(this.pbTile);
            this.gbImage.Location = new System.Drawing.Point(558, 46);
            this.gbImage.Name = "gbImage";
            this.gbImage.Size = new System.Drawing.Size(268, 312);
            this.gbImage.TabIndex = 7;
            this.gbImage.TabStop = false;
            this.gbImage.Text = "Image";
            // 
            // btnSaveTile
            // 
            this.btnSaveTile.Location = new System.Drawing.Point(751, 368);
            this.btnSaveTile.Name = "btnSaveTile";
            this.btnSaveTile.Size = new System.Drawing.Size(75, 23);
            this.btnSaveTile.TabIndex = 8;
            this.btnSaveTile.Text = "Save Tile";
            this.btnSaveTile.UseVisualStyleBackColor = true;
            this.btnSaveTile.Click += new System.EventHandler(this.btnSaveTile_Click);
            // 
            // btnSaveShapes
            // 
            this.btnSaveShapes.Location = new System.Drawing.Point(751, 10);
            this.btnSaveShapes.Name = "btnSaveShapes";
            this.btnSaveShapes.Size = new System.Drawing.Size(75, 23);
            this.btnSaveShapes.TabIndex = 9;
            this.btnSaveShapes.Text = "Save File";
            this.btnSaveShapes.UseVisualStyleBackColor = true;
            this.btnSaveShapes.Click += new System.EventHandler(this.btnSaveShapes_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 403);
            this.Controls.Add(this.btnSaveShapes);
            this.Controls.Add(this.btnSaveTile);
            this.Controls.Add(this.gbImage);
            this.Controls.Add(this.gbAltPalette);
            this.Controls.Add(this.gbTileByteState);
            this.Controls.Add(this.lbTileSelect);
            this.Controls.Add(this.btnTFBrowse);
            this.Controls.Add(this.tbTileFile);
            this.Controls.Add(this.lblTileFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbTile)).EndInit();
            this.gbImage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTileFile;
        private System.Windows.Forms.TextBox tbTileFile;
        private System.Windows.Forms.Button btnTFBrowse;
        private System.Windows.Forms.ListBox lbTileSelect;
        private System.Windows.Forms.GroupBox gbTileByteState;
        private System.Windows.Forms.PictureBox pbTile;
        private System.Windows.Forms.GroupBox gbAltPalette;
        private System.Windows.Forms.GroupBox gbImage;
        private System.Windows.Forms.Button btnSaveTile;
        private System.Windows.Forms.Button btnSaveShapes;
    }
}

