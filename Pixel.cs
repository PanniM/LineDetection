using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LineDetection
{
    public class Pixel
    {
        public bool checkedHorizontal { get; set; } = false;
        public bool checkedVertical { get; set; } = false;
        public bool checkedSouthWest { get; set; } = false;
        public bool checkedSouthEath { get; set; } = false;
        public int Value = 0;
        public Point Position;

        public Pixel(int Value, int X, int Y)
        {
            this.Value = Value;
            this.Position = new Point(X, Y);
        }

    }
}
