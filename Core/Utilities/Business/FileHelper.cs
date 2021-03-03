using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Business
{
    public class FileHelper
    {
        public static string Add(IFormFile fromFile)
        {
            string extension = Path.GetExtension(fromFile.FileName);
            string newGuid = CreateGuid() + extension;
            string path =Directory.GetCurrentDirectory()+@"\wwwroot\Images";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string imagePath;
            using (FileStream fileStream=File.Create(path+"\\"+newGuid))
            {
                fromFile.CopyTo(fileStream);
                fileStream.Flush();
                imagePath = path + "\\" + newGuid;
            }
            return imagePath;
        }
        public static string Update(IFormFile formFile,string oldPath)
        {
            using (FileStream fileStream = File.Open(oldPath, FileMode.Open))
            {
                formFile.CopyTo(fileStream);
                fileStream.Flush();
            }
            return oldPath;
        }

        private static string CreateGuid()
        {
            return Guid.NewGuid().ToString("N")+"-"+DateTime.Now.Month+"-"+DateTime.Now.Day+"-"+DateTime.Now.Year;
        }
    }
}
