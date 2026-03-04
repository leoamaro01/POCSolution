// <copyright file="AppShell.xaml.cs" company="POC NTSprint">
// Copyright (c) POC NTSprint. All rights reserved.
// </copyright>

namespace POCSolution
{
    /// <summary>
    /// Defines the main navigation container for the application, providing the structure and routing for pages using
    /// the Shell paradigm.
    /// </summary>
    /// <remarks>AppShell serves as the entry point for configuring navigation, flyout menus, and tab bars in
    /// a .NET MAUI application. Inherit from this class to customize the application's navigation experience.</remarks>
    public partial class AppShell : Shell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppShell"/> class.
        /// </summary>
        /// <remarks>This constructor sets up the application's shell and loads its components. Typically
        /// called by the framework during application startup.</remarks>
        public AppShell()
        {
            this.InitializeComponent();
        }
    }
}
