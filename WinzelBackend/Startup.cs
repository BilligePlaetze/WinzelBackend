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

namespace WinzelBackend
{
    using Microsoft.EntityFrameworkCore;

    using WinzelBackend.Models;
    using WinzelBackend.Utilites;

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
            services.AddDbContext<WinzelContext>(opt => opt.UseInMemoryDatabase("winzels"));
            services.AddMvc();
            services.AddCors(
                o => o.AddPolicy(
                    "MyPolicy",
                    builder =>
                        {
                            builder.AllowAnyOrigin();
                            builder.AllowAnyHeader();
                            builder.AllowAnyMethod();
                        }));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
            app.UseCors("MyPolicy");
            app.UseMvc();
           
        }
    }
}
