using AutoMapper;
using Ehi.Services.Contract.External.DataContracts.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models.Request;

namespace WebAPI.App_Start
{
    public class AutoMapperConfig : Profile
    {
        //public static void Initialize()
        //{
        //    var config = new MapperConfiguration(cfg => {
        //        cfg.CreateMap<ContactViewModelRequest, ContactRequest>();
        //    });
         
        //}

        public static IMapper Mapper { get; set; }
        public static void RegisterProfiles()
        {           
            var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<ContactViewModelRequest, ContactRequest>();
             
                });
            config.AssertConfigurationIsValid();
            Mapper = config.CreateMapper();
        }
    }
}