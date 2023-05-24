using System;
using System.Runtime.InteropServices;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GUI
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct CellInterop
    {
        public readonly int X;
        public readonly int Y;
        public readonly double Width;
        public readonly double Height;
        public IntPtr FillColor;
            
        [DllImport("CoreLib.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern CellInterop CreateCell(int x, int y, double width, double height);

        [DllImport("CoreLib.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr CreateCells(int horizontalAmount, int verticalAmount, double canvasWidth, double canvasHeight);
    }
    
    public struct Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Rectangle Rect { get; set; }

        internal static Cell MarshalCell(CellInterop cellInterop)
        {
            return new Cell
            {
                X = cellInterop.X,
                Y = cellInterop.Y,
                Rect = new Rectangle
                {
                    Width = cellInterop.Width,
                    Height = cellInterop.Height,
                    Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(Marshal.PtrToStringUni(cellInterop.FillColor))!)
                }
            };
        }

        public static Cell[] CreateCells(int horizontalAmount, int verticalAmount, double canvasWidth, double canvasHeight)
        {
            var cells = new Cell[horizontalAmount * verticalAmount];
            var cellInterop = CellInterop.CreateCells(horizontalAmount, verticalAmount, canvasWidth, canvasHeight);
            
            for (int i = 0; i < cells.Length; i++)
            {
                cells[i] = MarshalCell(Marshal.PtrToStructure<CellInterop>(cellInterop + i * Marshal.SizeOf<CellInterop>()));
            }

            return cells;
        }
    }
}