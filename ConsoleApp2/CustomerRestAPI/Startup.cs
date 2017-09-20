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
                /*
                var facade = new BLLFacade();

                var address = facade.AddressService.Create(
                    new AddressBO()
                    { 
                        City = "Kolding",
                        Street = "SesamStrasse",
                        Number = "22A"
                    });

                var address2 = facade.AddressService.Create(
                    new AddressBO()
                    {
                        City = "BingoCity",
                        Street = "DingoDoiok",
                        Number = "2e2"
                    });
                var address3 = facade.AddressService.Create(
                    new AddressBO()
                    {
                        City = "Hurly Smurf",
                        Street = "Trainstiik",
                        Number = "44D"
                    });

                var cust = facade.CustomerService.Create(
                    new CustomerBO()
                    {
                        Name = "Andreas",
                        Lastname = "Roedgaard",
                        AddressIds = new List<int>() { address.Id, address3.Id }
                    });
                facade.CustomerService.Create(
                    new CustomerBO()
                    {
                        Name = "Ole",
                        Lastname = "Eriksen",
                        AddressIds = new List<int>() { address.Id, address2.Id },
                        
                        

                    });
                for (int i = 0; i < 5; i++)
                {
                    facade.OrderService.Create(
                        new OrderBO()
                        {
                            DeliveryDate = DateTime.Now.AddMonths(1),
                            OrderDate = DateTime.Now.AddMonths(-1),
                            CustomerId = cust.Id
                        });
                }
                */
                    
            }

            app.UseMvc();
        }
    }
}