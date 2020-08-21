using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

//***************************
using System.Text.RegularExpressions;
//**************************
using cSharpBelt.Models;

namespace cSharpBelt.Controllers 
{
    public class HomeController : Controller   
    {
        private MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }

//==========================================================================

        [HttpGet("")]     
        public IActionResult Index()
        {
            return View("Index"); 
        }

//==========================================================================

        [HttpPost("/user/create")]
        public IActionResult CreateUser(LogRegWrapper Form)
        {
            if(ModelState.IsValid)
            {
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                Form.NewUser.Password = Hasher.HashPassword(Form.NewUser, Form.NewUser.Password);

                _context.Add(Form.NewUser);
                _context.SaveChanges();

                User ThisUser = _context.Users.FirstOrDefault(i => i.Email == Form.NewUser.Email);
                HttpContext.Session.SetInt32("UserID", ThisUser.UserID);

                return RedirectToAction("Dashboard");
            }
            return View("Index");
        }

//=========================================================================================

        [HttpPost("/user/checklogin")]
        public IActionResult Verify(LogRegWrapper Form)
        {
            if(ModelState.IsValid)
            {
                var inDB = _context.Users.FirstOrDefault(u => u.Email == Form.LoginUser.Email);

                if(inDB == null)
                {
                    ModelState.AddModelError("Email", "Invalid Email/Passoword");
                    return View("Index");
                }
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(Form.LoginUser , inDB.Password, Form.LoginUser.Password);

                if(result == 0)
                {
                    ModelState.AddModelError("Password", "Are you sure you belong here?");
                    return View("Index");
                }

                User ThisUser = _context.Users.FirstOrDefault(u => u.Email == Form.LoginUser.Email);
                
                HttpContext.Session.SetInt32("UserID", ThisUser.UserID);
                
                return RedirectToAction("Dashboard");
                
            }

            return View("Index");
        }

//======================================================================================

        [HttpGet("/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

//=============================================================================================

        [HttpGet("/dashboard")]
        public IActionResult Dashboard()
        {
            int? userid = HttpContext.Session.GetInt32("UserID");
            
            if(userid == null)
            {
                return RedirectToAction("Index");
            }

            DashWrapper DashWrap = new DashWrapper();
            DashWrap.UserThis = _context.Users
            .Include(p => p.HappeningsAttending)
            .FirstOrDefault(i => i.UserID == userid);

            DashWrap.AllHappening = _context.Happenings
            .Include(y => y.GuestsAttending)
            .Include(c => c.UserCreator)
            .OrderBy(o => o.HappeningDay)
            .Where(t => t.HappeningDay > DateTime.Now)
            .ToList();

            return View("Dashboard", DashWrap);
        }

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        [HttpGet("/addhappening")]
        public IActionResult AddHappening()
        {
            int? userid = HttpContext.Session.GetInt32("UserID");
            
            if(userid == null)
            {
                return RedirectToAction("Index");
            }

            NewHappeningWrap HapWrap = new NewHappeningWrap();
            HapWrap.UserThis = _context.Users
            .FirstOrDefault(i => i.UserID == userid);

            return View("AddHappening", HapWrap);
        }

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        [HttpPost("/createhappening")]
        public IActionResult CreateHap(NewHappeningWrap Form)
        {
            int? userid = HttpContext.Session.GetInt32("UserID");
            
            if(userid == null)
            {
                return RedirectToAction("Index");
            }

            if(ModelState.IsValid)
            {
                _context.Add(Form.NewHappening);
                _context.SaveChanges();

                return RedirectToAction("Dashboard");
            }

            return AddHappening();
        }

//------------------------------------------------------------------------

        [HttpGet("/delete/happening/{id}")]
        public IActionResult DeleteHap(int id)
        {
            int? userid = HttpContext.Session.GetInt32("UserID");
            
            if(userid == null)
            {
                return RedirectToAction("Index");
            }
            Happening ToDelete = _context.Happenings
            .FirstOrDefault(i => i.HappeningID == id);

            if(ToDelete == null)
            {
                return RedirectToAction("Dashboard");
            }

            _context.Remove(ToDelete);
            _context.SaveChanges();

            return RedirectToAction("Dashboard");
        }

//--------------------------------------------------------

        [HttpGet("/rsvp/happening/{id}")]
        public IActionResult RSVP(int id)
        {
            int? userid = HttpContext.Session.GetInt32("UserID");
            if(userid == null)
            {
                return RedirectToAction("Index");
            }

            User ThisUser = _context.Users.FirstOrDefault(i => i.UserID == userid);

            Happening ToAttend = _context.Happenings.FirstOrDefault(w => w.HappeningID == id);

            Attending NewRSVP = new Attending();
            NewRSVP.UserID = (int)userid;
            NewRSVP.User = ThisUser;
            NewRSVP.Happening = ToAttend;
            NewRSVP.HappeningID = id;



            _context.Add(NewRSVP);
            _context.SaveChanges();

            return RedirectToAction("Dashboard");
        }

//---------------------------------------------------------

        [HttpGet("/unrsvp/happening/{id}")]
        public IActionResult UnRSVP(int id)
        {
            int? userid = HttpContext.Session.GetInt32("UserID");
            if(userid == null)
            {
                return RedirectToAction("Index");
            }

            User ThisUser = _context.Users.FirstOrDefault(i => i.UserID == userid);

            Happening ToAttend = _context.Happenings.FirstOrDefault(w => w.HappeningID == id);

            Attending ToDelete = _context.Attendings.FirstOrDefault(i => i.UserID == ThisUser.UserID && i.HappeningID == id);

            _context.Remove(ToDelete);
            _context.SaveChanges();

            return RedirectToAction("Dashboard");
        }

//===========================================================================

        [HttpGet("/view/happening/{id}")]
        public IActionResult HapDetail(int id)
        {
            int? userid = HttpContext.Session.GetInt32("UserID");
            if(userid == null)
            {
                return RedirectToAction("Index");
            }

            NewHappeningWrap HapWrap = new NewHappeningWrap();

            HapWrap.NewHappening = _context.Happenings
            .Include(p => p.GuestsAttending)
            .ThenInclude(p => p.User)
            .Include(p => p.UserCreator)
            .FirstOrDefault(q => q.HappeningID == id);

            HapWrap.UserThis = _context.Users
            .Include(p => p.HappeningsAttending)
            .FirstOrDefault(e => e.UserID == userid);

            return View("ThisHappening", HapWrap);
        }
    }
}