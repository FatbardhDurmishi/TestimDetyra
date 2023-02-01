using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

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

        public static class GmailConfing
        {
            public static string Url = "https://mail.google.com/mail/u/0/#inbox";
            public static string Receiver = "fd200043k@riinvest.net";
            public static string Subject = "Test";
            public static string Body = "Test";
            public static string MessageSent = "Message sent";
            public static string AddressNotFount = "Address not found";
            public static string InvalidEmail = "hjvytcyv@gmail.com";
            public static string EmailScheduledMessage = "Send scheduled for ";
        }

        public static class GitConfig
        {
            public static string Url = "https://github.com/";
            public static string RepositoryName = "TestRepo2";
            public static string AfterRepoCreatedUrl = "https://github.com/FatbardhDurmishi/" + RepositoryName;
            public static string Password = "Bardhigit1";
            public static string Private = "Private";
            public static string Collaborator = "Bulza Rexhepi";
        }

        public static class GjirafaConfig
        {
            public static string GjirafaUrl = "https://gjirafa50.com/";
            public static string Name = "Filan";
            public static string Surname = "Fisteku";
            public static string Tel = "044111222";
            public static string Address = "Test";
            public static string Email = "test@gmail.com";
            public static string Confirm = "Urime! Porosia juaj është kryer me sukses.";
        }
        public static class HelpDeskConfig
        {
            public static string HelpDeskUrl = "https://helpdesk.riinvest.net/";
            public static string fullName = "Bulza";
            public static string email = "br200036k@riinvest.net";
            public static string statement = "test per lenden Testim i Softuerit";
            public static string confirmationCreate = "Support ticket request created";
            public static string confirmationStatus = "Bulza - access link sent to your email!";
            public static string ticketNum = "376280";
        }

        public static class InstagramConfig
        {
            public static string InstagramUrl = "https://www.instagram.com";
            public static string username = "bulza.rexhepi02";
            public static string password = "Testim1";
            public static string newPassword = "Testim9";
            public static string personToChat = "bulzaarexhepii";
            public static string personGroup = "albaarexhepii";
            public static string chatMessage = "Test Chat";
            public static string groupMessage = "Test Group";
        }
    }
}
