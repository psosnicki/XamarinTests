using Media.Plugin;
using Media.Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppXam
{
    public partial class MainMenuView : ContentPage
    {
        View _view;
        View _horizontalView;

        public MainMenuView()
        {
            InitializeComponent();
            BackgroundColor = Color.FromHex("#FF006092");// Color.FromRgb(151, 199, 201);
            this.ToolbarItems.Add(new ToolbarItem { Icon = "user.png",  Text="psosnicki" ,IsDestructive=true});
            SizeChanged+=MainMenuView_SizeChanged;
            _view = Content;
            _horizontalView = new MenuHorizontalView().Content;
        }

        private void OnMasterDetailClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavigationPage(new MainMasterPage() { BindingContext = this.BindingContext }));
        }

        private async void OnMenuItemTapped(object sender,EventArgs e)
        {
            //var src = (sender as StackLayout);
            //await src.FadeTo(0.5, 250);
            //await src.FadeTo(1, 250);
            //src.Animate(String.Empty, new Animation((d) => { src.BackgroundColor = Color.FromHex("#e8e8e8"); }));
            //src.Animate(String.Empty, new Animation((d) => { src.BackgroundColor = Color.White; }));

            var action = await DisplayActionSheet("Add new document", "Cancel", String.Empty, "Camera capture", "Upload from gallery");
            //MediaFile file = null;
            //if (action == "Camera capture")
            //{
            //    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            //    {
            //        await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
            //        return;
            //    }

            //    file = await CrossMedia.Current.TakePhotoAsync(new Media.Plugin.Abstractions.StoreCameraMediaOptions
            //    {

            //        Directory = "Sample",
            //        Name = "test.jpg"
            //    });

            //}
            //else if (action == "Upload from gallery")
            //{
            //    file = await CrossMedia.Current.PickPhotoAsync();

            //}

            //if (file == null)
            //    return;

            //await DisplayAlert("File Location", file.Path, "OK");
            AddNewFlow.CreateCapturePreview();

            //image.Source = ImageSource.FromStream(() =>
            //{
            //    var stream = file.GetStream();
            //    file.Dispose();
            //    return stream;
            //}); 
        }

        private void MainMenuView_SizeChanged(object sender, EventArgs e)
        {
           
           if(!IsPortrait(this))
           {
               _view = this.Content;
               BackgroundColor = Color.Transparent;
               this.Content = _horizontalView;
               //try
               //{
               //    App.Navigation.PushAsync(new NavigationPage(new TasksView()));
               //}
               //catch (Exception ex) { 
               //}
               
           }
           else
           {
               if (Content != _view)
               {
                   BackgroundColor = Color.FromRgb(151, 199, 201);
                   Content = _view;
               }
           }
        }
        
        bool IsPortrait(Page p) { return p.Width < p.Height; }
    }
}
