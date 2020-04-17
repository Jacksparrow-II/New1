using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using New1.Models;
using New1.Repository;

namespace New1.Controllers
{
    public class EmployesController : Controller
    {
        public IActionResult AddEmployes()
        {
            DepartmentRepo DepartmentRepo = new DepartmentRepo();
            var Department = DepartmentRepo.GetDepartment();
            ViewBag.DataDepartment = Department;

            DesignationRepo DesignationRepo = new DesignationRepo();
            var Designation = DesignationRepo.GetDesignation();
            ViewBag.DataDesignation = Designation;

            return View();
        }

        [HttpPost]
        public IActionResult AddEmployes(Employes emp)
        {
            DepartmentRepo DepartmentRepo = new DepartmentRepo();
            var Department = DepartmentRepo.GetDepartment();
            ViewBag.DataDepartment = Department;

            DesignationRepo DesignationRepo = new DesignationRepo();
            var Designation = DesignationRepo.GetDesignation();
            ViewBag.DataDesignation = Designation;

            AddRepo em = new AddRepo();

            if (em.AddEmp(emp))
            {
                ViewBag.ErrMsg = "Employee Details are successfully Added";
            }
            else
            {
                ViewBag.ErrMsg = "Employee Details are Not successfully Added";
            }
            return View(emp);
        }

        public IActionResult GetEmployee()
        {
            List sb = new List();
            return View(sb.GetEmp());
        }

        public IActionResult UpdateEmployee(int ID)
        {
            DepartmentRepo DepartmentRepo = new DepartmentRepo();
            var Department = DepartmentRepo.GetDepartment();
            ViewBag.DataDepartment = Department;

            DesignationRepo DesignationRepo = new DesignationRepo();
            var Designation = DesignationRepo.GetDesignation();
            ViewBag.DataDesignation = Designation;

            List st = new List();
            return View(st.GetEmp().Find(asd => asd.Id == ID));
        }

        [HttpPost]
        public IActionResult UpdateEmployee(int ID, Employes s1)
        {
            

            Update emp = new Update();
            if (emp.UpdateEmp(s1))
            {
                return RedirectToAction("GetEmployee");
            }
            else
            {
                return View();

            }
        }

        public IActionResult DeleteEmployee(int id)
        {
            List st = new List();
            return View(st.GetEmp().Find(asd => asd.Id == id));
        }

        [HttpPost]
        public IActionResult DeleteEmployee(int ID, Employes st)
        {
            Delete emp = new Delete();
            if (emp.DeleteEmp(ID))
            {
                return RedirectToAction("GetEmployee");
            }
            else
            {
                return View();
            }
        }
    }
}