using ERPSYS.MVC.DAO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.Models
{
    public class ViewModelHelper : Controller
    {
        public JsonResult CreateNotify(string message, string type)
        {
            return Json(new
            {
                data = new { message = message, type = type }
            });
        }
    }
}