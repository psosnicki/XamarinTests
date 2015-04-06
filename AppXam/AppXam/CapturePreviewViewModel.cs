using Media.Plugin;
using Media.Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppXam
{
    public class CapturePreviewViewModel : BaseViewModel
    {
        ImageSource _imgSrc;
        public ImageSource ImgSource 
        {
            get { return _imgSrc; }
            set
            {
                if(_imgSrc!=value)
                {
                    _imgSrc = value;
                    OnPropertyChanged();
                }
            }
        }
        public ICommand CaptureCmd { get; set; }
        public ICommand GoNextCmd { get; set; }



        public CapturePreviewViewModel()
        {
            CaptureCmd = new Command(()=>GetPhotoAgain("camera"));
            GoNextCmd = new Command(GoNext);
        }

        private void GoNext()
        {
           AddNewFlow.CreateBasicDocumentMetaView();
        }

        public async void GetPhotoAgain(string action)
        {
            // var action = await DisplayActionSheet("Add new document", "Cancel", String.Empty, "Camera capture", "Upload from gallery");
            MediaFile file = null;
            if (action == "camera")
            {
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    // await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
                    return;
                }

                file = await CrossMedia.Current.TakePhotoAsync(new Media.Plugin.Abstractions.StoreCameraMediaOptions
                {

                    Directory = "Sample",
                    Name = "test.jpg"
                });

            }
            else if (action == "Upload from gallery")
            {
                file = await CrossMedia.Current.PickPhotoAsync();

            }

            if (file == null)
                return;

            ImgSource = ImageSource.FromStream(()=>file.GetStream());
            // await DisplayAlert("File Location", file.Path, "OK");
        }
    }
}
