using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalManagementServicePOC.Domain.Mapping
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
           {
               cfg.AddProfile(new DomainModelToDtoMapping());
           });
        }
    }
}
