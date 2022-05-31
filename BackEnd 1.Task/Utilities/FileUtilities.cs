using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BackEnd_1.Task.Utilities
{
    public static class FileUtilities
    {
        public static async Task<string> FileExists(this IFormFile file,string root,string folder)
        {
            string fileName = Guid.NewGuid() + file.FileName;
            string path = Path.Combine(root,folder);
            string fullpath = Path.Combine(path,fileName);

            using (FileStream stream = new FileStream(fullpath,FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return fileName;
        }

        public static async  void FileDelete(string root, string path, string imageName)
        {
            string fullpath = Path.Combine(root,path,imageName);

            if (File.Exists(fullpath))
            {
                File.Delete(fullpath);
            }
        }

        

    }
}
