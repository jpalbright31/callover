using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using MVC5T_CallOver.DAL.CallOver;
using System;
using System.Web.Mvc;
using MVC5T_CallOver.ViewModels;

namespace MVC5T_CallOver.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Loader()
        {
            return View();
        }

        public ActionResult Containers_Read([DataSourceRequest]DataSourceRequest request)
        {
            var db = new CallOverContext();
            var model = db.Containers;

            DataSourceResult result = model.ToDataSourceResult(request, ModelState, m => new vm_Container()
            {
                ID = m.ID,
                ContainerNo = m.ContainerNo,
                Type = m.Type,
                VoyageNo = m.VoyageNo,
                Port = m.Port,
                HaulierAC = m.HaulierAC,
                HaulierName = m.HaulierName,
                DestinationOrigin = m.DestinationOrigin,
                dbBookingDate = m.BookingDate,
                dbBookingTime = m.BookingTime,
                dbGateDate = m.GateDate,
                dbGateTime = m.GateTime
            });

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);
            return File(fileContents, contentType, fileName);
        }

        [HttpPost]
        public ActionResult Pdf_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);
            return File(fileContents, "application/pdf", fileName);
        }
    }
}
