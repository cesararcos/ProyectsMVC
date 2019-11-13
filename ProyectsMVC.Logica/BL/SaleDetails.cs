﻿using System;
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
        }

        public void CreateShipping(bool shippingClient,
            bool shippingSeller,
            int? quantity,
            double? subtotalValue,
            double? shippingCost,
            int id)
        {
            if (shippingClient)
            {
                DAL.Models.ProyectsMVCEntities _context = new DAL.Models.ProyectsMVCEntities();
                _context.Sales.Add(new DAL.Models.Sales
                {
                    TotalValue = quantity * (subtotalValue + shippingCost),
                    Date = DateTime.Today
                });
                _context.SaveChanges();

                Sales sales = new Sales();
                var listasales = sales.GetSale().LastOrDefault();

                Services.UpdateSaleDetails updateSaleDetails = new Services.UpdateSaleDetails();
                updateSaleDetails.UpdateDetails(listasales.Id,
                    id);

                //_context.SaleDetails.Add(new DAL.Models.SaleDetails
                //{
                //    SaleId = listasales.Id
                //});
                //_context.SaveChanges();
            }
            else
            {
                DAL.Models.ProyectsMVCEntities _context = new DAL.Models.ProyectsMVCEntities();
                _context.Sales.Add(new DAL.Models.Sales
                {
                    TotalValue = quantity * subtotalValue,
                    Date = DateTime.Today
                });
                _context.SaveChanges();

                Sales sales = new Sales();
                var listasales = sales.GetSale().LastOrDefault();

                _context.SaleDetails.Add(new DAL.Models.SaleDetails
                {
                    SaleId = listasales.Id
                });
                _context.SaveChanges();
            }

        }
    }
}
