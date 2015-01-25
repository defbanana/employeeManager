using employeeManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace employeeManager.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentDataSource _db;

        public DepartmentController(IDepartmentDataSource db)
        {
            _db = db;
        }
        
        public ActionResult detail(int id)
        {
            var model = _db.Departments.Single(d => d.Id == id);
            return View(model);
        }
    }
}