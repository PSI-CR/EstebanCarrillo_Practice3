using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Initializer
    {
        [STAThread]
        public static void Main()
        {
            ImageAnalyzer imageReader = new ImageAnalyzer();
            ImageView image = new ImageView();
            ImageAdministrator imageManager = new ImageAdministrator(image, imageReader);
            ControllerManager directoryManager = new ControllerManager();
            MainWindow mainWindow = new MainWindow(imageManager, directoryManager);
            mainWindow.ShowDialog();
        }
    }
}
