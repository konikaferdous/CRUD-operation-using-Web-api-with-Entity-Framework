using EmployeeInformation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeInformation.Controllers
{
    public class EmployeeInfoController : ApiController
    {
        EmployeeInformationEntities db = new EmployeeInformationEntities();

           public List<PersonalInfo> getEmployeeInfo()
           {
            return  db.PersonalInfoes.ToList();
        }

        [HttpPost]
        public void AddEmployeeInfo(PersonalInfo obj)
        {
            db.PersonalInfoes.Add(obj);
            db.SaveChanges();
        }
        [HttpPut]
        public void EditEmployeeInfo(int id, PersonalInfo obj)
        {
            PersonalInfo employee = db.PersonalInfoes.Find(id);
            employee.Name = obj.Name;
            employee.Address = obj.Address;
            employee.PhoneNumber = obj.PhoneNumber;
            employee.Email = obj.Email;
            employee.Gender = obj.Gender;

            db.Entry(employee).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        [HttpPost]
        public void DeleteEmployeeInfo(int id)
        {
            PersonalInfo employee = db.PersonalInfoes.Find(id);
            db.PersonalInfoes.Remove(employee);
            db.SaveChanges();
        }

    }

}
