using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestimDetyra.Configs
{
    public class Config
    {
        public static string ScreenshotDir = @"C:\Riinvest\Viti III\Testimi Softuerit\Ushtrime\TestimDetyra\screenshots";
        public static class KosovaJobConfig
        {
            public static string Url = "https://kosovajob.com/";
            public static string JobPositon = "Administrat";
            public static string JobCategory = "Administratë";
            public static string JobLocation = "Prishtinë";
            public static string Time = "Full Time";
        }

        public static class YoutubeConfig
        {
            public static string Url = "https://www.youtube.com/";
            public static string Email = "fdurmishi789@gmail.com";
            public static string Password = "Bardhi1030";
            public static string PlaylistName = "test";
            public static string AddedSuccessfully = "Added to test";

        }
    }
}
