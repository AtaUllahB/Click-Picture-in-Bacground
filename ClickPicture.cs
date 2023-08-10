using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenCvSharp;
using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;

namespace VendingC.BAL
{
   public class ClickPicture
    {
        // Create class-level accesible variables
        VideoCapture capture;
        Mat frame;
        Bitmap image;
        private Thread camera;
        bool isCameraRunning = true;
        Bitmap snapshot;

        // Declare required methods


        public async Task CaptureCameraAsync()
        {

            MediaCapture captureManager = new MediaCapture();
            await captureManager.InitializeAsync();

            ImageEncodingProperties imgFormat = ImageEncodingProperties.CreateJpeg();

            // create storage file in local app storage
            StorageFolder folder = await ApplicationData.Current.LocalFolder.GetFolderAsync("Potraits");
            StorageFile file = await folder.CreateFileAsync(
                Global.General.SALE_NO+".jpg",
                CreationCollisionOption.GenerateUniqueName);

            // take photo
            await captureManager.CapturePhotoToStorageFileAsync(imgFormat, file);

            // Get photo as a BitmapImage
            BitmapImage bmpImage = new BitmapImage(new Uri(file.Path));


        }

    }
}
