using System;

namespace ProyectsMVC.Logica.Models.DB
{
   public class Proyects
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime? ExpectedCompletionDate { get; set; }
        public int? TenantId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Tenants Tenants { get; set; }    
    }
}
