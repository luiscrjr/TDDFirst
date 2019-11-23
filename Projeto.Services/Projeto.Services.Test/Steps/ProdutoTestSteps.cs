using FluentAssertions;
using Newtonsoft.Json;
using Projeto.Services.Models;
using Projeto.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Priority;

namespace Projeto.Services.Test.Steps
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public class ProdutoTestSteps
    {
        public readonly Context.AppContext appContext;
        private readonly string resource;

        //construtor
        public ProdutoTestSteps()
        {
            appContext = new Context.AppContext();
            resource = "/api/Produto";
        }

        [Fact, Priority(1)] // Método de teste do XUnit
        public async Task Produto_Post_ReturnsOkResponse()
        {
            var model = new ProdutoCadastroModel
            {
                Nome = "Notebook",
                Preco = 2500,
                Quantidade = 10
            };

            var request = new StringContent(JsonConvert.SerializeObject(model),
                Encoding.UTF8, "application/json");

            //testando uma requisoção POST para a API
            var response = await appContext.client.PostAsync(resource, request);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            //obtendo o retorno da API
            var content = await response.Content.ReadAsStringAsync();
            var produto = JsonConvert.DeserializeObject<Produto>(content);

            Assert.NotEmpty(produto.Id.ToString());

            Assert.Equal(model.Nome, produto.Nome);
            Assert.Equal(model.Preco, produto.Preco);
            Assert.Equal(model.Quantidade, produto.Quantidade);
        }

        [Fact, Priority(2)] // Método de teste do XUnit
        public async Task Produto_Put_ReturnsOkResponse()
        {
            var modelCadastro = new ProdutoCadastroModel
            {
                Nome = "Monitor",
                Preco = 500,
                Quantidade = 6
            };

            //criando uma requisição
            var requestPost = new StringContent(JsonConvert.SerializeObject(modelCadastro),
                Encoding.UTF8, "application/json");

            //enviando uma requisição PUT para a API
            var responsePost = await appContext.client.PostAsync(resource, requestPost);
            var contentPost = await responsePost.Content.ReadAsStringAsync();
            var produto = JsonConvert.DeserializeObject<Produto>(contentPost);

            var modelEdicao = new ProdutoEdicaoModel
            {
                Id = produto.Id.ToString(),
                Nome = "Celular",
                Preco = 600,
                Quantidade = 6
            };

            var requestPut = new StringContent(JsonConvert.SerializeObject(modelEdicao),
                                Encoding.UTF8, "application/json");

            //enviando requisição PUT para a API
            var responsePut = await appContext.client.PutAsync(resource, requestPut);
            var contentPut = await responsePut.Content.ReadAsStringAsync();
            var registro = JsonConvert.DeserializeObject<Produto>(contentPut);

            responsePut.StatusCode.Should().Be(HttpStatusCode.OK);

            Assert.Equal(modelEdicao.Id, registro.Id.ToString());
            Assert.Equal(modelEdicao.Nome, registro.Nome);
            Assert.Equal(modelEdicao.Preco, registro.Preco);
            Assert.Equal(modelEdicao.Quantidade, registro.Quantidade);
        }


        [Fact, Priority(5)] // Método de teste do XUnit
        public async Task Produto_Delete_ReturnsOkResponse()
        {
            var modelCadastro = new ProdutoCadastroModel
            {
                Nome = "Monitor",
                Preco = 500,
                Quantidade = 6
            };

            //criando uma requisição
            var requestPost = new StringContent(JsonConvert.SerializeObject(modelCadastro),
                Encoding.UTF8, "application/json");

            //enviando uma requisição PUT para a API
            var responsePost = await appContext.client.PostAsync(resource, requestPost);
            var contentPost = await responsePost.Content.ReadAsStringAsync();
            var produto = JsonConvert.DeserializeObject<Produto>(contentPost);


            //testando uma requisoção DELETE para a API
            var responseDelete = await appContext.client.DeleteAsync(resource + "/" + produto.Id.ToString());
            responseDelete.StatusCode.Should().Be(HttpStatusCode.OK);

            var contentDelete = await responseDelete.Content.ReadAsStringAsync();
            var registro = JsonConvert.DeserializeObject<Produto>(contentDelete);

            Assert.Equal(produto.Id, registro.Id);
            Assert.Equal(produto.Nome, registro.Nome);
            Assert.Equal(produto.Preco, registro.Preco);
            Assert.Equal(produto.Quantidade, registro.Quantidade);

        }

        [Fact, Priority(3)] // Método de teste do XUnit
        public async Task Produto_GetAll_ReturnsOkResponse()
        {
            var modelCadastro = new ProdutoCadastroModel
            {
                Nome = "Monitor",
                Preco = 500,
                Quantidade = 6
            };

            //criando uma requisição
            var requestPost = new StringContent(JsonConvert.SerializeObject(modelCadastro),
                Encoding.UTF8, "application/json");

            //enviando uma requisição PUT para a API
            await appContext.client.PostAsync(resource, requestPost);

            //testando uma requisoção Get para a API
            var response = await appContext.client.GetAsync(resource);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();
            var produto = JsonConvert.DeserializeObject<List<ProdutoConsultaModel>>(content);

            Assert.NotNull(produto);
            Assert.True(produto.Count > 0);
        }

        [Fact, Priority(4)] // Método de teste do XUnit
        public async Task Produto_GetById_ReturnsOkResponse()
        {
            var modelCadastro = new ProdutoCadastroModel
            {
                Nome = "Monitor",
                Preco = 500,
                Quantidade = 6
            };

            //criando uma requisição
            var requestPost = new StringContent(JsonConvert.SerializeObject(modelCadastro),
                Encoding.UTF8, "application/json");

            //enviando uma requisição PUT para a API
            var responsePost = await appContext.client.PostAsync(resource, requestPost);
            var contentPost = await responsePost.Content.ReadAsStringAsync();
            var produto = JsonConvert.DeserializeObject<Produto>(contentPost);


            //testando uma requisoção Get para a API
            var response = await appContext.client.GetAsync(resource + "/" + produto.Id.ToString());
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var contentGet = await response.Content.ReadAsStringAsync();
            var registro = JsonConvert.DeserializeObject<ProdutoConsultaModel>(contentGet);

            Assert.Equal(produto.Id.ToString(), registro.Id);
            Assert.Equal(produto.Nome, registro.Nome);
            Assert.Equal(produto.Preco, registro.Preco);
            Assert.Equal(produto.Quantidade, registro.Quantidade);

        }
    }
}
