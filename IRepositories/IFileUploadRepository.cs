using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace Api.IRepositories
{
    public interface IFileUploadRepository
    {
        Task<string> UploadFile([FromForm] IFormFile file, IWebHostEnvironment hostingEnvironment, string UserImagesPath);
        void DeleteFiles(string filename, string path, IWebHostEnvironment hostingEnvironment);
    }
}
