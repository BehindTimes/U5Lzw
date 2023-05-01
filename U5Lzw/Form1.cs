using System.Drawing;
using System.Security.Cryptography;
using System.Security.Policy;
using static System.Net.Mime.MediaTypeNames;

namespace U5Lzw
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();       
        }

        private void btnBrowseTiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult result = ofd.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                tbTiles.Text = ofd.FileName;
            }
        }

        private void btnBrowsePic_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            DialogResult result = sfd.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                tbOutput.Text = sfd.FileName;
            }
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] file_bytes = File.ReadAllBytes(tbTiles.Text);
                if (file_bytes.Length > 0)
                {
                    lzwdecompressor lzw = new lzwdecompressor();

                    if (rbCompress.Checked)
                    {
                        lzw.compress(file_bytes, tbOutput.Text);
                    }
                    else
                    {
                        lzw.extract(file_bytes, tbOutput.Text);
                    }  
                }
            }
            catch (IOException)
            {
            }
        }

        private void rbCompress_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCompress.Checked)
            {
                lblTileName.Text = "Tiles.lzw Location:";
                lblOutput.Text = "Output Tiles.16 File:";
                btnExtract.Text = "Compress";
            }
        }

        private void rbExtract_CheckedChanged(object sender, EventArgs e)
        {
            if (rbExtract.Checked)
            {
                lblTileName.Text = "Tiles.16 Location:";
                lblOutput.Text = "Output Tiles.lzw File:";
                btnExtract.Text = "Extract";
            }
        }
    }
}