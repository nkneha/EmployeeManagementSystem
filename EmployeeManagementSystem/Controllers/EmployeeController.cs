using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext context;
        //used to read the list of Employee from the database
        public EmployeeController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var employees = context.Employees.ToList();
            return View(employees);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Models.Employee employee)
        {
            if (ModelState.IsValid)
            {
                // Code to save the employee to the database
                context.Employees.Add(employee);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

       
        //public ActionResult Edit(int id)
        //{
        //    // Fetch employee by name and return edit view
        //    var empId = 
            
        //}


        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                context.Employees.Update(employee);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }
        public IActionResult Delete(int id)
        {
            return View();
        }


    }
}
