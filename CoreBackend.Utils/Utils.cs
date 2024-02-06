using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CoreBackend.Utils
{
    public static class Utils
    {


        public static string Today()
        {
            return DateTime.Now.ToString("MM/dd/yyyy");

        }
        public static string Yesterday()
        {
            DateTime d = DateTime.Now.AddDays(-1);
            return d.ToString("MM/dd/yyyy");
        }
        public static string LastWeek()
        {
            DateTime d = DateTime.Now.AddDays(-6);
            return d.ToString("MM/dd/yyyy");
        }
        public static bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }
        public static bool IsValidMimeType(string mimeType)
        {
            List<string> allowedMimeTypes = new List<string>
                {
                    "image/png", "image/jpeg", "image/gif", "image/bmp", "image/svg+xml", "image/x-icon",
                    "video/mp4", "video/avi", "video/mkv", "video/mov", "video/wmv", "video/flv", "video/webm",
                    "application/msword", "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                    "application/vnd.ms-powerpoint", "application/vnd.openxmlformats-officedocument.presentationml.presentation",
                    "application/vnd.ms-excel", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    "application/json", "application/sql", "text/plain", "application/javascript", "text/html", "text/sln"
                };

            return allowedMimeTypes.Contains(mimeType);
        }
    }
}
