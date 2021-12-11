using Api.IRepositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public class FileUploadRepository : IFileUploadRepository
    {
        private IWebHostEnvironment _hostingEnvironment;

        public FileUploadRepository()
        {
        }

        public void DeleteFiles(string filename ,string path , IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            var filePath = _hostingEnvironment.WebRootPath + "\\Images\\"+ path + "\\" + filename;
            if (File.Exists(filePath))
            {
                var fileInfo = new FileInfo(filePath);
                fileInfo.Delete();
            }
           
        }

        public async Task<string> UploadFile([FromForm] IFormFile file, IWebHostEnvironment hostingEnvironment, string UserImagesPath)
        {
            _hostingEnvironment = hostingEnvironment;
            try
            {
                string fileName = "";
                if (file.Length > 0)
                {
                    string webRootPath = _hostingEnvironment.ContentRootPath + "\\wwwroot\\Images\\" + UserImagesPath + "\\";

                    if (!Directory.Exists(webRootPath))
                        Directory.CreateDirectory(webRootPath);
                    //if (imgPath != null)
                    //    File.Copy(imgPath, newPath);
                    fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    string fullPath = Path.Combine(webRootPath, fileName);

                    using (FileStream fileStream = System.IO.File.Create(fullPath))
                    {
                        await file.CopyToAsync(fileStream);
                        await fileStream.FlushAsync();
                    }
                }
                return fileName;
            }
            catch (Exception)
            {
                return "";
            }
        }
        
    }
}
