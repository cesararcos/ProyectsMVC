using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.BL
{
    public class SaleDetails
    {
        public List<Models.DB.SaleDetails> GetSaleDetails()
        {
            DAL.Models.ProyectsMVCEntities db = new DAL.Models.ProyectsMVCEntities();
            var listDetails = (from _Details in db.SaleDetails
                               join _Products in db.Products on _Details.ProductId equals _Products.Id
                               select new Models.DB.SaleDetails
                               {
                                   Id = _Details.Id,
                                   products = new Models.DB.Products
                                   {
                                       Description = _Products.Description
                                   },
                                   Quantity = _Details.Quantity,
                                   SubtotalValue = _Details.SubtotalValue
                               }

                ).ToList();

            return listDetails;
        }

        public void CreateSaleProducts(string name,
            int? category,
            string description,
            string photo,
            int? states,
            int quantity,
            double price,
            double shippingCost,
            string warranty)
        {
            DAL.Models.ProyectsMVCEntities _context = new DAL.Models.ProyectsMVCEntities();

            _context.Products.Add(new DAL.Models.Products
            {
                Name = name,
                CategoryId = category,
                Description = description,
                StateId = states,
                Quantity = quantity,
                Price = price,
                ShippingCost = shippingCost,
                Warranty = warranty
            });
            _context.SaveChanges();

            //LAS SIGUIENTES DOS LINEA 58-59 SON PARA CAPTURAR EL ID DEL PRODUCTO Y ALMACENARLO CON LA IMAGEN
            Products products = new Products();
            var listaClientes = products.GetProducts().LastOrDefault();

            if (!photo.Split('.').Contains("octet-stream"))
            {
                //LINEAS DE CODIGO PARA ALMACENAR IMAGEN
                _context.ProductPhotos.Add(new DAL.Models.ProductPhotos
                {
                    ProductId = listaClientes.Id,
                    Guid = photo,

                });
                _context.SaveChanges();
            }
            
        }
    }
}
