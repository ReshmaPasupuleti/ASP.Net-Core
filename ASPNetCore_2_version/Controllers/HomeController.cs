using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNetCore_2_version.Models;
using Microsoft.AspNetCore.Mvc;
using ASPNetCore_2_version.ViewModels;


namespace ASPNetCore_2_version.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public ViewResult Index()
        {
            IEnumerable<Employee> employees = _employeeRepository.GetAllEmployees();
            return View(employees);
        }
        public ViewResult Details(int? id) 
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel
            {
                Employee = _employeeRepository.GetEmployee(id??1),
                PageTitle = "Employee Details"
            };
            return View(homeDetailsViewModel);
        }
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid) {
                Employee addedEmployee = _employeeRepository.AddEmployee(employee);
                return RedirectToAction("details", new { id = addedEmployee.Id });
            }
            return View(employee);
        }
    }
}