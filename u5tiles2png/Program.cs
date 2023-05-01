// See https://aka.ms/new-console-template for more information
using u5tiles2png;

if(args.Length != 3)
{
    Console.WriteLine("Usage: u5tiles2png <lzw file> <png file> <c/e>");
    Console.WriteLine("\tc = Compress");
    Console.WriteLine("\te = Extract");
    return;
}

string lzwfile = args[0];
string pngfile = args[1];
string isCompress = args[2];

PNGHelper helper = new PNGHelper();

if ("c" == isCompress)
{
    helper.makeLZW(lzwfile, pngfile);
}
else if("e" == isCompress)
{
    helper.makePng(lzwfile, pngfile);
}
else
{
    Console.WriteLine("Usage: u5tiles2png <lzw file> <png file> <c/e>");
    Console.WriteLine("\tc = Compress");
    Console.WriteLine("\te = Extract");
}

