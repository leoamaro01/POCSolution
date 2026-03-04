// <copyright file="AppDelegate.cs" company="POC NTSprint">
// Copyright (c) POC NTSprint. All rights reserved.
// </copyright>

namespace POCSolution
{
    using Foundation;

    /// <summary>
    /// Provides the application delegate for a .NET MAUI app on iOS, handling application lifecycle events and
    /// initialization.
    /// </summary>
    /// <remarks>This class is typically used as the entry point for iOS applications built with .NET MAUI. It
    /// configures the app and manages platform-specific startup logic by overriding methods from
    /// MauiUIApplicationDelegate. Most developers do not need to modify this class directly unless custom platform
    /// initialization is required.</remarks>
    [Register("AppDelegate")]
    public class AppDelegate : MauiUIApplicationDelegate
    {
        /// <inheritdoc/>
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
