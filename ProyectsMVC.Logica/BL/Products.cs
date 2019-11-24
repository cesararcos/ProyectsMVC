using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.BL
{
    public class Products
    {
        public List<Models.DB.Products> GetProducts()
        {
            DAL.Models.ProyectsMVCEntities db = new DAL.Models.ProyectsMVCEntities();
            var listProducts = (from _Products in db.Products
                                join _Categories in db.Categories on _Products.CategoryId equals _Categories.Id
                                join _States in db.States on _Products.StateId equals _States.Id
                                //where _Products.Quantity > 0
                                select new Models.DB.Products
                                {
                                    Id = _Products.Id,
                                    Categories = new Models.DB.Categories
                                    {
                                        Name = _Categories.Name
                                    },
                                    Name = _Products.Name,
                                    Price = _Products.Price,
                                    ShippingCost = _Products.ShippingCost,
                                    Warranty = _Products.Warranty,
                                    Description = _Products.Description,
                                    Quantity = _Products.Quantity,
                                    States = new Models.DB.States
                                    {
                                        Name = _States.Name
                                    }
                                }).ToList();

            return listProducts;
        }
    }
}
