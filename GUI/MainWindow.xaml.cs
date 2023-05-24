using System;
using System.Windows;
using System.Windows.Threading;

namespace GUI
{
    using static Interop.CoreLib;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly DispatcherTimer dispatcherTimer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            
            Loaded += OnLoad;
            Closed += OnClose;
            
            dispatcherTimer.Tick += (_, _) => UpdateEngine();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
        }

        public void OnLoad(object sender, RoutedEventArgs eventArgs)
        {
            addCellToCanvasDelegate = AddCellToCanvas;
            RegisterAddCellToCanvasCallback(addCellToCanvasDelegate);
            updateCellOnCanvasDelegate = UpdateCellOnCanvas;
            RegisterUpdateCellOnCanvasCallback(updateCellOnCanvasDelegate);
            
            InitializeEngine(mainCanvas.ActualWidth, mainCanvas.ActualHeight);
            dispatcherTimer.Start();
        }
        
        public void OnClose(object sender, EventArgs eventArgs)
        {
            dispatcherTimer.Stop();
            CleanupEngine();
        }
    }
}