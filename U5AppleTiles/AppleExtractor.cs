using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U5AppleTiles
{
    internal class AppleExtractor
    {
        public void Extract(string strFile, string strPng)
        {
            try
            {
                byte[] file_bytes = File.ReadAllBytes(strFile);
                if (file_bytes.Length != 0x4000)
                {
                    Console.WriteLine("SHAPES size must be 16384!");
                    return;
                }
                using (Bitmap b = new Bitmap(448, 256))
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

        public void LoadImage(byte[] file_bytes, Bitmap b)
        {
            for(int z_index = 0; z_index < 4; ++z_index)
            {
                for (int y_index = 0; y_index < 0x10; ++y_index)
                {
                    for (int x_index = 0; x_index < 0x100; ++x_index)
                    {
                        int pos = (z_index * 0x1000) + (y_index * 0x100) + x_index;
                        byte curByte = file_bytes[pos];
                        int colorType = (curByte >> 7) & 0x01;
                        for (int index = 0; index < 7; ++index)
                        {
                            int prevBit = -1;
                            int nextBit = -1;
                            int curBit = (curByte >> index) & 0x01;
                            if (index > 0)
                            {
                                int tmpIndex = (index - 1);
                                prevBit = (curByte >> tmpIndex) & 0x01;
                            }
                            else
                            {
                                if(z_index % 2 != 0)
                                {
                                    int temppos = ((z_index - 1) * 0x1000) + (y_index * 0x100) + x_index;
                                    byte tempByte = file_bytes[temppos];
                                    prevBit = (tempByte >> 6) & 0x01;
                                }
                            }
                            if (index < 6)
                            {
                                int tmpIndex = (index + 1);
                                nextBit = (curByte >> tmpIndex) & 0x01;
                            }
                            else
                            {
                                if (z_index % 2 == 0)
                                {
                                    int temppos = ((z_index + 1) * 0x1000) + (y_index * 0x100) + x_index;
                                    byte tempByte = file_bytes[temppos];
                                    nextBit = tempByte & 0x01;
                                }
                            }
                            Color newColor = Color.Black;

                            if (z_index % 2 == 0) // The left side
                            {
                                if (curBit == 0)
                                {
                                    if (nextBit == 1 && prevBit == 1)
                                    {
                                        if (index % 2 != 0) // color is green/orange
                                        {
                                            if (colorType == 0)
                                            {
                                                newColor = Color.FromArgb(67, 195, 0); // green
                                            }
                                            else
                                            {
                                                newColor = Color.FromArgb(234, 93, 21); // orange
                                            }
                                        }
                                        else // color is purple/blue
                                        {
                                            if (colorType == 0)
                                            {
                                                newColor = Color.FromArgb(182, 61, 255); // purple
                                            }
                                            else
                                            {
                                                newColor = Color.FromArgb(16, 164, 227); // blue
                                            }
                                        }
                                    }
                                    else // color is black
                                    {
                                        newColor = Color.Black;
                                    }
                                }
                                else
                                {
                                    if (nextBit == 1 || prevBit == 1) // color is white
                                    {
                                        newColor = Color.White;
                                    }
                                    else if (index % 2 != 0) // color is purple/blue
                                    {
                                        if (colorType == 0)
                                        {
                                            newColor = Color.FromArgb(182, 61, 255); // purple
                                        }
                                        else
                                        {
                                            newColor = Color.FromArgb(16, 164, 227); // blue
                                        }
                                    }
                                    else // color is green/orange
                                    {
                                        if (colorType == 0)
                                        {
                                            newColor = Color.FromArgb(67, 195, 0); // green
                                        }
                                        else
                                        {
                                            newColor = newColor = Color.FromArgb(234, 93, 21); // orange
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (curBit == 0)
                                {
                                    if (nextBit == 1 && prevBit == 1)
                                    {
                                        if (index % 2 == 0) // color is green/orange
                                        {
                                            if (colorType == 0)
                                            {
                                                newColor = Color.FromArgb(67, 195, 0); // green
                                            }
                                            else
                                            {
                                                newColor = newColor = Color.FromArgb(234, 93, 21); // orange
                                            }
                                        }
                                        else // color is purple/blue
                                        {
                                            if (colorType == 0)
                                            {
                                                newColor = Color.FromArgb(182, 61, 255); // purple
                                            }
                                            else
                                            {
                                                newColor = Color.FromArgb(16, 164, 227); // blue
                                            }
                                        }
                                    }
                                    else // color is black
                                    {
                                        newColor = Color.Black;
                                    }
                                }
                                else
                                {
                                    if (nextBit == 1 || prevBit == 1) // color is white
                                    {
                                        newColor = Color.White;
                                    }
                                    else if (index % 2 == 0) // color is purple/blue
                                    {
                                        if (colorType == 0)
                                        {
                                            newColor = Color.FromArgb(182, 61, 255); // purple
                                        }
                                        else
                                        {
                                            newColor = Color.FromArgb(16, 164, 227); // blue
                                        }
                                    }
                                    else // color is green/orange
                                    {
                                        if (colorType == 0)
                                        {
                                            newColor = Color.FromArgb(67, 195, 0); // green
                                        }
                                        else
                                        {
                                            newColor = newColor = Color.FromArgb(234, 93, 21); // orange
                                        }
                                    }
                                }
                            }
                                
                            
                            if(z_index % 2 == 0) // The left side
                            {
                                // image size is 896x128
                                int curX = (x_index * 14) + index;
                                int curY = (z_index * 0x10) + y_index;

                                if(curX >= 1792)
                                {
                                    curX -= 1792;
                                    curY += 16;
                                }

                                // correct the line it's on
                                int tmpY = curY / 16;
                                int tmpX = curX / 448;

                                curX %= 448;
                                curY %= 16;
                                curY += tmpX * 16;
                                curY += tmpY * 64;

                                b.SetPixel(curX, curY, newColor);

                            }
                            else // The right side
                            {
                                int curX = (x_index * 14) + index + 7;
                                int curY = ((z_index - 1) * 0x10) + y_index;

                                if (curX >= 1792)
                                {
                                    curX -= 1792;
                                    curY += 16;
                                }

                                // correct the line it's on
                                int tmpY = curY / 16;
                                int tmpX = curX / 448;

                                curX %= 448;
                                curY %= 16;
                                curY += tmpX * 16;
                                curY += tmpY * 64;

                                b.SetPixel(curX, curY, newColor);
                            }
                        }
                    }
                }
            }
            
        }
    }
}
