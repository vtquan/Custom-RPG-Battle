using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=234227

namespace Custom_RPG_Battle
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

            Object A1MP = Windows.Storage.ApplicationData.Current.LocalSettings.Values["A1MP"];

            Object A2Nm = Windows.Storage.ApplicationData.Current.LocalSettings.Values["A2Nm"];
            Object A2MinDmg = Windows.Storage.ApplicationData.Current.LocalSettings.Values["A2MinDmg"];
            Object A2MaxDmg = Windows.Storage.ApplicationData.Current.LocalSettings.Values["A2MaxDmg"];
            Object A2HP = Windows.Storage.ApplicationData.Current.LocalSettings.Values["A2HP"];
            Object A2MP = Windows.Storage.ApplicationData.Current.LocalSettings.Values["A2MP"];

            Object A3Nm = Windows.Storage.ApplicationData.Current.LocalSettings.Values["A3Nm"];
            Object A3MinDmg = Windows.Storage.ApplicationData.Current.LocalSettings.Values["A3MinDmg"];
            Object A3MaxDmg = Windows.Storage.ApplicationData.Current.LocalSettings.Values["A3MaxDmg"];
            Object A3HP = Windows.Storage.ApplicationData.Current.LocalSettings.Values["A3HP"];
            Object A3MP = Windows.Storage.ApplicationData.Current.LocalSettings.Values["A3MP"];

            Object A4Nm = Windows.Storage.ApplicationData.Current.LocalSettings.Values["A4Nm"];
            Object A4MinDmg = Windows.Storage.ApplicationData.Current.LocalSettings.Values["A4MinDmg"];
            Object A4MaxDmg = Windows.Storage.ApplicationData.Current.LocalSettings.Values["A4MaxDmg"];
            Object A4HP = Windows.Storage.ApplicationData.Current.LocalSettings.Values["A4HP"];
            Object A4MP = Windows.Storage.ApplicationData.Current.LocalSettings.Values["A4MP"];

            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used when the application is launched to open a specific file, to display
        /// search results, and so forth.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                if (!rootFrame.Navigate(typeof(MainPage), args.Arguments))
                {
                    throw new Exception("Failed to create initial page");
                }
            }
            // Ensure the current window is active
            Window.Current.Activate();
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
