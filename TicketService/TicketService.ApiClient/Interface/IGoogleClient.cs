﻿using Microsoft.AspNetCore.Http;

namespace TicketService.ApiClient.Interface
{
    public interface IGoogleClient
    {
        Task UploadFileAsync(IFormFile file, string path);
        Task<List<string>> GetFilesAsync(string path);
        string GenerateSignedUrl(string path);

        Task<(MemoryStream Stream, string ContentType, string FileName)> DownloadFileAsync(string objectPath);
    }
}
