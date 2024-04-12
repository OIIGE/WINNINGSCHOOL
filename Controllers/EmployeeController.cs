using ATTWOOLSCHOOL.EmployeeDbContext;
using ATTWOOLSCHOOL.Models;
using ATTWOOLSCHOOL.Models.DbEntities;
using Microsoft.AspNetCore.Mvc;

namespace ATTWOOLSCHOOL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AttwoolDbbContext _context;

        //INitialise Employee Dbcontext
        public EmployeeController(AttwoolDbbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // read employee data
            var employees = _context.Employees.ToList(); //will be used to communicate with Database
            List<EmployeeViewModel> employeeList = new List<EmployeeViewModel>(); // will be used to pass data from controller to view and view to controller

            if (employees != null)
            {
                foreach (var employee in employees)
                {
                    var EmployeeViewModel = new EmployeeViewModel()
                    {// passing the data to our view
                        Id = employee.Id,
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        DateOfBirth = employee.DateOfBirth,
                        Emails = employee.Emails,
                        PhoneNumbers = employee.PhoneNumbers,
                        Salary = employee.Salary
                    };
                    employeeList.Add(EmployeeViewModel);
                }
                return View(employeeList);
            }
            return View(employeeList);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var employee = new Employee()
                    {
                        FirstName = employeeData.FirstName,
                        LastName = employeeData.LastName,
                        DateOfBirth = employeeData.DateOfBirth,
                        Emails = employeeData.Emails,
                        PhoneNumbers = employeeData.PhoneNumbers,
                        Salary = employeeData.Salary
                    };

                    _context.Employees.Add(employee);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Employee Created Successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Model data is not Valid.";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();


            }

        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            try
            {
                var employee = _context.Employees.SingleOrDefault(x => x.Id == Id);
                if (employee != null)
                {
                    var employeeView = new EmployeeViewModel()
                    {
                        Id = employee.Id,
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        DateOfBirth = employee.DateOfBirth,
                        Emails = employee.Emails,
                        PhoneNumbers = employee.PhoneNumbers,
                        Salary = employee.Salary

                    };
                    return View(employeeView);
                }
                else
                {
                    TempData["errorMessage"] = $"Employee details not available with the Id:{Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Edit(EmployeeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var employee = new Employee()
                    {
                        Id = model.Id,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        DateOfBirth = model.DateOfBirth,
                        Emails = model.Emails,
                        PhoneNumbers = model.PhoneNumbers,
                        Salary = model.Salary

                    };
                    _context.Employees.Update(employee);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Employee details updated succesffulyy";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Model data is invalid";
                    return View();
                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = "Model data is invalid";
                return View();
            }

        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            try
            {
                var employee = _context.Employees.SingleOrDefault(x => x.Id == Id);
                if (employee != null)
                {
                    var employeeView = new EmployeeViewModel()
                    {
                        Id = employee.Id,
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        DateOfBirth = employee.DateOfBirth,
                        Emails = employee.Emails,
                        PhoneNumbers = employee.PhoneNumbers,
                        Salary = employee.Salary

                    };
                    return View(employeeView);
                }
                else
                {
                    TempData["errorMessage"] = $"Employee details not available with the Id:{Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Delete(EmployeeViewModel model)
        {
            try
            {
                var employee = _context.Employees.SingleOrDefault(x => x.Id == model.Id);
                if (employee != null)
                {
                    _context.Employees.Remove(employee);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Employee deleted succesfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = $"Employee details not available with the Id:{model.Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message;
                return View();
            }
          
        }
    }
}
