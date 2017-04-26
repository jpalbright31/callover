using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using MVC5T_CallOver.DAL.CallOver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public ActionResult Indexv2()
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
                dbBookingDate = m.BookingDate,//(m.BookingDate.HasValue) ? m.BookingDate.Value : new DateTime(),
                dbBookingTime = m.BookingTime,//(m.BookingTime.HasValue) ? m.BookingTime.Value : new TimeSpan(),
                dbGateDate = m.GateDate,//(m.GateDate.HasValue) ? m.GateDate.Value : new DateTime(),
                dbGateTime = m.GateTime//(m.GateTime.HasValue) ? m.GateTime.Value : new TimeSpan()
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

            return File(fileContents, "application/pdf", fileName);//return File(fileContents, contentType, fileName);
        }

        //public ActionResult TestInfo_Read([DataSourceRequest]DataSourceRequest request)
        //{
        //    var context = MvcApplication.MacDocsSession;

        //    var model = context.Query<CargoCrControlCnum>();

        //    DataSourceResult result = model.AsQueryable().ToDataSourceResult(request, ModelState, m => new vm_CargoControl()
        //    {
        //        Location = m.Location,
        //        VoyageNo = m.VoyageNo,
        //        Direction = m.Direction,
        //        BaseFrom = m.BaseFrom,
        //        BaseTo = m.BaseTo,
        //        BillNo = m.BillNo,
        //        Account = m.Account,
        //        Name = m.Name,
        //        ContainerNo = m.ContainerNo,
        //        ContainerType = m.ContainerType,
        //        ContainerLength = m.ContainerLength
        //    });

        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
    }
}