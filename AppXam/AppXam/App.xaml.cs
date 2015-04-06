using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Toasts.Forms.Plugin.Abstractions;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;
using XLabs.Ioc;

namespace AppXam
{
    public partial class App : Application
    {
        public static INavigation Navigation { get; set; }

        public App()
        {
            InitializeComponent();

            try
            {
                RegisterViewsModels();
                RegisterDependencies();
               // StartSyncTask();

                ImageCache.GetImageFromFileName("xlsx.png");
                ImageCache.GetImageFromFileName("pdf.png");
                ImageCache.GetImageFromFileName("star_unchecked.png");

                //MainPage = new IndexesView();
                //MainPage = (Page)ViewFactory.CreatePage<RepositoryViewModel, RepositoryView>();
                //MainPage = new AddBasicDocumentInfoView();
                //MainPage = new CapturePreview() { };

                MainPage = new NavigationPage((Page)ViewFactory.CreatePage<MainMenuViewModel, MainMenuView>());
                Navigation = MainPage.Navigation;
                // The root page of your application
               // MainPage = (MasterDetailPage)ViewFactory.CreatePage<MainMasterViewModel,MainMasterPage>();
                //MainPage = new DocumentDetailsView();
               // MainPage = new MainMenuView(); 
                //MainPage = new NavigationPage(new TasksView() {  BindingContext = new TasksViewModel(null)});//(new MainMenuView());//new NavigationPage(new DocumentSearchView { BindingContext = new DocumentSearchViewModel(null) });


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void RegisterDependencies()
        {
            
        }

        private void RegisterViewsModels()
        {
            ViewFactory.Register<MainMasterPage, MainMasterViewModel>();
            ViewFactory.Register<MainMenuView, MainMenuViewModel>();
            ViewFactory.Register<RepositoryView, RepositoryViewModel>();
            ViewFactory.Register<CapturePreview, CapturePreviewViewModel>();
        }
    
        public static IContainer Container { get; set; }
        public static string BaseUrl { get; set; }
        public static int syncCounter=0;
        public bool Synchronize() 
        {
            Device.BeginInvokeOnMainThread(() => {
                if (MainPage != null)
                {
                    NotifyAsync();
                    //DependencyService.Get<ITextToSpeechService>().Speak("Synchronizing");
                }
            });
            return true; 
        }

        public async Task<bool> NotifyAsync()
        {
            var notificator = DependencyService.Get<IToastNotificator>();
            return await notificator.Notify(ToastNotificationType.Info, "ECM info", "Sync...", TimeSpan.FromSeconds(2));
        }

        public void StartSyncTask()
        {
            Task.Factory.StartNew(() => {

                Device.StartTimer(TimeSpan.FromSeconds(5), Synchronize);
                
            }, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);
        }

        protected override void OnStart()
        {


            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}


