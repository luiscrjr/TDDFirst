using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Projeto.Services.Test.Context
{
    public class AppContext
    {
        public HttpClient client { get; set; }

        private readonly TestServer testServer;

        public AppContext()
        {
            //executando a classe de inicialização do projeto API
            testServer = new TestServer
                (new WebHostBuilder().UseStartup<Services.Startup>());

            //inicializar a propriedade HttpClient
            client = testServer.CreateClient();
        }
    }
}
