using AutoMapper;
using Ehi.Services.Contract.External.DataContracts.Request;
using Ehi.Services.Contract.External.ServiceContracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPI.Models.Request;
using WebAPI.Models.Response;

namespace WebAPI.Controllers
{
    public class ContactController : ApiController
    {
        private readonly IContactManager _contactManger;
        private readonly IMapper _mapper;
        public ContactController(IContactManager contactManger, IMapper mapper)
        {
            _mapper = mapper;
            _contactManger = contactManger;
        }
        // GET: api/Contact
        public async Task<List<ContactViewModelResponse>> GetAsync()
        {
            var response = new List<ContactViewModelResponse>();
            var result =  await _contactManger.GetContacts();

            foreach (var item in result)
            {
                response.Add(new ContactViewModelResponse
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    PhoneNumber = item.PhoneNumber,
                    Email=item.Email,
                    IsActive = item.IsActive,
                    Id = item.Id,
                });
            }
            return response;
        }



        // GET: api/Contact/5
        public string Get(int id)
        {
            //var data = new ContactRA();
            //return data.SaveData();
            return "aaa";

        }     


        // POST: api/Contact
        public async Task<bool> PostAsync([FromBody]ContactViewModelRequest request)
        {
            var sevRequest = new ContactRequest
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber
                ,
                IsActive = request.IsActive
            };
            //autommaper
            //var obj = _mapper.Map<ContactViewModelRequest, ContactRequest>(request);
            return await _contactManger.AddContacts(sevRequest);
        }

        // PUT: api/Contact/5
        public async Task<bool> Put(int id, [FromBody]ContactViewModelRequest request)
        {
            var sevRequest = new ContactRequest
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                IsActive = request.IsActive,
                Id = request.Id
            };

            //var obj = _mapper.Map<ContactViewModelRequest, ContactRequest>(request);
            return await _contactManger.UpdateContacts(id, sevRequest);

        }

        // DELETE: api/Contact/5
        public async Task<bool> Delete(int id)
        {
            return await _contactManger.DeleteContacts(id);
        }
    }
}
