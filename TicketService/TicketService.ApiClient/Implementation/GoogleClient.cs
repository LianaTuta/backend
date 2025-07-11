﻿using Google.Api.Gax;
using Google.Apis.Storage.v1.Data;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using TicketService.ApiClient.Interface;
using TicketService.Models.Configuration;
using Object = Google.Apis.Storage.v1.Data.Object;

namespace TicketService.ApiClient.Implementation
{
    public class GoogleClient : IGoogleClient
    {

        private readonly StorageClient _storageClient;
        private readonly GoogleBucketConfigurationModel _bucketSettings;
        private readonly UrlSigner _urlSigner;

        public GoogleClient(StorageClient storageClient, IOptions<GoogleBucketConfigurationModel> bucketSettings, UrlSigner urlSigner)
        {
            _storageClient = storageClient;
            _bucketSettings = bucketSettings.Value;
            _urlSigner = urlSigner;
        }

        public async Task UploadFileAsync(IFormFile file, string path)
        {
            using Stream stream = file.OpenReadStream();
            try
            {
                string objectName = $"{path}/{file.FileName}";
                _ = await _storageClient.UploadObjectAsync(_bucketSettings.BucketName, objectName, file.ContentType, stream);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public async Task<(MemoryStream Stream, string ContentType, string FileName)> DownloadFileAsync(string objectPath)
        {
            try
            {
                MemoryStream stream = new();
                Object obj = await _storageClient.DownloadObjectAsync(_bucketSettings.BucketName, objectPath, stream);
                stream.Position = 0;

                string contentType = obj.ContentType ?? "application/octet-stream";
                string fileName = Path.GetFileName(objectPath);

                return (stream, contentType, fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Download failed: {ex.Message}");
                throw;
            }
        }


        public async Task<List<string>> GetFilesAsync(string path)
        {

            List<string> files = [];
            PagedAsyncEnumerable<Objects, Object> objects = _storageClient.ListObjectsAsync(_bucketSettings.BucketName, path);
            await foreach (Object? obj in objects)
            {
                files.Add(obj.Name);
            }
            return files;
        }

        public string GenerateSignedUrl(string objectName)
        {
            return _urlSigner.Sign(
                _bucketSettings.BucketName,
                objectName,
                TimeSpan.FromDays(7),
                HttpMethod.Get);
        }

        public Task DownloadFileAsync(string objectPath, string localFilePath)
        {
            throw new NotImplementedException();
        }
    }
}
