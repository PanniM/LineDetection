using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LineDetection
{
    public class LineDetector
    {
        public static List<Line> detectLines(Pixel[,] pixels)
        {
            var detectedLines = new List<Line> { };
            detectHorizontalLines(pixels, detectedLines);
            detectVerticalLines(pixels, detectedLines);
            detectSouthEathDiagonalLines(pixels, detectedLines);
            detectSouthWestDiagonalLines(pixels, detectedLines);
            return detectedLines;
        }

        //TODO Checholni edgere meg megnézni mia  szarért nem működik!
        public static void detectSouthEathDiagonalLines(Pixel[,] pixels, List<Line> detectedLines)
        {
            if (detectedLines == null)
            {
                detectedLines = new List<Line> { };
            }

            var i = 0;
            while (i < pixels.GetLength(0))
            {
                var j = 0;
                while (j < pixels.GetLength(1))
                {
                    if (pixels[i, j].Value == 1 && !pixels[i, j].checkedSouthEath)
                    {
                        var lineLenght = 1;
                        var movingIndex = 1;
                        var start = new Point(j, i);
                        while ((i + movingIndex) < pixels.GetLength(0) && (j + movingIndex) < pixels.GetLength(1))
                        {
                            pixels[i + movingIndex, j + movingIndex].checkedSouthEath = true;
                            if (pixels[i + movingIndex, j + movingIndex].Value == 0)
                            {
                                if (lineLenght > 1)
                                {
                                    //előző pont volt a vége...
                                    detectedLines.Add(new Line(start, new Point(j + movingIndex - 1, i + movingIndex - 1)));
                                }
                                break;
                            }
                            if (pixels[i + movingIndex, j + movingIndex].Value == 1)
                            {
                                lineLenght++;
                                if ((i + movingIndex) == pixels.GetLength(0) - 1 || (j + movingIndex) == pixels.GetLength(1) - 1)
                                {
                                    detectedLines.Add(new Line(start, new Point(j + movingIndex, i + movingIndex)));
                                    break;
                                }
                            }
                            movingIndex++;
                        }
                    }
                    j++;
                }
                i++;
            }
        }


        public static void detectSouthWestDiagonalLines(Pixel[,] pixels, List<Line> detectedLines)
        {
            if (detectedLines == null)
            {
                detectedLines = new List<Line> { };
            }

            var i = 0;
            while (i < pixels.GetLength(0))
            {
                var j = pixels.GetLength(1) - 1;
                while (j >= 0)
                {
                    if (pixels[i, j].Value == 1 && !pixels[i, j].checkedSouthWest)
                    {
                        var lineLenght = 1;
                        var movingIndex = 1;
                        var start = new Point(j,i);
                        while ((i + movingIndex) < pixels.GetLength(0) && (j - movingIndex) >= 0)
                        {
                            pixels[i + movingIndex, j - movingIndex].checkedSouthWest = true;
                            if (pixels[i + movingIndex, j - movingIndex].Value == 0)
                            {
                                if (lineLenght > 1)
                                {
                                    detectedLines.Add(new Line(start, new Point(j - movingIndex +1, i + movingIndex - 1)));
                                }
                                break;
                            }
                            if (pixels[i + movingIndex, j - movingIndex].Value == 1)
                            {
                                lineLenght++;
                                if ((i + movingIndex) == pixels.GetLength(0) - 1 || (j - movingIndex) == 0)
                                {
                                    detectedLines.Add(new Line(start, new Point(j - movingIndex, i + movingIndex)));
                                    break;
                                }
                            }
                            movingIndex++;
                        }
                    }
                    j--;
                }
                i++;
            }
        }

        public static void detectVerticalLines(Pixel[,] pixels, List<Line> detectedLines)
        {

            if (detectedLines == null)
            {
                detectedLines = new List<Line> { };
            }

            var j = 0;
            while (j < pixels.GetLength(1))
            {
                var i = 0;
                while (i < pixels.GetLength(0))
                {
                    if (pixels[i, j].Value == 1 && !pixels[i, j].checkedVertical)
                    {
                        var lineLenght = 1;
                        var verticalMovingIndex = i + 1;
                        var start = new Point(j, i);
                        while (verticalMovingIndex < pixels.GetLength(0))
                        {
                            pixels[verticalMovingIndex, j].checkedVertical = true;
                            if (pixels[verticalMovingIndex, j].Value == 0)
                            {
                                if (lineLenght > 1)
                                {
                                    //előző pont volt a vége...
                                    detectedLines.Add(new Line(start, new Point(j, verticalMovingIndex - 1)));
                                }
                                break;
                            }
                            if (pixels[verticalMovingIndex, j].Value == 1)
                            {
                                lineLenght++;
                                if (verticalMovingIndex == pixels.GetLength(0) - 1)
                                {
                                    detectedLines.Add(new Line(start, new Point(j, verticalMovingIndex)));
                                    break;
                                }
                            }
                            verticalMovingIndex++;
                        }
                    }
                    i++;
                }
                j++;
            }

        }

        public static void detectHorizontalLines(Pixel[,] pixels, List<Line> detectedLines)
        {
            if (detectedLines == null)
            {
                detectedLines = new List<Line> { };
            }

            var i = 0;
            while (i < pixels.GetLength(0))
            {
                var j = 0;
                while (j < pixels.GetLength(1))
                {
                    if (pixels[i, j].Value == 1 && !pixels[i, j].checkedHorizontal)
                    {
                        var lineLenght = 1;
                        var horizontalMovingIndex = j + 1;
                        var start = new Point(j, i);
                        while (horizontalMovingIndex < pixels.GetLength(1))
                        {
                            pixels[i, horizontalMovingIndex].checkedHorizontal = true;
                            if (pixels[i, horizontalMovingIndex].Value == 0)
                            {
                                if (lineLenght > 1)
                                {
                                    //előző pont volt a vége...
                                    detectedLines.Add(new Line(start, new Point(horizontalMovingIndex - 1, i)));
                                }
                                break;
                            }
                            if (pixels[i, horizontalMovingIndex].Value == 1)
                            {
                                lineLenght++;
                                if (horizontalMovingIndex == pixels.GetLength(1) - 1)
                                {
                                    detectedLines.Add(new Line(start, new Point(horizontalMovingIndex, i)));
                                    break;
                                }
                            }
                            horizontalMovingIndex++;
                        }
                    }
                    j++;
                }
                i++;
            }

        }
    }


}
