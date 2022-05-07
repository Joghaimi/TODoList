using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TODoList.Data;
using TODoList.Models;

namespace TODoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDBContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDBContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                List<Note> note = _db.Note.Where(u => u.userId == 1).ToList();
                return View(note);
            }
            else
                return Redirect("/Identity/Account/Login");
        }
        public IActionResult Privacy()
        {
            return View();
        }


        [HttpPost]
        public JsonResult Compleated(int id)
        {
            //var result = _db.Note.SingleOrDefault(u => u.id == noteId);
            //result.completed = isCompleated;
            //_db.SaveChanges();
            //return RedirectToAction(nameof(Index));
            var i = id;
            return Json("Ok");
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
