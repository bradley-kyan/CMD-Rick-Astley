using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Text;

namespace Application1
{
    class Program
    {
        static void Main(string[] args)
        {
            Image image = Properties.Resources.mygif;
            FrameDimension dimension = new FrameDimension(
                               image.FrameDimensionsList[0]);
            int frameCount = image.GetFrameCount(dimension);

            string lyrics = "Never Never Never Never Gonna Gonna Gonna Gonna Give Give Give Give Give You You You You You Up! Up! Up! Up! Up! Up! Up! Up! Up! Never Never Never Never Never Gonna Gonna Gonna Gonna Let Let Let Let Let You You You You You Down! Down! Down! Down! Down! Down! Down! Down! Down!";
            int lyric = 0;


            // Remember cursor position
            int left = Console.WindowLeft, top = Console.WindowTop;

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
                string subtext = "SubmissiveAndBreedable ";
                string final = "";
                for (int r = 0; r < 20; r++)
                {
                    final += subtext;
                }
                char[] sub = final.ToCharArray();

                var submiss = new StringBuilder();
                int index2 = 0;

                image.SelectActiveFrame(dimension, i);

                for (int h = 0; h < image.Height; h++)
                {
                    for (int w = 0; w < image.Width; w++)
                    {
                        Color cl = ((Bitmap)image).GetPixel(w, h);
                        int gray = (cl.R + cl.G + cl.B) / 3;
                        int index = gray / 255;
                        if (index >= 1)
                            submiss.Append(' ');
                        else
                        {
                            submiss.Append(sub[index2]);
                            index2++;
                        }                      
                    }
                    submiss.Append('\n');
                    index2 = 0;
                }


                Console.SetCursorPosition(left, top);
                Console.Write(submiss.ToString());

                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
