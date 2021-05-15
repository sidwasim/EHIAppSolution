using Ehi.Services.Contract.External.DataContracts.Request;
using Ehi.Services.Contract.External.DataContracts.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ehi.Services.Contract.Internal.ServiceContracts
{
    public interface IContactEngine
    {
        Task<List<ContactResponse>> GetContacts();
        Task<bool> AddContacts(ContactRequest request);
        Task<bool> UpdateContacts(int empId, ContactRequest request);
        Task<bool> DeleteContacts(int empId);
    }
}
