using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyiBatisWeb.Models;
using MyiBatisWeb.Models.MetaTable;

namespace MyiBatisWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        { 
            return View();
        }

        public ActionResult About()
        {
            IList<StudentViewModel> ilsv= GetMoreRecord();
            ViewBag.Message = "Your application description page.";

            return View(ilsv);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Details(string id) {

            StudentViewModel svm = new StudentViewModel();
            svm.StudId = id;
            var GetOneStud = new BaseAccess_MyTestDB().QueryForObject("StudentOne", svm);
            return View(GetOneStud);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            StudentViewModel svm = new StudentViewModel();
            svm.StudId = id;
            var GetOneStud = new BaseAccess_MyTestDB().QueryForObject("StudentOne", svm);
            return View(GetOneStud);
        }

        [HttpPost]
        public ActionResult Edit(StudentViewModel svm)
        {
            int updatecount = new BaseAccess_MyTestDB().Update("UpdateStudent", svm);
            if (updatecount > 0)
                return RedirectToAction("About");
            else
                return View(svm);
        }

        public IList<StudentViewModel> GetMoreRecord()
        {
            //Hashtable ht = new Hashtable();
            //var GetMoreStud = new BaseAccess_MyTestDB().QueryForList<Hashtable>("StudentAll", null);
            var GetMoreStud = new BaseAccess_MyTestDB().QueryForList<StudentViewModel>("StudentAll", null);
            //if (GetMoreStud != null && GetMoreStud.Count > 0)
            //{
            //    ViewData["List"] = GetMoreStud;
            //}
            return GetMoreStud;
        }

      


        [HttpPost]
        public ActionResult Delete(string id)
        {
            int delcount = new BaseAccess_MyTestDB().Delete("DeleteStudent", id);
            if (delcount > 0)
                return RedirectToAction("About");
            else
                throw new Exception("something went wrong!");
        }


        //public void GetOneRecord(StudentViewModel svm) {
        //    //Hashtable ht = new Hashtable();
        //    //ht.Add("StuId", 2);

        //    var GetOneStud = new BaseAccess_MyTestDB().QueryForObject("StudentOne", svm);
        //    //ViewData["stu_id"] = GetOneStud["stud_id"];
        //    //ViewData["name"] = GetOneStud["name"];
        //    //ViewData["birthday"] = GetOneStud["birthday"];
        //    //ViewData["email"] = GetOneStud["email"];

        //}

    }
}