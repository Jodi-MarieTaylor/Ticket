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
    public class EventController : Controller
    {
        PGDbContext _context;

        public EventController()
        {
            _context = new PGDbContext();
        }
    
        [HttpPost]
        public ActionResult create_event()
        {
            DateTime now = DateTime.Now;
            Ticketv1.Models.Event umodel = new Ticketv1.Models.Event ();
            umodel.name = HttpContext.Request.Form["name"].ToString();
            umodel.summary = HttpContext.Request.Form["summary"].ToString();
            umodel.location = HttpContext.Request.Form["location"].ToString();
            umodel.category = "General";
            umodel.event_limit = Int32.Parse(HttpContext.Request.Form["event_limit"]);
            DateTime event_date;
            DateTime end_date;
            DateTime.TryParse(HttpContext.Request.Form["event_date"], out event_date);
            DateTime.TryParse(HttpContext.Request.Form["end_date"], out end_date);
            umodel.event_date = event_date ;
            umodel.end_date = end_date;
            umodel.zid = Guid.NewGuid().ToString();
            umodel.inserted_at = now;
            umodel.updated_at = now;

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


        
        public ActionResult create()
        {
            ViewBag.Message = "Create An Event";

            return View();
        }

   
    }
}