using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace Ncr.Retail.WebApi
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                //cfg.AddProfile<DomainModel.Security.AutoMapperSecurityProfile>();
                //cfg.AddProfile<Controllers.AutoMapperSecurityDtoProfile>();
                //cfg.AddProfile<DomainModel.Product.AutoMapperProductProfile>();
            });
        }
    }
}