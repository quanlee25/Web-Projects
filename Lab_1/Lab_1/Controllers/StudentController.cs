using Microsoft.AspNetCore.Mvc;
using Lab_1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Lab_1.Controllers
{
    public class StudentController : Controller
    {
        private List<Student> listStudents = new List<Student>();
        private readonly IWebHostEnvironment _env;

        public StudentController(IWebHostEnvironment env)
        {
            _env = env;
            listStudents = new List<Student>()
            {
                new Student()
                {
                    Id = 101 , Name= "Le Van Quan" ,Branch= Branch.IT , Gender = Gender.Male , IsRegular=true,
                    Address = "37 Nghe An" , Email = "q@gmail.com"
                },
                new Student()
                {
                    Id = 102 , Name= "Le Van B" ,Branch= Branch.CE , Gender = Gender.Male , IsRegular=true,
                    Address = "37 Nghe An" , Email = "b@gmail.com"
                },
                new Student()
                {
                    Id = 103 , Name= "Le Van C" ,Branch= Branch.BE , Gender = Gender.Male , IsRegular=true,
                    Address = "37 Nghe An" , Email = "c@gmail.com"
                },
                new Student()
                {
                    Id = 104 , Name= "Le Van D" ,Branch= Branch.EE , Gender = Gender.Female , IsRegular=true,
                    Address = "37 Nghe An" , Email = "d@gmail.com"
                },
            };
        }

        // === /Admin/Student/List === /
        public IActionResult List()
        {
            return View("~/Views/Admin/Student/List.cshtml", listStudents);
        }

        // === /Admin/Student/Add === //
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem() { Text= "IT" , Value= "1" },
                new SelectListItem() { Text= "BE" , Value= "2" },
                new SelectListItem() { Text= "CE" , Value= "3" },
                new SelectListItem() { Text= "EE" , Value= "4" },
            };
            return View("~/Views/Admin/Student/Add.cshtml");
        }

        [HttpPost]
        public IActionResult Add(Student s, IFormFile avatarFile)
        {
            // Lưu ảnh nếu có chọn
            if (avatarFile != null && avatarFile.Length > 0)
            {
                var uploadPath = Path.Combine(_env.WebRootPath, "images/students");

                if (!Directory.Exists(uploadPath))
                    Directory.CreateDirectory(uploadPath);

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(avatarFile.FileName);
                string filePath = Path.Combine(uploadPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    avatarFile.CopyTo(stream);
                }

                s.Avatar = fileName; // Lưu tên file vào student
            }

            s.Id = listStudents.Last().Id + 1;
            listStudents.Add(s);

            return View("~/Views/Admin/Student/List.cshtml", listStudents);
        }

    }
}
