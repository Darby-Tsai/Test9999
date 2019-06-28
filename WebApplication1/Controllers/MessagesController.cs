using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.MessageModels;

namespace WebApplication1.Controllers
{
    public class MessagesController : Controller
    {
        Test001Entities db = new Test001Entities();
        Test001 T = new Test001();
        // GET: Messages
        public ActionResult Index()
        {
            return View(db.Test001.ToList());
        }
        [HttpPost]
        public ActionResult Add(string name, string Memo)
        {
            try
            {
                var maxId = 0;
                if (db.Test001.Count() == 0)
                {
                    
                    T.Id = ++maxId;
                    T.Name = name;
                    T.Memo = Memo;
                    T.DateTime_Now = DateTime.Now;
                    db.Test001.Add(T);
                    db.SaveChanges();
                }
                else
                {
                    maxId = db.Test001.Select(s => s.Id).Max();
                    T.Id = maxId + 1;
                    T.Name = name;
                    T.Memo = Memo;
                    T.DateTime_Now = DateTime.Now;
                    db.Test001.Add(T);
                    db.SaveChanges();
                }
    
             
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());
            }
            return RedirectToAction("Index");

        }
    }
}