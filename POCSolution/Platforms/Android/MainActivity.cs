// <copyright file="MainActivity.cs" company="POC NTSprint">
// Copyright (c) POC NTSprint. All rights reserved.
// </copyright>

namespace POCSolution
{
    using Android.App;
    using Android.Content.PM;

    /// <summary>
    /// Represents the main activity for the application, serving as the entry point when launched on Android devices.
    /// </summary>
    /// <remarks>This activity is configured as the main launcher and uses the Maui splash theme. It handles
    /// configuration changes such as screen size, orientation, UI mode, screen layout, smallest screen size, and
    /// density. In most cases, developers do not need to modify this class directly; it is typically used by the MAUI
    /// framework to initialize and display the application.</remarks>
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
    }
}
