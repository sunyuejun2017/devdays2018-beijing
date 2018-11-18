using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace teamsconnectorsample
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {

                context.Response.ContentType = "text/plain;charset=utf-8";
                //打印出来用户关联信息
                var sb = new StringBuilder();
                foreach (var item in context.Request.Query)
                {
                    sb.AppendLine($"{item.Key}={item.Value}");
                }
                await context.Response.WriteAsync(sb.ToString());

                //推送一个欢迎消息
                var url = context.Request.Query["webhook_url"];
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post,url);
                request.Content = new StringContent("{\"text\":\"欢迎关联我的连接器，你将会收到很多消息推送\"}");
                await client.SendAsync(request);
            });
        }
    }
}
