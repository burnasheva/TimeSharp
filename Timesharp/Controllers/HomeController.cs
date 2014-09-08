// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="">
//   
// </copyright>
// <summary>
//   The home controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Timesharp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using NUnit.Framework;

    /// <summary>
    ///     The home controller.
    /// </summary>
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Json(new List<String>() { "foo", "bar" }, JsonRequestBehavior.AllowGet);
        }
    }
}