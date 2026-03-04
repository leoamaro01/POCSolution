// <copyright file="AppDelegate.cs" company="POC NTSprint">
// Copyright (c) POC NTSprint. All rights reserved.
// </copyright>

namespace POCSolution
{
    using Foundation;

    /// <summary>
    /// Provides the application delegate for a .NET MAUI app running on iOS, responsible for application lifecycle
    /// management and initialization.
    /// </summary>
    /// <remarks>This class is typically used to configure and launch the MAUI application on iOS platforms.
    /// It overrides platform-specific lifecycle methods as needed. The default implementation calls the application's
    /// startup logic defined in MauiProgram.CreateMauiApp().</remarks>
    [Register("AppDelegate")]
    public class AppDelegate : MauiUIApplicationDelegate
    {
        /// <inheritdoc/>
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
