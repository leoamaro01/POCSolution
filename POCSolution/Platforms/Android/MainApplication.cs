// <copyright file="MainApplication.cs" company="POC NTSprint">
// Copyright (c) POC NTSprint. All rights reserved.
// </copyright>

namespace POCSolution
{
    using Android.App;
    using Android.Runtime;

    /// <summary>
    /// Represents the main application class for a .NET MAUI Android app, providing the entry point and application
    /// lifecycle integration.
    /// </summary>
    /// <remarks>This class is typically used to initialize and configure the MAUI application when running on
    /// Android. It is decorated with the <see cref="ApplicationAttribute"/> to indicate its role as the application
    /// entry point. Override members as needed to customize application startup or lifecycle behavior.</remarks>
    [Application]
    public class MainApplication : MauiApplication
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainApplication"/> class using a native handle and ownership specification.
        /// </summary>
        /// <param name="handle">A pointer to the native object that represents the underlying Android application instance.</param>
        /// <param name="ownership">A value indicating whether the ownership of the native handle is transferred to the managed instance or
        /// retained by the caller.</param>
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
        }

        /// <inheritdoc/>
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
