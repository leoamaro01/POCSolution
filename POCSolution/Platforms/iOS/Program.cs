// <copyright file="Program.cs" company="POC NTSprint">
// Copyright (c) POC NTSprint. All rights reserved.
// </copyright>

namespace POCSolution
{
    using UIKit;

    /// <summary>
    /// Provides the main entry point for the application.
    /// </summary>
    /// <remarks>This class is typically used to launch the application and initialize the runtime
    /// environment. The entry point method configures the application delegate and starts the application lifecycle.
    /// For most scenarios, no modification to this class is required unless a custom application delegate is
    /// needed.</remarks>
    public class Program
    {
        /// <summary>
        /// Initializes and starts the application using the specified command-line arguments.
        /// </summary>
        /// <remarks>This is the entry point of the application. The method configures and launches the
        /// application using the default or specified application delegate. Typically, this method should not be called
        /// directly; it is invoked by the runtime when the application starts.</remarks>
        /// <param name="args">An array of command-line arguments to pass to the application on startup.</param>
        private static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, typeof(AppDelegate));
        }
    }
}
