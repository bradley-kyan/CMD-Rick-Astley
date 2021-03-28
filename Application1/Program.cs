using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Text;
using System.Resources.Extensions;

namespace Application1
{
    class Program
    {
        static string currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        static void Main(string[] args)
        {
            Image image = Properties.Resources.mygif;
            FrameDimension dimension = new FrameDimension(
                               image.FrameDimensionsList[0]);
            int frameCount = image.GetFrameCount(dimension);
            StringBuilder sb;

            string lyrics = "Never Never Never Never Gonna Gonna Gonna Gonna Give Give Give Give Give You You You You You Up! Up! Up! Up! Up! Up! Up! Up! Up! Never Never Never Never Never Gonna Gonna Gonna Gonna Let Let Let Let Let You You You You You Down! Down! Down! Down! Down! Down! Down! Down! Down!";
            int lyric = 0;

            // Remember cursor position
            int left = Console.WindowLeft, top = Console.WindowTop;

            char[] chars = { '#', '#', '@', '%', '=', '+',
                         '*', ':', '-', '.', '"', '|', '<', '>', ' ' };
            for (int i = 0; ; i = (i + 1) % frameCount)
            {
                Console.Title = lyrics.Split(' ')[lyric];

                if (lyric == 54)
                {
                    lyric = 0;
                }
                else
                {
                    lyric++;
                }

                sb = new StringBuilder();
                image.SelectActiveFrame(dimension, i);

                for (int h = 0; h < image.Height; h++)
                {
                    for (int w = 0; w < image.Width; w++)
                    {
                        Color cl = ((Bitmap)image).GetPixel(w, h);
                        int gray = (cl.R + cl.G + cl.B) / 3;
                        int index = (gray * (chars.Length - 1)) / 255;

                        sb.Append(chars[index]);
                    }
                    sb.Append('\n');
                }

                Console.SetCursorPosition(left, top);
                Console.Write(sb.ToString());

                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
