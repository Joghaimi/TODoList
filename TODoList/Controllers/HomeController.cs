using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TODoList.Data;
using TODoList.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace TODoList.Controllers

{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDBContext _db;
        private readonly IHttpContextAccessor _httpContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDBContext db, IHttpContextAccessor httpContext)
        {
            _logger = logger;
            _db = db;
            _httpContext = httpContext;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                List<Note> note = _db.Note.Where(u => u.userId == _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).ToString()).ToList();
                return View(note);
            }
            else
                return Redirect("/Identity/Account/Login");
        }
        public IActionResult Privacy()
        {
            return View();
        }


        //[HttpPost]
        public JsonResult Compleated(int id , bool isCompleated)
        {
            var result = _db.Note.SingleOrDefault(u => u.id == id);
            result.completed = isCompleated;
            _db.SaveChanges();
            return Json("Ok");
        }
        public JsonResult Delete(int id)
        {
            Note result = _db.Note.SingleOrDefault(u => u.id == id);
            _db.Note.Remove(result);
            _db.SaveChanges();
            return Json("Ok");
        }
        public JsonResult AddNote(String noteString ,String assignTo)
        {
            var tmpNote = new Note();
            tmpNote.assignTo = assignTo;
            tmpNote.noteString = noteString;
            tmpNote.userId= _httpContext.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier).ToString();
            _db.Note.Add(tmpNote);
            _db.SaveChanges();
            return Json("Ok");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
