using System;
using System.Runtime.InteropServices;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GUI
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CellInterop
    {
        public readonly int X;
        public readonly int Y;
        public readonly double Width;
        public readonly double Height;
        public IntPtr FillColor;
    }
    
    public struct Cell
    {
        public int X { get; }
        public int Y { get; }
        public Rectangle Rect { get; }

        public Cell(CellInterop cellInterop)
        {
            X = cellInterop.X;
            Y = cellInterop.Y;
            Rect = new Rectangle
            {
                Width = cellInterop.Width,
                Height = cellInterop.Height,
                Fill = new SolidColorBrush((Color) ColorConverter.ConvertFromString(Marshal.PtrToStringUni(cellInterop.FillColor))!)
            };
        }
    }
}