using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"E:\Documents\cognex\Find Lines\test.txt");
            // Display the file contents by using a foreach loop.

            Console.WriteLine("\n" + "Lets get started");
            Field[,] pixels = new Field[lines.Length, lines[0].Length];
            Console.WriteLine("\n pixels.GetLength(0)" + pixels.GetLength(0) + " pixels.GetLength(1) " + pixels.GetLength(1));
            for (var index = 0; index < lines.Length; index++)
            {
                for (var jzso = 0; jzso < lines[index].Length; jzso++)
                {
                    Console.WriteLine("\n" + "lines[i][j]" + lines[index][jzso]);
                    pixels[index, jzso] = new Field((lines[index][jzso] - 48), index, jzso);
                }
            }

            var detectedLines = new List<Line> { };
            doHorizontalLineCheck(pixels, detectedLines);
        }

        public static void doHorizontalLineCheck(Field[,] pixels, List<Line> detectedLines)
        {
            if (detectedLines == null || detectedLines.Count == 0) { 
                detectedLines = new List<Line> { };

                var i = 0;
                while (i < pixels.GetLength(0))
                {
                    var j = 0;
                    while (j < pixels.GetLength(1))
                    {
                        Console.WriteLine("pixels[i, j].Value  i" + i + " j: " + j + " is " + pixels[i, j].Value);
                        if (pixels[i, j].Value == 1 && !pixels[i, j].checkedHorizontal)
                        {
                            Console.WriteLine("find a starter point: (" + i + "," + j + ")");
                            var lineLenght = 1;
                            var horizontalMovingIndex = j + 1;
                            while (horizontalMovingIndex < pixels.GetLength(1))
                            {
                                pixels[i, horizontalMovingIndex].checkedHorizontal = true;
                                if (pixels[i, horizontalMovingIndex].Value == 0)
                                {
                                    Console.WriteLine("find a line end");
                                    if (lineLenght > 1)
                                    {
                                        //előző pont volt a vége...
                                        detectedLines.Add(new Line(new Point(i, horizontalMovingIndex - 1), new Point(i, j)));
                                        Console.WriteLine("real line end: (" + i + "," + (horizontalMovingIndex - 1) + ")");
                                    }
                                    break;
                                }
                                if (pixels[i, horizontalMovingIndex].Value == 1)
                                {
                                    lineLenght++;
                                    if (horizontalMovingIndex == pixels.GetLength(1) - 1)
                                    {
                                        detectedLines.Add(new Line(new Point(i, horizontalMovingIndex), new Point(i, j)));
                                        Console.WriteLine("real line end on the end: (" + i + "," + (horizontalMovingIndex) + ")");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("find an middle point: i " + i + " j: " + j);
                                    }
                                }
                                horizontalMovingIndex++;
                            }
                            j = horizontalMovingIndex;
                        }
                        j++;
                    }
                    Console.WriteLine("End of  I cycle " + i);
                    i++;
                }
            }


        }
    }

    class Line
    {
        public Point start;
        public Point end;
        public Line(Point start, Point end)
        {
            this.start = start;
            this.end = end;
        }
    }

    class Field
    {
        public bool checkedHorizontal { get; set; } = false;
        public bool checkedVertical { get; set; } = false;
        public bool checkedSouthWest { get; set; } = false;
        public bool checkedSouthEath { get; set; } = false;
        public int Value = 0;
        public Point Position;

        public Field(int Value, int X, int Y)
        {
            this.Value = Value;
            this.Position = new Point(X, Y);
        }

    }

   
}
