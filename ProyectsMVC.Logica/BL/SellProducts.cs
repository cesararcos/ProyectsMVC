using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.BL
{
    public class SellProducts
    {
        public void CreateSaleProducts(string name,
            int? category,
            string description,
            string photo,
            string guid,
            int? states,
            int quantity,
            double price,
            double shippingCost,
            string warranty,
            int customerId)
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
                Warranty = warranty,
                CustomerId = customerId
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
                    Ext = guid

                });
                _context.SaveChanges();
            }

        }
    }
}
