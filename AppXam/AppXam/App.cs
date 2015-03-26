﻿using Acr.XamForms.Mobile.IO;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Forms.Controls;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Platform.Services;


namespace AppXam
{
    public class App : Application
    {
        public static IContainer Container { get; set; }
        public static string BaseUrl { get; set; }

        public bool Synchronize() 
        {
            Device.BeginInvokeOnMainThread(() => { });
            return true; 
        }

        public void StartSyncTask()
        {
            Task.Factory.StartNew(() => {

                Device.StartTimer(TimeSpan.FromSeconds(5000), Synchronize);
                
            }, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);
        }


        public App()
        {


           
      
           // var fs = DependencyService.Get<IFileSystem>();

           // var container = new ContainerBuilder();
           // //container.RegisterType<IMediaPicker>();
           // var mp  = DependencyService.Get<IMediaPicker>();
         

           // Container = container.Build();
           // //var mp = Container.Resolve<IMediaPicker>();

           //var z =  Resolver.Resolve<IMediaPicker>();

           // IResolver autofacResolver = new AutofacResolver(Container);
           // Resolver.SetResolver(autofacResolver);



          

           // var mp2 = autofacResolver.Resolve<IMediaPicker>();

            try
            {

                StartSyncTask();

                ImageCache.GetImageFromFileName("xlsx.png");
                ImageCache.GetImageFromFileName("pdf.png");
                ImageCache.GetImageFromFileName("star_unchecked.png");

                // The root page of your application

                //MainPage = new DocumentDetailsView();
                MainPage = new NavigationPage(new TasksView());//(new MainMenuView());//new NavigationPage(new DocumentSearchView { BindingContext = new DocumentSearchViewModel(null) });
                

            }
            catch (Exception ex)
            {

            }

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
