using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalManagementServicePOC.Application.Mapping
{
    public class MapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ModelToDomainModel());
                cfg.AddProfile(new ModelToDto());
            });
        }
    }
}
