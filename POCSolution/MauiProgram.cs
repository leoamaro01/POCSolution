// <copyright file="MauiProgram.cs" company="POC NTSprint">
// Copyright (c) POC NTSprint. All rights reserved.
// </copyright>

namespace POCSolution
{
    using Microsoft.Extensions.Logging;
    using Plugin.Maui.Biometric;
    using POCSolution.Services.Implementations;
    using POCSolution.Services.Interfaces;

    /// <summary>
    /// Maui pogrram main class.
    /// </summary>
    public static class MauiProgram
    {
        /// <summary>
        /// Start of the pipeline to create the Maui app.
        /// </summary>
        /// <returns><see cref="MauiApp"/>.</returns>
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<ICameraService, CameraService>();
            builder.Services.AddSingleton(BiometricAuthenticationService.Default);
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
