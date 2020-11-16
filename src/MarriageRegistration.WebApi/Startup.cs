using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using MarriageRegistration.WebApi.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MarriageRegistration.WebApi
{
    public class Startup
    {
        public const string AppS3BucketKey = "AppS3Bucket";

        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }


        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IDataContext>();
            var dynamoDbConfig = _config.GetSection("DynamoDb");
            var runLocalDynamoDb = dynamoDbConfig.GetValue<bool>("LocalMode");

            if (runLocalDynamoDb)
            {
                services.AddSingleton<IAmazonDynamoDB>(sp =>
                {
                    var clientConfig = new AmazonDynamoDBConfig { ServiceURL = dynamoDbConfig.GetValue<string>("LocalServiceUrl") };
                    return new AmazonDynamoDBClient(clientConfig);
                });
            }
            else
            {
                services.AddAWSService<IAmazonDynamoDB>();
            }
            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
