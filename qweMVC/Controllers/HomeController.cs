using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using qweMVC.DAL;
using qweMVC.Models;

namespace qweMVC.Controllers
{
    public class HomeController : BaseController
    {
        private readonly byte[] _data;
        private readonly DataContext _context;

        public HomeController()
        {
            _data = System.IO.File.ReadAllBytes("C:/inetpub/wwwroot/qweMVC/json.json");
            _context = new DataContext();
        }

        public ActionResult PartialContacts(int? page)
        {
            var model=FormData(page);
            if (Request.IsAjaxRequest())
                return PartialView("_Partial",model.Persons);
            return View(model);
        }

        public ActionResult JsonContacts(int? page)
        {
            var model = FormData(page);
            if (Request.IsAjaxRequest())
                return Json(model.Persons,JsonRequestBehavior.AllowGet);
            return View(model);
        }

        public ActionResult PartialComments(string comment)
        {
            return PartialView(Rework(comment));
        }

        public ActionResult JsonComments(string comment)
        {
            return Json(Rework(comment),JsonRequestBehavior.AllowGet);
        }

        public List<Comments> Rework(string comment)
        {
            if (_context.Comments.Count() >= 5)
            {
                var a = _context.Comments.ToList();
                a.RemoveAt(0);
                _context.Comments.RemoveRange(_context.Comments);
                _context.SaveChanges();
                _context.Comments.AddRange(a);
                _context.SaveChanges();
            }
            _context.Comments.Add(new Comments() { Text = comment });
            _context.SaveChanges();
            return _context.Comments.ToList();
        }

        private PersonListViewModel FormData(int? page)
        {
            var pageNumber = page ?? 1;
            const int pageSize = 6;
            var dat = JsonConvert.DeserializeObject<List<Person>>(System.Text.Encoding.UTF8.GetString(_data));
            var model = new PersonListViewModel
            {
                Persons = dat.Skip((pageNumber - 1) * pageSize).Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = dat.Count()
                }
            };
            return model;
        }
    }
}
