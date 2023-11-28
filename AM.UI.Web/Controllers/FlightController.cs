using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AM.UI.Web.Controllers
{
    public class FlightController : Controller
    {
        IServiceFlight serviceFlight;
        private IServicePlane servicePlane;


        public FlightController(IServiceFlight serviceFlight , IServicePlane servicePlane)
        {
            this.serviceFlight = serviceFlight;
            this.servicePlane = servicePlane;
        }
        // GET: FlightController
        public ActionResult Index(DateTime? dateDepart)
        {
            if (dateDepart == null)
            {
                return View(serviceFlight.GetAll().ToList());
            }
            else
            {
                return View(serviceFlight.GetMany(f => f.FlightDate == dateDepart).ToList());
            }
        }

        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FlightController/Create
        public ActionResult Create()
        {
            ViewBag.PlaneId = new SelectList(servicePlane.GetAll(),"PlaneId","PlaneId");
            return View();
        }

        // POST: FlightController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flight flight)
        {
            try
            {
                serviceFlight.Add(flight);
                serviceFlight.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FlightController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FlightController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Sort()
        {
            return View("Index", serviceFlight.SortFLights());
        }
    }
}
