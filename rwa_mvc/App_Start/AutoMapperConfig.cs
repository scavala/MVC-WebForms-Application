using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using rwa_mvc.Models.DataTransferObject;

namespace rwa_mvc.App_Start
{
    public static class AutoMapperConfig
    {
        public static IMapper Mapper { get; set; }

        public static void Init()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Kupac, KupacDTO>());
            Mapper = config.CreateMapper();

        }
    }
}