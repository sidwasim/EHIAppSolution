using Ehi.Services.Contract.External.DataContracts.Request;
using Ehi.Services.Contract.External.DataContracts.Response;
using Ehi.Services.Contract.Internal.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ehi.Services.Contact.Engines
{
    public class ContactEngine : IContactEngine
    {

        private readonly IContactRa _contactRa;

        public ContactEngine(IContactRa contactRa)
        {
            _contactRa = contactRa;
        }

        public async Task<bool> AddContacts(ContactRequest request)
        {
            return await _contactRa.AddContacts(request);
        }

        public async Task<bool> DeleteContacts(int empId)
        {
            return await _contactRa.DeleteContacts(empId);
        }

        public async Task<List<ContactResponse>> GetContacts()
        {
            return await _contactRa.GetContacts();
        }

        public async Task<bool> UpdateContacts(int empId, ContactRequest request)
        {
            return await _contactRa.UpdateContacts(empId, request);
        }
    }
}
