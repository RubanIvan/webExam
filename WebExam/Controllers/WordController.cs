using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WebExam.Models;

namespace WebExam.Controllers
{

   public class WordController : Controller
    {

        /// <summary>Создать новый  тест</summary>
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [Authorize]
        [HttpPost]
        public ActionResult Create(TestModel model)
        {
            if (model == null) return Json("Error");
            //User.Identity.Name;

            WebExamEntities WordEntities = new WebExamEntities();
            WordPackage wp = new WordPackage();
            wp.UserName = User.Identity.Name;
            wp.Title = model.title;

            //добавляем новую запись в таблицу WordPackage
            WordEntities.WordPackage.Add(wp);
            WordEntities.SaveChanges();

            //получаем id только что добавленного элемента
            int id = (from p in WordEntities.WordPackage
                      where p.UserName == wp.UserName && p.Title == wp.Title
                      orderby p.WordPackageID descending
                      select p.WordPackageID).First();

            //Debug.WriteLine(id);


            foreach (word word in model.word)
            {
                Word w = new Word();
                w.WordPackageID = id;
                w.En = word.en;
                w.Ru = word.ru;
                WordEntities.Word.Add(w);
            }
            WordEntities.SaveChanges();


            return Json("Success");

        }

        /// <summary>Отобразить список всех тестов</summary>
        [HttpGet]
        [Authorize]
        public ActionResult WordPackage()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public JsonResult GetWordPackageList()
        {
            WebExamEntities WordEntities = new WebExamEntities();

            //other your code goes here
            var PackageList = from p in WordEntities.WordPackage
                              where p.UserName == User.Identity.Name
                              select new { p.WordPackageID, p.Title };

            return Json(new { result = PackageList }, JsonRequestBehavior.AllowGet);
        }



        /// <summary>Пройти определенный тест</summary>
        [Authorize]
        public ActionResult Run(int? id)
        {
            ViewBag.id = id;
            return View();
        }


        [HttpGet]
        [Authorize]
        public JsonResult GetRunList(int? id)
        {
            List<RunModel> model = new List<RunModel>();

            WebExamEntities WordEntities = new WebExamEntities();

            var words = from w in WordEntities.Word
                        where w.WordPackageID == id
                        select new { w.En, w.Ru };

            List<string> wrong = (from w in WordEntities.Word
                        select w.Ru).ToList();

            foreach (var w in words)
            {
                RunModel wordpair=new RunModel();
                wordpair.ru=new List<string>();

                wordpair.en = w.En;
                wordpair.answer = Rnd.Next(5);
                for (int i = 0; i < wordpair.answer; i++)
                {
                    wordpair.ru.Add(wrong[Rnd.Next(wrong.Count)]);
                }
                wordpair.ru.Add(w.Ru);
                for (int i = wordpair.answer; i <5; i++)
                {
                    wordpair.ru.Add(wrong[Rnd.Next(wrong.Count)]);
                }
                
                model.Add(wordpair);
            }
            return Json(new { result = model }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
