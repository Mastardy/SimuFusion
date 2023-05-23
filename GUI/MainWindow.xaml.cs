using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            Loaded += OnLoad;
        }

        public void OnLoad(object sender, RoutedEventArgs eventArgs)
        {
            var horizontalAmount = 50;
            var verticalAmount = 50;
            
            var cellWidth = mainCanvas.ActualWidth/horizontalAmount;
            var cellHeight = mainCanvas.ActualHeight/verticalAmount;

            Console.WriteLine(mainCanvas.ActualWidth);
            Console.WriteLine(mainCanvas.ActualHeight);
            
            for (int x = 0; x < mainCanvas.ActualWidth / cellWidth; x++)
            {
                for(int y = 0; y < mainCanvas.ActualHeight / cellHeight; y++)
                {
                    var cell = new Cell
                    {
                        X = x,
                        Y = y,
                        Color = new SolidColorBrush(Colors.White)
                    };

                    var rect = new Rectangle
                    {
                        Width = cellWidth,
                        Height = cellHeight,
                        Fill = cell.Color
                    };
                    
                    Canvas.SetLeft(rect, cell.X * cellWidth);
                    Canvas.SetTop(rect, cell.Y * cellHeight);
                    
                    mainCanvas.Children.Add(rect);
                }
            }
        }
    }

    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public SolidColorBrush Color { get; set; }
    }
}