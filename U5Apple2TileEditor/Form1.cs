using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace U5Apple2TileEditor
{
    public partial class Form1 : Form
    {
        byte[] file_bytes = null;
        CheckBox[,] cbBSArray;
        CheckBox[,] cbArray;

        Color cGreen;
        Color cOrange;
        Color cPurple;
        Color cBlue;
        Bitmap origBMP;

        public Form1()
        {
            InitializeComponent();

            cGreen = Color.FromArgb(67, 195, 0); // green
            cOrange = Color.FromArgb(234, 93, 21); // orange
            cPurple = Color.FromArgb(182, 61, 255); // purple
            cBlue = Color.FromArgb(16, 164, 227); // blue
            origBMP = new Bitmap(14, 16);
        }

        private void btnTFBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult result = ofd.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                tbTileFile.Text = ofd.FileName;

                try
                {
                    file_bytes = File.ReadAllBytes(tbTileFile.Text);
                    if (file_bytes.Length == 0x4000)
                    {
                        lbTileSelect.Items.Clear();
                        for (int index = 0; index < 512; ++index)
                        {
                            string strItem = "Tile " + index;
                            lbTileSelect.Items.Add(strItem);
                        }
                        lbTileSelect.SelectedIndex = 0;
                    }
                }
                catch (IOException)
                {
                }
            }
        }

        private void lbTileSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null == file_bytes)
            {
                return;
            }

            enable_checkbox_refreshes(false);

            for (int xPos = 0; xPos < 2; xPos++)
            {
                for (int yPos = 0; yPos < 16; yPos++)
                {
                    cbBSArray[xPos, yPos].Checked = false;
                }
            }

            for (int xPos = 0; xPos < 14; xPos++)
            {
                for (int yPos = 0; yPos < 16; yPos++)
                {
                    cbArray[xPos, yPos].Checked = false;
                }
            }

            int curId = lbTileSelect.SelectedIndex;
            int offset = 0;
            if(curId >= 256)
            {
                offset = 0x2000;
                curId %= 256;
            }
            
            for(int hIndex = 0; hIndex < 2; hIndex++)
            {
                int tempOffset = curId + offset + (hIndex * 0x1000);
                int tempXOffset = hIndex * 7;

                for (int vIndex = 0; vIndex < 16; vIndex++)
                {
                    byte curByte = file_bytes[tempOffset];
                    int colorType = (curByte >> 7) & 0x01;

                    cbBSArray[hIndex, vIndex].Checked = colorType != 0;

                    for (int index = 0; index < 7; ++index)
                    {
                        int curBit = (curByte >> index) & 0x01;
                        cbArray[index + tempXOffset, vIndex].Checked = (curBit == 1);
                    }

                    tempOffset += 0x100;
                }
            }
            enable_checkbox_refreshes(true);
            for(int curRow = 0; curRow < 16; ++curRow)
            {
                for (int indexX = 0; indexX < 14; indexX++)
                {
                    setColor(indexX, curRow);
                }
            }

            pbTile.Refresh();
        }

        private void enable_checkbox_refreshes(bool bIsEnabled)
        {
            if(bIsEnabled)
            {
                for (int xPos = 0; xPos < 2; xPos++)
                {
                    for (int yPos = 0; yPos < 16; yPos++)
                    {
                        cbBSArray[xPos, yPos].CheckedChanged += Form1_CheckedChanged;
                    }
                }

                for (int xPos = 0; xPos < 14; xPos++)
                {
                    for (int yPos = 0; yPos < 16; yPos++)
                    {
                        cbArray[xPos, yPos].CheckedChanged += Form1_CheckedChanged;
                    }
                }
            }
            else
            {
                for (int xPos = 0; xPos < 2; xPos++)
                {
                    for (int yPos = 0; yPos < 16; yPos++)
                    {
                        cbBSArray[xPos, yPos].CheckedChanged -= Form1_CheckedChanged;
                    }
                }

                for (int xPos = 0; xPos < 14; xPos++)
                {
                    for (int yPos = 0; yPos < 16; yPos++)
                    {
                        cbArray[xPos, yPos].CheckedChanged -= Form1_CheckedChanged;
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbBSArray = new CheckBox[2, 16];

            for (int xPos = 0; xPos < 2; xPos++)
            {
                for (int yPos = 0; yPos < 16; yPos++)
                {
                    cbBSArray[xPos, yPos] = new CheckBox();
                    cbBSArray[xPos, yPos].Parent = gbAltPalette;
                    cbBSArray[xPos, yPos].Appearance = Appearance.Button;
                    cbBSArray[xPos, yPos].AutoSize = false;
                    cbBSArray[xPos, yPos].Size = new Size(16, 16);
                    cbBSArray[xPos, yPos].Text = "";
                    cbBSArray[xPos, yPos].Location = new Point(10 + (18 * xPos), 18 + (18 * yPos));
                    cbBSArray[xPos, yPos].CheckedChanged += Form1_CheckedChanged;
                    cbBSArray[xPos, yPos].Tag = new Point(xPos, yPos);
                }
            }

            cbArray = new CheckBox[14, 16];
            for (int xPos = 0; xPos < 14; xPos++)
            {
                for (int yPos = 0; yPos < 16; yPos++)
                {
                    cbArray[xPos, yPos] = new CheckBox();
                    cbArray[xPos, yPos].Parent = gbTileByteState;
                    cbArray[xPos, yPos].Appearance = Appearance.Button;
                    cbArray[xPos, yPos].AutoSize = false;
                    cbArray[xPos, yPos].Size = new Size(16, 16);
                    cbArray[xPos, yPos].Text = "";
                    cbArray[xPos, yPos].Location = new Point(10 + (18 * xPos), 18 + (18 * yPos));
                    cbArray[xPos, yPos].CheckedChanged += Form1_CheckedChanged;
                    cbArray[xPos, yPos].Tag = new Point(xPos, yPos);
                }
            }
            
        }

        private void setColor(int curCol, int curRow)
        {
            // No need to check out of bounds
            if(curCol < 0 || curCol > 13)
            {
                return;
            }
            bool bIsChecked = cbArray[curCol, curRow].Checked;
            int paletteVal = 0;
            bool nextVal = false;
            bool prevVal = false;

            if (curCol + 1 < 14)
            {
                nextVal = cbArray[curCol + 1, curRow].Checked;
            }
            if (curCol > 0)
            {
                prevVal = cbArray[curCol - 1, curRow].Checked;
            }

            if (curCol > 6)
            {
                paletteVal = 1;
            }
            bool bPaletteChecked = cbBSArray[paletteVal, curRow].Checked;
            if (bIsChecked)
            {
                if (!nextVal && !prevVal)
                {
                    origBMP.SetPixel(curCol, curRow, Color.White);
                    if (curCol % 2 == 0)
                    {
                        if (bPaletteChecked)
                        {
                            origBMP.SetPixel(curCol, curRow, cOrange);
                        }
                        else
                        {
                            origBMP.SetPixel(curCol, curRow, cGreen);
                        }
                    }
                    else
                    {
                        if (bPaletteChecked)
                        {
                            origBMP.SetPixel(curCol, curRow, cBlue);
                        }
                        else
                        {
                            origBMP.SetPixel(curCol, curRow, cPurple);
                        }
                    }
                }
                else
                {
                    origBMP.SetPixel(curCol, curRow, Color.White);
                }
            }
            else
            {
                if (nextVal && prevVal)
                {
                    // fringing occured
                    if (curCol % 2 == 0)
                    {
                        if (bPaletteChecked)
                        {
                            origBMP.SetPixel(curCol, curRow, cBlue);
                        }
                        else
                        {
                            origBMP.SetPixel(curCol, curRow, cPurple);
                        }
                       
                    }
                    else
                    {
                        if (bPaletteChecked)
                        {
                            origBMP.SetPixel(curCol, curRow, cOrange);
                        }
                        else
                        {
                            origBMP.SetPixel(curCol, curRow, cGreen);
                        }
                    }
                }
                else
                {
                    origBMP.SetPixel(curCol, curRow, Color.Black);
                }
            }
        }

        private void Form1_CheckedChanged(object sender, EventArgs e)
        {
            if(((CheckBox)sender).Tag != null)
            {
                if (((CheckBox)sender).Tag is Point)
                {
                    int curRow = (((Point)((CheckBox)sender).Tag)).Y;
                    for(int indexX = 0; indexX < 14; indexX++)
                    {
                        setColor(indexX, curRow);
                    }

                    pbTile.Refresh();
                }
            }
        }

        private void pbTile_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            e.Graphics.DrawImage(
                origBMP,
            new Rectangle(0, 0, pbTile.Width, pbTile.Height),
            // destination rectangle 
            0,
            0,           // upper-left corner of source rectangle
            origBMP.Width,       // width of source rectangle
            origBMP.Height,      // height of source rectangle
            GraphicsUnit.Pixel);
        }

        private void btnSaveTile_Click(object sender, EventArgs e)
        {
            if(file_bytes == null)
            {
                return;
            }

            int curId = lbTileSelect.SelectedIndex;
            int offset = 0;
            if (curId >= 256)
            {
                offset = 0x2000;
                curId %= 256;
            }

            for (int hIndex = 0; hIndex < 2; hIndex++)
            {
                int tempOffset = curId + offset + (hIndex * 0x1000);
                int tempXOffset = hIndex * 7;

               

                for (int vIndex = 0; vIndex < 16; vIndex++)
                {
                    byte curByte = 0;
                    int colorType = (curByte >> 7) & 0x01;

                    if(cbBSArray[hIndex, vIndex].Checked)
                    {
                        curByte = 1;
                    }

                    for (int index = 6; index >= 0; --index)
                    {
                        curByte <<= 1;
                        if(cbArray[index + tempXOffset, vIndex].Checked)
                        {
                            curByte |= 1;
                        }
                    }
                    file_bytes[tempOffset] = curByte;
                    tempOffset += 0x100;
                }
            }
        }

        private void btnSaveShapes_Click(object sender, EventArgs e)
        {
            if (file_bytes == null)
            {
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            DialogResult result = sfd.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                try
                {
                    using (BinaryWriter binWriter =
                        new BinaryWriter(File.Open(sfd.FileName, FileMode.Create)))
                    {
                        binWriter.Write(file_bytes);
                    }
                }
                catch (IOException ioexp)
                {
                    Console.WriteLine("Error: {0}", ioexp.Message);
                }
            }
        }
    }
}
