using AndrewCSharpCodingTest.Core;
using AndrewCSharpCodingTest.GatewayClients;
using AndrewCSharpCodingTest.Helpers;
using AndrewCSharpCodingTest.Respositories;
using AndrewCSharpCodingTest.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace AndrewCSharpCodingTest
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
            services.AddDbContextPool<DatabaseContext>(options => options.UseSqlServer(Configuration["ConnectionString:PaymentTestDB"]));
            services.AddControllers()
                    .ConfigureApiBehaviorOptions(options =>
                    {
                        options.InvalidModelStateResponseFactory = context =>
                        {
                           return ResponseHelper.Response(HelperVariables.BAD_REQUEST, HelperVariables.FAILED_STATUS, HelperVariables.INVALID_REQUEST_MESSAGE, null);
                        };
                    });
            services.AddScoped<IProccessPaymentService, ProcessPaymentService>();
            services.AddSingleton<ICheapGatewayService, CheapGatewayService>();
            services.AddSingleton<IExpensiveGatewayService, ExpensivePaymentGateway>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AndrewCSharpCodingTest", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AndrewCSharpCodingTest v1"));
            }

            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = exceptionHandlerPathFeature.Error;
                await context.Response.WriteAsJsonAsync(new ResponseModel{ code = HelperVariables.INTERNAL_SERVER_ERROR, status = HelperVariables.FAILED_STATUS, message = exception.Message, response = null });
            }));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
