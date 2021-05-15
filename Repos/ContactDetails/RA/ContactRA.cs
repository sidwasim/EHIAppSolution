using Repository.ContactDetails.RA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos.ContactDetails.RA
{
    public class ContactRA
    {

        public string SaveData()
        {
            using (var ctx = new ContactContext())
            {
                var stud = new Contact() { FirstName = "Wasim" ,LastName= "Siddiqui", Email="wasim.siddiqui@live.com", IsActive=true,PhoneNumber="9819092167"};

                ctx.Contact.Add(stud);
                ctx.SaveChanges();
            }
            return "DATASAVE";
        }

        public bool SaveContactInfo(Contact request)
        {
            try
            {
                using (var ctx = new ContactContext())
                {
                    var record = new Contact
                    {
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        PhoneNumber = request.PhoneNumber,
                        Email = request.Email,
                        IsActive = request.IsActive
                    };

                    ctx.Contact.Add(record);
                    ctx.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }         
        }

        public List<Contact> GetData()
        {
            List<Contact> data = null;
            using (var ctx = new ContactContext())
            {
               data = ctx.Contact.Where(p=>p.IsActive).Select(a => a).ToList();
            }
            return data;
        }

        public bool DeleteData(int empId)
        {
            try
            {
                using (var ctx = new ContactContext())
                {
                    var values = ctx.Contact.Where(c => c.Id == empId).FirstOrDefault();
                    var record = new Contact
                    {
                        FirstName = values.FirstName,
                        LastName = values.LastName,
                        PhoneNumber = values.PhoneNumber,
                        Email = values.Email,
                        IsActive = false
                    };

                    ctx.Contact.Remove(values);
                    ctx.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateEmployeeConatct(int empId, Contact request)
        {
            try
            {
                using (var context = new ContactContext())
                {
                    var values = context.Contact.Where(c => c.Id == empId).FirstOrDefault();
                    if (string.IsNullOrWhiteSpace(request.FirstName) && string.IsNullOrWhiteSpace(request.LastName))
                    {
                        values.IsActive = request.IsActive;
                    }
                    else
                    {
                        values.FirstName = request.FirstName;
                        values.LastName = request.LastName;
                        values.PhoneNumber = request.PhoneNumber;
                        values.Email = request.Email;
                        values.IsActive = request.IsActive;                 
                    }
                    context.Contact.Attach(values);
                    context.Entry(values).State = EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
