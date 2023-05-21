using HomeWorkCookie.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HomeWorkCookie.Controllers
{
    public class HomeController : Controller
    {
        private static List<string> onlineUsers = new List<string>();

        public IActionResult Index()
        {
            ViewData["OnlineUsersCount"] = onlineUsers.Count;
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(string username)
        {
            if (!string.IsNullOrEmpty(username) && !onlineUsers.Contains(username))
            {
                onlineUsers.Add(username);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveUser(string username)
        {
            if (!string.IsNullOrEmpty(username) && onlineUsers.Contains(username))
            {
                onlineUsers.Remove(username);
            }

            return RedirectToAction("Index");
        }
    }
}