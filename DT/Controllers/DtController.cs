using DT.DAL;
using DT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DT.Controllers
{
    public class DtController : Controller
    {
        private readonly DtDAL _dtDAL;

        public DtController(DtDAL dtDAL)
        {
            _dtDAL = dtDAL;
        }
        // GET: DtController
        public IActionResult Index()
        {
            List<Dt> dtl = new List<Dt>();
            dtl = _dtDAL.Getall();
            return View(dtl);
        }
        
        // GET: DtController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: DtController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DtController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Dt dt)
        {
            try
            {
                bool result = _dtDAL.Insert(dt);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DtController/Edit/5
        public IActionResult Edit(int id)
        {
            Dt dtl = new Dt();
            dtl = _dtDAL.GetById(id);
            return View(dtl);
        }

        // POST: DtController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Dt dt)
        {
            try
            {
                bool result = _dtDAL.Edit(dt);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DtController/Delete/5
        public IActionResult Delete(int id)
        {
            Dt dtl = new Dt();
            dtl = _dtDAL.GetById(id);
            return View(dtl);
        }

        // POST: DtController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Dt dt)
        {
            try
            {
                bool result = _dtDAL.Delete(dt);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
