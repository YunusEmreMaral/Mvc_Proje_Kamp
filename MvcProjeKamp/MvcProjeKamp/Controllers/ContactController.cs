﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EFContactDal());
        ContactValidator cv = new ContactValidator();
        public ActionResult Index()
        {
            var contactvalueS = cm.GetList();
            return View(contactvalueS);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactDetail = cm.GetByID(id);
            return View(contactDetail);
        }
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
    }
}