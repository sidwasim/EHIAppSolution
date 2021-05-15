using Ehi.Services.Contact.RA.Models;
using Ehi.Services.Contract.External.DataContracts.Request;
using Ehi.Services.Contract.External.DataContracts.Response;
using Ehi.Services.Contract.Internal.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ehi.Services.ContactRA
{
    public class ContactRa : IContactRa
    {
        public async Task<bool> AddContacts(ContactRequest request)
        {
            try
            {
                using (var ctx = new ContactContext())
                {
                    var record = new Contact.RA.Models.Contact
                    {
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        PhoneNumber = request.PhoneNumber,
                        Email = request.Email,
                        IsActive = request.IsActive
                    };

                     ctx.Contact.Add(record);
                    await ctx.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteContacts(int empId)
        {
            try
            {
                using (var ctx = new ContactContext())
                {
                    var values = ctx.Contact.Where(c => c.Id == empId).FirstOrDefault();
                    ctx.Contact.Remove(values);
                    await ctx.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<ContactResponse>> GetContacts()
        {
            var contactResponses = new List<ContactResponse>();
            using (var ctx = new ContactContext())
            {
                var data =  ctx.Contact.Where(p => p.IsActive).Select(a => a).ToList();

                if(data != null)
                {
                    foreach (var item in data)
                    {
                        contactResponses.Add(new ContactResponse
                        {
                            Email = item.Email,
                            FirstName = item.FirstName,
                            LastName = item.LastName,
                            Id = item.Id,
                            PhoneNumber = item.PhoneNumber,
                            IsActive = item.IsActive
                        });
                    }
                };
            }
            return contactResponses;
        }

        public async Task<bool> UpdateContacts(int empId, ContactRequest request)
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
                    await context.SaveChangesAsync();
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
