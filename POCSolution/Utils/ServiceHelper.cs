// <copyright file="ServiceHelper.cs" company="POC NTSprint">
// Copyright (c) POC NTSprint. All rights reserved.
// </copyright>

namespace POCSolution.Utils
{
    /// <summary>
    /// Provides utility methods for working with service-related operations.
    /// </summary>
    public class ServiceHelper
    {
        /// <summary>
        /// Retrieves a service of the specified type from the current application's dependency injection container.
        /// </summary>
        /// <remarks>This method relies on the current application's Maui context and service provider.
        /// Ensure that the application and its service provider are properly initialized before calling this
        /// method.</remarks>
        /// <typeparam name="T">The type of service to retrieve. Must be a reference type.</typeparam>
        /// <returns>An instance of the requested service type if it is registered; otherwise, the method throws an exception.</returns>
        /// <exception cref="Exception">Thrown if the service of type T cannot be resolved from the application's service provider.</exception>
        public static T GetService<T>()
            where T : class
        {
            if (Application.Current?.Handler?.MauiContext?.Services.GetService(typeof(T)) is T service)
            {
                return service;
            }

            throw new Exception($"Unable to resolve type {typeof(T).Name}");
        }
    }
}
