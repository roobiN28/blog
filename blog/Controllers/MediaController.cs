using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace blog.Controllers
{
    public class MediaController : Controller
    {
        private string path = ConfigurationManager.AppSettings.Get("MediaPath");

        public string SaveFile()
        {
            using (StreamWriter _testData = new StreamWriter(Server.MapPath(path+"/"+"data.txt"), true))
            {
             
                _testData.WriteLine("To jest tekst który chcem zapisać."); // Write the file.
                _testData.Close();
                _testData.Dispose();
            }


            return "exit";
        }

        public ActionResult Post()
        {


            return View();
        }

        [HttpPost]
        public string SaveFilePost(HttpPostedFileBase file)
        {
/*            using (StreamWriter _testData = new StreamWriter(Server.MapPath(path + "/" + "data.txt"), true))
            {

                _testData.WriteLine("To jest tekst który chcem zapisać."); // Write the file.
                _testData.Close();
                _testData.Dispose();
            }*/

            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var sciezka = Path.Combine(Server.MapPath(path), fileName);
                file.SaveAs(sciezka);

            }

            return "exit";
        }

        public string CreateMD5()
        {
            var calculateMd5Hash = CalculateMD5Hash("robert");
            return calculateMd5Hash;
        }

        public ActionResult TestImg()
        {
            return View();

        }



        private string CalculateMD5Hash(string input)

        {

            // step 1, calculate MD5 hash from input

            MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);

            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)

            {

                sb.Append(hash[i].ToString("D"));

            }

            return sb.ToString();

        }
    }
}