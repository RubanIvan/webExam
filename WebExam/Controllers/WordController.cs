using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebExam.Controllers
{
    public class WordController : Controller
    {

        /// <summary>Создать новый  тест</summary>
        [Authorize]
        public ActionResult Create()
        {
            return View();
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
