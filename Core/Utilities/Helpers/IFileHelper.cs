using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public interface IFileHelper
    {
        string Upload(IFormFile file, string root);
        string Update(IFormFile file, string fileName, string root);
        void Delete(string fileName);
    }

    public class FileHelper : IFileHelper
    {
        public void Delete(string fileName)
        {
            if(File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }

        public string Update(IFormFile file, string fileName, string root)
        {
            if(File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            return Upload(file, root);
        }

        public string Upload(IFormFile file, string root)
        {
            if(file.Length >0)
            {
                if (!Directory.Exists(root))//if the root directory does not exist, create it.
                {
                    Directory.CreateDirectory(root);
                }

                string extension = Path.GetExtension(file.FileName); //.jpg, png, txt, etc..
                string guid = Guid.NewGuid().ToString();
                string fileName = guid + extension;

                using(FileStream fileStream = File.Create(root + fileName)) //create a file on root+filename path.
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush(); //send it to root+file
                    return fileName;
                }
            }
            return null;
        }
    }
}
