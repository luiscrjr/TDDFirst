using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Services.Repositories
{
    public class ProdutoRepository
    {
        private ConcurrentDictionary<Guid, Produto> map;

        //construtor com entrada de argumentos
        public ProdutoRepository(ConcurrentDictionary<Guid, Produto> map)
        {
            this.map = map;
        }

        public void Add(Produto produto)
        {
            map[produto.Id] = produto;
        }

        public void Modify(Produto produto)
        {
            if (map[produto.Id] != null)
            {
                map[produto.Id] = produto;
            }
        }

        public Produto Remove(Guid id)
        {
            var produto = new Produto();
            map.Remove(id, out produto);

            return produto;
        }

        public List<Produto> GetAll()
        {
            return map.Values.OrderBy(p => p.Nome).ToList();
        }

        public Produto GetById(Guid id)
        {
            return map.Values.FirstOrDefault(p => p.Id.Equals(id));
        }

    }
}
