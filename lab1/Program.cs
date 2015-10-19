using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Text;
using System.Text.RegularExpressions;


namespace rsoi_lab1
{
    static class Program
    {
        private static string Client_ID = "bb5ee5e2659b1bf147d6";
        private static string Client_Secret = "15fadc1422afe54b3adc594395cd1d4d6e5ca664";
        public static string AccessToken = null;
        public static string Code = null;
        public static int oauth = 0;
        [STAThread]
        
        static void Main()
        {
            ShowHome();
            if (oauth == 0)
            {
                UnAuthReq();
            }
            else
            {
                ShowAuthForm(StrGetReq());
                GetAccessToken();
                string answer = AuthReq();
                Console.WriteLine(answer);
            }
            Console.ReadKey();
        }

        public static string StrGetReq()
        {
            string scope = "user,repo";
            string redirect_uri = "https://github.com/users";
            string state = "***";

            return string.Format("https://github.com/login/oauth/authorize?client_id={0}&scope={1}&redirect_uri={2}&state={3}",
                Client_ID, scope, redirect_uri, state);
        }

        public static void ShowAuthForm(string uri)
        {
            AutForm authForm = new AutForm(uri);
            Application.Run(authForm);
            
        }
        
        private static void ShowHome()
        {
            Home HomeForm = new Home();
            Application.Run(HomeForm);
        }

        private static string UnAuthReq()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://api.github.com/user");
            req.UserAgent = @"Mozilla/5.0 (Windows NT 6.2; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/32.0.1667.0 Safari/537.36";
            try
            {
                HttpWebResponse resp;
                    resp = (HttpWebResponse)req.GetResponse();
                Stream stream = resp.GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                string Out = sr.ReadToEnd();
                sr.Close();
                return Out;
            }
            catch(WebException e)
            {
                Console.WriteLine("Exception caught {0} {1}",e.Message, e.Response.Headers);
                return "0";
            }
        }

        private static void GetAccessToken()
        {
            string redirect_uri = "https://github.com/users";
            string state = "***";
            string post, uri = "https://github.com/login/oauth/access_token";
            post = string.Format("client_id={0}&client_secret={1}&code={2}&redirect_uri={3}&state={4}",
                Client_ID, Client_Secret, Code, redirect_uri, state);
            WebRequest req = WebRequest.Create(uri);
            req.Method = "POST";
            req.Timeout = 100000;
            req.ContentType = "application/x-www-form-urlencoded";
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(post);
            req.ContentLength = bytes.Length;
            System.IO.Stream os = req.GetRequestStream(); // создаем поток 
            os.Write(bytes, 0, bytes.Length); // отправляем в сокет 
            os.Close(); 
            WebResponse res = req.GetResponse();
        
            Stream ReceiveStream = res.GetResponseStream();
            StreamReader sr = new StreamReader(ReceiveStream, Encoding.UTF8);
            Char[] read = new Char[256];
            int count = sr.Read(read, 0, 256);
            string Out = String.Empty;
            String str = new String(read, 0, count);
            AccessToken = Regex.Match(str, "(?<=access_token=)[\\da-z]+").ToString();
        }
        private static string AuthReq()
        {
            string uri = string.Format("https://api.github.com/user?access_token={0}", AccessToken);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
            req.UserAgent = @"Mozilla/5.0 (Windows NT 6.2; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/32.0.1667.0 Safari/537.36";
            try
            {
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                Stream stream = res.GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                string Out = sr.ReadToEnd();
                sr.Close();
                return Out;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught {0}", e.Message);
                return "0";
            }
        }
    }
}