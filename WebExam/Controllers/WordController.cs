using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace WebExam.Controllers
{

    public class word
    {
        public string en { get; set; }
        public string ru { get; set; }
    }

    public class TestModel
    {
        public List<word> word { get; set; }
        public string title { get; set; }
    }

    


    public class WordController : Controller
    {

        /// <summary>Создать новый  тест</summary>
        [Authorize][HttpGet]
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
            WordPackage wp=new WordPackage();
            wp.UserName= User.Identity.Name;
            wp.Title = model.title;

            //добавляем новую запись в таблицу WordPackage
            WordEntities.WordPackage.Add(wp);
            WordEntities.SaveChanges();

            //получаем id только что добавленного элемента
            int id=(from p in WordEntities.WordPackage
                  where p.UserName== wp.UserName && p.Title== wp.Title
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
        [Authorize]
        public ActionResult WordPackage(int? id)
        {
            return View();
        }

        /// <summary>Пройти определенный тест</summary>
        [Authorize]
        public ActionResult Run(int? id)
        {
            return View();
        }
    }
}
