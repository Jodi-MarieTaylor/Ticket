using Ticketv1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Npgsql;
using System.Security.Cryptography;
using System.Text;


namespace Ticketv1.Controllers
{
    public class AuthController : Controller
    {
        PGDbContext _context;

        public AuthController()
        {
            _context = new PGDbContext();
        }
        public ActionResult signin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult signup2()
        {
            DateTime now = DateTime.Now;
            Ticketv1.Models.User umodel = new Ticketv1.Models.User();
            umodel.firstname = HttpContext.Request.Form["firstname"].ToString();
            umodel.lastname = HttpContext.Request.Form["lastname"].ToString();
            umodel.username = HttpContext.Request.Form["username"].ToString();
            umodel.phone = HttpContext.Request.Form["phone"].ToString();
            umodel.email = HttpContext.Request.Form["email"].ToString();
            umodel.role = 1;
            umodel.address = HttpContext.Request.Form["address"].ToString();
            umodel.zid = Guid.NewGuid().ToString();
            umodel.inserted_at =now;
            umodel.updated_at = now;
            string password = HttpContext.Request.Form["password"].ToString();
            MD5 md5Hash = MD5.Create();
            string hash = GetMd5Hash(md5Hash, password);

            umodel.password = hash;
            int result = umodel.SaveDetails();
            if (result > 0)
            {
                ViewBag.Result = "Data Saved Successfully";
            }
            else
            {
                ViewBag.Result = "Something Went Wrong";
            }
            return View("~/Views/Home/Index.cshtml");


        }


        
        public ActionResult signup()
        {
            ViewBag.Message = "This is the first version of Ticket app";

            return View();
        }

        

        public ActionResult login()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult logout()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}