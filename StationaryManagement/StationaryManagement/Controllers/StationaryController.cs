using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StationaryManagement.Manager;
using StationaryManagement.Models;

namespace StationaryManagement.Controllers
{
    public class StationaryController : Controller
    {
        //
        // GET: /Stationary/
        StationaryTypeManager stationaryTypeManager = new StationaryTypeManager();
        StationaryManager stationaryManager = new StationaryManager();
        Stationary stationary = new Stationary();

        public List<StationaryType> LoadAllType()
        {
            return stationaryTypeManager.ViewAllStationaryType();
        }
        public ActionResult SaveStationary()
        {
            ViewBag.stationaryType =LoadAllType();
            return View();
        }

        [HttpPost]
        public ActionResult SaveStationary(Stationary stationary)
        {
            ViewBag.stationaryType = LoadAllType();
            ViewBag.msz = stationaryManager.SaveStationary(stationary);
            return View();
        }

        public ActionResult Show()
        {
            ViewBag.stationaryType = LoadAllType();
            return View();
        }

        [HttpPost]
        public ActionResult Show(int typeId)
        {
            ViewBag.stationaryType = LoadAllType();
            List<Stationary> stationaries = stationaryManager.ViewSelectedStationary(typeId);
            ViewBag.totalPrice = stationaryManager.GettotalPrice(typeId);
            return View(stationaries);
        }
	}
}