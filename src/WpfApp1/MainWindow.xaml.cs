using Microsoft.Win32;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.Drawing.Imaging;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private bool _imageLoad;
        private ImageAdministrator _imageManager;
        private ControllerManager _controllerManager;
        string _filePath;
        Bitmap _image;
        public MainWindow(ImageAdministrator imageManager, ControllerManager directoryManager)
        {
            this._imageManager = imageManager;
            this._controllerManager = directoryManager;
            InitializeComponent();
            _imageLoad = false;
        }
        private void openFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg)|*.jpg";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    string imagePath = openFileDialog.FileName;
                    displayImage(imagePath);
                    string directoryPath = System.IO.Path.GetDirectoryName(imagePath);
                    _controllerManager.PackDirectory(directoryPath);
                    _controllerManager.SetActualImage(imagePath);
                    _imageLoad = true;
                    _txtboxInfo.Text = openFileDialog.FileName;
                    _filePath = openFileDialog.FileName;
                }
                catch
                {
                    displayError("Format Invalid");
                }
            }            
        }
        private void _btnFilterSobel_Click(object sender, RoutedEventArgs e)
        {
            if (_imageLoad)
            {
                IFilter sobel = new FiltersSobel();
                Bitmap modifiedImage = sobel.AdvancedFilters(_imageManager.ObtainOriginalImage());
                image.Source = InputAdjuster.ConvertToBitmapSource(modifiedImage);
            }
        }
        private void _btnFilterRoberts_Click(object sender, RoutedEventArgs e)
        {
            if (_imageLoad)
            {
                IFilter prewitt = new FiltersRoberts();
                Bitmap modifiedImage = prewitt.AdvancedFilters(_imageManager.ObtainOriginalImage());
                image.Source = InputAdjuster.ConvertToBitmapSource(modifiedImage);
            }
        }
        private void displayError(string message)
        {
            if (message == null)
            {
                throw new ArgumentNullException("The message cannot be null");
            }
            MessageBox.Show(message, "Error!");
        }
        private void displayImage(string imagePath)
        {
            Bitmap originalImage = null;
            originalImage = _imageManager.ReadImage(imagePath);
            _imageManager.SaveOriginalImage(originalImage);
            image.Source = InputAdjuster.ConvertToBitmapSource(originalImage);
        }
        public void pictureViewer(int mobilizeImage)
        {
            if (_imageLoad)
            {
                if (_controllerManager.direct(mobilizeImage))
                {
                    displayImage(_controllerManager.GetActualPath());
                }
            }
        }
        private void previous_MouseClickUp(object sender, MouseButtonEventArgs e)
        {
            imagePrevious.Source = new ImageSourceConverter().ConvertFromString("../../Images/PreviousHover.png") as ImageSource;
            pictureViewer(-1);
            _txtboxInfo.Text = _controllerManager.GetActualPath();
        }
        private void next_MouseClickUp(object sender, MouseButtonEventArgs e)
        {
            imageNext.Source = new ImageSourceConverter().ConvertFromString("../../Images/NextHover.png") as ImageSource;
            pictureViewer(1);
            _txtboxInfo.Text = _controllerManager.GetActualPath();

        }

        private void _btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void _btnReset_Click(object sender, RoutedEventArgs e)
        {
            if (_imageLoad)
            {
                _image = new Bitmap(_filePath);
                Uri fileUri = new Uri(_filePath);
                image.Source = new BitmapImage(fileUri);
            }
        }
    }
}
