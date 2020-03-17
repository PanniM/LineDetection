using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LineDetection
{
    public class Line
    {
        public Point start;
        public Point end;
        public Line(Point start, Point end)
        {
            this.start = start;
            this.end = end;
        }

        public string toString() {
            return "(" + start.X + "," + start.Y + ") (" + end.X + "," + end.Y + ")";
        }

        public static string printLines(string fileName, List<Line> lines) {
            var allLinesInFileInHumanReadableFormat = fileName;
            foreach (Line line in lines)
            {
                allLinesInFileInHumanReadableFormat += " " + line.toString();
                
            }
            Console.WriteLine(allLinesInFileInHumanReadableFormat);
            //for test purposes
            return allLinesInFileInHumanReadableFormat;

        }
    }

   
}
