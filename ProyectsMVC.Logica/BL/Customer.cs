using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.BL
{
    public class Customer
    {

        public List<Models.DB.Customer> GetCustomer()
        {
            DAL.Models.ProyectsMVCEntities db = new DAL.Models.ProyectsMVCEntities();
            var listCustomer = (from _Customer in db.Customer
                                join _Cities in db.Cities on _Customer.CityId equals _Cities.Id
                                join _DocumentTypes in db.DocumentTypes on _Customer.DocumentTypeId equals _DocumentTypes.Id
                                select new Models.DB.Customer
                                {
                                    Id = _Customer.Id,
                                    documentTypes = new Models.DB.DocumentTypes
                                    {
                                        Name = _DocumentTypes.Name
                                    },
                                    DocumentNumber = _Customer.DocumentNumber,
                                    FirstName = _Customer.FirstName,
                                    SecondName = _Customer.SecondName,
                                    Surname = _Customer.Surname,
                                    SecondSurname = _Customer.SecondSurname,
                                    Telephone = _Customer.Telephone,
                                    Address = _Customer.Address,
                                    cities = new Models.DB.Cities
                                    {
                                        Name = _Cities.Name
                                    },
                                    UserId=_Customer.UserId
                                }).ToList();

            return listCustomer;
        }



        public void CustomerCreate(int? documentTypeId,
            string documentNumber,
            string firstName,
            string secondName,
            string surname,
            string secondSurname,
            string telephone,
            string address,
            int? cityId,
            string userId)
        {
            DAL.Models.ProyectsMVCEntities _context = new DAL.Models.ProyectsMVCEntities();

            _context.Customer.Add(new DAL.Models.Customer
            {
                DocumentTypeId = documentTypeId,
                DocumentNumber = documentNumber,
                FirstName = firstName,
                SecondName = secondName,
                Surname = surname,
                SecondSurname = secondSurname,
                Telephone = telephone,
                Address = address,
                CityId = cityId,
                UserId = userId
            });
            _context.SaveChanges();
        }
    }
}
