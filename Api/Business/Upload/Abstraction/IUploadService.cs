using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mozer.Business.Upload.Abstraction
{
    public interface IUploadService
    {
        Task<(string Name, string BaseUrl)> UploadAsync(IFormFile formFile, string name, string url = null);
    }
}
