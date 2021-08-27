using System;
using System.Drawing;

namespace convert
{
    class Program
    {
        static void Main(string[] args)
        {
            Image image = Properties.Resources.mygif;
            Console.Write(converterDemo(image));
        }

        public static byte[] converterDemo(Image x)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
        }

    }
}
