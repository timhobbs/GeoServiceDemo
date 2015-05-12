using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Th.GeoServices;
using Th.GeoServices.Domain;
using GeoServiceDemo.Models;

namespace GeoServiceDemo.Controllers {
    public class HomeController : Controller {
        //
        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Lookup form) {
            var addr = new Address {
                Street = form.Street,
                City = form.City,
                StateAbbreviation = form.StateAbbreviation,
                Zip = form.Zip,
            };

            var model = GetModel(addr);
            if (model == null) return View();

            return View("Result", model);
        }

        public ActionResult Demo() {
            var addr = new Address() {
                Street = "350 5th Ave",
                City = "New York",
                StateAbbreviation = "NY",
                Zip = "10118",
            };

            var model = GetModel(addr);

            return View("Result", model);
        }

        private GeocodeAddressModel GetModel(Address addr) {
            var svc = GeoService.GetAddressResponse(addr);
            if (svc == null || svc.Candidates.Count == 0) {
                ModelState.AddModelError("", "No matches found. Please try again");
                return null;
            }

            var topCandidate = svc.Candidates.First();

            var svc2 = GeoService.GetCensusBlockResponse(topCandidate.Location);

            var county = GeoService.GetCounty(addr);

            var model = new GeocodeAddressModel {
                Address = addr,
                TopCandidate = topCandidate,
                GeocodeJsonResult = svc,
                FccJsonResult = svc2,
                County = county,
            };

            return model;
        }
    }
}
