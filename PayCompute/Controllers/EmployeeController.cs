using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using PayCompute.Entity;
using PayCompute.Models;
using PayCompute.Service;
namespace PayCompute.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly HostingEnvironment _hostingEnvironment;
        public EmployeeController(IEmployeeService employeeService, HostingEnvironment hostingEnvironment)
        {
            _employeeService = employeeService;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            var employees = _employeeService.GetAll().Select(employee => new EmployeeIndexViewModel
            {
                Id = employee.Id,
                EmployeeNo = employee.EmployeeNo,
                ImageUrl = employee.ImageUrl,
                FullName = employee.FullName,
                Gender = employee.Gender,
                Designation = employee.Designation,
                City = employee.City,
                DateJoined = employee.DateJoined
            }).ToList();
            return View(employees);
        }
        public IActionResult Create()
        {
            var model = new EmployeeCreateViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeCreateViewModel employeeCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee
                {
                    Id = employeeCreateViewModel.Id,
                    EmployeeNo = employeeCreateViewModel.EmployeeNo,
                    FirstName = employeeCreateViewModel.FirstName,
                    LastName = employeeCreateViewModel.LastName,
                    FullName = employeeCreateViewModel.FullName,
                    Gender = employeeCreateViewModel.Gender,
                    Email = employeeCreateViewModel.Email,
                    DOB = employeeCreateViewModel.DOB,
                    DateJoined = employeeCreateViewModel.DateJoined,
                    InsuranceNo = employeeCreateViewModel.InsuranceNo,
                    PaymentMethod = employeeCreateViewModel.PaymentMethod,
                    StudentLoan = employeeCreateViewModel.StudentLoan,
                    UnionMember = employeeCreateViewModel.UnionMember,
                    Address = employeeCreateViewModel.Address,
                    City = employeeCreateViewModel.City,
                    PhoneNumber = employeeCreateViewModel.PhoneNumber,
                    Designation = employeeCreateViewModel.Designation,
                    Postcode = employeeCreateViewModel.Postcode,

                };
                if (employeeCreateViewModel.ImageUrl != null && employeeCreateViewModel.ImageUrl.Length > 0)
                {
                    var uploadDir = @"images/employee";
                    var filename = Path.GetFileNameWithoutExtension(employeeCreateViewModel.ImageUrl.FileName);
                    var extension = Path.GetExtension(employeeCreateViewModel.ImageUrl.FileName);
                    var webRootPath = _hostingEnvironment.ContentRootPath;
                    filename = DateTime.UtcNow.ToString("yymmssfff") + filename + extension;
                    var path = Path.Combine(webRootPath, uploadDir, filename);
                    await employeeCreateViewModel.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
                    employee.ImageUrl = "/" + uploadDir + "/" + filename;
                }
                await _employeeService.CreateAsync(employee);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public IActionResult Edit(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            var model = new EmployeeEditViewModel()
            {
                Id = employee.Id,
                EmployeeNo = employee.EmployeeNo,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Gender = employee.Gender,
                Email = employee.Email,
                DOB = employee.DOB,
                DateJoined = employee.DateJoined,
                InsuranceNo = employee.InsuranceNo,
                PaymentMethod = employee.PaymentMethod,
                StudentLoan = employee.StudentLoan,
                UnionMember = employee.UnionMember,
                Address = employee.Address,
                City = employee.City,
                PhoneNumber = employee.PhoneNumber,
                Designation = employee.Designation,
                Postcode = employee.Postcode,
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Edit(EmployeeEditViewModel employeeEditViewModel)
        {
            if (ModelState.IsValid)
            {
                var employee = _employeeService.GetById(employeeEditViewModel.Id);
                if (employee == null)
                {
                    return NotFound();
                }
                employee.EmployeeNo = employeeEditViewModel.EmployeeNo;
                employee.FirstName = employeeEditViewModel.FirstName;
                employee.LastName = employeeEditViewModel.LastName;
                employee.InsuranceNo = employeeEditViewModel.InsuranceNo;
                employee.Gender = employeeEditViewModel.Gender;
                employee.Email = employeeEditViewModel.Email;
                employee.DOB = employeeEditViewModel.DOB;
                employee.DateJoined = employeeEditViewModel.DateJoined;
                employee.Designation = employeeEditViewModel.Designation;
                employee.PhoneNumber = employeeEditViewModel.PhoneNumber;
                employee.PaymentMethod = employeeEditViewModel.PaymentMethod;
                employee.StudentLoan = employeeEditViewModel.StudentLoan;
                employee.UnionMember = employeeEditViewModel.UnionMember;
                employee.Address = employeeEditViewModel.Address;
                employee.City = employeeEditViewModel.City;
                employee.Postcode = employeeEditViewModel.Postcode;
                if (employeeEditViewModel.ImageUrl != null && employeeEditViewModel.ImageUrl.Length > 0)
                {
                    var uploadDir = @"images/employee";
                    var filename = Path.GetFileNameWithoutExtension(employeeEditViewModel.ImageUrl.FileName);
                    var extension = Path.GetExtension(employeeEditViewModel.ImageUrl.FileName);
                    var webRootPath = _hostingEnvironment.ContentRootPath;
                    filename = DateTime.UtcNow.ToString("yymmssfff") + filename + extension;
                    var path = Path.Combine(webRootPath, uploadDir, filename);
                    await employeeEditViewModel.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
                    employee.ImageUrl = "/" + uploadDir + "/" + filename;
                }
                await _employeeService.UpdateAsync(employee);
                RedirectToAction(nameof(Index));
            }
            return View();
        }
    public IActionResult Detail(int id)
        {
            var employee = _employeeService.GetById(id);
            if(employee == null)
            {
                return NotFound();
            }
            EmployeeDetailViewModel model = new EmployeeDetailViewModel()
            {
                Id = employee.Id,
                EmployeeNo = employee.EmployeeNo,
                FullName = employee.FullName,
                Gender = employee.Gender,
                Email = employee.Email,
                DOB = employee.DOB,
                DateJoined = employee.DateJoined,
                InsuranceNo = employee.InsuranceNo,
                PaymentMethod = employee.PaymentMethod,
                StudentLoan = employee.StudentLoan,
                UnionMember = employee.UnionMember,
                Address = employee.Address,
                City = employee.City,
                PhoneNumber = employee.PhoneNumber,
                Designation = employee.Designation,
                Postcode = employee.Postcode,
                ImageUrl = employee.ImageUrl
            };

            return View(model);
        }
        public IActionResult Delete(int id)
        {
            var employee = _employeeService.GetById(id);
            if(employee == null)
            {
                return NotFound();
            }
            var model = new EmployeeDeleteViewModel()
            {
                Id = employee.Id,
                FullName = employee.FullName
            }; 
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(EmployeeDeleteViewModel employeeDeleteViewModel)
        {
            await _employeeService.Delete(employeeDeleteViewModel.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
