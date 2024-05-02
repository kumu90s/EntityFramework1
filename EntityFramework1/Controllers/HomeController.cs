using EntityFrameworkModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFrameworkDB.DBEntity;

namespace EntityFramework1.Controllers
{
    public class HomeController : Controller
    {
        employeeOperations operation = null;
        public HomeController() 
        {
            operation = new employeeOperations();
            
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult create(EmployeeModel _employeeModel)
        {
            if (ModelState.IsValid)
            {
                int id = operation.AddEmployee(_employeeModel);
                if(id > 0){
                    ModelState.Clear();
                    ViewBag.Issuccess = "Data Added";
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult getAllEmployee()
        {
            var result =operation.getAllEmployess();
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var info = operation.getEmployess(id);
            return View(info);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var info = operation.getEmployess(id);
            return View(info);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeModel employeeModel)
        {
            if(ModelState.IsValid)
            {
                operation.UpdateEmployee(employeeModel.Id, employeeModel);

                return RedirectToAction("getAllEmployee");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            operation.DeleteEmployess(id);
            return RedirectToAction("getAllEmployee");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}