using Microsoft.AspNetCore.Http;

namespace BackEnd_1.Task.Areas.Extensisons
{
    public static class FileCombine
    {
        public static bool IsImage(this IFormFile file)
        {
            return file.ContentType.Contains("image");
        }

        public static bool IsGreater(this IFormFile file,int mb)
        {
            return file.Length > mb * 1024 * 1024;
        }

        public static bool IsOkey(this IFormFile file, int mb)
        {
            return IsImage(file) && IsGreater(file, mb);
        }
    }
}
