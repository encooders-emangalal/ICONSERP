namespace ICONSERP.Models.Security
{
    public static class EmailHelper
    {
        public static string emailAddress = "encooders@gmail.com";
        public static string password = "Encood@123";
        public static void genrateValidationCodeEmail(string Email, string name, string code)
        {
            EmailUtilities email = new EmailUtilities();
            //var emailbringt = "bringit.application.qa@gmail.com";
            //var passwordbringt = "br!ngtqa";

            //string emailAddress = emailbringt;
            //string password = passwordbringt;





            string sMTP = "smtp.gmail.com";
            string sMTPPort = "587";

            string cc = "admin.encooders@gmail.com";

            email.SendEmail(Email, "Validation Code", EmailBody(name, code), null, emailAddress, password, sMTP, int.Parse(sMTPPort), cc);
        }

        public static void sentEmail(string Email, string subject, string body)
        {
            EmailUtilities email = new EmailUtilities();
            //var emailbringt = "bringit.application.qa@gmail.com";
            //var passwordbringt = "br!ngtqa";
            //var emailabq = "bird.kids.qa@gmail.com";
            //var passwordabq = "Birdkids123456";
            //string emailAddress = emailbringt;
            //string password = passwordbringt;





            string sMTP = "smtp.gmail.com";
            string sMTPPort = "587";

            string cc = "admin.encooders@gmail.com";

            email.SendEmail(Email, subject, body, null, emailAddress, password, sMTP, int.Parse(sMTPPort), cc);
        }
        private static string EmailBody(string name, string code)
        {

            var ss = $"dear {name}\r\n Validation Code : {code}.\r\n" +
                $"Thanks ";
            return ss;
        }
        public static string GenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max).ToString();
        }
    }
}

