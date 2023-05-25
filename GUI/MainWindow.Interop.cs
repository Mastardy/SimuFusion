using System;
using System.Runtime.InteropServices;
using System.Windows.Controls;
using System.Windows.Media;

namespace GUI;

public partial class MainWindow
{
    public Cell[,] Cells { get; set; } = new Cell[20, 20];
    
    [DllImport("CoreLib.dll")]
    internal static extern void RegisterAddCellToCanvasCallback(AddCellToCanvasDelegate addCellToCanvasDelegate);

    public delegate void AddCellToCanvasDelegate(CellInterop cellInterop);
    private AddCellToCanvasDelegate addCellToCanvasDelegate;
    
    public void AddCellToCanvas(CellInterop cellInterop)
    {
        var cell = new Cell(cellInterop);
        
        Cells[cell.X, cell.Y] = cell;
        
        mainCanvas.Dispatcher.Invoke(() =>
        {
            Canvas.SetLeft(cell.Rect, cell.X * cell.Rect.Width);
            Canvas.SetTop(cell.Rect, cell.Y * cell.Rect.Height);
            mainCanvas.Children.Add(cell.Rect);
        });
    }
    
    [DllImport("CoreLib.dll")]
    internal static extern void RegisterUpdateCellOnCanvasCallback(UpdateCellOnCanvasDelegate updateCellOnCanvasDelegate);
    
    public delegate void UpdateCellOnCanvasDelegate(int x, int y, IntPtr color);
    private UpdateCellOnCanvasDelegate updateCellOnCanvasDelegate;
    
    public void UpdateCellOnCanvas(int x, int y, IntPtr color)
    {
        Cell cell = Cells[x, y];

        cell.Rect.Dispatcher.Invoke(() =>
        {
            cell.Rect.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(Marshal.PtrToStringUni(color))!);
        });
    }
}