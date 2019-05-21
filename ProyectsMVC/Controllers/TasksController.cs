using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectsMVC.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {

        // GET: Tasks
        public ActionResult Index(int? proyectId)
        {
            Logica.BL.Tasks tasks = new Logica.BL.Tasks();
            var listTasks = tasks.GetTasks(proyectId, null);

            var listTasksViewModel = listTasks.Select(x => new Logica.Models.ViewModel.TasksIndexViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Details = x.Details,
                ExpirationDate = x.ExpirationDate,
                IsCompleted = x.IsCompleted,
                Effort = x.Effort,
                RemainigWork = x.RemainigWork,
                States = x.States.Name,
                Activity = x.Activities.Name,
                Priority = x.Priorities.Name
            }).ToList();

            Logica.BL.Proyects proyects = new Logica.BL.Proyects();
            var proyect = proyects.GetProyects(proyectId, null).FirstOrDefault();

            ViewBag.Proyect = proyect;

            return View(listTasksViewModel);
        }

        public ActionResult Create(int? proyectId)
        {
            var taskBindingModel = new Logica.Models.BindingModel.TasksCreateBindingModel
            {
                proyectId = proyectId
            };

            Logica.BL.States states = new Logica.BL.States();
            ViewBag.States = states.GetStates();

            Logica.BL.Activities activities = new Logica.BL.Activities();
            ViewBag.Activities = activities.GetActivities();

            Logica.BL.Priorities priorities = new Logica.BL.Priorities();
            ViewBag.Priorities = priorities.GetPriorities();

            return View(taskBindingModel);
        }

        [HttpPost]
        public ActionResult Create(Logica.Models.BindingModel.TasksCreateBindingModel model)
        {
            if (ModelState.IsValid)
            {
                Logica.BL.Tasks tasks = new Logica.BL.Tasks();
                tasks.CreateTasks(model.Title,
                    model.Details,
                    model.ExpirationDate,
                    model.IsCompleted,
                    model.Effort,
                    model.RemainigWork,
                    model.StateId,
                    model.ActivityId,
                    model.PriorityId,
                    model.proyectId);

                return RedirectToAction("Index", new { proyectId = model.proyectId });
            }

            Logica.BL.States states = new Logica.BL.States();
            ViewBag.States = states.GetStates();

            Logica.BL.Activities activities = new Logica.BL.Activities();
            ViewBag.Activities = activities.GetActivities();

            Logica.BL.Priorities priorities = new Logica.BL.Priorities();
            ViewBag.Priorities = priorities.GetPriorities();

            return View(model);
        }

        public ActionResult Calendar()
        {
            return View();
        }

        public ActionResult GetTaskCalendar(int? projectId)
        {
            try
            {
                Logica.BL.Tasks tasks = new Logica.BL.Tasks();
                var listTasks = tasks.GetTasks(projectId, null);

                var listTasksCalendarViewModel = listTasks.Select(x => new Logica.Models.ViewModel.TasksGetTasksCalendarViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    AllDay = true,
                    Color = "#FFFF00",
                    Start = x.ExpirationDate.Value.AddDays(Convert.ToDouble(-x.RemainigWork)).ToString("yyyy-MM-dd HH:mm:ss"),
                    End = x.ExpirationDate.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                    TextColor = "#000000"

                }).ToList();

                return Json(new
                {
                    Data = listTasksCalendarViewModel,
                    IsSuccessful = true
                });
            }
            catch (Exception ex)
            {
                return Json(new Logica.Models.ViewModel.ResponseViewModel
                {
                    IsSuccessful = true,
                    Errors = new List<string> { ex.Message }
                });
            }
        }

    }
}