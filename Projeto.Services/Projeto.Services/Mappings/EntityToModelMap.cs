using AutoMapper;
using Projeto.Services.Models;
using Projeto.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Services.Mappings
{
    public class EntityToModelMap : Profile
    {
        public EntityToModelMap()
        {
            CreateMap<Produto, ProdutoConsultaModel>()
            .AfterMap((src, dest) =>
            {
                dest.Id = src.Id.ToString();
            });
        }
    }
}
