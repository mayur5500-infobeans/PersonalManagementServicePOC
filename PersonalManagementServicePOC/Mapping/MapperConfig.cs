using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalManagementServicePOC.Application.Mapping
{
    public class MapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {                
                cfg.AddProfile(new ModelToDomainModelMapping());
                cfg.AddProfile(new DomainModelToModelResultMapping());
            });
        }
    }
}
