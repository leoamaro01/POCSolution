// <copyright file="ICameraService.cs" company="POC NTSprint">
// Copyright (c) POC NTSprint. All rights reserved.
// </copyright>

namespace POCSolution.Services.Interfaces
{
    /// <summary>
    /// Defines a service for capturing pictures asynchronously using the device camera.
    /// </summary>
    public interface ICameraService
    {
        /// <summary>
        /// Captures a photo asynchronously and returns the file path of the saved image.
        /// </summary>
        /// <remarks>The method initiates the device's camera to take a picture. The returned file path
        /// can be used to access the image for further processing or display. The operation may be canceled by the user
        /// or fail due to device limitations or permissions.</remarks>
        /// <returns>A string containing the file path of the captured image if the operation succeeds; otherwise, null if the
        /// capture is canceled or fails.</returns>
        Task<string?> TakePictureAsync();
    }
}