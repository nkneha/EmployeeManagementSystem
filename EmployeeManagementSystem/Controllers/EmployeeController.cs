using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        //private readonly ApplicationDbContext context;
        ////used to read the list of Employee from the database 
        //public EmployeeController(ApplicationDbContext context)
        //{
        //    this.context = context;
        //}

        private readonly IEmployeeService _employeeService;

        //make a call to the service
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public IActionResult Index()
        {
            //var employees = context.Employees.ToList();
            var employees = _employeeService.GetAllEmployees();
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
                //context.Employees.Add(employee);
                //context.SaveChanges();
                _employeeService.AddEmployee(employee);
                return RedirectToAction(nameof(Index));

                //return RedirectToAction("Index");
            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Fetch the employee by ID without service class
            //var employee = context.Employees.Find(id);

            //Fetch the employee by ID with service class
            var employee = _employeeService.GetEmployeeById(id);

            // If the employee does not exist, return a NotFound result
            if (employee == null)
            {
                return NotFound();
            }

            // Pass the employee to the view
            return View(employee);
        }



        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                //context.Employees.Update(employee);
                //context.SaveChanges();
                //return RedirectToAction("Index");
                _employeeService.UpdateEmployee(employee);
                return RedirectToAction(nameof(Index));
            }

            return View(employee);
        }
        public IActionResult Delete(int id)
        {
            // Fetch the employee by ID without using service
            //var employee = context.Employees.Find(id);

            //Fetch the employee by ID with using service
            var employee = _employeeService.GetEmployeeById(id);

            // If the employee does not exist, return a NotFound result
            if (employee == null)
            {
                return NotFound();
            }

            // Pass the employee to the view
            return View(employee);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            //var employee = context.Employees.Find(id);
            var employee = _employeeService.GetEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }

            //context.Employees.Remove(employee);
            //context.SaveChanges();

            _employeeService.DeleteEmployee(id);
            return RedirectToAction(nameof(Index));

            //return RedirectToAction("Index");
        }



    }
}
