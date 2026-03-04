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
    /// environment. The entry point is defined by the static Main method, which is called by the operating system when
    /// the application starts.</remarks>
    public class Program
    {
        // This is the main entry point of the application.
        private static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, typeof(AppDelegate));
        }
    }
}
