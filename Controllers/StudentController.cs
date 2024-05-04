using WINNINGSCHOOL.AttwoolContext;
using WINNINGSCHOOL.Models;
using WINNINGSCHOOL.Models.DbEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WINNINGSCHOOL.Controllers
{
    public class StudentController : Controller
    {
        private readonly WinningSchoolDbbContext _context;

        //INitialise Employee Dbcontext
        public StudentController(WinningSchoolDbbContext context)
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

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var student = _context.Students.SingleOrDefault(x => x.Id == Id);
            try
            {
                if (student != null)
                {
                    var studentView = new StudentViewModel()
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
                    return View(studentView);
                }
                else
                {
                    TempData["errorMessage"] = $"Student details not available with the Id:{Id}";
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
        public IActionResult Edit(StudentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var student = new Student()
                    {
                        Id = model.Id,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        DateOfBirth = model.DateOfBirth,
                        StateOfOrigin = model.StateOfOrigin,
                        Address = model.Address,
                        ParentFullName = model.ParentFullName,
                        ParentPhoneNumber = model.ParentPhoneNumber,
                        ParentAddress = model.ParentAddress,
                        GuidanceEmail = model.GuidanceEmail,
                        EnrollmentDate = model.EnrollmentDate
                    };
                    _context.Students.Update(student);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Student details updated succesffulyy";
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
            var student = _context.Students.SingleOrDefault(x => x.Id == Id);
            try
            {
                if (student != null)
                {
                    var studentView = new StudentViewModel()
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
                    return View(studentView);
                }
                else
                {
                    TempData["errorMessage"] = $"Student details not available with the Id:{Id}";
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
        public IActionResult Delete(StudentViewModel model)
        {
            try
            {
                var student = _context.Students.SingleOrDefault(x => x.Id == model.Id);
                if (student != null)
                {
                    _context.Students.Remove(student);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Student deleted succesfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = $"student details not available with the Id:{model.Id}";
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
