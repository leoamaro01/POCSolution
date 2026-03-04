// <copyright file="CameraService.cs" company="POC NTSprint">
// Copyright (c) POC NTSprint. All rights reserved.
// </copyright>

namespace POCSolution.Services.Implementations
{
    using System;
    using POCSolution.Services.Interfaces;

    /// <summary>
    /// Provides camera-related functionality, including capturing photos asynchronously using the device's camera <see cref="ICameraService"/>.
    /// </summary>
    /// <remarks>This service abstracts camera operations for use in applications that require photo capture.
    /// It checks device capabilities before attempting to capture a photo and handles file storage in the application's
    /// cache directory. The service is intended to be used in environments where camera access is available and
    /// supported. Thread safety and error handling are managed internally; errors during capture are surfaced to the
    /// user via an alert and result in a null return value.</remarks>
    public class CameraService : ICameraService
    {
        /// <inheritdoc/>
        public async Task<string?> TakePictureAsync()
        {
            try
            {
                if (MediaPicker.Default.IsCaptureSupported)
                {
                    var photo = await MediaPicker.Default.CapturePhotoAsync();

                    if (photo != null)
                    {
                        var newPath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                        using (var stream = await photo.OpenReadAsync())
                        using (var newStream = File.OpenWrite(newPath))
                        {
                            await stream.CopyToAsync(newStream);
                        }

                        return newPath;
                    }
                }
            }
            catch (Exception ex)
            {
                var currentPage = Application.Current?.Windows.Count > 0
                    ? Application.Current.Windows[0].Page
                    : null;

                if (currentPage != null)
                {
                    await currentPage.DisplayAlertAsync("Error", $"Error al capturar foto: {ex.Message}", "OK");
                }
            }

            return null;
        }
    }
}