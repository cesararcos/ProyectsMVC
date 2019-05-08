using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.BL
{
    public class PreguntasCertyHigh
    {
        public List<Models.DB.PreguntasCertyHigh> GetPreguntas(int? pruebaId)
        {
            DAL.Models.ProyectsMVCEntities _context = new DAL.Models.ProyectsMVCEntities();

            var listPreguntas = (from _preguntas in _context.tbPreguntas
                             select new Models.DB.PreguntasCertyHigh
                             {
                                 Id = _tasks.Id,
                                 Title = _tasks.Title,
                                 Details = _tasks.Details,
                                 ExpirationDate = _tasks.ExpirationDate,
                                 IsCompleted = _tasks.IsCompleted,
                                 Effort = _tasks.Effort,
                                 RemainigWork = _tasks.RemainingWork,
                                 StateId = _tasks.StateId,
                                 States = new Models.DB.States
                                 {
                                     Name = _states.Name
                                 },
                                 PriorityId = _tasks.PriorityId,
                                 Priorities = new Models.DB.Priorities
                                 {
                                     Name = _priorities.Name
                                 },
                                 ActivityId = _tasks.ActivityId,
                                 Activities = new Models.DB.Activities
                                 {
                                     Name = _activities.Name
                                 },
                                 ProyectId = _tasks.ProjectId

                             }).ToList();

            if (proyectId != null)
                listTasks = listTasks.Where(x => x.ProyectId == proyectId).ToList();


            return listTasks;
        }
    }
}
