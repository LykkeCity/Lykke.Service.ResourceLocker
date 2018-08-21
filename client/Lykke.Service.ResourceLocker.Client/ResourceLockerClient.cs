﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Lykke.Service.ResourceLocker.Client.Models;
using Microsoft.Extensions.PlatformAbstractions;
using Refit;

namespace Lykke.Service.ResourceLocker.Client
{
    /// <summary>
    /// ResourceLocker API aggregating interface.
    /// </summary>
    public class ResourceLockerClient : IResourceLockerClient, IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly ApiRunner _runner;
        private readonly IResourceLockerApi _resourceLockerApi;
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="settings"></param>
        public ResourceLockerClient(ResourceLockerServiceClientSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            if (string.IsNullOrEmpty(settings.ServiceUrl))
                throw new Exception("Service URL required");

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(settings.ServiceUrl),
                DefaultRequestHeaders =
                {
                    {
                        "User-Agent",
                        $"{PlatformServices.Default.Application.ApplicationName}/{PlatformServices.Default.Application.ApplicationVersion}"
                    }
                }
            };

            _resourceLockerApi = RestService.For<IResourceLockerApi>(_httpClient);
            _runner = new ApiRunner();
        }
        /// <summary>
        /// Lock resource
        /// </summary>
        /// <param name="request">loecked resource request model</param>
        /// <returns></returns>
        public Task<LockedResourceResponse> LockResource(LockedResourceRequest request)
        {
            return _runner.RunWithDefaultErrorHandlingAsync(() => _resourceLockerApi.LockResourceAsync(request));
        }
        /// <summary>
        /// Release resource
        /// </summary>
        /// <param name="request">Released resource request model</param>
        /// <returns></returns>
        public Task<bool> ReleaseResource(ReleaseResourceRequest request)
        {
            return _runner.RunWithDefaultErrorHandlingAsync(() => _resourceLockerApi.ReleaseResourceAsync(request));
        }
        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}
