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
    public class PromoterController : Controller
    {
        PGDbContext _context;

        public PromoterController()
        {
            _context = new PGDbContext();
        }
        public ActionResult profile()
        {
           PGDbContext db = new PGDbContext();

           return View(_context.events.Where(e => e.id ==  1).ToList());
        }
        
      

    }
}