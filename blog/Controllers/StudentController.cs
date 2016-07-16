using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using blog.Database;
using blog.Models;
using WebGrease.Css.Extensions;

namespace blog.Controllers
{
    public class StudentController : Controller
    {
        BlogContext context = new BlogContext();
        // GET: Student
        public ActionResult Index()
        {

            IList<Student> students = createSimpleData();

            students.ForEach(student =>
            {
                context.Students.Add(student);
            });

            context.SaveChanges();
            return View(students);
        }

        public ActionResult All()
        {
            List<Student> students = context.Students.ToList();
            return View(students);
        }

        public ActionResult Standards()
        {
            List<Standard> standards = context.Standards.ToList();
            return View(standards);
        }

        public ActionResult Test()
        {
            Student student = new Student()
            {
                StudentName = "to jest nazwa <strong> pogrubiona </strong> <p> paragraf </p"
            };

            return View(student);


        }

        private IList<Student> createSimpleData()
        {
            IList<Student> students = new List<Student>();


            Student witek = new Student() {StudentName = "Witel",Weight = 200,DateOfBirth = DateTime.Now, Height = 300 };
            Student michal = new Student() {StudentName = "Michal",Weight = 200,DateOfBirth = DateTime.Now, Height = 300 };
            Student robert = new Student() {StudentName = "Robert",Weight = 200,DateOfBirth = DateTime.Now, Height = 300 };
            Student ania = new Student() {StudentName = "Ania",Weight = 200,DateOfBirth = DateTime.Now, Height = 300 };
            Standard standardA = new Standard() {StandardName = "A"};
            Standard standardB = new Standard() {StandardName = "B"};

            witek.Standard = standardA;
            michal.Standard = standardA;
            robert.Standard = standardB;
            standardB.Students = new Collection<Student>();
            standardB.Students.Add(ania);
            standardB.Students.Add(witek);
            standardB.Students.Add(robert);
            standardB.Students.Add(ania);
            standardB.Students.Add(ania);
            standardB.Students.Add(ania);
            standardB.Students.Add(ania);

            

            students.Add(witek);
            students.Add(michal);
            students.Add(robert);
            students.Add(robert);
            students.Add(robert);
            students.Add(robert);
            students.Add(robert);
            students.Add(robert);
            students.Add(robert);
            students.Add(robert);
            students.Add(robert);
            students.Add(robert);
            students.Add(robert);
            students.Add(robert);
            students.Add(robert);
            students.Add(robert);
            students.Add(robert);
            students.Add(robert);
            students.Add(robert);
            students.Add(robert);
            students.Add(robert);
            students.Add(robert);
            students.Add(robert);
            students.Add(robert);
            students.Add(robert);
            students.Add(robert);
            students.Add(robert);
            students.Add(robert);
            students.Add(robert);
            students.Add(robert);
            students.Add(robert);
            students.Add(robert);
            students.Add(robert);
            students.Add(robert);
            students.Add(robert);
            students.Add(robert);
            students.Add(robert);
            students.Add(robert);
            students.Add(robert);
            students.Add(robert);
            students.Add(ania);



            return students;
        }
    }
}