using Microsoft.AspNetCore.Http;
using MinsCarsShop.Dto.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Constants;

namespace MinsCarsShop.Application.Interfaces
{
    public interface IFileService
    {
        Task<string> UploadFileAsync(IFormFile FileUploaded, string folderName);

        Task RemoveFileAsync(string path);
    }
}
