﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U5AppleTiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppleExtractor ae = new AppleExtractor();
            string strFile = "F:\\source\\U5Lzw\\U5AppleTiles\\SHAPES.BAK";
            string strPng = "F:\\source\\U5Lzw\\U5AppleTiles\\SHAPES.PNG";
            ae.Extract(strFile, strPng);
        }
    }
}
