using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Capture;
using Windows.Media.Core;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CameraApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void ClickMe_Click(object sender, RoutedEventArgs e)
        {

            clickbAsync();
        }
        public async System.Threading.Tasks.Task clickbAsync()
        {
            CameraCaptureUI captureUI = new CameraCaptureUI();
            captureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            captureUI.PhotoSettings.CroppedSizeInPixels = new Size(200, 200);
            StorageFile photo = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);
            if (photo == null)
            {
                return;
            }
            StorageFolder destinationFolder =
             await ApplicationData.Current.LocalFolder.CreateFolderAsync("ProfilePhotoFolder",
             CreationCollisionOption.OpenIfExists);

            await photo.CopyAsync(destinationFolder, "ProfilePhoto.jpg", NameCollisionOption.ReplaceExisting);
            await photo.DeleteAsync();

            //captureUI.VideoSettings.Format = CameraCaptureUIVideoFormat.Mp4;
            //StorageFile video = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Video);
            //if (video == null)
            //{
            //    return;
            //}
            
            //mediaPlayerElement.Source = MediaSource.CreateFromStorageFile(video);
            //mediaPlayerElement.MediaPlayer.Play();

        }

    }
}