using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectsMVC.Logica.BL
{
    public class Proyects
    {
        /// <summary>
        /// GET PROYECTS BY ID OR TENANT OR USER
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tenanId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Models.DB.Proyects> GetProyects(int? id,
            int? tenanId,
            string userId = null)
        {
            DAL.Models.ProyectsMVCEntities db = new DAL.Models.ProyectsMVCEntities();

            var listProyectsEF = (from _proyects in db.Projects
                                  select _proyects);

            if (id != null)
                listProyectsEF = listProyectsEF.Where(x => x.Id == id);
            if (tenanId != null)
                listProyectsEF = listProyectsEF.Where(x => x.TenantId == tenanId);
            if (!string.IsNullOrEmpty(userId))
                listProyectsEF = (from _proyects in listProyectsEF
                                  join _userProyects in db.UserProjects on _proyects.Id equals _userProyects.ProjectId
                                  where _userProyects.Id.Equals(userId)
                                  select _proyects);

            var listProyects = (from _proyects in listProyectsEF
                                select new Models.DB.Proyects
                                {
                                    Id = _proyects.Id,
                                    Title = _proyects.Title,
                                    Details = _proyects.Details,
                                    ExpectedCompletionDate = _proyects.ExpectedCompletionDate,
                                    TenantId = _proyects.TenantId,
                                    CreatedAt = _proyects.CreatedAt,
                                    UpdatedAt = _proyects.UpdatedAt
                                }).ToList();

            return listProyects;
        }

        /// <summary>
        /// CREATE PROYECTS
        /// </summary>
        /// <param name="title"></param>
        /// <param name="details"></param>
        /// <param name="expectedCompletionDate"></param>
        /// <param name="tenantId"></param>
        public void CreateProyects(string title,
            string details,
            DateTime? expectedCompletionDate,
            int? tenantId)
        {
            DAL.Models.ProyectsMVCEntities db = new DAL.Models.ProyectsMVCEntities();

            db.Projects.Add(new DAL.Models.Projects
            {
                Title = title,
                Details = details,
                ExpectedCompletionDate = expectedCompletionDate,
                TenantId = tenantId,
                CreatedAt = DateTime.Now
            });

            db.SaveChanges();
        }

        /// <summary>
        /// UPDATE PROYECT
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="details"></param>
        /// <param name="expectedCompletionDate"></param>
        public void UpdateProyects(int id,
            string title,
            string details,
            DateTime? expectedCompletionDate)
        {
            DAL.Models.ProyectsMVCEntities db = new DAL.Models.ProyectsMVCEntities();

            var proyect = db.Projects.FirstOrDefault(x => x.Id == id);

            proyect.Title = title;
            proyect.Details = details;
            proyect.ExpectedCompletionDate = expectedCompletionDate;
            proyect.UpdatedAt = DateTime.Now;

            db.SaveChanges();
        }

        /// <summary>
        /// DELETE PROYECT
        /// </summary>
        /// <param name="id"></param>
        public void DeleteProyects(int? id)
        {
            DAL.Models.ProyectsMVCEntities db = new DAL.Models.ProyectsMVCEntities();

            var proyect = db.Projects.FirstOrDefault(x => x.Id == id);
            db.Projects.Remove(proyect);

            db.SaveChanges();
        }
    }
}
