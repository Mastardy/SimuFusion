using System.Windows;
using System.Windows.Controls;

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
            
            var cells = Cell.CreateCells(horizontalAmount, verticalAmount, mainCanvas.ActualWidth, mainCanvas.ActualHeight);

            for (int i = 0; i < cells.Length; i++)
            {
                var cell = cells[i];
                
                Canvas.SetLeft(cell.Rect, cell.X * cellWidth);
                Canvas.SetTop(cell.Rect, cell.Y * cellHeight);
                    
                mainCanvas.Children.Add(cell.Rect);
            }
        }
    }
}