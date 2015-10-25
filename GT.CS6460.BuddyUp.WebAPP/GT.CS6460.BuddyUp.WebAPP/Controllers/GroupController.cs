using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GT.CS6460.BuddyUp.WebAPP.Models;

namespace GT.CS6460.BuddyUp.WebAPP.Controllers
{
    public class GroupController : Controller
    {
        // GET: Group
        public ActionResult GroupDetail()
        {
            return View();
        }


        public ActionResult GroupSummary()
        {
            GroupListModel glm = new GroupListModel();
            var suggestedGroups = new List<GroupSummary>();
            for (int i = 1; i <= 5; i++)
            {
                suggestedGroups.Add(new GroupSummary()
                    {
                        GroupName = "Group" + i.ToString(),
                        Objective = "The quick brown fox jumped over the lazy dog. The quick brown fox jumped over the lazy dog. The quick brown fox jumped over the lazy dog. The quick brown fox jumped over the lazy dog.",
                        TimeZone = "EST - Eastern Standard Time - GMT-5:00"
                    });
            }
            var allGroups = new List<GroupSummary>();
            for (int i = 1; i <= 11; i++)
            {
                allGroups.Add(new GroupSummary()
                {
                    GroupName = "Group" + i.ToString(),
                    Objective = "The quick brown fox jumped over the lazy dog. The quick brown fox jumped over the lazy dog. The quick brown fox jumped over the lazy dog. The quick brown fox jumped over the lazy dog.",
                    TimeZone = "EST - Eastern Standard Time - GMT-5:00"
                });
            }
            glm.SuggestedGroups = suggestedGroups;
            glm.AllGroups = allGroups;
            return View(glm);
        }

        //// GET: Group/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Group/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Group/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Group/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Group/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Group/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Group/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
