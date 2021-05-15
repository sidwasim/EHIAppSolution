using Ehi.Services.Contract.External.DataContracts.Request;
using Ehi.Services.Contract.External.DataContracts.Response;
using Ehi.Services.Contract.External.ServiceContracts;
using Ehi.Services.Contract.Internal.ServiceContracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ehi.Services.Contact.Managers
{
    public class ContactManager : IContactManager
    {
        private readonly IContactEngine _contactEngine;

        public ContactManager(IContactEngine contactEngine)
        {
            _contactEngine = contactEngine;
    }

        public async Task<bool> AddContacts(ContactRequest request)
        {
           return await _contactEngine.AddContacts(request);
        }

        public async Task<bool> DeleteContacts(int empId)
        {
            return await _contactEngine.DeleteContacts(empId);
        }

        public async Task<List<ContactResponse>> GetContacts()
        {
            return await _contactEngine.GetContacts();
        }

        public async Task<bool> UpdateContacts(int empId, ContactRequest request)
        {
            return await _contactEngine.UpdateContacts(empId,request);
        }
    }
}
