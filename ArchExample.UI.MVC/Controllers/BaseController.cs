using System.Collections.Generic;
using System.Web.Mvc;
using ArchExample.Common.Interfaces.Helpers;
using ArchExample.Common.Interfaces.Services;
using ArchExample.UI.MVC.Models;

namespace ArchExample.UI.MVC.Controllers
{
    public class BaseController : Controller
    {
        private readonly ILogHelper _logHelper;

        protected ILogHelper Logger
        {
            get
            {
                return _logHelper;
            }

        }

        public BaseController(ILogHelper logHelper)
        {
            _logHelper = logHelper;
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}