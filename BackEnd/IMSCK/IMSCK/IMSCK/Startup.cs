using IMSCK.Auth;
using IMSCK.Config;
using IMSCK.DAO;
using IMSCK.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace IMSCK
{
    public class Startup
    {
        public static readonly JwtSettings jwtSettings = new JwtSettings();
        private readonly string jwtSecret;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            configuration.Bind(nameof(jwtSettings), jwtSettings);
            
            var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json").Build();

            var section = config.GetSection(nameof(JwtConfig));
            var jwtConfig = section.Get<JwtConfig>();

            this.jwtSecret = jwtConfig.Secret;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton(jwtSettings);

            services.AddSingleton<ILoginDao, LoginDao>();
            services.AddSingleton<IQuestionnaireDao, QuestionnaireDao>();
            services.AddSingleton<IRegisterDao, RegisterDao>();
            services.AddSingleton<ISymptomsDao, SymptomsDao>();

            services.AddScoped<RegisterService, RegisterService>();
            
            services.AddAuthentication(x =>
              {
                  x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                  x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                  x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

              }).AddJwtBearer(x =>
              {
                  x.SaveToken = true;
                  x.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuerSigningKey = true,
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(this.jwtSecret)),
                      ValidateIssuer = false,
                      ValidateAudience = false,
                      RequireExpirationTime = false,
                      ValidateLifetime = true
                  };
              });
            
            services.AddCors(options => options.AddDefaultPolicy(
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader())) ;
        }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization(); // AUTHENTICATION

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
