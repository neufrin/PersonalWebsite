﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonalWebsite.Data.Entities;
using PersonalWebsite.IdentityModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Data
{
    public class Initialization
    {
        public Initialization(IServiceCollection services)
        {
            this.ConfigureServices(services);
        }
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = @"Server=DESKTOP-14EBE41\SQLEXPRESS;Database=SeedTest1;Trusted_Connection=True;";

            services.AddDbContext<DataContext>(options => options.UseSqlServer(connection, b =>b.MigrationsAssembly("PersonalWebsite.Data")), ServiceLifetime.Scoped);

        }
        public void Configure(IServiceProvider serviceProvider)
        {
        }

    }
}
