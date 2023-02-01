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

        public static class KosovaJobMultiLanguageConfig
        {
            public static string Url = "https://kosovajob.com/";
            public static string Profile = "MY PROFILE";
            public static string Search = "SEARCH";
            public static string Contact = "CONTACT";
            public static string Products = "PRODUCTS";

            public static string Profili = "PROFILI IM";
            public static string Kerko = "KËRKO";
            public static string Kontakt = "KONTAKT";
            public static string Produktet = "PRODUKTET";
        }

        public static class SpotifyLikedSongsConfig
        {
            public static string Url = "https://open.spotify.com";
            public static string RandomPlaylist = "//*[@id=\"main\"]/div/div[2]/div[3]/div[1]/div[2]/div[2]/div/div/div[2]/main/section/div/div/section[1]/div[2]/div[2]/div";
        }


        public static class Udemy
        {
            public static string Url = "https://www.udemy.com";
            public static string cartURL = "https://www.udemy.com/cart/";
            public static string learningPathUrl = "https://www.udemy.com/home/my-courses/learning/";
            public static string RandomPlaylist = "//*[@id=\"main\"]/div/div[2]/div[3]/div[1]/div[2]/div[2]/div/div/div[2]/main/section/div/div/section[1]/div[2]/div[2]/div";
            public static string MostPopularCourseNumber1Xpath = "//*[@id=\"course-unit-container-Mostpopular\"]/div[1]";
        }

        public static class Trello
        {
            public static string Url = "https://www.trello.com";
        }
    }
}
