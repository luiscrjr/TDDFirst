using AutoMapper;
using Projeto.Services.Models;
using Projeto.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Services.Mappings
{
    public class ModelToEntityMap : Profile
    {
        public ModelToEntityMap()
        {
            CreateMap<ProdutoCadastroModel, Produto>()
                .AfterMap((src, dest) =>
                {
                    dest.Id = Guid.NewGuid();
                });

            CreateMap<ProdutoEdicaoModel, Produto>()
                .AfterMap((src, dest) =>
                {
                    dest.Id = Guid.Parse(src.Id);
                });
        }
    }
}
