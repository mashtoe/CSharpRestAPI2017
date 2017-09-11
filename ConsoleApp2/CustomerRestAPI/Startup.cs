using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ConsoleApp2BLL;
using ConsoleApp2BLL.BusinessObjects;

namespace CustomerRestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                var facade = new BLLFacade();
                facade.CustomerService.Create(
                    new CustomerBO()
                    {
                        Name = "Casper",
                        Lastname = "Roedgaard",
                        Address = "Home"
                    });
                facade.CustomerService.Create(
                    new CustomerBO()
                    {
                        Name = "Ole",
                        Lastname = "Eriksen",
                        Address = "Somewhere"
                    });
            }

            app.UseMvc();
        }
    }
}
