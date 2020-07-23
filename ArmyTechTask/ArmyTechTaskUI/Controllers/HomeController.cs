using Repositories;
using Service;
using Service.Neighborhood;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;

namespace ArmyTechTaskUI.Controllers
{
    public class HomeController : Controller
    {
        private StudentService StudentService;
        private GovernorateService GovernorateService;
        private  NeighborhoodService NeighborhoodService;
        private FieldService FieldService;

        public HomeController(StudentService studentService ,
            GovernorateService governorateService,
            NeighborhoodService neighborhoodService,
            FieldService fieldService

            )
        {
            StudentService = studentService;
            GovernorateService = governorateService;
            NeighborhoodService = neighborhoodService;
            FieldService = fieldService;

        }
        [HttpGet]
        public ActionResult Index()
        {
            var students = StudentService.GetAll();
            return View(students);
        }
        [HttpGet]
        public ActionResult AddStudent()
        {
            ViewBag.Governate = GovernorateService.GetAll();
            ViewBag.Field = FieldService.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(StudentEditViewModel student)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Governate = GovernorateService.GetAll();
                ViewBag.Field = FieldService.GetAll();
                return View(student);
            }
            if (student.NeighborhoodId == 0)
            {
                student.NeighborhoodId = null;
            }
            StudentService.Add(student);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateStudent(int id)
        {
            var student = StudentService.GetFilter(id);
            ViewBag.Governate = GovernorateService.GetAll();

            getNeighborhood(student);
            ViewBag.Field = FieldService.GetAll();
            return View(student);
        }
        //this function for fill  Neighborhood DropDownList
        private void getNeighborhood(StudentEditViewModel student)
        {
            var Neighborhoods = NeighborhoodService.GetFilter(student.GovernorateId);
            if (student.NeighborhoodId != null && student.NeighborhoodId>0)
                ViewBag.Neighborhood = Neighborhoods;
            else
            {
                List<NeighborhoodViewModel> list = new List<NeighborhoodViewModel>();
                list.Add(new NeighborhoodViewModel() { ID = 0, Name = "Select" });
                if (NeighborhoodService.GetFilter(student.GovernorateId) != null)
                {
                    foreach (NeighborhoodViewModel temp in Neighborhoods)
                    {
                        list.Add(temp);
                    }
                }
                ViewBag.Neighborhood = list;
            }

        }
        [HttpPost]
        public ActionResult UpdateStudent(StudentEditViewModel student)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Governate = GovernorateService.GetAll();

                getNeighborhood(student);
                ViewBag.Field = FieldService.GetAll();
                return View(student);
            }
            if(student.NeighborhoodId==0)
            {
                student.NeighborhoodId = null;
            }
            StudentService.Update(student);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DeleteStudent(int id)
        {

            StudentService.Remove(new StudentEditViewModel(){ ID=id});
            return RedirectToAction("Index");
        }
        [HttpGet]
        public JsonResult getNeighborhood(int governorateID)
        {


            var units = NeighborhoodService.GetFilter(governorateID);

            return new JsonResult { Data = units, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}