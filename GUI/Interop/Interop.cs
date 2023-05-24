using System.Runtime.InteropServices;

namespace GUI.Interop
{
    public static class CoreLib
    {
        [DllImport("CoreLib.dll")]
        public static extern bool InitializeEngine(double width, double height);
        
        [DllImport("CoreLib.dll")]
        public static extern void UpdateEngine();
        
        [DllImport("CoreLib.dll")]
        public static extern void CleanupEngine();
    }
}