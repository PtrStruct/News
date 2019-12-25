using System.Web.Mvc;
using News.Models;

namespace News.Controllers
{
    public class SourceController : Controller
    {
        // GET: Source
        public ActionResult NT()
        {
            ViewBag.Collection = NewsFactory.GetNTArticles();
            return View();
        }

        public ActionResult Expressen()
        {
            ViewBag.Collection = NewsFactory.GetExpressenArticles();
            return View();
        }

        public ActionResult Svd()
        {
            ViewBag.Collection = NewsFactory.GetSvdArticles();
            return View();
        }
    }
}