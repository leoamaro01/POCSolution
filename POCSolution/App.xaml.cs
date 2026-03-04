// <copyright file="App.xaml.cs" company="POC NTSprint">
// Copyright (c) POC NTSprint. All rights reserved.
// </copyright>

namespace POCSolution
{
    /// <summary>
    /// Represents the application entry point and manages application-level behavior, including initialization and
    /// window creation.
    /// </summary>
    /// <remarks>This class is typically used as the root type for a .NET MAUI application. It handles startup
    /// logic and is responsible for creating the main window and shell. Override members to customize application
    /// lifecycle events or window configuration as needed.</remarks>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        /// <remarks>This constructor sets up the application and loads its initial components. Typically
        /// called by the application framework during startup.</remarks>
        public App()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Creates and returns the main application window for the current activation state.
        /// </summary>
        /// <param name="activationState">The activation state containing information about how the application was activated. May be null if no
        /// activation data is available.</param>
        /// <returns>A new instance of the application's main window.</returns>
        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}