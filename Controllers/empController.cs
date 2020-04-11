using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using New1.Models;

namespace New1.Controllers
{
    public class empController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Addemp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Addemp(Employee emp)
        {
            Employee em = new Employee();
                if (em.Addemp(emp))
                {
                    ViewBag.ErrMsg = "Employee Details are successfully Added";
                }
                else
                {
                    ViewBag.ErrMsg = "Employee Details are Not successfully Added";
                }
                return View(emp);
        }

        public IActionResult Getemp()
        {
            Employee sb = new Employee();
            return View(sb.Getemp());
        }

        public IActionResult UpdateEmployee(int id)
        {
            Employee st = new Employee();
            return View(st.Getemp().Find(asd => asd.Id == id));
        }

        [HttpPost]
        public IActionResult UpdateEmployee(int ID, Employee s1)
        {
            Employee emp = new Employee();
            if (emp.Updateemp(s1))
            {
                return RedirectToAction("Getemp");
            }
            else
            {
                return View();

            }
        }


        public IActionResult DeleteEmployee(int ID)
        {
            Employee emp = new Employee();
            if(emp.Deleteemp(ID))
            {
                return RedirectToAction("Getemp");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Listemp()
        {
            return View();
        }
    }
}


