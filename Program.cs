using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;

namespace LineDetection
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory()+"\\..\\..\\..\\Find Lines";
            string[] filePaths = { };
            if (args.Length == 0 && Directory.Exists(path))
            {
                filePaths = Directory.GetFiles(path);
            }
            else if (Directory.Exists(args[0]))
            {
                filePaths = Directory.GetFiles(args[0]);
            } else
            {
                Console.WriteLine("No valid file or directory was set.");
            }

            foreach (string filePath in filePaths)
                {
                    if (filePath.Contains("img"))
                    {
                        string[] lines = System.IO.File.ReadAllLines(filePath);
                        Pixel[,] pixels = new Pixel[lines.Length, lines[0].Length];

                        for (var index = 0; index < lines.Length; index++)
                        {
                            for (var jzso = 0; jzso < lines[index].Length; jzso++)
                            {
                                pixels[index, jzso] = new Pixel((lines[index][jzso] - 48), index, jzso);
                            }
                        }

                        var detectedLines = LineDetector.detectLines(pixels);
                        var filePathParts = filePath.Split("\\");
                        var fileName = filePathParts[filePathParts.Length - 1];
                        Line.printLines(fileName, detectedLines);

                    }
                }
            
        }

    }
}