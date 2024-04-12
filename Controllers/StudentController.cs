using ATTWOOLSCHOOL.EmployeeDbContext;
using ATTWOOLSCHOOL.Models;
using ATTWOOLSCHOOL.Models.DbEntities;
using Microsoft.AspNetCore.Mvc;

namespace ATTWOOLSCHOOL.Controllers
{
    public class StudentController : Controller
    {
        private readonly AttwoolDbbContext _context;

        //INitialise Employee Dbcontext
        public StudentController(AttwoolDbbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            List<StudentViewModel> Studentlist = new List<StudentViewModel>();
            if (students != null)
            {
                foreach (var student in students)
                {
                    var StudentViewModel = new StudentViewModel()
                    {
                        Id = student.Id,
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        DateOfBirth = student.DateOfBirth,
                        StateOfOrigin = student.StateOfOrigin,
                        Address = student.Address,
                        ParentFullName = student.ParentFullName,
                        ParentPhoneNumber = student.ParentPhoneNumber,
                        ParentAddress = student.ParentAddress,
                        GuidanceEmail = student.GuidanceEmail,
                        EnrollmentDate = student.EnrollmentDate
                    };

                    Studentlist.Add(StudentViewModel);
                }
                return View(Studentlist);
            }
            return View(Studentlist);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(StudentViewModel studentData)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var student = new Student()
                    {
                        Id = studentData.Id,
                        FirstName = studentData.FirstName,
                        LastName = studentData.LastName,
                        DateOfBirth = studentData.DateOfBirth,
                        StateOfOrigin = studentData.StateOfOrigin,
                        Address = studentData.Address,
                        ParentFullName = studentData.ParentFullName,
                        ParentPhoneNumber = studentData.ParentPhoneNumber,
                        ParentAddress = studentData.ParentAddress,
                        GuidanceEmail = studentData.GuidanceEmail,
                        EnrollmentDate = studentData.EnrollmentDate
                    };

                    _context.Students.Add(student);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Student Created Successfully!";
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
    }
}
