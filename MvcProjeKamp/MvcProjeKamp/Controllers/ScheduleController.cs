using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using MvcProjeKamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class ScheduleController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        //GET: Schedule
        //public ActionResult Index()
        //{
        //    DateTime dt = DateTime.Now;
        //    var sched = new DHXScheduler(this);
        //    sched.Skin = DHXScheduler.Skins.Terrace;
        //    sched.LoadData = true;
        //    sched.EnableDataprocessor = true;
        //    sched.InitialDate = new DateTime(2021, 9, 9);
        //    return View(sched);
        //}

        //public ContentResult Data()
        //{
        //    return (new SchedulerAjaxData(
        //        new Context().Headings
        //        .Select(e => new { e.HeadingID, e.HeadingName, e.HeadingDate, e.LastHeadingDate })
        //        )
        //        );
        //}

        //public ContentResult Save(int? id, FormCollection actionValues)
        //{
        //    var action = new DataAction(actionValues);
        //    var changedEvent = DHXEventsHelper.Bind<Heading>(actionValues);
        //    var entities = new Context();
        //    try
        //    {
        //        switch (action.Type)
        //        {
        //            case DataActionTypes.Insert:
        //                entities.Headings.Add(changedEvent);
        //                break;
        //            case DataActionTypes.Delete:
        //                changedEvent = entities.Headings.FirstOrDefault(ev => ev.HeadingID == action.SourceId);
        //                entities.Headings.Remove(changedEvent);
        //                break;
        //            default:// "update"
        //                var target = entities.Headings.Single(e => e.HeadingID == changedEvent.HeadingID);
        //                DHXEventsHelper.Update(target, changedEvent, new List<string> { "HeadingID" });
        //                break;
        //        }
        //        entities.SaveChanges();
        //        action.TargetId = changedEvent.HeadingID;
        //    }
        //    catch (Exception a)
        //    {
        //        action.Type = DataActionTypes.Error;
        //    }

        //    return (new AjaxSaveResponse(action));
        //}
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Calender());
        }

        public JsonResult GetEvents(DateTime start, DateTime end)
        {
            var viewModel = new Calender();
            var events = new List<Calender>();

            foreach (var item in hm.GetList())
            {
                events.Add(new Calender()
                {
                    title = item.HeadingName,
                    start = item.HeadingDate,
                    end = item.HeadingDate.AddDays(-14), // Bu değeri kontrol edin
                    allDay = false
                });



            }

            return Json(events.ToArray(), JsonRequestBehavior.AllowGet);
        }

    }
}