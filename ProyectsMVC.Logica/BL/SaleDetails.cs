using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectsMVC.Logica.BL
{
    public class SaleDetails
    {
        public List<Models.DB.SaleDetails> GetSaleDetails()
        {
            DAL.Models.ProyectsMVCEntities db = new DAL.Models.ProyectsMVCEntities();
            var listDetails = (from _Details in db.SaleDetails
                               join _Products in db.Products on _Details.ProductId equals _Products.Id
                               //join _Sales in db.Sales on _Details.SaleId equals _Sales.Id
                               select new Models.DB.SaleDetails
                               {
                                   Id = _Details.Id,
                                   //sales= new Models.DB.Sales
                                   //{
                                   //    TotalValue = _Sales.TotalValue
                                   //},
                                   ProductId = _Details.ProductId,
                                   //products = new Models.DB.Products
                                   //{
                                   //    Name = _Products.Name
                                   //},
                                   Quantity = _Details.Quantity,
                                   SubtotalValue = _Details.SubtotalValue
                               }

                ).ToList();

            return listDetails;
        }

        public void CreateSaleProducts(int id,
            int? quantity,
            double? price)
        {
            DAL.Models.ProyectsMVCEntities _context = new DAL.Models.ProyectsMVCEntities();

            _context.SaleDetails.Add(new DAL.Models.SaleDetails
            {
                ProductId = id,
                Quantity = quantity,
                SubtotalValue = price
            });
            _context.SaveChanges();

            var Product = _context.Products.Where(x => x.Id == id).FirstOrDefault();
            Product.Quantity = Product.Quantity - quantity;

            _context.SaveChanges();
        }

        public void CreateShipping(bool shippingClient,
            bool shippingSeller,
            int? quantity,
            double? subtotalValue,
            double? shippingCost,
            int id,
            int? methodPayment,
            int CustomerId)
        {
            if (shippingClient)
            {
                DAL.Models.ProyectsMVCEntities _context = new DAL.Models.ProyectsMVCEntities();
                _context.Sales.Add(new DAL.Models.Sales
                {
                    TotalValue = (quantity * subtotalValue) + shippingCost,
                    Date = DateTime.Now,
                    CustomerId = CustomerId
                });
                _context.SaveChanges();

                Sales sales = new Sales();
                var listasales = sales.GetSale().LastOrDefault();

                // RECIBE ID PARA ACTUALIZAR TABLA SQL
                Services.UpdateSaleDetails updateSaleDetails = new Services.UpdateSaleDetails();
                updateSaleDetails.UpdateDetails(listasales.Id,
                    id);

                updateSaleDetails.UpdatemethodPayment(methodPayment,
                    listasales.Id);
            }
            else
            {
                DAL.Models.ProyectsMVCEntities _context = new DAL.Models.ProyectsMVCEntities();
                _context.Sales.Add(new DAL.Models.Sales
                {
                    TotalValue = quantity * subtotalValue,
                    Date = DateTime.Now,
                    CustomerId = CustomerId
                });
                _context.SaveChanges();

                Sales sales = new Sales();
                var listasales = sales.GetSale().LastOrDefault();

                // RECIBE ID PARA ACTUALIZAR TABLA SQL
                Services.UpdateSaleDetails updateSaleDetails = new Services.UpdateSaleDetails();
                updateSaleDetails.UpdateDetails(listasales.Id,
                    id);

                updateSaleDetails.UpdatemethodPayment(methodPayment,
                    listasales.Id);
            }

        }
    }
}
