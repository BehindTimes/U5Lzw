using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace u5tiles2png
{
    internal class PNGHelper
    {
        Color[] color_array = {
            Color.FromArgb(0, 0, 0),        //black
            Color.FromArgb(0, 0, 160),      //dark blue
            Color.FromArgb(0, 160, 0),      //dark green
            Color.FromArgb(0, 160, 160),    //blue green
            Color.FromArgb(160, 0, 0),      //maroon
            Color.FromArgb(160, 0, 160),    //dark purple
            Color.FromArgb(160, 80, 0),    //brown
            Color.FromArgb(160, 160, 160),  //light grey
            Color.FromArgb(80, 80, 80),     //dark grey
            Color.FromArgb(0, 0, 255),      //blue
            Color.FromArgb(80, 255, 80),    //light green
            Color.FromArgb(80, 255, 255),   //light blue
            Color.FromArgb(255, 80, 80),    //light red
            Color.FromArgb(255, 80, 255),   //light purple
            Color.FromArgb(255, 255, 80),   //yellow
            Color.FromArgb(255, 255, 255)   //white
        };

        private Color GetColor(byte curByte)
        {
            Color pixColor = Color.Black;

            if(curByte < 16)
            {
                pixColor = color_array[curByte];
            }

            return pixColor;
        }

        private byte GetByte(Color curColor)
        {
            int retval = Array.IndexOf(color_array, curColor);
            if(retval < 0)
            {
                retval = 0;
            }
            return (byte)retval;
        }

        public void LoadImage(byte[] file_bytes, Bitmap b)
        {
            for (int y_index = 0; y_index < 16; ++y_index)
            {
                for (int x_index = 0; x_index < 32; ++x_index)
                {
                    long cur_tile = (y_index * 32 + x_index) * 128;
                    for (int pix_y_index = 0; pix_y_index < 16; ++pix_y_index)
                    {
                        for (int pix_x_index = 0; pix_x_index < 8; ++pix_x_index)
                        {
                            byte cur_byte = file_bytes[cur_tile + ((pix_y_index * 8) + pix_x_index)];
                            byte b1 = (byte)((cur_byte >> 4) & 0xF);
                            byte b2 = (byte)(cur_byte & 0xF);

                            Color pixColor1 = GetColor(b1);
                            Color pixColor2 = GetColor(b2);

                            b.SetPixel((x_index * 16) + pix_x_index * 2, (y_index * 16) + pix_y_index, pixColor1);
                            b.SetPixel((x_index * 16) + pix_x_index * 2 + 1, (y_index * 16) + pix_y_index, pixColor2);
                        }
                    }
                }
            }
        }

        public void makePng(string strFile, string strPng)
        {
            try
            {
                byte[] file_bytes = File.ReadAllBytes(strFile);
                if (file_bytes.Length != 65536)
                {
                    Console.WriteLine("Tile.16 size must be 65536!");
                    return;
                }
                using (Bitmap b = new Bitmap(512, 256))
                {
                    LoadImage(file_bytes, b);
                    b.Save(strPng, System.Drawing.Imaging.ImageFormat.Png);
                    Console.WriteLine("Image Created");
                }
            }
            catch (IOException)
            {
                Console.WriteLine("LZW file does not exist!");
                return;
            }
        }

        public void WriteImage(byte[] file_bytes, Bitmap b)
        {
            for (int y_index = 0; y_index < 16; ++y_index)
            {
                for (int x_index = 0; x_index < 32; ++x_index)
                {
                    long cur_tile = (y_index * 32 + x_index) * 128;
                    for (int pix_y_index = 0; pix_y_index < 16; ++pix_y_index)
                    {
                        for (int pix_x_index = 0; pix_x_index < 16; pix_x_index += 2)
                        {
                            Color color1 = b.GetPixel((x_index * 16) + pix_x_index, (y_index * 16) + pix_y_index);
                            Color color2 = b.GetPixel((x_index * 16) + pix_x_index + 1, (y_index * 16) + pix_y_index);

                            byte b1 = (byte)((GetByte(color1) << 4) & 0xF0);
                            byte b2 = (byte)(GetByte(color2) & 0x0F);

                            byte outbyte = (byte)(b1 + b2);
                            file_bytes[cur_tile + ((pix_y_index * 8) + (pix_x_index / 2))] = outbyte;
                        }
                    }
                }
            }
        }

        public void makeLZW(string strFile, string strPng)
        {
            try
            {
                Bitmap image = (Bitmap)Image.FromFile(strPng);
                if(image.Height != 256 && image.Width != 512)
                {
                    Console.WriteLine("Image must be 512x256 pixels!");
                    return;
                }
                using (BinaryWriter binWriter =
                    new BinaryWriter(File.Open(strFile, FileMode.Create)))
                {
                    byte[] destination = new byte[256 * 256];
                    WriteImage(destination, image);
                    binWriter.Write(destination);
                    Console.WriteLine("LZW Created");
                }
            }
            catch (IOException)
            {
                Console.WriteLine("PNG file does not exist!");
                return;
            }
        }
    }
}
