using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCorePractice.Services;
using DotNetCorePractice.Services.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace APIPractice
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            #region Swagger
            services.AddSwaggerGen( action => {
                action.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Version = "v1.1.0",
                    Title = "Dotnet Core API Practice",
                    Description = "框架练习",
                    TermsOfService = "None",
                    Contact = new Swashbuckle.AspNetCore.Swagger.Contact { Name = "Jiangle", Email = "jiangle.he@foxmail.com", Url = "https://github.com/hejiangle" }
                });
            });

            #endregion

            services.AddSingleton<ITodoListService, TodoListService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // Approach 1 : Add redirection configuration to redirect to swagger page by default.

            // var option = new RewriteOptions();
            // option.AddRedirect("^$", "swagger");
            // app.UseRewriter(option);
            app.UseHttpsRedirection();
            app.UseMvc();

            #region Swagger
            app.UseSwagger();

            app.UseSwaggerUI(action => {
                action.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiHelp V1");

                // Approach 2 : Add this line will make swagger UI page as main url.
                action.RoutePrefix = string.Empty;
            });
            #endregion
        }
    }
}
