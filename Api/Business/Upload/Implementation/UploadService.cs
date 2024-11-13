using Microsoft.AspNetCore.Http;
using Mozer.Business.Upload.Abstraction;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Mozer.Business.Upload.Implementation
{
    public class UploadService : IUploadService
    {
        public async Task<(string Name, string BaseUrl)> UploadAsync(IFormFile formFile, string name = null, string url = null)
        {
            var baseUrl = url;


            var fileName = name ?? formFile.Name;
            bool exists = Directory.Exists(baseUrl);

            if (!exists)
            {
                Directory.CreateDirectory(baseUrl);
            }
            var i = formFile.FileName.LastIndexOf('.');
            var extension = formFile.FileName[i..];
            fileName += extension;
            var filePath = Path.Combine(baseUrl, fileName);
            using (var stream = File.Create(filePath))
            {
                await formFile.CopyToAsync(stream);
            }
            return (fileName, baseUrl);
        }
    }
}
