using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Projeto.Services.Test.Steps
{
    public class ProdutoTestSteps
    {
        public readonly Context.AppContext appContext;
        private readonly string resourse;

        //construtor
        public ProdutoTestSteps()
        {
            appContext = new Context.AppContext();
            resourse = "/api/Produto";
        }

        [Fact] // Método de teste do XUnit
        public async Task Produto_Post_ReturnsOkResponse()
        {
            //testando uma requisoção POST para a API
            var response = await appContext.client.PostAsync(resourse, null);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact] // Método de teste do XUnit
        public async Task Produto_Put_ReturnsOkResponse()
        {
            //testando uma requisoção PUT para a API
            var response = await appContext.client.PutAsync(resourse, null);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact] // Método de teste do XUnit
        public async Task Produto_Delete_ReturnsOkResponse()
        {
            //testando uma requisoção DELETE para a API
            var response = await appContext.client.DeleteAsync(resourse + "/1");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact] // Método de teste do XUnit
        public async Task Produto_GetAll_ReturnsOkResponse()
        {
            //testando uma requisoção Get para a API
            var response = await appContext.client.GetAsync(resourse);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact] // Método de teste do XUnit
        public async Task Produto_GetById_ReturnsOkResponse()
        {
            //testando uma requisoção Get para a API
            var response = await appContext.client.GetAsync(resourse + "/1");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
