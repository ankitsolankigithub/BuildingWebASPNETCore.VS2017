using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreWorld.ViewModels;
using CoreWorld.Services;
using Microsoft.Extensions.Configuration;
using CoreWorld.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace CoreWorld.Controllers.Web
{
    public class AppController : Controller
    {
        //private IMailService _mailService;
        private IConfigurationRoot _config;
        private IWorldRepository _repository;
        private ILogger _logger;

        public AppController(
            //IMailService mailService,
            IConfigurationRoot config,
            IWorldRepository repository,
            ILogger<AppController> logger)
        {
            //_mailService = mailService;
            _config = config;
            _repository = repository;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Trips()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            if (model.Email.Contains("aol.com"))
                ModelState.AddModelError("Email", "We don't support AOL address");

            if (ModelState.IsValid)
            {
                //_mailService.SendMail(model.Email, _config["Mailsettings:ToAddress"], "From The Trip Manager", model.Message);
                ViewBag.UserMessage = "Message sent successfully !";
                ModelState.Clear();
            }

            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
